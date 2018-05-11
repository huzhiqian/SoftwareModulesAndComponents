using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：AutoDeleteImageMode
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：自动删除图片的模式
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/10 15:01:57
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    /// <summary>
    /// 自动删除图片的模式
    /// </summary>
    public enum AutoDeleteImageModeEnum
    {
        /// <summary>
        /// 不自动删除
        /// </summary>
        NONE=0,
        /// <summary>
        /// 按照时间删除
        /// </summary>
        TIME=1,
        /// <summary>
        /// 按照容量删除
        /// </summary>
        CAPACITY=2,
    }

}
