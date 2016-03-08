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
using BLL;
using Model;
using Common;
using WebSite.admin;

namespace Users
{
    public partial class Default : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckModulePermission("Users", "view");
            if (!IsPostBack)
            {
                base.TabKey = "all";
                Repeater1bind();
            }
        }
        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "O.IsDeleted<>1";
            if (ViewState["ss"] != null)
            {
                Condition += " and " + ViewState["ss"].ToString();
            }
            if (base.UserType != Common.enumUserType.host.ToString())
            {
                Condition += " and O.UserType<>'" + Common.enumUserType.host.ToString() + "'";
                if (base.UserType != Common.enumUserType.admin.ToString())
                    Condition += " and O.UserType<>'" + Common.enumUserType.admin.ToString() + "'";
            }
            return Condition;
        }
        private void Repeater1bind()
        {
            //List<Model.Users> list = Controller.GetUsers();
            //Repeater1.DataSource = list;
            //Repeater1.DataBind();
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            //DataTable list = BLL.UsersBLL.GetPager(PageSize, CurrentPage, where, "UserID desc", "", ref total);
            DataTable dt = BLL.UsersBLL.GetPager(where, "O.UserID desc", CurrentPage, PageSize, ref total, "Users_GetPageUsers");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUsers.aspx");
        }

        protected void btneidt_Click(object sender, EventArgs e)
        {
            int userid = 0;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfUserId = (HiddenField)Repeater1.Items[i].FindControl("hfUserId");
                    userid = Convert.ToInt32(hfUserId.Value);
                }
            }
            if (userid > 0)
                Response.Redirect("EditUsers.aspx?userid=" + userid);
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string ssval = txbfieldval.Text.Trim();
            ViewState["ss"] = "" + ddlfield.SelectedValue + " like '%" + ssval + "%'";
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "touserroles")
            {
                Response.Redirect("UserRoles.aspx?userid=" + e.CommandArgument.ToString());
            }
        }
        /// <summary>
        /// 模块权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnModulesRoles_Click(object sender, EventArgs e)
        //{
        //    string userid = "";
        //    for (int i = 0; i < Repeater1.Items.Count; i++)
        //    {
        //        if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
        //        {
        //            HiddenField hfUserId = (HiddenField)Repeater1.Items[i].FindControl("hfUserId");
        //            userid += hfUserId.Value;
        //            break;
        //        }
        //    }
        //    if (userid.Length == 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择用户！');", true);
        //        return;
        //    }
        //    Response.Redirect("/DesktopModules/Permission/ModulesPermission.aspx?userid=" + userid);
        //}
        /// <summary>
        /// 菜单权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnTabsRoles_Click(object sender, EventArgs e)
        //{
        //    string userid = "";
        //    for (int i = 0; i < Repeater1.Items.Count; i++)
        //    {
        //        if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
        //        {
        //            HiddenField hfUserId = (HiddenField)Repeater1.Items[i].FindControl("hfUserId");
        //            userid += hfUserId.Value;
        //            break;
        //        }
        //    }
        //    if (userid.Length == 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择用户！');", true);
        //        return;
        //    }
        //    Response.Redirect("/DesktopModules/Permission/TabsPermission.aspx?userid=" + userid);
        //}
        /// <summary>
        /// 选择的用户
        /// </summary>
        /// <returns></returns>
        private string selectuseridstr()
        {
            string useridstr = "";
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfUserId = (HiddenField)Repeater1.Items[i].FindControl("hfUserId");
                    useridstr += hfUserId.Value + ",";
                }
            }
            if (useridstr.Length > 0)
                return useridstr.Remove(useridstr.Length - 1);
            else
                return useridstr;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox CheckBox1 = (CheckBox)e.Item.FindControl("CheckBox1");
                ImageButton ibtnRoles = (ImageButton)e.Item.FindControl("ibtnRoles");

                Literal ltrRoles = (Literal)e.Item.FindControl("ltrRoles");
                //Literal ltrCompanyName = (Literal)e.Item.FindControl("ltrCompanyName");
                DataRowView dv = (DataRowView)e.Item.DataItem;
                //Model.Users info = (Model.Users)e.Item.DataItem;
                if (dv == null)
                    return;
                string _usertype = dv["UserType"] != DBNull.Value ? dv["UserType"].ToString() : "";
                int userid = dv["userid"] != DBNull.Value ? Convert.ToInt32(dv["userid"]) : -1;
                if (_usertype == Common.enumUserType.host.ToString() || _usertype == Common.enumUserType.admin.ToString())
                {
                    CheckBox1.Visible = false;
                    if (base.UserType == Common.enumUserType.host.ToString())
                    {
                        CheckBox1.Visible = true;
                    }
                    else if (base.UserType == Common.enumUserType.admin.ToString() && UserType == base.UserType)
                    {
                        CheckBox1.Visible = true;
                    }
                    ibtnRoles.Visible = false;
                }
                else
                {
                    List<Model.RoleInfo> rolelist = BLL.RolesBLL.GetList(-1, "RoleID in (select Roleid from UserRoles where userid=" + userid + ")", "");
                    string rolestr = "";
                    foreach (Model.RoleInfo roleinfo in rolelist)
                    {
                        rolestr = rolestr + roleinfo.RoleName + ",";
                    }
                    ltrRoles.Text = rolestr;
                }

                //int CompanyID = CompanysBLL.GetCompanyIdByUserID(info.UserId);
                //if (CompanyID > 0)
                //{
                //    CompanysInfo companysInfo = CompanysBLL.GetCompanysInfoByCompanyID(CompanyID);
                //    ltrCompanyName.Text = companysInfo.CompanyName;
                //}

            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            //string useridstr = "";
            int result = 0;
            int total = Repeater1.Items.Count;
            for (int i = 0; i < total; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfUserId = (HiddenField)Repeater1.Items[i].FindControl("hfUserId");
                    HiddenField hfUserType = (HiddenField)Repeater1.Items[i].FindControl("hfUserType");
                    int usertype = int.Parse(hfUserType.Value);
                    if (usertype == (int)enumUserType.host || usertype == (int)enumUserType.host)
                    {
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('不能删除管理员和超级管理员用户！');", true);
                        continue;
                    }
                    int userid = int.Parse(hfUserId.Value);
                    if (userid > 0)
                    {
                        int del = BLL.CommonBLL<Model.UserInfo>.Update("Users", "IsDeleted=1", "userid=" + userid);// UsersController.UpdateIsDeleted(true, userid);
                        if (del > 0)
                            result++;
                    }
                    //useridstr += hfUserId.Value + ",";
                }
            }

            //if (useridstr.Trim().Length > 0)
            //{ useridstr = useridstr.Remove(useridstr.Trim().Length - 1); }
            //else
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择用户！');", true);
            //    return;
            //}

            //int result = UsersController.DeleteUsersByUserIds(useridstr);

            if (result > 0)
            {
                Repeater1bind();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('成功" + result + "个！失败" + (total - result) + "个');", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
            }
        }




    }
}
