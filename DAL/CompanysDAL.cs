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
    //Companys
    public class CompanysDAL : CommonData<CompanysInfo>
    {

        /// <summary>
        /// 更新余额
        /// </summary>
        /// <param name="com"></param>
        /// <param name="totalamount"></param>
        /// <param name="CompanyID"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public int updatetotalamount(SqlCommand com, decimal totalamount, int CompanyID, ref string resultMsg)
        {
            try
            {
                string sql = "update Companys set totalamount=ISNULL(totalamount,0)+@totalamount where CompanyID=@CompanyID";

                com.Parameters.Clear();
                com.Parameters.Add("@totalamount", SqlDbType.Money, 8);
                com.Parameters.Add("@CompanyID", SqlDbType.Int, 4);



                com.Parameters[0].Value = totalamount;
                com.Parameters[1].Value = CompanyID;

                com.CommandText = sql;
                com.CommandType = CommandType.Text;
                int result = com.ExecuteNonQuery();
                return result;

            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;

        }

        public int updatetotalamount(decimal totalamount, int CompanyID, ref string resultMsg)
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
                int result = updatetotalamount(com, totalamount, CompanyID, ref resultMsg);
                if (result <= 0)
                {
                    myTran.Rollback();
                    return result;
                }
                Companys_costlogInfo cloginfo = new Companys_costlogInfo();
                cloginfo.userid = 0;
                cloginfo.companyid = CompanyID;
                cloginfo.amount = totalamount;
                cloginfo.description = "充值";
                cloginfo.createtime = DateTime.Now;
                string resultstr = "";
                int addlog = new Companys_costlogDAL().Add(cloginfo, ref resultstr);
                if (addlog <= 0)
                {
                    myTran.Rollback();
                    return 0;
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

        

        public int Getid(int CompanyID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select CompanyID  ");
                strSql.Append("  from Companys ");
                strSql.Append(" where CompanyID=@CompanyID");
                SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
			};
                parameters[0].Value = CompanyID;

                CompanysInfo info = new CompanysInfo();
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
                return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            }
            catch { }
            return 0;
        }
        //public CompanysInfo GetModel(string where)
        //{
        //    try
        //    {
        //        StringBuilder strSql = new StringBuilder();
        //        strSql.Append("select *  ");
        //        strSql.Append("  from Companys ");
        //        if (where.Trim().Length>0)
        //            strSql.Append(" where " + where);
        //        CompanysInfo info = new CompanysInfo();
        //        using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text))
        //        {
        //            if (dr.Read())
        //            {
        //                info = GetInfoByDr(dr);
        //            }
        //        }
        //        return info;
        //    }
        //    catch { }
        //    return null;
        //}
        public int Getid(string domain, string where)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select CompanyID  ");
                strSql.Append("  from Companys ");
                strSql.Append(" where domain=@domain ");
                if (where.Trim().Length > 0)
                {
                    strSql.Append(" and " + where);
                }
                SqlParameter[] parameters = {
					new SqlParameter("@domain", SqlDbType.VarChar,80)
			};
                parameters[0].Value = domain;

                CompanysInfo info = new CompanysInfo();
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
                return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// 查余额
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public decimal Gettotalamount(int CompanyID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select totalamount  ");
                strSql.Append("  from Companys ");
                strSql.Append(" where CompanyID=@CompanyID");
                SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
			    };
                parameters[0].Value = CompanyID;

                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
                return obj != DBNull.Value && obj != null ? Convert.ToDecimal(obj) : 0;
            }
            catch { }
            return -1;
        }

        public DataTable GetPageCompanys(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
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
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection,"Companys_GetPageCompanys", CommandType.StoredProcedure, paras);
                TotalRows = Convert.ToInt32(paras[4].Value != DBNull.Value ? paras[4].Value : 0);
                return dt;
            }
            catch { }
            return null;
        }

        public int getmaxid()
        {
            string sql = "select max(CompanyID) from Companys";
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,sql, CommandType.Text);
            int id = obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
            return id;
        }

        #region 帐号
        public CompanysInfo getModel(string username, string password)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from Companys ");
                //strSql.Append(" where uname=@uname and password=@password and companyid=@companyid");
                strSql.Append(" where username=@username and password=@password");
                SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,80),
                    new SqlParameter("@password", SqlDbType.VarChar,80),
			    };
                parameters[0].Value = username;
                parameters[1].Value = password;
                CompanysInfo info = new CompanysInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        info = BS.Components.Data.Entity.EntityHelper.GetDataReaderObject<CompanysInfo>("*", dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }
        #endregion
    }
}

