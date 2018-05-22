using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using SaveHalconImage;
using SaveImage;
using HalconDotNet;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

//**********************************************
//文件名：SafeSaveHalconImage
//命名空间：SaveHalconImage
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/14 11:17:48
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveHalconImage
{
    public class SafeSaveHalconImage : SafeSaveImageHelper
    {
        #region 构造函数
        /// <summary>
        /// 构造保存图片对象
        /// </summary>
        /// <param name="configFilePath">存图配置文件路径</param>
        public SafeSaveHalconImage(string configFilePath) : base(configFilePath)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilePath">存图配置文件路径</param>
        /// <param name="path">图片保存路径</param>
        /// <param name="isSave">是否保存图片</param>
        public SafeSaveHalconImage(string configFilePath, string path, bool isSave, string sectionName)
            : base(configFilePath, path, isSave, sectionName)
        {

        }
        #endregion


        #region 属性



        #endregion

        #region 公共方法
        /// <summary>
        /// 保存灰度图
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageName"></param>
        public void SaveGreyImage(HObject image, string imageName)
        {
            if (image == null) return;
            try
            {
                Bitmap bitmap;
                TransGreyHobjectToBitMap(image, out bitmap);

                base.Save(bitmap, imageName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存彩色图像
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageName"></param>
        public void SaveRGBImage(HObject image, string imageName)
        {
            if (image == null) return;
            Bitmap bitmap;
            TransRGBHObjectToBitmap(image.Clone(), out bitmap);
            base.Save(bitmap, imageName);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 将halcon的灰度图转化成bitmap
        /// </summary>
        /// <returns></returns>
        private void TransGreyHobjectToBitMap(HObject image, out Bitmap bitmap)
        {
            try
            {
                //将halcont图像转换成bitmap
                HTuple hpoint, type, width, height;
                const int Alpha = 255;
                int[] ptr = new int[2];
                HOperatorSet.GetImagePointer1(image, out hpoint, out type, out width, out height);

                bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);//创建一张空的bitmap
                ColorPalette pal = bitmap.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    pal.Entries[i] = Color.FromArgb(Alpha, i, i, i);
                }
                bitmap.Palette = pal;
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

                int pixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
                ptr[0] = bitmapData.Scan0.ToInt32();
                ptr[1] = hpoint.I;
                if (width % 4 == 0)
                {
                    CopyMemory(ptr[0], ptr[1], width * height * pixelSize);
                }
                else
                {
                    for (int i = 0; i < height.I - 1; i++)
                    {
                        ptr[1] += width.I;
                        CopyMemory(ptr[0], ptr[1], width.I * pixelSize);
                        ptr[0] += bitmapData.Stride;
                    }
                }
                bitmap.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void TransRGBHObjectToBitmap(HObject image, out Bitmap bitmap)
        {
            HTuple hred, hgreen, hblue, type, width, height;
            HOperatorSet.GetImagePointer3(image, out hred, out hgreen, out hblue, out type, out width, out height);

            bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Rectangle rect = new Rectangle(0, 0, width, height);

            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* bptr = (byte*)bitmapData.Scan0;
                byte* r = (byte*)hred.I;
                byte* g = (byte*)hgreen.I;
                byte* b = (byte*)hblue.I;
                for (int i = 0; i < width * height; i++)
                {
                    bptr[i * 4] = r[i];
                    bptr[i * 4 + 1] = g[i];
                    bptr[i * 4 + 2] = b[i];
                    bptr[i * 4 + 3] = 255;
                }
            }
            bitmap.UnlockBits(bitmapData);

        }

        [DllImport("kernel32.dll")]
        private static extern void CopyMemory(int Destination, int add, int Length);
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
