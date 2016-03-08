using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Roles;
using System.Data.SqlClient;
using Model;
using BLL;
using WebSite.admin;

namespace Users
{
    public partial class UserRoles : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckModulePermission("Users", "view");
            try
            {
                if (Request["userid"] != null)
                    userid = Convert.ToInt32(Request["userid"]);
            }
            catch { }
            if (!IsPostBack)
            {
                base.TabKey = "all";
                ddlRolesbind();
                ddlRoles.SelectedValue = "0";
                Repeater1bind();
            }
        }

        private int userid
        {
            get { try { if (ViewState["userid"] != null) return Convert.ToInt32(ViewState["userid"]); else return 0; } catch { return 0; } }
            set { ViewState["userid"] = value; }
        }
        private void ddlRolesbind()
        {
            List<Model.RoleInfo> list = BLL.RolesBLL.GetList(-1,"","");// RolesController.GetListRolesByWhere("", "", "O.roleid desc");
            ddlRoles.Items.Add(new ListItem("选择角色", "0"));
            foreach (Model.RoleInfo info in list)
            {
                //string CompanyName = "";
                //if (info.CompanyID > 0)
                //{
                //    CompanyName = info.CompanyName;
                //}
                //else
                //{
                //    CompanyName = "系统角色";
                //}
                ddlRoles.Items.Add(new ListItem(info.RoleName, info.RoleID.ToString()));
            }
            //ddlRoles.DataSource = list;
            //ddlRoles.DataTextField = "rolename";
            //ddlRoles.DataValueField = "roleid";
            //ddlRoles.DataBind();

        }

        protected void ibtnAddRolesToUser_Click(object sender, ImageClickEventArgs e)
        {
            if (userid > 0)
            {
                //UsersController.AddUserRole(userid, Convert.ToInt32(ddlRoles.SelectedValue), base.UserID);
                Model.UserRolesInfo info = new UserRolesInfo();
                info.UserID = userid;
                info.RoleID = Convert.ToInt32(ddlRoles.SelectedValue);
                BLL.UserRolesBLL.Add(info);
                Repeater1bind();
            }
        }
        private void Repeater1bind()
        {
            if (userid > 0)
            {
                Model.UserInfo info = BLL.UsersBLL.GetModel(userid);// UsersController.GetUserByUserID(userid);
                lbUserName.Text = info.UserName;
                //List<Model.Roles> list = BLL.Roles.GetList(-1, "RoleID in (select Roleid from UserRoles where userid=" + userid + ")", ""); //UsersController.GetListUserRoleByUserId(userid);
                DataTable dt = BLL.UserRolesBLL.GetUserRolesANDRoles("O.userid=" + userid);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                //Components.UsersController.DeleteUserRole(Convert.ToInt32(e.CommandArgument));
                BLL.UserRolesBLL.Delete(e.CommandArgument.ToString(), "");
                Repeater1bind();
            }
        }

        protected void lbtnreturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUsers.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltrCompanyName = (Literal)e.Item.FindControl("ltrCompanyName");

                //Model.Roles roleInfo = (Model.Roles)e.Item.DataItem;
                //if (roleInfo.CompanyID > 0)
                //{
                //    //CompanysInfo companysInfo = CompanysBLL.GetCompanysInfoByCompanyID(roleInfo.CompanyID);
                //    //ltrCompanyName.Text = companysInfo.CompanyName;
                //}
                //else
                //{
                //    ltrCompanyName.Text = "系统角色";
                //}

            }
        }
    }
}
