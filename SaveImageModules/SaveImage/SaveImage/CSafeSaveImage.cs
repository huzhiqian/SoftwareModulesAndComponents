using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using SaveImage.Implemention.Internal;
using System.Threading.Tasks.Schedulers;
using System.Threading.Tasks;

//**********************************************
//文件名：CSafeSaveImage
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：该类是CSaveImage的一个具体装饰者
//功能：安全保存图像类，在保存图像之前会检查磁盘容量，自动删除等
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/10 13:54:22
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    public class CSafeSaveImage : SaveImageDecorator
    {
        private ISaveImage mySaveImage;
        //字段
        private AutoDeleteImageModeEnum _deleteMode = AutoDeleteImageModeEnum.SPACE; //自动删除模式
        private int _imageLifeSpan = 1;          //图片存在寿命(天)
        private double _diskAllowsMinCapacity = 1;  //磁盘允许最小容量（GB）

        private CINIFile ini_Obj;
        private COperaterDisk diskOperator;     //磁盘操作类
        private COperaterDB dbOperator;         //数据库操作类

        static object _lockObj = new object();

        #region 构造函数
        public CSafeSaveImage(ref CSaveImage _saveImage) : base(_saveImage)
        {
            mySaveImage = _saveImage;
            diskOperator = new COperaterDisk(mySaveImage.SaveImageRootDictroy);
            mySaveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(diskOperator.ChangeRootDirectory);
            ini_Obj = new CINIFile(mySaveImage.ConfigFilePath);
            dbOperator = new COperaterDB();
            //从本地INI文件中获取参数
            GetParaFromINIFile();

            mySaveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(diskOperator.ChangeRootDirectory);
        }

        public CSafeSaveImage(ref CSaveImage _saveImage, string dbLinkStr) : base(_saveImage)
        {
            mySaveImage = _saveImage;
            diskOperator = new COperaterDisk(mySaveImage.SaveImageRootDictroy);
            mySaveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(diskOperator.ChangeRootDirectory);
            ini_Obj = new CINIFile(mySaveImage.ConfigFilePath);
            dbOperator = new COperaterDB(dbLinkStr);
            //从本地INI文件中获取参数
            GetParaFromINIFile();

            mySaveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(diskOperator.ChangeRootDirectory);
        }
        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置删除图像的模式
        /// </summary>
        public AutoDeleteImageModeEnum DeleteMode
        {
            get { return _deleteMode; }
            set
            {
                if (value != _deleteMode)
                {
                    _deleteMode = value;
                    switch (_deleteMode)
                    {
                        case AutoDeleteImageModeEnum.NONE:
                            ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "NONE");
                            break;
                        case AutoDeleteImageModeEnum.TIMEANDSPACE:
                            ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "TIME");
                            break;
                        case AutoDeleteImageModeEnum.SPACE:
                            ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "CAPACITY");
                            break;
                        default:
                            ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "CAPACITY");
                            break;
                    }
                }

            }
        }

        /// <summary>
        /// 获取或设置图片在磁盘上允许存在时间（单位：天）
        /// </summary>
        public int ImageLifeSpan
        {
            get { return _imageLifeSpan; }
            set
            {
                if (value != _imageLifeSpan)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("允许图片存在时间必须大于等于1（天）");
                    }
                    else
                    {
                        _imageLifeSpan = value;
                        ini_Obj.Write<int>(mySaveImage.SectionName, "ImageLifeSpan", value);
                    }
                }

            }
        }

        /// <summary>
        /// 获取或设置磁盘最小可用空间（GB）
        /// </summary>
        public double DiskAllowsMinCapacity
        {
            get { return _diskAllowsMinCapacity; }
            set
            {
                if (value != _diskAllowsMinCapacity)
                {
                    if (value <= 0.5)
                    {
                        throw new ArgumentOutOfRangeException("磁盘最小可用空间设定必须大于0.5（GB）");
                    }
                    else
                    {
                        _diskAllowsMinCapacity = value;
                        ini_Obj.Write<double>(mySaveImage.SectionName, "DiskAllowsMinCapacity", value);
                    }
                }

            }
        }
        /// <summary>
        /// 获取数据库是否连接
        /// </summary>
        public bool IsDBLinked
        {
            get { return dbOperator.LinkDB; }
        }

        public int DeleteCountMax { get; set; } = 20;
        #endregion

        #region 公共方法

        public string SaveImage(Bitmap image, string imageName)
        {
            Func<object, string> func = obj =>
             {
                 lock (_lockObj)
                 {
                     
                     string imageFullName = base.Save(image, imageName);
                     //将保存的图片路径保存到数据库中
                     dbOperator.WriteSaveInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), imageFullName);
                     //自动删除图片
                     switch (_deleteMode)
                     {
                         case AutoDeleteImageModeEnum.NONE:
                             if (CheckCapacityCanSave() == false) return "Have not enough Space";
                             break;
                         case AutoDeleteImageModeEnum.TIMEANDSPACE:      //按时间删除
                             DeleteImageByTime();
                             break;
                         case AutoDeleteImageModeEnum.SPACE:  //按容量删除
                             DeleteImageByCapacity();
                             break;
                         default:
                             break;
                     }
                     return imageFullName;
                 }
             };

            var scheduler = new LimitedConcurrencyLevelTaskScheduler(5);
         return  Task.Factory.StartNew<string>(func, ImageName, CancellationToken.None, TaskCreationOptions.None,
                    scheduler).Result;
               
                 

           
        
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">需要保存的图片</param>
        /// <param name="imageFullName">图片的全名</param>
        public void SaveImageWithFullName(Bitmap image, string imageFullName)
        {
            Action<object> act = obj =>
            {
                lock (_lockObj)
                {
                    base.SaveImageByFullName(image, imageFullName);
                    //将保存的图片路径保存到数据库中
                    dbOperator.WriteSaveInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), imageFullName);
                    //自动删除图片
                    switch (_deleteMode)
                    {
                        case AutoDeleteImageModeEnum.NONE:
                            if (CheckCapacityCanSave() == false)
                                return;
                            break;
                        case AutoDeleteImageModeEnum.TIMEANDSPACE:      //按时间删除
                            DeleteImageByTime();
                            break;
                        case AutoDeleteImageModeEnum.SPACE:  //按容量删除
                            DeleteImageByCapacity();
                            break;
                        default:
                            break;
                    }
                }

            };

            var scheduler = new LimitedConcurrencyLevelTaskScheduler(5);
             Task.Factory.StartNew(act, ImageName, CancellationToken.None, TaskCreationOptions.None,
                       scheduler);

        }

        public void ClearDataBase()
        {
            dbOperator.ClearDB();
        }
        #endregion

        #region 私有方法

        private void GetParaFromINIFile()
        {
            if (System.IO.File.Exists(mySaveImage.ConfigFilePath))
            {
                //读取删除模式
                string deleMode = ini_Obj.Read<string>(mySaveImage.SectionName, "DeleteMode");
                switch (deleMode)
                {
                    case "NONE":
                        _deleteMode = AutoDeleteImageModeEnum.NONE;
                        break;
                    case "TIME":
                        _deleteMode = AutoDeleteImageModeEnum.TIMEANDSPACE;
                        break;
                    case "CAPACITY":
                        _deleteMode = AutoDeleteImageModeEnum.SPACE;
                        break;
                    default:
                        _deleteMode = AutoDeleteImageModeEnum.SPACE;
                        break;
                }

                //读取时间参数
                int imageLife = ini_Obj.Read<int>(mySaveImage.SectionName, "ImageLifeSpan");
                if (imageLife >= 1)
                {
                    _imageLifeSpan = imageLife;
                }
                //读取容量参数
                double capacity = ini_Obj.Read<double>(mySaveImage.SectionName, "DiskAllowsMinCapacity");
                if (capacity >= 0.5)
                    _diskAllowsMinCapacity = capacity;

            }
        }

        /// <summary>
        /// 按时间删除
        /// </summary>
        private void DeleteImageByTime()
        {
            string time = DateTime.Now.Subtract(TimeSpan.FromDays(_imageLifeSpan)).ToString("yyyy-MM-dd");
            List<string> fileList = dbOperator.GetBeforeTimeAllFile(time);
            int count = 0;
            foreach (var item in fileList)
            {
                //删除数据库中的记录
                dbOperator.DeleteInfo(item);
                diskOperator.DeleteFile(item);
                LogModules.LogControlser.WriteLog($"按时间删除：{item}");
                count++;
                if (count >= DeleteCountMax)
                    break;
            }
            //检查磁盘空间，是否低于允许最小值
            //DeleteImageByCapacity();
        }

        /// <summary>
        /// 按磁盘容量删除
        /// </summary>
        private void DeleteImageByCapacity()
        {
            if (CheckCapacityCanSave() == false)//磁盘容量低
            {
                
                string[] fileName = dbOperator.GetEarlistSavePath(DeleteCountMax);    //从数据库中找出最早的图片路径
                LogModules.LogControlser.WriteLog($"按容量删除数量：{fileName.Length}");
                foreach (var item in fileName)
                {
                    LogModules.LogControlser.WriteLog($"按容量删除：{item}");
                    //删除数据库中的记录
                    dbOperator.DeleteInfo(item);
                    if (diskOperator.DeleteFile(item) == false)
                    {
                        if (LogEvent != null)
                            LogEvent("删除图片出错！");
                    }
                    
                }
            }
          
        }

        /// <summary>
        /// 检查磁盘容量是否大于允许的下限值
        /// </summary>
        /// <returns></returns>
        private bool CheckCapacityCanSave()
        {
            double freeSapce = diskOperator.GetDiskCapacity();
            LogModules.LogControlser.WriteLog($"磁盘当前容量：{freeSapce.ToString()},设定下限值：{_diskAllowsMinCapacity}" );
            if (freeSapce == -1) return false;

            if (freeSapce > _diskAllowsMinCapacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 委托



        #endregion

        #region 事件

        public event LogInfoEventHandle LogEvent;

        #endregion

        /// <summary>
        /// Log事件委托
        /// </summary>
        /// <param name="info"></param>
        public delegate void LogInfoEventHandle(string info);
    }
}
