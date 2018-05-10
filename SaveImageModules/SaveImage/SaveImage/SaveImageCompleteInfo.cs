using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.IO;


//**********************************************
//文件名：SaveImageCompleteInfo
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：保存图片完成信息类
//功能：包含保存图片完成后的信息
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/10 11:13:45
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    public class SaveImageCompleteInfo
    {
        private string _imageFullName;  //图像完整路径
        private string _saveCompleteTime;  //保存图片完成时间
        private bool _isSaveSuccess=false;
        private string _expectionInfo;   //保存图像错误信息
        #region 构造函数


        public SaveImageCompleteInfo(bool isSuccess)
        {
            _isSaveSuccess = isSuccess;
        }

        public SaveImageCompleteInfo(string errinfo)
        {
            _expectionInfo = errinfo;
        }
        #endregion


        #region 属性
        /// <summary>
        /// 获取或设置图像完整路径
        /// </summary>
        public string ImageFullName
        {
            get { return _imageFullName; }
            set { _imageFullName = value; }
        }
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        {
            get { return GetImageName(_imageFullName); }
        }

        /// <summary>
        /// 获取或设置保存图像完成时间
        /// </summary>
        public string SaveCompleteTime
        {
            get { return _saveCompleteTime; }
            set { _saveCompleteTime = value; }
        }

        /// <summary>
        /// 获取或设置保存图像是否成功
        /// </summary>
        public bool IsSaveImageSuccess
        {
            get { return _isSaveSuccess; }
        }

        /// <summary>
        /// 获取保存图像错误信息
        /// </summary>
        public string ErrInfo
        {
            get { return _expectionInfo; }
        }
        #endregion

        #region 公共方法



        #endregion

        #region 私有方法

        private string GetImageName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return null;
            return Path.GetFileName(fullName);
        }

        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
