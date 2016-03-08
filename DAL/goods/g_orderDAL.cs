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
    public class g_orderDAL : CommonData<g_orderInfo>
    {
        public int add(g_orderInfo g_orderinfo, List<goodsExchInfo> goodsExchs, ref string resultMsg)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Config.SqlConnection;
            con.Open();
            // 启动一个事务。 
            SqlTransaction myTran = con.BeginTransaction();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.Transaction = myTran;
            try
            {
                int orderid = Insert(g_orderinfo, con, com, myTran, ReturnTypes.Identity);
                if (orderid <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }

                if (goodsExchs != null && goodsExchs.Count > 0)
                {
                    foreach (goodsExchInfo goodsExchinfo in goodsExchs)
                    {
                        com.Parameters.Clear();
                        goodsExchinfo.orderid = orderid;
                        int seller_orderid = new CommonData<goodsExchInfo>().Insert(goodsExchinfo, con, com, myTran, ReturnTypes.Identity);
                        if (seller_orderid <= 0)
                        {
                            myTran.Rollback();
                            return 0;
                        }
                    }
                }
                myTran.Commit();
                return orderid;
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message;
                myTran.Rollback();
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
            return 0;
        }
        /// <summary>
        /// 查用户已购的数量
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public int getcount(long uid, int goodsid)
        {
            string sql = "select SUM(goods_count) from g_order where uid=@uid and goodsid=@goodsid";
            SqlParameter[] parameters = {
				new SqlParameter("@uid", SqlDbType.Int,4) ,            
	            new SqlParameter("@goodsid", SqlDbType.Int,4)           
	        };

            parameters[0].Value = uid;
            parameters[1].Value = goodsid;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }
        public int getcount(string where)
        {
            string sql = "select SUM(goods_count) from g_order";
            if (where.Trim().Length > 0)
                sql = sql + " where " + where;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }


    }
}
