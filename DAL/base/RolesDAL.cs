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
    public class RolesDAL : CommonData<Model.RoleInfo>
    {
        /// <summary>
        /// 延时实例化
        /// </summary>
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly RolesDAL instance = new RolesDAL();
        }

        /// <summary>
        /// 单件实例
        /// </summary>
        public static RolesDAL Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        public int GetMaxId()
        {
            string sql = "select max(RoleID) from Roles";
            object obj = SQLHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, null);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }

       
    }
}
