using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


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
    public class SqlServerHelper : IDBHelper
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
        /// 测试数据是否能够连接的上
        /// </summary>
        /// <returns></returns>
        public bool TestCanLink()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_linkStr))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        #region 添加数据

        /// <summary>
        /// 向数据库内中写入数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldNames">所要写的字段名集合</param>
        /// <param name="fieldValues">对应字段的值得集合</param>
        /// <returns></returns>
        public bool WriteDataToDB(string tableName, string[] fieldNames, string[] fieldValues)
        {
            string columnString = string.Join(",", fieldNames);
            for (int i = 0; i < fieldValues.Length; i++)
            {
                StringBuilder sb = new StringBuilder("'");
                sb.Append(fieldValues[i]).Append("'");
                fieldValues[i] = sb.ToString();
            }
            string valueString = string.Join(",", @fieldValues);
            string sqlStr = string.Format("insert into [{0}] ({1})values({2})", tableName, columnString, valueString);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }

        }
        #endregion

        #region 查询数据
        /// <summary>
        /// 通过字段值获取数据库中匹配的行数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="fieldName">字段值</param>
        /// <returns></returns>
        public DataTable GetRowsbyFieldValue(string tableName, string fieldName, string fieldValue)
        {
            //sql字符串拼接
            string sqlStr = string.Format("select * from [{0}] where {1}={2}", tableName, fieldName, fieldValue);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                DataTable dataTable = new DataTable();
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
                return dataTable;
            }
        }

        /// <summary>
        /// 查询某一行某一列的值
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="TableName">表名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="resultFieldName">需要查询的字段</param>
        /// <returns></returns>
        public T Query<T>(string TableName, string fieldName, string fieldValue, string resultFieldName)
        {
            T resultValue = default(T);
            string sqlStr = string.Format("Select * from [{0}] where {1} = {2}", TableName, fieldName, fieldValue);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader[resultFieldName] is DBNull)
                    {
                        resultValue = default(T);
                    }
                    else
                    {
                        resultValue = (T)sqlDataReader[resultFieldName];
                    }
                }
            }
            return resultValue;
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
            string sqlStr = string.Format("Select * from [{0}] where {1}={0}", tableName, fieldName, fieldValue);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int rowCount = 0;
                while (sqlDataReader.Read())
                {
                    rowCount++;
                    if (rowCount >= 2) return true;
                }
                return rowCount > 1;
            }
        }

        /// <summary>
        /// 按时间查询最早的一项的某个字段的值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <param name="resultFieldName">需要查询字段名</param>
        /// <returns></returns>
        public T QueryByTimeTheEarliestFieldValue<T>(string tableName, string timeFieldName, string resultFieldName)
        {
            string sqlStr = string.Format("select Top 1 {0} from [{1}] order by {2}", resultFieldName, tableName, timeFieldName);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader[resultFieldName] is DBNull)
                        return default(T);
                    else
                        return (T)sqlDataReader[resultFieldName];
                }
                return default(T);
            }
        }

        /// <summary>
        /// 查询最早的一条数据，返回SqlDataReader
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <returns></returns>
        public SqlDataReader QueryByTimeTheEarliestData(string tableName, string timeFieldName)
        {
            string sqlStr = string.Format("select Top 1 * from [{0}] order by {1}", tableName, timeFieldName);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
        }

        /// <summary>
        /// 按时间查询最晚的一项的某个字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <param name="resultFieldName">查询字段名</param>
        /// <returns></returns>
        public T QueryByTimeTheLatestFieldValue<T>(string tableName, string timeFieldName, string resultFieldName)
        {
            string sqlStr = string.Format("select Top 1 {0} from [{1}] order by {2} desc", resultFieldName, tableName, timeFieldName);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader[resultFieldName] is DBNull)
                        return default(T);
                    else
                        return (T)sqlDataReader[resultFieldName];
                }
                return default(T);
            }
        }

        /// <summary>
        /// 查询最晚的一条数据，返回SqlDataReader
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <returns></returns>
        public SqlDataReader QueryByTimeTheLatestData(string tableName, string timeFieldName)
        {
            string sqlStr = string.Format("select Top 1 * from [{0}] order by {1} desc", tableName, timeFieldName);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
        }

        /// <summary>
        /// 按时间从打到小查询，返回数据库中所有数据记录
        /// </summary>
        /// <param name="tableName">表明名</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <returns></returns>
        public DataTable QuerybyTime(string tableName, string timeFieldName)
        {
            string sqlStr = string.Format("Select * from [{0}] order by {1}", tableName, timeFieldName);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                DataTable dataTable = new DataTable();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
                return dataTable;
            }
        }

        /// <summary>
        /// 按时间查询，查询某一段时间段内的数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable QueryBetweentime(string tableName, string timeFieldName, string beginTime, string endTime)
        {
            string sqlStr = string.Format("Select * from [{0}] where {1} between '{2}' and '{3}'",
                tableName, timeFieldName, beginTime, endTime);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                DataTable table = new DataTable();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                table.Load(sqlDataReader);
                return table;

            }
        }

        /// <summary>
        /// 查询某一时间之前的所有数据
        /// </summary>
        /// <param name="tableName">表名成</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public DataTable QueryByBeforeTime(string tableName, string timeFieldName, string time)
        {
            string sqlStr = string.Format("select * from [{0}] where {1} < '{2}'", tableName, timeFieldName, time);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                DataTable table = new DataTable();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                table.Load(sqlDataReader);
                return table;
            }
        }

        /// <summary>
        /// 查询大于某一时间的某个字段的所有数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="timeFieldName">时间字段名</param>
        /// <param name="time">时间</param>
        /// <param name="queryFieldName">所要查询的字段名</param>
        /// <returns></returns>
        public List<string> QueryByTimeBeforeTimeOneFieldAllValue(string tableName, string timeFieldName, string time, string queryFieldName)
        {
            string sqlStr = string.Format("Select * from [{0}] where {1} < '{2}'", tableName, timeFieldName, @time);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> valList = new List<string>();
                while (reader.Read())
                {
                    if (!(reader[queryFieldName] is DBNull))
                    {
                        valList.Add(reader[queryFieldName].ToString());
                    }
                }
                return valList;
            }
        }

        #endregion

        #region 修改数据

        /// <summary>
        /// 更新多个字段的值
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">指定字段名</param>
        /// <param name="fieldValue">指定字段值</param>
        /// <param name="updateFieldNames">需要更新的字段名集合</param>
        /// <param name="updateFieldValues">需要更新的字段值集合</param>
        /// <returns></returns>
        public bool UpdateFieldsValues(string tableName, string fieldName, string fieldValue, string[] updateFieldNames, string[] updateFieldValues)
        {
            string[] updateString = new string[updateFieldNames.Length];
            for (int i = 0; i < updateFieldNames.Length; i++)
            {
                StringBuilder stringBuilder = new StringBuilder(updateFieldNames[i]);
                stringBuilder.Append("=").Append(updateFieldValues[i]);
                updateString[i] = stringBuilder.ToString();
            }
            string sqlUpdateString = string.Join(",", updateString);
            string sqlStr = string.Format("Update [{0}] set {1} where {2}={3}", tableName, sqlUpdateString, fieldName, fieldValue);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">指定字段名</param>
        /// <param name="fieldValue">指定字段值</param>
        /// <param name="updataFieldName">要更新的字段名</param>
        /// <param name="updataFieldvalue">要更新字段的值</param>
        /// <returns></returns>
        public bool UpdateFieldvalue(string tableName, string fieldName, string fieldValue, string updateFieldName, string updateFieldvalue)
        {
            string sqlStr = string.Format("update [{0}] set {1}={2} where {3}={4}", tableName, updateFieldName, updateFieldvalue, fieldName, fieldValue);
            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        #endregion

        #region 删除数据

        /// <summary>
        /// 删除数据库中某一行数据
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>

        public bool DeleteRowData(string tableName, string fieldName, string fieldValue)
        {
            string sqlStr = string.Format("delete from [{0}] where {1} = '{2}'", tableName, fieldName, @fieldValue);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// 删除整个表格中所有数据
        /// </summary>
        /// <param name="tableName">需要删除数据的表名称</param>
        /// <returns></returns>
        public bool DeleteAllTableData(string tableName)
        {
            string sqlStr = string.Format("Truncate Table {0}", tableName);

            using (SqlConnection conn = new SqlConnection(_linkStr))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        #endregion


        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
