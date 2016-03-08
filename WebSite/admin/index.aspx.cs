using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin
{
    public partial class index : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                base.TabKey = "all";
                

                string ajaxmethod = Request["ajaxmethod"] != null ? Request["ajaxmethod"].ToString().ToLower() : "";

                if (ajaxmethod.Trim().Length > 0)
                {
                    switch (ajaxmethod)
                    {
                        case "bindmenu":
                            Response.Write(getmenu());
                            Response.End();
                            break;
                        case "bindsubmenu":
                            string parentid = Common.Utils.ObjectToStr(Request["parentid"]);
                            Response.Write(getsubmenu(parentid));
                            Response.End();
                            break;
                    }
                }
                else {
                    Userbind();
                }

            }
        }

        #region 用户信息
        protected string rolenamestr = "";
        private void Userbind()
        {
            if (base.userinfo != null && base.UserID > 0)
            {
                //ltrDisplayName.Text = base.UserInfo.DisplayName;

                if (base.UserType == Common.enumUserType.host.ToString())
                    rolenamestr = "超级管理员 ";
                else if (base.UserType == Common.enumUserType.admin.ToString())
                    rolenamestr = "系统管理员 ";
                else
                {
                    //if (base.UserType == Common.enumUserType.company.ToString())
                    //    rolenamestr = "系统管理员 ";
                    //if (base.UserType == (int)Common.enumUserType.person)
                    //    rolenamestr = "商户管理员 ";
                    List<Model.RoleInfo> rolelist = BLL.RolesBLL.GetList(-1, "RoleID in (select Roleid from UserRoles where userid=" + base.UserID + ")", "");// RolesController.GetListRolesByUserID(base.UserID);
                    foreach (Model.RoleInfo roleInfo in rolelist)
                    {
                        rolenamestr += roleInfo.RoleName + ",";
                    }
                    if (rolenamestr.Length > 0)
                        rolenamestr = rolenamestr.Remove(rolenamestr.Length - 1);

                }


                //ltrRoleName.Text = rolenamestr;
            }
        }
        #endregion


        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            BLL.UsersBLL.Exit();
        }

        protected string getmenu()
        {
            string json = TabsBLL.GetMenuJSON(base.UserID);
            return json;
        }
        protected string getsubmenu(string parentid)
        {
            //[{ "id": 1, "name": "aaaaa", "submenu": [{ "id": 3, "name": "cccc", "submenu": [] }, { "id": 4, "name": "ddddd", "submenu": [] }] }, { "id": 2, "name": "bbbb", "submenu": [] }]
            string json = TabsBLL.GetSubMenuJSON(base.UserID, parentid.ToString(), 3);
            return json;
        }
    }
}