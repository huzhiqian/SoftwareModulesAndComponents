using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;




/// <summary>
/// 保存图片接口
/// </summary>
public interface ISaveImage
{

    #region 属性

    /// <summary>
    /// 保存图片路径
    /// </summary>
    string Path { get; set; }
    /// <summary>
    /// 获取保存的图像
    /// </summary>
    Bitmap @Image { get; }

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
    #endregion


    #region 方法
    /// <summary>
    /// 保存bitmap类型图片
    /// </summary>
    /// <param name="image">需要保存的图片</param>
    void Save(Bitmap image,string imageName);

    #endregion

    #region 事件

    /// <summary>
    /// 图像保存完成事件
    /// </summary>
    event SaveImasgeCompleteEventHandle SaveCompleteEvent;

    #endregion

    }
