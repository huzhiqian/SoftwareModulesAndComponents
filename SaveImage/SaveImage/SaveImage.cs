using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


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
    class SaveImage:ISaveImage
    {

        #region 构造函数
        public SaveImage()
        {

        }





        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置保存图片路径
        /// </summary>
        public string Path { get; set; }

        #endregion

        #region 公共方法

        void ISaveImage.SaveImage(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
