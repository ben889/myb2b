using BS.Components.Data.Entity;
using BS.Components.Data.SQLProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据通用操作类，实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonData<T> where T : class
    {
        /// <summary>
        /// db生产器
        /// </summary>
        public BS.Components.Data.SQLProvider.ISQLFactory sqlfactory;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CommonData()
        {
            string dbtype = "sql";
            if (dbtype.Equals("sql"))
                sqlfactory = new BS.Components.Data.SQLProvider.SQLFactory(Config.SqlConnection);
            else if (dbtype.Equals("access"))
            {
                //isqlfactory = new BS.Components.Data.SQLProvider.AccessFactory(Config.SqlConnection);
            }
        }

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue">key字段值</param>
        /// <param name="customKey">key字段名(可为空)</param>
        /// <param name="customColumns">要查询的字段;*为全部;取指定字段(aaa,bbb);空为取全部</param>
        /// <returns></returns>
        public T GetModel(object keyValue, string customKey, string customColumns)
        {
            return sqlfactory.GetModel<T>(keyValue, customKey, customColumns);
        }

        /// <summary>
        /// 获取表所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetList(int top, string where, string orderby)
        {
            return sqlfactory.GetList<T>(top, where, orderby, null, null);
            //if (m_cacheKey != null)
            //{
            //    var list = Cache.Container.Instance.GetObject<List<T>>(m_cacheKey);
            //    if (list == null)
            //    {
            //        lock (m_cacheLocker)
            //        {
            //            if (list == null)
            //            {
            //                list = sqlFactory.GetList<T>(top, where, null, orderby, null);
            //                Cache.Container.Instance.AddObject(m_cacheKey, list);
            //            }
            //        }
            //    }
            //    return list;
            //}
            //else
            //{
            //    return sqlFactory.GetList<T>(0, null, null, null, null);
            //}
        }
        public List<T> GetList(int top, string where, string orderby, string columns)
        {
            return sqlfactory.GetList<T>(top, where, orderby, null, columns);
        }
        /// <summary>
        /// 向表插入一行数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public int Insert(T t, ReturnTypes types)
        {
            var rel = sqlfactory.Insert<T>(t, types);
            //ClearCacheData();
            return rel;
        }
        /// <summary>
        /// 插入一行数据(带事务)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sqlconnection"></param>
        /// <param name="command"></param>
        /// <param name="trans"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public int Insert(T t, SqlConnection sqlconnection, SqlCommand command, SqlTransaction trans, ReturnTypes types)
        {
            var rel = sqlfactory.Insert<T>(t, sqlconnection, command, trans, types);
            //ClearCacheData();
            return rel;
        }
        public int Insert(string sql, SqlConnection sqlconnection, SqlCommand command, SqlTransaction trans, SqlParameter[] parms, ReturnTypes returnType)
        {
            var rel = sqlfactory.Insert(sql, sqlconnection, command, trans, parms, returnType);
            //ClearCacheData();
            return rel;
        }
        /// <summary>
        /// 向表插入一行数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            return sqlfactory.Update<T>(t, null);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <param name="customColumns">按哪个字段值修改(用于没有自增索引的表)</param>
        /// <returns></returns>
        public int Update(T t, string customColumns)
        {
            return sqlfactory.Update<T>(t, customColumns);
        }
        public int Update(T t, SqlConnection sqlconnection, SqlCommand command, SqlTransaction trans, string customColumns)
        {
            return sqlfactory.Update<T>(t, sqlconnection, command, trans, customColumns);
        }
        public int Update(string sql, SqlConnection sqlconnection, SqlCommand command, SqlTransaction trans, SqlParameter[] parms)
        {
            return sqlfactory.Update(sql, sqlconnection, command, trans, parms);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <param name="customKey">字段名;如为空则按索引删除</param>
        /// <returns></returns>
        public int Delete(object keyValue, string customKey)
        { return sqlfactory.Delete<T>(keyValue, customKey); }
        public int Delete(string where)
        {
            return sqlfactory.Delete<T>(where);
        }
        public int Delete(SqlConnection sqlconnection, SqlCommand command, SqlTransaction trans, string where)
        {
            return sqlfactory.Delete<T>(sqlconnection, command, trans, where);
        }
        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="currentpage"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="columns"></param>
        /// <param name="tablename"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public DataTable GetPager(int pagesize, int currentpage, string where, string orderby, string columns, string tablename, ref int record)
        {
            var list = sqlfactory.GetTablePager(pagesize, currentpage, where, orderby, columns, ref record, null, tablename);
            return list;
        }

        public DataTable GetPager(int pagesize, int currentpage, string where, string orderby, string columns, ref int record)
        {
            var list = sqlfactory.GetTablePager<T>(pagesize, currentpage, where, orderby, columns, ref record, null);
            return list;
        }
        /// <summary>
        /// 调用存储过程分页
        /// </summary>
        /// <param name="WhereClause"></param>
        /// <param name="OrderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalRows"></param>
        /// <param name="StoredProcedure">存储过程名称</param>
        /// <returns></returns>
        public DataTable GetPager(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows, string StoredProcedure)
        {

            SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@WhereClause",SqlDbType.VarChar,2000),
                    new SqlParameter("@OrderBy",SqlDbType.VarChar,2000),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@TotalRows",SqlDbType.Int),
                };
            parms[0].Value = WhereClause;
            parms[1].Value = OrderBy;
            parms[2].Value = PageIndex;
            parms[3].Value = PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTableCollection tables = SQLHelper.DataSet(BS.Components.Data.Config.ConnConfig.getConn, StoredProcedure, CommandType.StoredProcedure, parms).Tables;
            if (tables.Count > 0)
            {
                DataTable dt = tables[0];
                TotalRows = Convert.ToInt32(parms[4].Value != DBNull.Value ? parms[4].Value : 0);
                return dt;
            }
            return null;
        }

        public DataTable GetTable(string sql)
        {
            DataTable dt = sqlfactory.GetTable(sql, CommandType.Text, null);
            return dt;
        }
        /// <summary>
        /// 获得单个值
        /// </summary>
        //public object GetValue(object keyValue, string customKey, string customColumn)
        //{
        //    return sqlFactory.GetExecuteScalarByKey<T>(keyValue, customKey, customColumn);
        //}

        /// <summary>
        /// 获得单个值
        /// </summary>
        //public object GetValue(string customColumn)
        //{
        //    return sqlFactory.GetExecuteScalarByWhere<T>(null, null, null, customColumn);
        //}

        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="column">指定字段</param>
        /// <param name="content">指定字段的值</param>
        //public void Update(string column, object content)
        //{
        //    sqlFactory.Update<T>(new string[] { column }, new object[] { content });
        //    ClearCacheData();
        //}

        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="keyId">主键</param>
        /// <param name="column">指定字段</param>
        /// <param name="content">指定字段的值</param>
        //public void Update(object keyId, string column, object content)
        //{
        //    sqlFactory.Update<T>(keyId, column, content);
        //    ClearCacheData();
        //}

        public int Update(string tablename, string setstr, string where)
        {
            return sqlfactory.NonQuery("update " + tablename + " set " + setstr + " where " + where);
        }



        /// <summary>
        /// 根据主键更新多个字段的值
        /// </summary>
        /// <param name="keyId">主键</param>
        /// <param name="column">指定多个字段</param>
        /// <param name="content">指定多个字段的值</param>
        //public void Update(object keyId, string[] column, object[] content)
        //{
        //    sqlFactory.Update<T>(keyId, column, content);
        //    ClearCacheData();
        //}


        /// <summary>
        /// 根据主键判断是否存在记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool IsExist(string where)
        {
            return sqlfactory.IsExist<T>(where);
        }
    }
}
