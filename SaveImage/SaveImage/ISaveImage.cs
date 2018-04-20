using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 保存图片接口
/// </summary>
interface ISaveImage
{

    /// <summary>
    /// 保存图片路径
    /// </summary>
    string Path { get; set; }

    /// <summary>
    /// 保存图片
    /// </summary>
    /// <param name="filePath">保存路径</param>
    void SaveImage(string filePath);


}
