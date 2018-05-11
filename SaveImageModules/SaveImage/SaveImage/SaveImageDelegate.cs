using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


namespace SaveImage
{
    /// <summary>
    /// 保存图片完成事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SaveImasgeCompleteEventHandle(object sender,SaveImageCompleteInfo e);

    /// <summary>
    /// 保存图片路径改变事件委托
    /// </summary>
    /// <param name="currentPath">当前保存图像的路径</param>
    public delegate void SavePathChangedEventHandle(string currentPath);

    /// <summary>
    /// 保存图像根目录改变事件委托
    /// </summary>
    /// <param name="rootDirectroy"></param>
    public delegate void SaveImageRootDirectoryChangedEventHandle(string rootDirectroy);
}
     