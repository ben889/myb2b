using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class member_join_orderDAL : CommonData<member_join_orderInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="payment">支付方式</param>
        /// <param name="status">订单状态</param>
        /// <param name="Amount">订单总额</param>
        /// <param name="transaction_id">交易ID</param>
        /// <param name="Exce_remark">是否异常</param>
        /// <param name="Exce_remark">异常备注</param>
        /// <param name="vip">vip</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public int order_payresult(string orderid, int payment, int status, decimal Amount, string transaction_id, bool isExce, string Exce_remark, int vip, ref string resultMsg)
        {
            //DateTime now = DateTime.Now;
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
                string sql = "update [member_join_order] set payment=@payment,isExce=@isExce,Exce_remark=@Exce_remark,orderstatus=@status,transaction_id=@transaction_id,vip=@vip where orderid=@orderid";
                DateTime rentstart_time = DateTime.Now;
                SqlParameter[] parameters = {
                    new SqlParameter("@payment", SqlDbType.Int) , 
                    new SqlParameter("@isExce", SqlDbType.Bit) ,
                    new SqlParameter("@Exce_remark", SqlDbType.VarChar,300) ,
                    new SqlParameter("@status", SqlDbType.Int) ,
                    new SqlParameter("@transaction_id", SqlDbType.VarChar,50) ,
                    new SqlParameter("@vip", SqlDbType.Int) ,
                    new SqlParameter("@orderid", SqlDbType.VarChar,50) ,
                };
                parameters[0].Value = payment;
                parameters[1].Value = isExce;
                parameters[2].Value = Exce_remark;
                parameters[3].Value = status;
                parameters[4].Value = transaction_id;
                parameters[5].Value = vip;
                parameters[6].Value = orderid;
                int result = Update(sql, con, com, myTran, parameters);
                if (result <= 0)
                    return result;
                if (status == 1)
                {

                    //返提成给用户
                    //string sql3 = "update member set integral=(case when integral is null then 0 else integral end) +@integral where uid=@uid";
                    //com.Parameters.Clear();
                    //SqlParameter[] para3 = {
                    //    new SqlParameter("@integral", SqlDbType.Decimal,50) ,
                    //    new SqlParameter("@uid", SqlDbType.VarChar,50) ,
                    //};
                    //para3[0].Value = integral;
                    //para3[1].Value = uid;
                    //int result3 = Update(sql3, con, com, myTran, para3);
                    //if (result3 <= 0)
                    //{
                    //    myTran.Rollback();
                    //    return 0;
                    //}

                    //========================
                }
                myTran.Commit();
                return result;
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
    }
}
