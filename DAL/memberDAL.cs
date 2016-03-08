using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using Model;
using BS.Components.Data.SQLProvider;
using BS.Components.Data.Entity;
namespace DAL
{
    //member 
    public class memberDAL : CommonData<memberInfo>
    {

        #region 添加(事务)
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="minfo"></param>
        /// <param name="balance"></param>
        /// <param name="CompanyID"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public long AddTran(memberInfo minfo, ref string resultMsg)
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
                //long uid = Add(com, minfo, ref resultMsg);
                long uid = Insert(minfo, con, com, myTran, ReturnTypes.Identity);
                if (uid <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }
                myTran.Commit();
                return uid;
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


        #endregion

        public int Updatepassword(long uid, string password, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update member set ");

                strSql.Append(" password = @password ");
                strSql.Append(" where uid=@uid ");

                SqlParameter[] parameters = {
					            new SqlParameter("@uid", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@password", SqlDbType.NVarChar,50) ,	 
	            };

                parameters[0].Value = uid;
                parameters[1].Value = password;
                int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters);

                return rows;
            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;
        }


        public memberInfo GetModel(long uid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from member ");
                strSql.Append(" where uid=@uid");
                SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
                parameters[0].Value = uid;

                memberInfo info = new memberInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        //info = GetInfoByDr(dr);
                        info = BS.Components.Data.Entity.EntityHelper.GetDataReaderObject<memberInfo>("*", dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }
        public memberInfo getModel(string uname, string password)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from member ");
                strSql.Append(" where uname=@uname and password=@password");
                SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,80),
                    new SqlParameter("@password", SqlDbType.VarChar,80)
			    };
                parameters[0].Value = uname;
                parameters[1].Value = password;
                memberInfo info = new memberInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        //info = GetInfoByDr(dr);
                        info = BS.Components.Data.Entity.EntityHelper.GetDataReaderObject<memberInfo>("*", dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }

        public int Getidbyuno(string uno)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select uid  ");
                strSql.Append("  from member ");
                strSql.Append(" where uno=@uno");
                SqlParameter[] parameters = {
					new SqlParameter("@uno", SqlDbType.VarChar,80),
			    };
                parameters[0].Value = uno;
                object obj = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters);
                return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            }
            catch { }
            return 0;
        }
        public int Getidbywhere(string where)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select uid  ");
                strSql.Append("  from member ");
                if (where.Trim().Length > 0)
                {
                    strSql.Append(" where " + where);
                }
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, strSql.ToString(), CommandType.Text);
                return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            }
            catch { }
            return 0;
        }
        /// <summary>
        /// 查会员余额
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public decimal Getbalance(long uid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select balance  ");
                strSql.Append("  from member ");
                strSql.Append(" where uid=@uid");
                SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			    };
                parameters[0].Value = uid;

                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters);
                return obj != DBNull.Value && obj != null ? Convert.ToDecimal(obj) : 0;
            }
            catch { }
            return -1;
        }


        public DataTable GetPagemember(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            try
            {
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@WhereClause",SqlDbType.VarChar,2000),
                    new SqlParameter("@OrderBy",SqlDbType.VarChar,2000),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@TotalRows",SqlDbType.Int),
                };
                paras[0].Value = WhereClause;
                paras[1].Value = OrderBy;
                paras[2].Value = PageIndex;
                paras[3].Value = PageSize;
                paras[4].Direction = ParameterDirection.Output;
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection, "member_GetPagemember", CommandType.StoredProcedure, paras);
                TotalRows = Convert.ToInt32(paras[4].Value != DBNull.Value ? paras[4].Value : 0);
                return dt;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int Getutype(long uid)
        {
            string sql = "select utype from member where uid=@uid";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@uid",SqlDbType.Int),
            };
            paras[0].Value = uid;
            object obj_utype = BS.Components.Data.SQLProvider.SQLHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, paras);
            int utype = obj_utype != null && obj_utype != DBNull.Value ? Convert.ToInt32(obj_utype) : -1;
            return utype;
        }

        public List<long> Getuidlist(string where)
        {
            List<long> listid = new List<long>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select uid  ");
                strSql.Append("  from member ");
                if (where.Trim().Length > 0)
                {
                    strSql.Append(" where " + where);
                }
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text))
                {
                    while (dr.Read())
                    {
                        long uid = int.Parse(dr["uid"] != DBNull.Value ? dr["uid"].ToString() : "0");
                        listid.Add(uid);
                    }
                }
            }
            catch { }
            return listid;
        }

        #region 收支
        /// <summary>
        /// 收支
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="amount">提成金额</param>
        /// <param name="balance">帐号可用余额</param>
        /// <param name="remark"></param>
        /// <param name="way">1增加2减少</param>
        /// <param name="resultmsg"></param>
        /// <returns></returns>
        public int member_cash(long uid, decimal amount, decimal balance, string remark, int way, ref string resultmsg)
        {
            //if (arruid.Length != 3)
            //{
            //    resultmsg = "返回拥金不等于3级";
            //    return 0;
            //}
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
                int result = cash(con, com, myTran, uid, amount, ref resultmsg);
                if (result <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }
                member_CashRecordInfo rinfo = new member_CashRecordInfo();
                rinfo.uid = uid;
                rinfo.way = way;
                rinfo.Reamrk = remark;
                rinfo.balance = balance;
                rinfo.Amount = amount;
                rinfo.CreateTime = DateTime.Now;
                int cr_result = new member_CashRecordDAL().Insert(rinfo, con, com, myTran, ReturnTypes.Identity);
                if (cr_result <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }
                myTran.Commit();
                return result;
            }
            catch (Exception exc)
            {
                resultmsg = exc.Message;
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
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="command"></param>
        /// <param name="trans"></param>
        /// <param name="companyid"></param>
        /// <param name="uid"></param>
        /// <param name="amount">发生金额</param>
        /// <param name="resultmsg"></param>
        /// <returns></returns>
        public int cash(SqlConnection con, SqlCommand com, SqlTransaction myTran
            , long uid, decimal amount, ref string resultmsg)
        {
            com.Parameters.Clear();
            string sql_cash = "update member set Balance=(case when Balance is null then 0 else Balance end)+@amount where uid=@uid";
            SqlParameter[] parms = {
                        new SqlParameter("@amount", SqlDbType.Decimal,18) , 
                        new SqlParameter("@uid", SqlDbType.BigInt) , 
                    };
            parms[0].Value = amount;
            parms[1].Value = uid;
            int row = BS.Components.Data.SQLProvider.SQLHelper.NonQuery(sql_cash, con, com, myTran, CommandType.Text, parms);
            if (row <= 0)
            {
                myTran.Rollback();
                return 0;
            }
            return row;
        }
        #endregion
    }
}

