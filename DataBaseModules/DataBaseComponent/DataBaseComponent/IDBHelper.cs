using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

/// <summary>
/// 数据库接口
/// </summary>
interface IDBHelper
{

    #region 属性
    /// <summary>
    /// 获取或设置数据库链接字符串
    /// </summary>
    string LinkString { get; set; }

    #endregion


    #region 添加数据

    /// <summary>
    /// 向数据库内中写入数据
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="fieldNames">所要写的字段名集合</param>
    /// <param name="fieldValues">对应字段的值得集合</param>
    /// <returns></returns>
    bool WriteDataToDB(string tableName, string[] fieldNames, string[] fieldValues);

    #endregion

    #region 查询数据
    /// <summary>
    /// 查询某一字段是否有重复的值
    /// </summary>
    /// <param name="tableName">表格名称</param>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldValue">字段值</param>
    /// <returns></returns>
    bool QueryRepeat(string tableName, string fieldName, string fieldValue);

   

    /// <summary>
    /// 查询某一行某一列的值
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    /// <param name="TableName">表名称</param>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldValue">字段值</param>
    /// <param name="resultFieldName">需要查询的字段</param>
    /// <returns></returns>
    T Query<T>(string TableName,string fieldName,string fieldValue,string resultFieldName);

    /// <summary>
    /// 通过字段值获取数据库中匹配的行数据
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldValue">字段值</param>
    /// <returns></returns>
    DataTable GetRowsbyFieldValue(string tableName,string fieldName,string fieldValue);

    /// <summary>
    /// 按时间查询最早的一项的某个字段的值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tableName">表名称</param>
    /// <param name="timeFieldName">时间字段名</param>
    /// <param name="resultFieldName">查询字段名</param>
    /// <returns></returns>
    T QueryByTimeTheEarliestFieldValue<T>(string tableName,string timeFieldName,string resultFieldName);

    /// <summary>
    /// 查询最早的一条数据，返回SqlDataReader
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="timeFieldName">时间字段名</param>
    /// <returns></returns>
    SqlDataReader QueryByTimeTheEarliestData(string tableName,string timeFieldName);


    /// <summary>
    /// 按时间查询最晚的一项的某个字段的值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tableName">表名称</param>
    /// <param name="timeFieldName">时间字段名</param>
    /// <param name="resultFieldName">查询字段名</param>
    /// <returns></returns>
    T QueryByTimeTheLatestFieldValue<T>(string tableName, string timeFieldName, string resultFieldName);

    /// <summary>
    /// 查询最晚的一条数据，返回SqlDataReader
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="timeFieldName">时间字段名</param>
    /// <returns></returns>
    SqlDataReader QueryByTimeTheLatestData(string tableName, string timeFieldName);

    /// <summary>
    /// 按时间查询，返回数据库中所有数据记录
    /// </summary>
    /// <param name="tableName">表明名</param>
    /// <param name="timeFieldName">时间字段名</param>
    /// <returns></returns>
    DataTable QuerybyTime(string tableName, string timeFieldName);

    #endregion

    #region 更新数据

    /// <summary>
    /// 更新指定字段的值
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="fieldName">指定字段名</param>
    /// <param name="fieldValue">指定字段值</param>
    /// <param name="updateFieldName">要更新的字段名</param>
    /// <param name="updateFieldvalue">要更新字段的值</param>
    /// <returns></returns>
    bool UpdateFieldvalue(string tableName,string fieldName,string fieldValue,string updateFieldName, string updateFieldvalue);

    /// <summary>
    /// 更新多个字段的值
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="fieldName">指定字段名</param>
    /// <param name="fieldValue">指定字段值</param>
    /// <param name="updateFieldNames">需要更新的字段名集合</param>
    /// <param name="updateFieldValues">需要更新的字段值集合</param>
    /// <returns></returns>
    bool UpdateFieldsValues(string tableName,string fieldName,string fieldValue,string[] updateFieldNames,string[] updateFieldValues);


    #endregion

    #region 删除数据
    /// <summary>
    /// 删除数据库中某一行数据
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldValue">字段值</param>
    /// <returns></returns>
    bool DeleteRowData(string tableName,string fieldName,string fieldValue);

    /// <summary>
    /// 删除整个表格中所有数据
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    bool DeleteAllTableData(string tableName);
    #endregion



}
