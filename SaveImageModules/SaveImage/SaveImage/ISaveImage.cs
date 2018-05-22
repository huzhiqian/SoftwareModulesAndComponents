using SaveImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;



namespace SaveImage
{
    /// <summary>
    /// 保存图片接口
    /// </summary>
    public interface ISaveImage : IDisposable
    {

        #region 属性

        string SectionName { get; set; }

        string ConfigFilePath { get; }
        /// <summary>
        /// 保存图片路径
        /// </summary>
        string SavePath { get; set; }
        /// <summary>
        /// 获取保存图片的根目录
        /// </summary>
        string SaveImageRootDictroy { get; }

        /// <summary>
        /// 获取或设置保存图像的类型
        /// </summary>
        SaveImageType SaveType { get; set; }

        /// <summary>
        /// 获取或设置是否保存图像
        /// </summary>
        bool IsSaveImage { get; set; }

        /// <summary>
        /// 获取保存图像的名称
        /// </summary>
        string ImageName { get; }

        /// <summary>
        /// 获取或设置是否向图像名称中自动添加时间
        /// </summary>
        bool IsAddTimeToImageName { get; set; }

        /// <summary>
        /// 获取或设置图像队列最大允许的数量，-1为内存允许范围内可以无限大
        /// </summary>
        int ImageQueueMaxCount { get; set; }
        #endregion


        #region 方法
        /// <summary>
        /// 保存bitmap类型图片
        /// </summary>
        /// <param name="image">需要保存的图片</param>
        string Save(Bitmap image, string imageName);

        #endregion

        #region 事件
        /// <summary>
        /// 保存图像完成事件
        /// </summary>
        event SaveImasgeCompleteEventHandle SaveCompleteEvent;

        /// <summary>
        /// 保存图像路径改变事件
        /// </summary>
        event SavePathChangedEventHandle SavePathChangedEvent;

        /// <summary>
        /// 保存图像根目录改变事件
        /// </summary>
        event SaveImageRootDirectoryChangedEventHandle RootDirectoryChangedEvent;
        #endregion

    }

}
