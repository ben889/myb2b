using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using Model;
using BS.Components.Data.SQLProvider;
namespace DAL
{
    //Companys_costlog
    public class Companys_costlogDAL
    {


        public int Add(Companys_costlogInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Companys_costlog(");
                strSql.Append("userid,companyid,amount,description,createtime");
                strSql.Append(") values (");
                strSql.Append("@userid,@companyid,@amount,@description,@createtime");
                strSql.Append(") ");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					            new SqlParameter("@userid", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@companyid", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@amount", SqlDbType.Money,8) ,            
	            	            new SqlParameter("@description", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@createtime", SqlDbType.DateTime)             
	              
	            };

                parameters[0].Value = model.userid;
                parameters[1].Value = model.companyid;
                parameters[2].Value = model.amount;
                parameters[3].Value = model.description;
                parameters[4].Value = model.createtime;

                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
                if (obj == null)
                {
                    return 0;
                }
                else
                {

                    return Convert.ToInt32(obj);

                }

            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;
        }

        public int Add(SqlCommand com, Companys_costlogInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Companys_costlog(");
                strSql.Append("userid,companyid,amount,description,createtime");
                strSql.Append(") values (");
                strSql.Append("@userid,@companyid,@amount,@description,@createtime");
                strSql.Append(") ");
                strSql.Append(";select @@IDENTITY");

                com.Parameters.Clear();
                com.Parameters.Add("@userid", SqlDbType.Int, 4);
                com.Parameters.Add("@companyid", SqlDbType.Int, 4);
                com.Parameters.Add("@amount", SqlDbType.Money, 8);
                com.Parameters.Add("@description", SqlDbType.NVarChar, 255);
                com.Parameters.Add("@createtime", SqlDbType.DateTime);



                com.Parameters[5].Value = model.userid;
                com.Parameters[6].Value = model.companyid;
                com.Parameters[7].Value = model.amount;
                com.Parameters[8].Value = model.description;
                com.Parameters[9].Value = model.createtime;
                com.CommandText = strSql.ToString();
                com.CommandType = CommandType.Text;


                object obj = com.ExecuteScalar();
                if (obj == null)
                {
                    return 0;
                }
                else
                {

                    return Convert.ToInt32(obj);

                }

            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;

        }

        public int Update(Companys_costlogInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Companys_costlog set ");

                strSql.Append(" userid = @userid , ");
                strSql.Append(" companyid = @companyid , ");
                strSql.Append(" amount = @amount , ");
                strSql.Append(" description = @description , ");
                strSql.Append(" createtime = @createtime  ");
                strSql.Append(" where id=@id ");

                SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@userid", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@companyid", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@amount", SqlDbType.Money,8) ,	            
	            	            new SqlParameter("@description", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@createtime", SqlDbType.DateTime) 	            
	              
	            };

                parameters[0].Value = model.id;
                parameters[1].Value = model.userid;
                parameters[2].Value = model.companyid;
                parameters[3].Value = model.amount;
                parameters[4].Value = model.description;
                parameters[5].Value = model.createtime;
                int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);

                return rows;
            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Companys_costlog ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Companys_costlog ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Companys_costlogInfo> GetList(int Top, string strWhere, string filedOrder)
        {
            List<Companys_costlogInfo> list = new List<Companys_costlogInfo>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" * ");
                strSql.Append(" FROM Companys_costlog ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text))
                {
                    while (dr.Read())
                    {
                        Companys_costlogInfo info = GetInfoByDr(dr);
                        list.Add(info);
                    }
                }
                return list;
            }
            catch { }
            return null;
        }

        public Companys_costlogInfo GetModel(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from Companys_costlog ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
                parameters[0].Value = id;

                Companys_costlogInfo info = new Companys_costlogInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        info = GetInfoByDr(dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }

        private Companys_costlogInfo GetInfoByDr(SqlDataReader dr)
        {
            Companys_costlogInfo info = new Companys_costlogInfo();
            info.id = int.Parse(dr["id"] != DBNull.Value ? dr["id"].ToString() : "0");
            info.userid = int.Parse(dr["userid"] != DBNull.Value ? dr["userid"].ToString() : "0");
            info.companyid = int.Parse(dr["companyid"] != DBNull.Value ? dr["companyid"].ToString() : "0");
            info.amount = decimal.Parse(dr["amount"] != DBNull.Value ? dr["amount"].ToString() : "0");
            info.description = dr["description"] != DBNull.Value ? dr["description"].ToString() : "";
            info.createtime = DateTime.Parse(dr["createtime"] != DBNull.Value ? dr["createtime"].ToString() : "");
            return info;

        }


        public DataTable GetPageCompanys_costlog(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
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
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection,"Companys_GetPageCompanys_costlog", CommandType.StoredProcedure, paras);
                TotalRows = Convert.ToInt32(paras[4].Value != DBNull.Value ? paras[4].Value : 0);
                return dt;
            }
            catch { }
            return null;
        }
    }
}

