using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

//**********************************************
//文件名：SaveImage
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：保存图片类
//功能：负责保存各种类型的图片
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/4/20 19:39:38
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    public class CSaveImage : ISaveImage
    {
        private CINIFile myINIObj;
        private Queue<SaveImageStr> myImageQueue;     //图像队列，缓冲池
        private System.Timers.Timer saveImageTimer;
        private bool IsTimerStart = false;

        //字段
        protected string _path;
        protected SaveImageType _saveType = SaveImageType.BMP;
        protected bool _isSaveImage = true;
        protected bool _isAddTimeToImageName = true;
        protected string _configFilePath;
        protected string _SectionName = "SaveImagePara";

        private ImageFormat imageFormat;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilePath">配置文件路径</param>
        public CSaveImage(string configFilePath)
        {
            imageFormat = new ImageFormat(new Guid());
            _configFilePath = configFilePath;
            myImageQueue = new Queue<SaveImageStr>();
            saveImageTimer = new System.Timers.Timer();
            saveImageTimer.Interval = 10;
            saveImageTimer.Elapsed += new System.Timers.ElapsedEventHandler(SaveImagePump);
            if (File.Exists(_configFilePath))
            {
                myINIObj = new CINIFile(_configFilePath);
            }
            else
            {
                try
                {
                    File.Create(_configFilePath);
                    myINIObj = new CINIFile(_configFilePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            InitPara();
            WritePara();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="savePath">保存图片的路径</param>
        public CSaveImage(string configFilepath, string savePath, bool isSave, string sectionName)
        {
            _configFilePath = configFilepath;
            _path = savePath;
            _SectionName = sectionName;
            _isSaveImage = isSave;
            myImageQueue = new Queue<SaveImageStr>();
            saveImageTimer = new System.Timers.Timer();
            saveImageTimer.Interval = 10;
            saveImageTimer.Elapsed += new System.Timers.ElapsedEventHandler(SaveImagePump);
            if (File.Exists(_configFilePath))
            {
                myINIObj = new CINIFile(_configFilePath);
            }
            else
            {
                try
                {
                    File.Create(_configFilePath);
                    myINIObj = new CINIFile(_configFilePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            InitPara();
            WritePara();

        }

        #endregion


        #region 属性
        /// <summary>
        /// 设置配置文件中的节名称
        /// </summary>
        public string SectionName
        {
            get { return _SectionName; }
            set { _SectionName = value; }
        }

        /// <summary>
        /// 获取保存图片的配置文路径
        /// </summary>
        public string ConfigFilePath
        {
            get { return _configFilePath; }
        }

        /// <summary>
        /// 获取或设置保存图片路径
        /// </summary>
        public string SavePath
        {
            get { return _path; }
            set
            {
                if (!value.Equals(_path))
                {
                    _path = value;
                    if (Path.GetPathRoot(value) != SaveImageRootDictroy)
                    {
                        SaveImageRootDictroy = Path.GetPathRoot(value);
                        if (RootDirectoryChangedEvent != null)
                            RootDirectoryChangedEvent(SaveImageRootDictroy);
                    }

                    myINIObj.Write<string>(_SectionName, "SavePath", value);
                    if (SavePathChangedEvent != null)
                        SavePathChangedEvent(value);
                }

            }
        }
        /// <summary>
        /// 获取保存图片的根目录
        /// </summary>
        public string SaveImageRootDictroy { get; private set; }

        /// <summary>
        /// 获取或设置保存图像的格式，默认是bmp格式
        /// </summary>
        public SaveImageType SaveType
        {
            get
            {
                return _saveType;
            }
            set
            {
                _saveType = value;
                switch (_saveType)
                {
                    case SaveImageType.NONE:
                        myINIObj.Write<string>(_SectionName, "SaveImageType", "None");

                        break;
                    case SaveImageType.BMP:
                        myINIObj.Write<string>(_SectionName, "SaveImageType", "Bmp");
                        break;
                    case SaveImageType.JPG:
                        myINIObj.Write<string>(_SectionName, "SaveImageType", "Jpg");
                        break;
                    default:
                        myINIObj.Write<string>(_SectionName, "SaveImageType", "Bmp");
                        break;
                }
            }
        }

        /// <summary>
        /// 获取或设置是否保存图像,默认保存图像
        /// </summary>
        public bool IsSaveImage
        {
            get
            {
                return _isSaveImage;
            }
            set
            {
                _isSaveImage = value;
                myINIObj.Write<bool>(_SectionName, "IsSaveImage", value);
            }
        }

        /// <summary>
        /// 获取保存图像的名称
        /// </summary>
        public string ImageName { get; private set; }

        /// <summary>
        /// 获取或设置是否向图像名称中自动添加时间 
        /// </summary>
        public bool IsAddTimeToImageName
        {
            get
            {
                return _isAddTimeToImageName;
            }
            set
            {
                _isAddTimeToImageName = value;
                myINIObj.Write<bool>(_SectionName, "IsAddTimeToImageName", value);
            }
        }

        /// <summary>
        /// 获取或设置图像队列最大允许的数量，超出则丢弃
        /// -1为内存允许范围内可以无限大.
        /// 默认最大数量为20
        /// </summary>
        public int ImageQueueMaxCount { get; set; } = 20;

        #endregion

        #region 公共方法

        /// <summary>
        /// 保存bitmap类型的图片
        /// </summary>
        /// <param name="image"></param>
        public virtual string Save(Bitmap image, string imageName)
        {
            if (IsSaveImage == false) return null;
            try
            {
                if (IsFilePathExist(SavePath))  //判断文件路径是否存在
                {
                    if (SaveType == SaveImageType.NONE) return null;
                    Bitmap saveImage = image.Clone() as Bitmap;
                    //检查输入图像名称的合法性
                    CheckImageNameValidity(imageName);
                    string filename = JudgementImageType(MakeImageName(imageName));
                    //判断队列中的数量是否大于0或存图是否正忙
                    if (myImageQueue.Count > 0)
                    {
                        PushImageToQueue(saveImage, filename);
                        return filename;
                    }
                    else
                    {
                        SavaimageMethod(saveImage, filename);
                        return filename;
                    }
                }
                else
                    return "Err";

            }
            catch (Exception ex)
            {
                if (SaveCompleteEvent != null)
                {
                    SaveImageCompleteInfo saveImageCompleteInfo = new SaveImageCompleteInfo(ex.ToString());
                    saveImageCompleteInfo.SaveCompleteTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    SaveCompleteEvent(this, saveImageCompleteInfo);   //保存完成事件  
                }
                return "Err";
            }
        }

        public virtual void SaveImageByFullName(Bitmap image,string imageFullName)
        {
            if (IsSaveImage == false) return;
            try
            {
                
                if (IsFilePathExist(Path.GetDirectoryName(imageFullName)))  //判断文件路径是否存在
                {
                    Bitmap saveImage = image.Clone() as Bitmap;
                    //判断队列中的数量是否大于0或存图是否正忙
                    if (myImageQueue.Count > 0)
                    {
                        PushImageToQueue(saveImage, imageFullName);
                    }
                    else
                    {
                        SavaimageMethod(saveImage, imageFullName);
                                          }
                }
            }
            catch (Exception ex)
            {
                if (SaveCompleteEvent != null)
                {
                    SaveImageCompleteInfo saveImageCompleteInfo = new SaveImageCompleteInfo(ex.ToString());
                    saveImageCompleteInfo.SaveCompleteTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    SaveCompleteEvent(this, saveImageCompleteInfo);   //保存完成事件  
                }
                throw ex;
            }

        }

        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);

        }
        #endregion

        #region 私有方法

        protected virtual void Dispose(bool disposing)
        {
            //释放非托管内存

            if (disposing)
            {


            }
        }

        protected void SavaimageMethod(Bitmap image, string fileName)
        {
            try
            {
                Task saveTask = new Task(new Action(() =>
                {
                    image.Save(fileName);
                    ImageName = System.IO.Path.GetFileName(fileName);
                    if (SaveCompleteEvent != null)
                    {
                        SaveImageCompleteInfo saveImageCompleteInfo = new SaveImageCompleteInfo(true);
                        saveImageCompleteInfo.ImageFullName = fileName;
                        saveImageCompleteInfo.SaveCompleteTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        SaveCompleteEvent(this, saveImageCompleteInfo);   //保存完成事件  
                    }

                }));
                saveTask.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        /// <summary>
        /// 检查保存图像的路径存不存在
        /// </summary>
        /// <returns></returns>
        protected bool IsFilePathExist(string path)
        {
            if (path == null)
            {
                throw new Exception("保存图像路径为空，请设置保存路径！");
            }
            else
            {
                if (System.IO.Directory.Exists(path)) return true;
                else
                {
                    //创建文件夹
                    try
                    {
                        System.IO.Directory.CreateDirectory(path);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("文件路径不存在。创建文件夹失败！" + ex.Message);
                    }

                }

            }
        }

        protected string MakeImageName(string name)
        {

            StringBuilder stringBuilder = new StringBuilder(SavePath).Append(@"\").Append(name);
            if (IsAddTimeToImageName)
            {
                stringBuilder.Append("_").Append(DateTime.Now.ToString("HH-mm-ss-fff"));
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// 检测输入图像名称的合法性
        /// </summary>
        /// <returns></returns>
        protected void CheckImageNameValidity(string name)
        {
            if (name == "" || name == string.Empty)
            {
                throw new Exception("输入图像名称为空！");
            }
            //检测图像名称中是否包含不合法的字符串
            if (name.Contains(" ") || name.Contains("?") || name.Contains(":") ||
                name.Contains("*") || name.Contains("/") || name.Contains(@"\")
                || name.Contains(">") || name.Contains("<") || name.Contains("|") ||
                name.Contains("\""))
            {
                throw new Exception("图像名称不合法！");
            }
        }

        protected string JudgementImageType(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(name);
            switch (SaveType)
            {
                case SaveImageType.BMP:
                    stringBuilder.Append(".bmp");
                    break;
                case SaveImageType.JPG:
                    stringBuilder.Append(".jpg");
                    break;
                default:    //bmp
                    stringBuilder.Append(".bmp");
                    break;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 图像队列连续为空次数
        /// </summary>
        private static int successionEmptyCount = 0;
        /// <summary>
        /// 存图泵机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveImagePump(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (myImageQueue.Count == 0 && successionEmptyCount >= 600)
            {
                successionEmptyCount = 0;
                saveImageTimer.Stop();
                IsTimerStart = false;
            }
            else if (myImageQueue.Count == 0)
            {
                successionEmptyCount++;
            }
            else
            {
                SaveImageStr saveImageStr = myImageQueue.Dequeue();
                SavaimageMethod(saveImageStr.image, saveImageStr.imageName);

            }


        }
        /// <summary>
        /// 将图像压入队列
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageName"></param>
        protected void PushImageToQueue(Bitmap image, string imageName)
        {
            if (myImageQueue.Count > ImageQueueMaxCount) return;
            //检查泵机是否启动
            if (IsTimerStart == false)
            {
                saveImageTimer.Start();
                IsTimerStart = true;
            }
            SaveImageStr saveImageStr = new SaveImageStr();
            saveImageStr.image = image;
            saveImageStr.imageName = imageName;
            myImageQueue.Enqueue(saveImageStr);

        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitPara()
        {
            try
            {
                SavePath = myINIObj.Read<string>(_SectionName, "SavePath");
                string save_type = myINIObj.Read<string>(_SectionName, "SaveImageType");
                switch (save_type)
                {
                    case "None":
                        _saveType = SaveImageType.NONE;
                        break;
                    case "Bmp":
                        _saveType = SaveImageType.BMP;
                        break;
                    case "Jpg":
                        _saveType = SaveImageType.JPG;
                        break;
                    default:
                        _saveType = SaveImageType.BMP;
                        break;
                }
                _isSaveImage = myINIObj.Read<bool>(_SectionName, "IsSaveImage");
                _isAddTimeToImageName = myINIObj.Read<bool>(_SectionName, "IsAddTimeToImageName");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        private void WritePara()
        {
            myINIObj.Write<string>(_SectionName, "SavePath", _path);
            myINIObj.Write<bool>(_SectionName, "IsSaveImage", _isSaveImage);
            myINIObj.Write<bool>(_SectionName, "IsAddTimeToImageName", _isAddTimeToImageName);
        }
        #endregion

        #region 委托



        #endregion

        #region 事件
        /// <summary>
        /// 保存图像完成事件
        /// </summary>
        public event SaveImasgeCompleteEventHandle SaveCompleteEvent;

        /// <summary>
        /// 保存图像路径改变事件
        /// </summary>
        public event SavePathChangedEventHandle SavePathChangedEvent;

        /// <summary>
        /// 保存图像根目录改变事件
        /// </summary>
        public event SaveImageRootDirectoryChangedEventHandle RootDirectoryChangedEvent;
        #endregion

        private class SaveImageStr
        {
            public Bitmap image;
            public string imageName;
        }

    }

}
