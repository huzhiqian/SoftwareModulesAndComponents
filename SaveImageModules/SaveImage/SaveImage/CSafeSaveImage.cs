using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;


//**********************************************
//文件名：CSafeSaveImage
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：该类是CSaveImage的一个具体装饰者
//功能：安全保存图像类，在保存图像之前会检查磁盘容量，自动删除等
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/10 13:54:22
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    class CSafeSaveImage:SaveImageDecorator
    {
        //字段
        private AutoDeleteImageModeEnum _deleteMode = AutoDeleteImageModeEnum.NULL; //自动删除模式
        private int ImagelifeSpan = 1;          //图片存在寿命(天)
        private int DiskAllowsMinCapacity = 1;  //磁盘允许最小容量（GB）


        #region 构造函数

        public CSafeSaveImage(ISaveImage saveImage):base(saveImage)
        {

        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法

        public void SaveImage(Bitmap image, string imageName)
        {
            //添加新的行为

           string imageFullName= base.Save(image,imageName);
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
