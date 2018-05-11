using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


//**********************************************
//文件名：SqlServerHelper
//命名空间：DataBaseComponent.DB.SqlServer
//CLR版本：4.0.30319.42000
//内容：
//功能：SqlServer数据库类，负责与SqlServer数据库交互
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2018/5/11 16:37:41
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace DataBaseComponent.DB.SqlServer
{

    /// <summary>
    /// SqlServer数据库类
    /// </summary>
  public  class SqlServerHelper:IDBHelper
    {
        private string _linkStr;


        #region 构造函数
        /// <summary>
        /// SqlServer构造函数
        /// </summary>
        /// <param name="m_LinkString"></param>
        public SqlServerHelper(string m_LinkString)
        {
            _linkStr = m_LinkString;
        }



        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置数据库链接字符串
        /// </summary>
       public string LinkString
        {
            get { return _linkStr; }
            set { _linkStr = value; }
        }


        #endregion

        #region 公共方法

        /// <summary>
        /// 删除数据库中某一行数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>

        public bool DeleteRowData(string tableName, string fieldName, string fieldValue)
        {
            string sqlStr = string.Format("delete form [{0}] where {1}= {2}", tableName, fieldName, fieldValue);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr,conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }

        }

        /// <summary>
        /// 获取某一行所有数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="fieldName">字段值</param>
        /// <returns></returns>
        public DataTable GetOneRowAllValue(string tableName, string FieldName, string fieldName)
        {
            string sqlStr = string.Format("");
        }

        /// <summary>
        /// 查询某一行某一列的值
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="TableName">表名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="resultFieldName">需要查询的字段</param>
        /// <param name="resultValue">需要查询字段的值</param>
        /// <returns></returns>
        public T Query<T>(string TableName, string fieldName, string fieldValue, string resultFieldName, T resultValue)
        {
           
        }
        /// <summary>
        /// 查询某一字段是否有重复的值
        /// </summary>
        /// <param name="tableName">表格名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>
        public bool QueryRepeat(string tableName, string fieldName, string fieldValue)
        {
           
        }

        /// <summary>
        /// 向数据库内中写入数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">所要写的字段名集合</param>
        /// <param name="fieldValues">对应字段的值得集合</param>
        public void WriteDataToDB(string tableName, string[] fieldName, string[] fieldValues)
        {
          
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
