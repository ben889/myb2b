using BS.Components.Data.Entity;
using BS.Components.Data.SQLProvider;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class goodsExchDAL : CommonData<goodsExchInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns>O.*,D.orderno,D.goods_count,G.GoodsName,G.Img,G.Description</returns>
        public DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" O.*,D.orderno,D.goods_count,G.GoodsName,G.Img,G.Description,G.enddate,G.startdate,O.ExchTime,G.Price,O.status");
                strSql.Append(" FROM goodsExch O ");
                strSql.Append(" left join g_order D ON D.orderid=O.orderid ");
                strSql.Append(" left join goods G ON G.goodsid=O.goodsid ");
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

        public int getcount(string where)
        {
            string sql = "select count(1) from goodsExch";
            if (where.Trim().Length > 0)
                sql = sql + " where " + where;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }

        /// <summary>
        /// 用户兑换
        /// </summary>
        /// <param name="ExchId"></param>
        /// <param name="goodsid">订单对应的商品</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public int exch(int ExchId, int goodsid, ref string resultMsg)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Config.SqlConnection;
            con.Open();
            // 启动一个事务。 
            SqlTransaction trans = con.BeginTransaction();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.Transaction = trans;
            try
            {
                string ExchTime = DateTime.Now.ToString();
                string sql = "update goodsExch set status=1,ExchTime=@ExchTime where ExchId=@ExchId";
                SqlParameter[] parameters = {
                    new SqlParameter("@ExchId", SqlDbType.Int, 4),
                    new SqlParameter("@ExchTime", SqlDbType.VarChar, 50),
                };
                parameters[0].Value = ExchId;
                parameters[1].Value = ExchTime;
                int result = Update(sql, con, com, trans, parameters);
                if (result <= 0)
                {
                    trans.Rollback();
                    return 0;
                }

                //string sql2 = "update goods set exchcount=exchcount+1 where goodsid=@goodsid";
                //SqlParameter[] parameters2 = {
                //    new SqlParameter("@goodsid", SqlDbType.Int, 4)
                //};
                //parameters2[0].Value = goodsid;
                //int result2 = Update(sql2, con, com, trans, parameters2);
                //if (result2 <= 0)
                //{
                //    trans.Rollback();
                //    return 0;
                //}
                trans.Commit();
                return result;
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message;
                trans.Rollback();
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
            return 0;
        }
    }
}
