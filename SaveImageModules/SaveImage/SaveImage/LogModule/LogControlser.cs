using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.IO;


//**********************************************
//文件名：LogControlser
//命名空间：YiKe_DataRetrospect.LogModules
//CLR版本：4.0.30319.42000
//内容：
//功能：Log控制器，负责写log信息
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/28 15:43:40
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage.LogModules
{
    internal class LogControlser
    {
        static object locker = new object();
        #region 构造函数

        public LogControlser()
        {

        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法

        /// <summary>
        /// 写log信息
        /// </summary>
        /// <param name="logStr">log信息</param>
        public static void WriteLog(string logStr)
        {
            //将Log信息写入到本地磁盘
            WriteLogInfoToLocal(logStr);
            //显示Log信息
            if (ShowLogInfoEvent != null)
            {
                ShowLogInfoEvent(logStr);
            }
        }

        /// <summary>
        /// 写Log信息
        /// </summary>
        /// <param name="logStr">log信息</param>
        /// <param name="writeLocal">是否写入到本地磁盘</param>
        public static void WriteLog(string logStr, bool writeLocal)
        {
            if (writeLocal)
            {
                WriteLogInfoToLocal(logStr);
            }
            //显示Log信息
            if (ShowLogInfoEvent != null)
            {
                ShowLogInfoEvent(logStr);
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 将log信息写入到本地磁盘
        /// </summary>
        /// <param name="logInfo"></param>
        private static void WriteLogInfoToLocal(string logInfo)
        {
            lock (locker)
            {
                StreamWriter sw =null;
                try
                {
                    string path = System.Environment.CurrentDirectory;
                    string pro = Path.GetDirectoryName(path);

                    string LogAddress = pro + @"\log";
                    if (!Directory.Exists(LogAddress + "\\PRG"))
                    {
                        Directory.CreateDirectory(LogAddress + "\\PRG");
                    }
                    LogAddress = string.Concat(LogAddress, "\\PRG\\",
                     DateTime.Now.Year, '-', DateTime.Now.Month, '-',
                     DateTime.Now.Day, "_program.log");
                   sw = new StreamWriter(LogAddress, true);
                    sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), logInfo));
                    sw.Close();
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Dispose();
                        sw = null;
                    }
                }
               
            }
        }

        #endregion

        #region 委托

        public delegate void ShowLogInfoEventHandle(string logInfo);


        #endregion

        #region 事件

        /// <summary>
        /// 显示Log信息事件
        /// </summary>
        public static event ShowLogInfoEventHandle ShowLogInfoEvent;

        #endregion
    }
}
