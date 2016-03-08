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
    public class PermissionDAL : CommonData<Model.PermissionInfo>
    {
        /// <summary>
        /// 查询是否有权限
        /// </summary>
        /// <param name="TabID">菜单ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <param name="PermissionKey">权限Key(全部为大写 如添加为ADD,修改为UPDATE,删除为DELETE,查看为VIEW)</param>
        /// <returns></returns>
        public bool GetPermission(int TabID, int RoleID, string PermissionKey)
        {
            string sql = "select * from TabPermission where PermissionID in(" +
            "select PermissionID from Permission where PermissionKey=@PermissionKey and PermissionCode='SYSTEM_TAB'" +
            ") and roleid=@RoleID and (TabID=@TabID or TabID=0)";
            bool b = false;
            try
            {
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@TabID",SqlDbType.Int),
                    new SqlParameter("@RoleID",SqlDbType.Int),
                    new SqlParameter("@PermissionKey",SqlDbType.VarChar,50),
		        };
                paras[0].Value = TabID;
                paras[1].Value = RoleID;
                paras[2].Value = PermissionKey;

                using (SqlDataReader dr = SQLHelper.DataReader(Config.SqlConnection, sql, CommandType.Text, paras))
                {
                    if (dr.Read())
                    {
                        b = true;
                    }
                }
            }
            catch
            { }
            return b;
        }

        public int GetMaxId()
        {
            string sql = "select max(PermissionID) from Permission";
            object obj = SQLHelper.ExecuteScalar(Config.SqlConnection, sql, CommandType.Text, null);
            return obj != null && obj != DBNull.Value ? Convert.ToInt32(obj) : 0;
        }
    }
}
