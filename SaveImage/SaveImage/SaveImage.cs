using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;


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

        /// <summary>
        /// 保存bitmap类型的图片
        /// </summary>
        /// <param name="image"></param>
        public void Save(Bitmap image)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存图像，泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="image"></param>
        public void Save<T>(T image)
        {

        }
        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件
        /// <summary>
        /// 保存图像完成事件
        /// </summary>
        public event SaveImasgeCompleteEventHandle SaveCompleteEvent;

        #endregion
    }
}
