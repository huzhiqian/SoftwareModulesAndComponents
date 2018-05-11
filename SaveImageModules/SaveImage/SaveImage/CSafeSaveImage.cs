using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using SaveImage.Implemention.Internal;

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
        private AutoDeleteImageModeEnum _deleteMode = AutoDeleteImageModeEnum.CAPACITY; //自动删除模式
        private int _imageLifeSpan = 1;          //图片存在寿命(天)
        private double _diskAllowsMinCapacity = 1;  //磁盘允许最小容量（GB）

        private CINIFile ini_Obj;
        private COperaterDisk diskOperator;
        #region 构造函数

        public CSafeSaveImage(ISaveImage _saveImage) : base(_saveImage)
        {
            mySaveImage = _saveImage;
            diskOperator = new COperaterDisk(_saveImage.SaveImageRootDictroy);
            _saveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(diskOperator.ChangeRootDirectory);
            ini_Obj = new CINIFile(mySaveImage.ConfigFilePath);
            //从本地INI文件中获取参数
            GetParaFromINIFile();
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
                _deleteMode = value;
                switch (_deleteMode)
                {
                    case AutoDeleteImageModeEnum.NONE:
                        ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "NONE");
                        break;
                    case AutoDeleteImageModeEnum.TIME:
                        ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "TIME");
                        break;
                    case AutoDeleteImageModeEnum.CAPACITY:
                        ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "CAPACITY");
                        break;
                    default:
                        ini_Obj.Write<string>(mySaveImage.SectionName, "DeleteMode", "CAPACITY");
                        break;
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

        /// <summary>
        /// 获取或设置磁盘最小可用空间（GB）
        /// </summary>
        public double DiskAllowsMinCapacity
        {
            get { return _diskAllowsMinCapacity; }
            set
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

        #endregion

        #region 公共方法

        public string SaveImage(Bitmap image, string imageName)
        {
            //自动删除图片
            switch (_deleteMode)
            {
                case AutoDeleteImageModeEnum.NONE:
                    if (CheckCapacityCanSave() == false) return "NotEnoughSpace";
                    break;
                case AutoDeleteImageModeEnum.TIME:      //按时间删除
                    DeleteImageByTime();
                    break;
                case AutoDeleteImageModeEnum.CAPACITY:  //按容量删除
                    DeleteImageByCapacity();
                    break;
                default:
                    break;
            }

            string imageFullName = base.Save(image, imageName);
            //将保存的图片路径保存到数据库中


            return imageFullName;
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
                        _deleteMode = AutoDeleteImageModeEnum.TIME;
                        break;
                    case "CAPACITY":
                        _deleteMode = AutoDeleteImageModeEnum.CAPACITY;
                        break;
                    default:
                        _deleteMode = AutoDeleteImageModeEnum.CAPACITY;
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
        /// 按时间删除容量
        /// </summary>
        private void DeleteImageByTime()
        {

        }

        /// <summary>
        /// 按磁盘容量删除
        /// </summary>
        private void DeleteImageByCapacity()
        {

        }

        /// <summary>
        /// 检查磁盘容量是否低于允许的下限值
        /// </summary>
        /// <returns></returns>
        private bool CheckCapacityCanSave()
        {
            double freeSapce = diskOperator.GetDiskCapacity();
            if (freeSapce == -1) return false;

            if (freeSapce > _diskAllowsMinCapacity)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
