using System;
using System.Collections.Generic;
using System.Data;
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
    /// <param name="fieldName">所要写的字段名集合</param>
    /// <param name="fieldValues">对应字段的值得集合</param>
    void WriteDataToDB(string tableName, string[] fieldName, string[] fieldValues);

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
    /// <param name="resultValue">需要查询字段的值</param>
    /// <returns></returns>
    T Query<T>(string TableName,string fieldName,string fieldValue,string resultFieldName,T resultValue );

    /// <summary>
    /// 获取某一行所有数据
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="FieldName">字段名</param>
    /// <param name="fieldName">字段值</param>
    /// <returns></returns>
    DataTable GetOneRowAllValue(string tableName,string FieldName,string fieldName);

    #endregion

    #region 修改数据


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

    #endregion



}
