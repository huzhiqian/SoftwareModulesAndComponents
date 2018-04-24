﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;

//**********************************************
//文件名：SaveImageDecorator
//命名空间：SaveImage
//CLR版本：4.0.30319.42000
//内容：实现CSaveImage功能，与CSaveImage是为聚合关系
//功能：CSaveImage的装饰者
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/4/23 14:50:27
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
  internal  class SaveImageDecorator : ISaveImage
    {
        //被装饰者
        private ISaveImage mySaveImage;
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SaveImageDecorator(ISaveImage _SaveImage)
        {
            mySaveImage = _SaveImage;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="savePath">保存图片的路径</param>
        public SaveImageDecorator(string savePath, bool isSave,ISaveImage _saveImage)
        {
            Path = savePath;
            IsSaveImage = isSave;
            mySaveImage = _saveImage;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置保存图片路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 获取保存的图片
        /// </summary>
        public Bitmap Image { get; private set; }
        /// <summary>
        /// 获取或设置保存图像的格式，默认是bmp格式
        /// </summary>
        public SaveImageType SaveType { get; set; } = SaveImageType.BMP;

        /// <summary>
        /// 获取或设置是否保存图像,默认保存图像
        /// </summary>
        public bool IsSaveImage { get; set; } = true;

        /// <summary>
        /// 获取保存图像的名称
        /// </summary>
        public string ImageName { get; private set; }

        /// <summary>
        /// 获取或设置是否向图像名称中自动添加时间 
        /// </summary>
        public bool IsAddTimeToImageName { get; set; } = true;

        /// <summary>
        /// 获取或设置图像队列最大允许的数量，超出则丢弃
        /// -1为内存允许范围内可以无限大.
        /// 默认最大数量为20
        /// </summary>
        public int ImageQueueMaxCount { get; set; } = 20;
        #endregion

        #region 公共方法

        /// <summary>
        /// 保存bitmap类型的图片
        /// </summary>
        /// <param name="image"></param>
        public virtual void Save(Bitmap image, string imageName)
        {
            if (IsSaveImage == false) return;
            try
            {
                Image = image;
                if (IsFilePathExist())  //判断文件路径是否存在
                {
                    if (SaveType == SaveImageType.NONE) return;
                    Task saveTask = new Task(new Action(() =>
                    {
                        //检查输入图像名称的合法性
                        CheckImageNameValidity(imageName);

                        image.Save(JudgementImageType(MakeImageName(imageName)));

                        if (SaveCompleteEvent != null)
                        {
                            SaveCompleteEvent();   //保存完成事件  
                        }
                    }));
                    saveTask.Start();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            Image.Dispose();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 检查保存图像的路径存不存在
        /// </summary>
        /// <returns></returns>
        protected bool IsFilePathExist()
        {
            if (Path == null)
            {
                throw new Exception("保存图像路径为空，请设置保存路径！");
            }
            else
            {
                if (System.IO.Directory.Exists(Path)) return true;
                else
                    throw new Exception("保存图像文件路径不存在，请检查文件路径！");
            }
        }

        protected string MakeImageName(string name)
        {

            StringBuilder stringBuilder = new StringBuilder(Path).Append(@"\").Append(name);
            if (IsAddTimeToImageName)
            {
                stringBuilder.Append("_").Append(DateTime.Now.ToString("hh-mm-ss-fff"));
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// 检测输入图像名称的合法性
        /// </summary>
        /// <returns></returns>
        protected void CheckImageNameValidity(string name)
        {
            if (name == "" || name == string.Empty)
            {
                throw new Exception("输入图像名称为空！");
            }
            //检测图像名称中是否包含不合法的字符串
            if (name.Contains(" ") || name.Contains("?") || name.Contains(":") ||
                name.Contains("*") || name.Contains("/") || name.Contains(@"\")
                || name.Contains(">") || name.Contains("<") || name.Contains("|") ||
                name.Contains("\""))
            {
                throw new Exception("图像名称不合法！");
            }
        }

        protected string JudgementImageType(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(name);
            switch (SaveType)
            {
                case SaveImageType.BMP:
                    stringBuilder.Append(".bmp");
                    break;
                case SaveImageType.JPG:
                    stringBuilder.Append(".jpg");
                    break;
                default:    //bmp
                    stringBuilder.Append(".bmp");
                    break;
            }
            return stringBuilder.ToString();
        }

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
