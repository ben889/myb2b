using BS.Components.Data.SQLProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TabsDAL : CommonData<Model.TabsInfo>
    {

        public List<int> GetTabIDsByTabKey(string TabKey)
        {
            if (TabKey != null && TabKey.Length > 0)
            {
                List<int> list = new List<int>();
                string sql = "SELECT TabID FROM Tabs WHERE TabKey=@TabKey";
                try
                {
                    SqlParameter[] paras = new SqlParameter[]{
			            new SqlParameter("@TabKey",SqlDbType.VarChar,50),
		            };
                    paras[0].Value = TabKey;
                    //object obj = new SqlDbHelper().ExecuteScalar(sql, CommandType.Text, paras);
                    //return Convert.ToInt32(obj);
                    using (SqlDataReader dr = SQLHelper.DataReader(Config.SqlConnection, sql, CommandType.Text, paras))
                    {
                        while (dr.Read())
                        {
                            list.Add(dr["TabID"] != DBNull.Value ? Convert.ToInt32(dr["TabID"]) : 0);
                        }
                    }
                }
                catch { }
                return list;
            }
            return null;
        }

        public int GetMaxId()
        {
            string sql = "select max(tabid) from tabs";
            object obj = SQLHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, null);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }
    }
}
