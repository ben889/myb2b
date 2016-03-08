using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using BS.Components.Data.SQLProvider;

namespace DAL
{
    public class publicDAL
    {
        public int GetProvinceIDByProvinceName(string ProvinceName)
        {

            try
            {
                string sql = "select ProvinceID from Province WHERE [Province] like '%" + ProvinceName + "%'";

                //SqlParameter[] paras = new SqlParameter[]{
                //    new SqlParameter("@ProvinceName",SqlDbType),
                //};
                //paras[0].Value = ProvinceName;
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, null);
                return Convert.ToInt32(obj);
                // return excrows;
            }
            catch
            { }
            return 0;
        }

        public int GetCityIDByCityName(string CityName)
        {

            try
            {
                string sql = "select CityID from City WHERE [City] like '%" + CityName + "%'";

                //SqlParameter[] paras = new SqlParameter[]{
                //    new SqlParameter("@ProvinceName",SqlDbType),
                //};
                //paras[0].Value = ProvinceName;
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, null);
                return Convert.ToInt32(obj);
                // return excrows;
            }
            catch
            { }
            return 0;
        }


        /// <summary>
        /// 根据条件更新数据库表的内容
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="SetContent">更新内容</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public int Update(string TableName, string SetContent, string strWhere)
        {
            string sql = "update " + TableName + " set " + SetContent + " where " + strWhere;
            int result = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection, sql, CommandType.Text);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(string TableName, string where)
        {
            try
            {
                string sql = "select count(1) from " + TableName;
                if (where.Trim().Length > 0)
                    sql = sql + " where " + where;
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text);
                return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            }
            catch { }
            return -1;
        }

        public DataTable GetDt(string table, int Top, string strWhere, string filedOrder)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" * ");
                strSql.Append(" FROM " + table);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection, strSql.ToString(), CommandType.Text);
                return dt;
            }
            catch { }
            return null;
        }
    }
}
