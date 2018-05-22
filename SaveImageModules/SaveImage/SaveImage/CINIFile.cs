using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;


//**********************************************
//文件名：CINIFile
//命名空间：HalAcquisitionTool
//CLR版本：4.0.30319.42000
//内容：读取INI文件
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/4/2 17:08:15
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace SaveImage
{
    /// <summary>
    /// 读写INI文件类
    /// </summary>
    internal class CINIFile
    {
        private string iniFilePath = string.Empty;

        #region 构造函数

        public CINIFile(string path)
        {
            iniFilePath = path;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置ini文件路径
        /// </summary>
        public string FilePath
        {
            get { return iniFilePath; }
            set { iniFilePath = value; }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 读取INI文件中的内容（泛型方法）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m_Section"></param>
        /// <param name="m_AppName"></param>
        /// <returns></returns>
        public T Read<T>(string m_Section, string m_AppName)
        {
            try
            {
                if (typeof(T) == typeof(bool))
                {
                    string strResult = GetINI(m_Section, m_AppName, "", iniFilePath);
                    if (string.IsNullOrEmpty(strResult))
                    {
                        return default(T);
                    }
                    else
                    {
                        if (strResult == "true" || strResult == "True" || strResult == "TRUE")
                            return (T)Convert.ChangeType(true, typeof(T));
                        else
                            return (T)Convert.ChangeType(false, typeof(T));
                    }

                }
                else
                {
                    string result = GetINI(m_Section, m_AppName, "", iniFilePath);
                    if (string.IsNullOrEmpty(result))
                    {
                        return default(T);
                    }
                    else
                        return (T)Convert.ChangeType(result, typeof(T));
                }

            }
            catch (Exception ex)//抛出异常
            {

                throw ex;
            }

        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="m_Section"></param>
        /// <param name="m_AppName"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public object Read(string m_Section, string m_AppName, ValueType valueType)
        {
            try
            {
                switch (valueType)
                {
                    case ValueType._Integer:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(int));
                    case ValueType._Int16:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(Int16));

                    case ValueType._Int64:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(Int64));

                    case ValueType._UInteger:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(uint));

                    case ValueType._Double:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(double));

                    case ValueType._Long:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(long));

                    case ValueType._Short:
                        return Convert.ChangeType(GetINI(m_Section, m_AppName, "", iniFilePath), typeof(short));

                    case ValueType._String:
                        return GetINI(m_Section, m_AppName, "", iniFilePath);

                    case ValueType._Boolean:
                        string strResult = GetINI(m_Section, m_AppName, "", iniFilePath);
                        if (strResult == "true" || strResult == "True" || strResult == "TRUE")
                            return true;
                        else
                            return false;

                    default:
                        return null;
                }
            }
            catch (Exception ex)//抛出异常
            {

                throw ex;
            }

        }

        /// <summary>
        /// 写INI文件（泛型方法）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m_Section"></param>
        /// <param name="m_AppName"></param>
        /// <param name="m_value"></param>
        /// <returns></returns>
        public bool Write<T>(string m_Section, string m_AppName, T m_value)
        {
            try
            {
                if (typeof(T) == typeof(string))
                {
                    string _value = Convert.ToString(m_value);
                    if (string.IsNullOrEmpty(_value))
                        _value = " ";
                    WriteINI(m_Section, m_AppName, _value, iniFilePath);
                }
                else
                {
                    if (m_value != null)
                        WriteINI(m_Section, m_AppName, m_value.ToString(), iniFilePath);
                }

                return true;
            }
            catch (Exception ex) //抛出异常
            {
                throw ex;
            }
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="m_section"></param>
        /// <param name="m_AppName"></param>
        /// <param name="m_value"></param>
        /// <returns></returns>
        public bool Write(string m_section, string m_AppName, string m_value)
        {
            try
            {
                WriteINI(m_section, m_AppName, m_value.ToString(), iniFilePath);
                return true;
            }
            catch (Exception ex)    //抛出异常
            {

                throw ex;
            }

        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 读取INI文件中的内容
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="AppName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private string GetINI(string Section, string AppName, string lpDefault, string FileName)
        {
            StringBuilder strBulider = new StringBuilder(256);
            GetPrivateProfileStringA(Section, AppName, lpDefault, strBulider, 256, FileName);
            return strBulider.ToString();
        }
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="AppName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private long WriteINI(string Section, string AppName, string lpDefault, string FileName)
        {
            return WritePrivateProfileStringA(Section, AppName, lpDefault, FileName);
        }




        /// <summary>
        /// 读ini API函数
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileStringA(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 写ini API函数
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpString"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileStringA(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }

    public enum ValueType
    {
        _Integer,
        _Int16,
        _Int64,
        _UInteger,
        _Double,
        _Long,
        _Short,
        _String,
        _Boolean,
    }
}
