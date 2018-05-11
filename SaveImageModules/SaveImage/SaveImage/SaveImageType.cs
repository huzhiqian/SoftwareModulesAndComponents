using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace SaveImage
{
    /// <summary>
    /// 保存图像的类型
    /// </summary>
    public enum SaveImageType
    {
        /// <summary>
        /// 不保存图像
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 将图像保存的bmp格式
        /// </summary>
        BMP = 1,
        /// <summary>
        /// 将图像保存成jpg格式
        /// </summary>
        JPG = 2,

    }

}
