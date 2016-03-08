using BS.Components.Data.SQLProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DistrictDAL
    {
        public int get_parentid(int DistId)
        {
            string sql = "select parentid from District where DistId=@DistId";
            SqlParameter[] parameters = {
				new SqlParameter("@DistId", SqlDbType.Int)   
	        };

            parameters[0].Value = DistId;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }
        public string get_parentids(int DistId)
        {
            string sql = "select parentids from District where DistId=@DistId";
            SqlParameter[] parameters = {
				new SqlParameter("@DistId", SqlDbType.Int)   
	        };

            parameters[0].Value = DistId;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
            return obj != null && obj != DBNull.Value ? obj.ToString() : "";
        }
    }
}
