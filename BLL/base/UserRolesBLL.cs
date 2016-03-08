using BS.Components.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class UserRolesBLL : CommonBLL<Model.UserRolesInfo>
    {
        public static int Add(Model.UserRolesInfo info)
        {
            List<Model.UserRolesInfo> list = GetList(1, "RoleID=" + info.RoleID + " and UserId=" + info.UserID, "");
            if (list != null && list.Count > 0)
                return 0;
            return Insert(info, ReturnTypes.Identity);
        }
        public static DataTable GetUserRolesANDRoles(string where)
        {
            string sql = "select O.*,R.RoleName from UserRoles O LEFT JOIN Roles R ON R.RoleID=O.RoleID";
            if (where.Trim().Length > 0)
                sql = sql + " where " + where;
            return GetTable(sql);
        }
    }
}
