﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;

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
    public class CSaveImage : ISaveImage, IDisposable
    {
        private CINIFile myINIObj;
        private Queue<SaveImageStr> myImageQueue;     //图像队列，缓冲池
        private System.Timers.Timer saveImageTimer;
        private bool IsTimerStart = false;

        //字段
        private string _path;
        private SaveImageType _saveType = SaveImageType.BMP;
        private bool _isSaveImage = true;
        private bool _isAddTimeToImageName = true;
        private string _configFilePath;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilePath">配置文件路径</param>
        public CSaveImage(string configFilePath)
        {
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
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="savePath">保存图片的路径</param>
        public CSaveImage(string configFilepath, string savePath, bool isSave)
        {
            _configFilePath = configFilepath;
            Path = savePath;
            IsSaveImage = isSave;
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
            myINIObj.Write<string>("SaveImagePara", "SavePath", savePath);
            myINIObj.Write<bool>("SaveImagePara", "SavePath",isSave);
            InitPara();
        }

        #endregion


        #region 属性

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
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                myINIObj.Write<string>("SaveImagePara", "SavePath", value);
            }
        }

        /// <summary>
        /// 获取保存的图片
        /// </summary>
        public Bitmap Image { get; private set; }
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
                        myINIObj.Write<string>("SaveImagePara", "SaveImageType", "None");
                        break;
                    case SaveImageType.BMP:
                        myINIObj.Write<string>("SaveImagePara", "SaveImageType", "Bmp");
                        break;
                    case SaveImageType.JPG:
                        myINIObj.Write<string>("SaveImagePara", "SaveImageType", "Jpg");
                        break;
                    default:
                        myINIObj.Write<string>("SaveImagePara", "SaveImageType", "Bmp");
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
                myINIObj.Write<bool>("SaveImagePara", "IsSaveImage", value);
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
                myINIObj.Write<bool>("SaveImagePara", "IsAddTimeToImageName", value);
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
        public virtual void Save(Bitmap image, string imageName)
        {
            if (IsSaveImage == false) return;
            try
            {
                Image = image;

                if (IsFilePathExist())  //判断文件路径是否存在
                {
                    if (SaveType == SaveImageType.NONE) return;
                    //判断队列中的数量是否大于0或存图是否正忙
                    if (myImageQueue.Count > 0)
                    {
                        PushImageToQueue(image, imageName);
                        return;
                    }
                    SavaimageMethod(image, imageName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            Image.Dispose();
        }
        #endregion

        #region 私有方法

        protected void SavaimageMethod(Bitmap image, string fileName)
        {
            Task saveTask = new Task(new Action(() =>
            {
                //检查输入图像名称的合法性
                CheckImageNameValidity(fileName);
                string filename = JudgementImageType(MakeImageName(fileName));

                image.Save(filename);

                if (SaveCompleteEvent != null)
                {
                    SaveCompleteEvent();   //保存完成事件  
                }
            }));
            saveTask.Start();
        }
        /// <summary>
        /// 检查保存图像的路径存不存在
        /// </summary>
        /// <returns></returns>
        protected bool IsFilePathExist()
        {
            if (Path == null)
            {
                throw new Exception("保存图像路径为空，请设置保存路径！");
            }
            else
            {
                if (System.IO.Directory.Exists(Path)) return true;
                else
                    throw new Exception("保存图像文件路径不存在，请检查文件路径！");
            }
        }

        protected string MakeImageName(string name)
        {

            StringBuilder stringBuilder = new StringBuilder(Path).Append(@"\").Append(name);
            if (IsAddTimeToImageName)
            {
                stringBuilder.Append("_").Append(DateTime.Now.ToString("hh-mm-ss-fff"));
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
            if (myImageQueue.Count == 0)
            {
                successionEmptyCount++;
                saveImageTimer.Stop();
                IsTimerStart = false;
            }
            else
            {
                SavaimageMethod(myImageQueue.Dequeue().image, myImageQueue.Dequeue().imageName);
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
            SaveImageStr saveImageStr;
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
                _path = myINIObj.Read<string>("SaveImagePara", "SavePath");
                string save_type = myINIObj.Read<string>("SaveImagePara", "SaveImageType");
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
                _isSaveImage = myINIObj.Read<bool>("SaveImagePara", "IsSaveImage");
                _isAddTimeToImageName = myINIObj.Read<bool>("SaveImagePara", "IsAddTimeToImageName");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }


        }
        #endregion

        #region 委托



        #endregion

        #region 事件
        /// <summary>
        /// 保存图像完成事件
        /// </summary>
        public event SaveImasgeCompleteEventHandle SaveCompleteEvent;

        #endregion

        private struct SaveImageStr
        {
            public Bitmap image;
            public string imageName;
        }

    }

}