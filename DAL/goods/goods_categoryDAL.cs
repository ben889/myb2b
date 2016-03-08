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
    public class goods_categoryDAL : CommonData<goods_categoryInfo>
    {
        public int get_parentid(int goods_category_id)
        {
            string sql = "select parentid from goods_category where goods_category_id=@goods_category_id";
            SqlParameter[] parameters = {
				new SqlParameter("@goods_category_id", SqlDbType.Int)   
	        };

            parameters[0].Value = goods_category_id;
            object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, parameters);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }
    }
}
