using BS.Components.Data.Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolesBLL : CommonBLL<Model.RoleInfo>
    {
        public static int Add(Model.RoleInfo info)
        {
            return Insert(info,ReturnTypes.EffectRow);
        }

        public static DataTable GetDataTable()
        {
            return GetTable("select * from Roles");
        }
        public static int GetMaxId()
        {
            return new DAL.RolesDAL().GetMaxId();
        }
        #region 数据初始化
        public static void init()
        {
            int roleid_company = (int)Common.enumUserType.company;
            int roleid_person = (int)Common.enumUserType.person;
            List<int> listid = new List<int>();
            listid.Add(roleid_company);
            listid.Add(roleid_person);
            //BLL.UserRolesBLL.Delete("");
            //Delete("");
            for (int i = 0; i < listid.Count; i++)
            {
                int roleid = listid[i];
                string RoleName = Common.EnumHelper.GetEnumDescription(typeof(Common.enumUserType), roleid);
                string tabs_where = "";
                if (roleid == (int)Common.enumUserType.company)
                {
                    tabs_where = "TabKey not in('withdraw_cash')";
                }
                else if (roleid == (int)Common.enumUserType.person)
                {
                    tabs_where = "TabKey not in('withdraw_cash')";
                }
                Model.RoleInfo roleinfo = BLL.RolesBLL.GetModel(roleid);
                if (roleinfo == null || roleinfo.RoleID != roleid)
                {
                    roleinfo = new Model.RoleInfo();
                    roleinfo.RoleID = roleid;
                    roleinfo.RoleName = RoleName;
                    roleinfo.Description = "";
                    roleinfo.IconFile = "";
                    int addroleresult = BLL.RolesBLL.Add(roleinfo);
                }
                if (roleinfo.RoleID == roleid)
                {
                    //重新删除后再添加对应的权限
                    TabPermissionBLL.Delete("roleid=" + roleid);// .DeleteTabPermissionByRoleID(roleid);
                    List<TabsInfo> tabslist = TabsBLL.GetList(-1, tabs_where, "");
                    if (tabslist != null)
                    {
                        foreach (TabsInfo tabsInfo in tabslist)
                        {
                            if (tabsInfo == null || tabsInfo.TabID <= 0)
                                continue;
                            List<PermissionInfo> list = PermissionBLL.GetList(-1, "PermissionCode='SYSTEM_TAB' AND (TabID=0 OR TabID is NULL or TabID=" + tabsInfo.TabID + ")", "");
                            if (list == null || list.Count == 0)
                                continue;
                            foreach (PermissionInfo info in list)
                            {
                                //PermissionBLL.UpdateTabPermissionByRoleID(tabsInfo.TabID, info.PermissionID, roleid, 0, 0, 0);
                                TabPermissionInfo tabpinfo = new TabPermissionInfo();
                                tabpinfo.TabID = tabsInfo.TabID;
                                tabpinfo.RoleID = roleid;
                                tabpinfo.PermissionID = info.PermissionID;
                                TabPermissionBLL.Save(tabpinfo);
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
