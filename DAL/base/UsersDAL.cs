using BS.Components.Data.Entity;
using BS.Components.Data.SQLProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UsersDAL : CommonData<Model.UserInfo>
    {
        /// <summary>
        /// 延时实例化
        /// </summary>
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly UsersDAL instance = new UsersDAL();
        }

        /// <summary>
        /// 单件实例
        /// </summary>
        public static UsersDAL Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public Model.UserInfo Login(string UserName, string PassWord)
        {
            try
            {
                string sql = "select * from users where username=@UserName and PassWord=@PassWord";
                SqlParameter[] parameter = new SqlParameter[]{
                    new SqlParameter("@UserName",SqlDbType.NVarChar,100),
			        new SqlParameter("@PassWord",SqlDbType.NVarChar,50),
		        };
                parameter[0].Value = UserName;
                parameter[1].Value = PassWord;
                Model.UserInfo info = new Model.UserInfo();
                using (SqlDataReader dr = SQLHelper.DataReader(Config.SqlConnection, sql, CommandType.Text, parameter))
                {
                    if (dr.Read())
                    {
                        //info = GetInfoByDr(dr);
                        info = BS.Components.Data.Entity.EntityHelper.GetDataReaderObject<UserInfo>("*", dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }
        //private Model.UserInfo GetInfoByDr(SqlDataReader dr)
        //{
        //    Model.UserInfo info = new Model.UserInfo();
        //    info.UserID = int.Parse(dr["UserID"] != DBNull.Value ? dr["UserID"].ToString() : "0");
        //    info.LastIPAddress = dr.GetSchemaTable().Select("ColumnName='LastIPAddress'").Length > 0 && dr["LastIPAddress"] != DBNull.Value ? dr["LastIPAddress"].ToString() : "";
        //    info.CreatedByUserID = int.Parse(dr["CreatedByUserID"] != DBNull.Value ? dr["CreatedByUserID"].ToString() : "0");
        //    info.CreatedOnDate = DateTime.Parse(dr["CreatedOnDate"] != DBNull.Value ? dr["CreatedOnDate"].ToString() : "1900-01-01");
        //    info.LastModifiedByUserID = int.Parse(dr["LastModifiedByUserID"] != DBNull.Value ? dr["LastModifiedByUserID"].ToString() : "0");
        //    info.LastModifiedOnDate = DateTime.Parse(dr["LastModifiedOnDate"] != DBNull.Value ? dr["LastModifiedOnDate"].ToString() : "1900-01-01");
        //    info.LastLoginDate = DateTime.Parse(dr["LastLoginDate"] != DBNull.Value ? dr["LastLoginDate"].ToString() : "1900-01-01");
        //    info.LastPasswordChangedDate = DateTime.Parse(dr["LastPasswordChangedDate"] != DBNull.Value ? dr["LastPasswordChangedDate"].ToString() : "1900-01-01");
        //    info.LastLockoutDate = DateTime.Parse(dr["LastLockoutDate"] != DBNull.Value ? dr["LastLockoutDate"].ToString() : "1900-01-01");
        //    info.UserName = dr.GetSchemaTable().Select("ColumnName='UserName'").Length > 0 && dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
        //    info.Comment = dr.GetSchemaTable().Select("ColumnName='Comment'").Length > 0 && dr["Comment"] != DBNull.Value ? dr["Comment"].ToString() : "";
        //    info.UserType = dr["UserType"] != DBNull.Value ? dr["UserType"].ToString() : "";
        //    info.PassWord = dr.GetSchemaTable().Select("ColumnName='PassWord'").Length > 0 && dr["PassWord"] != DBNull.Value ? dr["PassWord"].ToString() : "";
        //    info.FirstName = dr.GetSchemaTable().Select("ColumnName='FirstName'").Length > 0 && dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
        //    info.LastName = dr.GetSchemaTable().Select("ColumnName='LastName'").Length > 0 && dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
        //    info.Email = dr.GetSchemaTable().Select("ColumnName='Email'").Length > 0 && dr["Email"] != DBNull.Value ? dr["Email"].ToString() : "";
        //    info.DisplayName = dr.GetSchemaTable().Select("ColumnName='DisplayName'").Length > 0 && dr["DisplayName"] != DBNull.Value ? dr["DisplayName"].ToString() : "";
        //    return info;

        //}

        public int UpdatePassWord(string PassWord, int UserID)
        {
            string sql = "UPDATE Users SET PassWord=@PassWord WHERE UserID=@UserID";
            SqlParameter[] parameter = new SqlParameter[]{
                    new SqlParameter("@UserName",SqlDbType.NVarChar,100),
			        new SqlParameter("@PassWord",SqlDbType.NVarChar,50),
		        };
            parameter[0].Value = PassWord;
            parameter[1].Value = UserID;
            return SQLHelper.NonQuery(Config.SqlConnection, sql, CommandType.Text, parameter);
        }

        public string GetCompanyId(int userid)
        {
            try
            {
                //string sql = "select CompanyID from Companys where userid=@userid";
                //SqlParameter[] parameters = {           
                //    new SqlParameter("@userid", SqlDbType.Int,4), 
                //};

                //parameters[0].Value = userid;
                //object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
                //string companyid = obj != null && obj != DBNull.Value ? obj.ToString() : "";
                //if (companyid.Trim().Length > 0)
                //    return companyid;

                //SqlParameter[] parameters2 = {           
                //    new SqlParameter("@userid", SqlDbType.Int,4), 
                //};
                //parameters2[0].Value = userid;

                //string sql2 = "select CompanyID from Persons where userid=@userid";
                //object obj2 = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql2, CommandType.Text, parameters2);
                //companyid = obj2 != null && obj2 != DBNull.Value ? obj2.ToString() : "";
                //return companyid;


                string sql = "select CompanyId from Users where userid=@userid";
                SqlParameter[] parameters = {           
                    new SqlParameter("@userid", SqlDbType.Int,4), 
                };

                parameters[0].Value = userid;
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
                string companyid = obj != null && obj != DBNull.Value ? obj.ToString() : "";
                if (companyid.Trim().Length > 0)
                    return companyid;
            }
            catch
            { }
            return "";
        }
    }
}
