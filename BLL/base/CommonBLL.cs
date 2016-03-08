using BLL;
using BS.Components.Data.Entity;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace BLL
{
    /// <summary>
    /// 数据通用操作类，实体类继承它
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonBLL<T> where T : class
    {
        //public DAL.CommonData<T> dal;
        ///// <summary>
        ///// 构造函数
        ///// </summary>
        //public CommonData()
        //{
        //    dal = new DAL.CommonData<T>();
        //}
        public static T GetModel(object keyValue)
        {
            return new DAL.CommonData<T>().GetModel(keyValue, null, null);
        }
        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue">key字段值</param>
        /// <param name="customKey">key字段名(可为空)</param>
        /// <param name="customColumns">要查询的字段;*为全部;取指定字段(aaa,bbb);空为取全部</param>
        /// <returns></returns>
        public static T GetModel(object keyValue, string customKey, string customColumns)
        {
            return new DAL.CommonData<T>().GetModel(keyValue, customKey, customColumns);
        }
        /// <summary>
        /// 获取表所有数据
        /// </summary>
        /// <returns></returns>
        public static List<T> GetList(int top, string where, string orderby)
        {
            return new DAL.CommonData<T>().GetList(top, where, orderby);
        }

        /// <summary>
        /// 向表插入一行数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public static int Insert(T t, ReturnTypes returnType)
        {
            var rel = new DAL.CommonData<T>().Insert(t, returnType);
            return rel;
        }


        public static int Update(T t)
        {
            return new DAL.CommonData<T>().Update(t);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <param name="customColumns">按哪个字段值修改(用于没有自增索引的表)</param>
        /// <returns></returns>
        public static int Update(T t, string customColumns)
        {
            return new DAL.CommonData<T>().Update(t, customColumns);
        }
        public static int Update(string tablename, string setstr, string where)
        {
            int result = new DAL.CommonData<T>().Update(tablename, setstr, where);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <param name="customKey">字段名;如为空则按索引删除</param>
        /// <returns></returns>
        public static int Delete(object keyValue, string customKey)
        { return new DAL.CommonData<T>().Delete(keyValue, customKey); }
        public static int Delete(string where)
        {
            return new DAL.CommonData<T>().Delete(where);
        }

        public static DataTable GetTable(string sqlText)
        {
            var list = new DAL.CommonData<T>().GetTable(sqlText);
            return list;
        }
        public static DataTable GetPager(int pagesize, int currentpage, string where, string orderby, string columns, string tablename, ref int record)
        {
            var list = new DAL.CommonData<T>().GetPager(pagesize, currentpage, where, orderby, columns, tablename, ref record);
            return list;
        }
        public static DataTable GetPager(int pagesize, int currentpage, string where, string orderby, string columns, ref int record)
        {
            var list = new DAL.CommonData<T>().GetPager(pagesize, currentpage, where, orderby, columns, ref record);
            return list;
        }
        public static DataTable GetPager(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows, string StoredProcedure)
        {
            var list = new DAL.CommonData<T>().GetPager(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows, StoredProcedure);
            return list;
        }

        

        

        /// <summary>
        /// 根据主键判断是否存在记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static bool IsExist(string where)
        {
            bool result = new DAL.CommonData<T>().IsExist(where);
            return result;
        }
    }
}
