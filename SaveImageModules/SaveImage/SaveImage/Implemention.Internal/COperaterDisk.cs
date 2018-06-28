using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：COperaterDisk
//命名空间：SaveImage.Implemention.Internal
//CLR版本：4.0.30319.42000
//内容：
//功能：本地计算机磁盘操作类，负者检查磁盘容量，删除磁盘上的文件等操作
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/11 11:37:40
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage.Implemention.Internal
{
   internal class COperaterDisk
    {
        private string rootDirectroy;

        static object locker = new object();
        #region 构造函数

        public COperaterDisk(string _rootPath)
        {
            rootDirectroy = _rootPath;
        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法

        /// <summary>
        /// 修改保存图像根目录
        /// </summary>
        /// <param name="root"></param>
        public void ChangeRootDirectory(string root)
        {
            rootDirectroy = root;
        }

        /// <summary>
        /// 获取磁盘容量
        /// </summary>
        /// <returns>返回磁盘容量，如何检查出错或磁盘不存在则返回-1</returns>
        public double GetDiskCapacity()
        {
            try
            {
                if (!string.IsNullOrEmpty(rootDirectroy))
                {
                    if (System.IO.Directory.Exists(rootDirectroy))
                    {
                        double freeSpace = 0;
                        System.IO.DriveInfo[] dirves = System.IO.DriveInfo.GetDrives();
                        foreach (var item in dirves)
                        {
                            if (item.Name == rootDirectroy || item.Name == rootDirectroy.ToUpper())
                            {
                                freeSpace = item.TotalFreeSpace / Math.Pow(1024,3);
                            }
                        }
                        return freeSpace;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除磁盘上指定的文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回删除是否删掉了文件</returns>
        public bool DeleteFile(string fileName)
        {
            lock (locker)
            {
                if (System.IO.File.Exists(fileName))
                {
                    try
                    {
                        System.IO.File.Delete(fileName);
                        //LogModules.LogControlser.WriteLog("成功删除：" + fileName);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        LogModules.LogControlser.WriteLog("删除" + fileName + "出错！" + System.Environment.NewLine + ex.ToString());
                        return false;
                    }

                }
                else
                {
                    //LogModules.LogControlser.WriteLog("删除" + fileName + "出错！" + System.Environment.NewLine + "图片不存在！");
                    return true;
                }
            }
            
        }

        /// <summary>
        /// 删除磁盘上一系列文件
        /// </summary>
        /// <param name="fileNames">要删除的文件名集合</param>
        /// <returns></returns>
        public bool DeleteFiles(string[] fileNames)
        {
            int deleteCount = 0;
            if (fileNames.Length > 0)
            {
                foreach (var item in fileNames)
                {
                    if (DeleteFile(item))
                    {
                        deleteCount++;
                    }
                }
                if (deleteCount == fileNames.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
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
