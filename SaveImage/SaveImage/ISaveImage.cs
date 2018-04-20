using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

public delegate void SaveImasgeCompleteEventHandle();

/// <summary>
/// 保存图片接口
/// </summary>
interface ISaveImage
{

    #region 属性

    /// <summary>
    /// 保存图片路径
    /// </summary>
    string Path { get; set; }

    #endregion


    #region 方法
    /// <summary>
    /// 保存bitmap类型图片
    /// </summary>
    /// <param name="image">需要保存的图片</param>
    void Save(Bitmap image);

    /// <summary>
    /// 保存图片，泛型类型
    /// </summary>
    /// <typeparam name="T">图片类型</typeparam>
    /// <param name="image">需要保存的图像</param>
    void Save<T>(T image);
    #endregion

    #region 事件

    /// <summary>
    /// 图像保存完成事件
    /// </summary>
    event SaveImasgeCompleteEventHandle SaveCompleteEvent;

    #endregion

    }
