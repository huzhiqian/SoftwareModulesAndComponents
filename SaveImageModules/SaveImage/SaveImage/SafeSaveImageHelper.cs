using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using static SaveImage.CSafeSaveImage;


//**********************************************
//文件名：SafeSaveImageHelper
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：
//功能：对CSaveImage和CSafeSaveImage的封装
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/14 10:50:38
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
   public class SafeSaveImageHelper
    {
        private CSaveImage mySaveImage;
        private CSafeSaveImage mySafeSaveImage;
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilePath">保存图片的config文件路径</param>
        public SafeSaveImageHelper(string configFilePath)
        {
            mySaveImage = new CSaveImage(configFilePath);
            mySafeSaveImage = new CSafeSaveImage( ref mySaveImage);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilepath">保存图片的config文件路径</param>
        /// <param name="savePath">保存图片路径</param>
        /// <param name="isSave">是否保存图片</param>
        /// <param name="sectionName">config文件中section（节）名称</param>
        public SafeSaveImageHelper(string configFilepath, string savePath, bool isSave, string sectionName)
        {
            mySaveImage = new CSaveImage(configFilepath, savePath, isSave, sectionName);
            mySafeSaveImage = new CSafeSaveImage( ref mySaveImage);

            //绑定事件
            mySaveImage.SaveCompleteEvent += new SaveImasgeCompleteEventHandle(SaveCompleteEventFun);
            mySaveImage.RootDirectoryChangedEvent += new SaveImageRootDirectoryChangedEventHandle(RootDirectoryChangedEventFun);
            mySaveImage.SavePathChangedEvent += new SavePathChangedEventHandle(SavePathChangedEventFun);

            mySafeSaveImage.LogEvent += new LogInfoEventHandle(LogFun);
        }
        #endregion


        #region 属性

        /// <summary>
        /// 设置配置文件中的节名称
        /// </summary>
        public string SectionName
        {
            get { return mySaveImage.SectionName; }
            set { mySaveImage.SectionName = value; }
        }

        /// <summary>
        /// 获取保存图片的配置文路径
        /// </summary>
        public string ConfigFilePath
        {
            get { return mySaveImage.ConfigFilePath; }
        }

        /// <summary>
        /// 获取或设置保存图片路径
        /// </summary>
        public string SavePath
        {
            get { return mySaveImage.SavePath; }
            set { mySaveImage.SavePath = value; }
        }
        /// <summary>
        /// 获取保存图片的根目录
        /// </summary>
        public string SaveImageRootDictroy
        {
            get { return mySaveImage.SaveImageRootDictroy; }
        }

        /// <summary>
        /// 获取或设置保存图像的格式，默认是bmp格式
        /// </summary>
        public SaveImageType SaveType
        {
            get { return mySaveImage.SaveType; }
            set { mySaveImage.SaveType = value; }
        }

        /// <summary>
        /// 获取或设置是否保存图像,默认保存图像
        /// </summary>
        public bool IsSaveImage
        {
            get { return mySaveImage.IsSaveImage; }
            set { mySaveImage.IsSaveImage = value; }
        }

        /// <summary>
        /// 获取保存图像的名称
        /// </summary>
        public string ImageName
        {
            get { return mySaveImage.ImageName; }
        }

        /// <summary>
        /// 获取或设置是否向图像名称中自动添加时间 
        /// </summary>
        public bool IsAddTimeToImageName
        {
            get { return mySaveImage.IsAddTimeToImageName; }
            set { mySaveImage.IsAddTimeToImageName = value; }
        }

        /// <summary>
        /// 获取或设置图像队列最大允许的数量，超出则丢弃
        /// -1为内存允许范围内可以无限大.
        /// 默认最大数量为20
        /// </summary>
        public int ImageQueueMaxCount
        {
            get { return mySaveImage.ImageQueueMaxCount; }
            set { mySaveImage.ImageQueueMaxCount = value; }
        }


        /// <summary>
        /// 获取或设置删除图像的模式
        /// </summary>
        public AutoDeleteImageModeEnum DeleteMode
        {
            get { return mySafeSaveImage.DeleteMode; }
            set { mySafeSaveImage.DeleteMode = value; }
        }

        /// <summary>
        /// 获取或设置图片在磁盘上允许存在时间（单位：天）
        /// </summary>
        public int ImageLifeSpan
        {
            get { return mySafeSaveImage.ImageLifeSpan; }
            set { mySafeSaveImage.ImageLifeSpan = value; }
        }

        /// <summary>
        /// 获取或设置磁盘最小可用空间（GB）
        /// </summary>
        public double DiskAllowsMinCapacity
        {
            get { return mySafeSaveImage.DiskAllowsMinCapacity; }
            set { mySafeSaveImage.DiskAllowsMinCapacity = value; }
        }

        #endregion

        #region 公共方法

        public string Save(Bitmap image, string imageName)
        {
            return mySafeSaveImage.SaveImage(image, imageName);
        }
        /// <summary>
        /// 获取数据库是否连接
        /// </summary>
        public bool IsDBLinked
        {
            get { return mySafeSaveImage.IsDBLinked; }
        }
        #endregion

        #region 私有方法

        private void LogFun(string info)
        {
            if (LogInfoEvent != null)
            {
                LogInfoEvent(info);
            }
        }

        private void SaveCompleteEventFun(object sender, SaveImageCompleteInfo e)
        {
            if (SaveCompleteEvent != null)
            {
                SaveCompleteEvent(sender,e);
            }
        }

        private void SavePathChangedEventFun(string currentPath)
        {
            if (SavePathChangedEvent != null)
            {
                SavePathChangedEvent(currentPath);
            }
        }

        private void RootDirectoryChangedEventFun(string rootDirectroy)
        {
            if (RootDirectoryChangedEvent != null)
            {
                RootDirectoryChangedEvent(rootDirectroy);
            }
        }
        #endregion

        #region 委托



        #endregion

        #region 事件

        /// <summary>
        /// Log事件
        /// </summary>
        public event LogInfoEventHandle LogInfoEvent;

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
    }
}
