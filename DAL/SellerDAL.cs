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
    //商家
    public class SellerDAL :CommonData<SellerInfo>
    {

        #region 事务
        public int AddTran(SellerInfo cinfo, ref string resultMsg)
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

                //long uid = new CommonData<memberInfo>().Insert(minfo, con, com, myTran, ReturnTypes.Identity);
                //if (uid <= 0)
                //{
                //    myTran.Rollback();
                //    return 0;
                //}
                //cinfo.uid = uid;
                //com.Parameters.Clear();
                int sellerid = Insert(cinfo, con, com, myTran, ReturnTypes.Identity);
                if (sellerid <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }
                myTran.Commit();
                return sellerid;
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
        public int UpdateTran(SellerInfo cinfo, ref string resultMsg)
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

                //int m_rows = new CommonData<memberInfo>().Update(minfo, con, com, myTran, null);
                //if (m_rows <= 0)
                //{
                //    myTran.Rollback();
                //    return 0;
                //}
                int c_rows = Update(cinfo, con, com, myTran, null);
                if (c_rows <= 0)
                {
                    myTran.Rollback();
                    return 0;
                }
                myTran.Commit();
                return c_rows;
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

        #region 事务 已注悉
        /// <summary>
        /// 添加编号
        /// </summary>
        /// <param name="minfo"></param>
        /// <param name="cinfo"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        //public int AddTran(memberInfo minfo, SellerInfo cinfo, ref string resultMsg)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = Config.SqlConnection;
        //    con.Open();
        //    // 启动一个事务。 
        //    SqlTransaction myTran = con.BeginTransaction();
        //    SqlCommand com = new SqlCommand();
        //    com.Connection = con;
        //    com.Transaction = myTran;
        //    try
        //    {
        //        long uid = new memberDAL().Add(com, minfo, ref resultMsg);
        //        if (uid <= 0)
        //        {
        //            myTran.Rollback();
        //            return 0;
        //        }
        //        cinfo.uid = uid;
        //        int addowner = Add(com, cinfo, ref resultMsg);
        //        if (addowner <= 0)
        //        {
        //            myTran.Rollback();
        //            return 0;
        //        }
        //        myTran.Commit();
        //        return uid;
        //    }
        //    catch (Exception exc)
        //    {
        //        resultMsg = exc.Message;
        //        myTran.Rollback();
        //    }
        //    finally
        //    {
        //        com.Dispose();
        //        con.Close();
        //    }
        //    return 0;
        //}

        //public int UpdateTran(memberInfo minfo, SellerInfo cinfo, ref string resultMsg)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = Config.SqlConnection;
        //    con.Open();
        //    // 启动一个事务。 
        //    SqlTransaction myTran = con.BeginTransaction();
        //    SqlCommand com = new SqlCommand();
        //    com.Connection = con;
        //    com.Transaction = myTran;
        //    try
        //    {
        //        int updatemember = new memberDAL().Update(com, minfo, ref resultMsg);
        //        if (updatemember <= 0)
        //        {
        //            myTran.Rollback();
        //            return 0;
        //        }
        //        int updateowner = Update(com, cinfo, ref resultMsg);
        //        if (updateowner <= 0)
        //        {
        //            myTran.Rollback();
        //            return 0;
        //        }
        //        myTran.Commit();
        //        return updatemember;
        //    }
        //    catch (Exception exc)
        //    {
        //        resultMsg = exc.Message;
        //        myTran.Rollback();
        //    }
        //    finally
        //    {
        //        com.Dispose();
        //        con.Close();
        //    }
        //    return 0;
        //}

        #endregion

        public SellerInfo getModel(string uname, string password)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from Seller ");
                //strSql.Append(" where uname=@uname and password=@password and companyid=@companyid");
                strSql.Append(" where uname=@uname and password=@password");
                SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,80),
                    new SqlParameter("@password", SqlDbType.VarChar,80),
			    };
                parameters[0].Value = uname;
                parameters[1].Value = password;
                SellerInfo info = new SellerInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection, strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        info = BS.Components.Data.Entity.EntityHelper.GetDataReaderObject<SellerInfo>("*", dr);
                        //info = GetInfoByDr(dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }

    }
}

