using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web.UI;
using Model;

namespace WebSite.admin.DesktopModules.Companys
{
    public partial class companys : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "companys";
                Repeater1bind();
            }
        }

        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = ""; //BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O");
            //if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
            //{
            //    Condition = "C.companyid=" + base.user_companyid;
            //}
            if (txbfieldval.Text.Trim().Length > 0)
            {
                if (ddlfield.SelectedValue == "O.[companyname]")
                {
                    Condition += " and O.[companyname] like '%" + txbfieldval.Text.Trim() + "%'";
                }
            }
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.CompanysBLL.GetPageCompanys(where, "O.companyid desc", CurrentPage, PageSize, ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "status")
            {
                string str = e.CommandArgument.ToString();
                string[] arrstr = str.Split('|');
                int id = Convert.ToInt32(arrstr[0]);
                int statusval = Convert.ToInt32(arrstr[1]);
                if (statusval == -1)
                    statusval = 0;
                else
                    statusval = -1;
                int result = BLL.publicBLL.UpdateTableValue("Companys", "[status]=" + statusval, "CompanyID=" + id);
                if (result > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！');", true);
                }

            }
            else if (e.CommandName == "login")
            {
                if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('只有系统管理员/才有进入商家系统的权限！');", true);
                    return;
                }
                int companyid = Convert.ToInt32(e.CommandArgument);
                if (companyid <= 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('companyid错误！');", true);
                    return;
                }
                string resultMsg = "";
                int result = BLL.CompanysBLL.company_login(companyid, ref resultMsg);
                if (result > 0)
                {
                    Response.Write("<script>top.location.href='/seller/index.aspx';</script>");
                }
            }
            else if (e.CommandName == "status") //0正常-1关闭
            {
                string str = e.CommandArgument.ToString();
                string[] arrstr = str.Split('|');
                int companyid = Convert.ToInt32(arrstr[1]);
                int status = arrstr[0].Equals("") ? -1 : Convert.ToInt32(arrstr[0]);
                string statusint = (status == 0 ? -1 : 0).ToString();
                string where = "companyid='" + companyid + "'";
                int result = BLL.SellerBLL.Update("companys", " status=" + statusint, where);
                if (result > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！');", true);
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editcompanys.aspx");
        }

        protected string status(object objstatus)
        {
            if (objstatus == null)
                return "正常";
            if (objstatus.ToString().Equals("-1"))
                return "<span style='color:red;'>锁定</span>";
            else
                return "正常";
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbtnstatus = (LinkButton)e.Item.FindControl("lbtnstatus");
                DataRowView dv = (DataRowView)e.Item.DataItem;
                int status = dv["status"] != DBNull.Value ? Convert.ToInt32(dv["status"]) : 0;
                lbtnstatus.Text = status == -1 ? "<span style='color:red;'>解锁</span>" : "锁定";
                if (base.UserType != Common.enumUserType.admin.ToString() && base.UserType != Common.enumUserType.host.ToString())
                { lbtnstatus.Enabled = false; }
            }
        }

        //protected string user(object objcompanyid)
        //{
        //    if (objcompanyid == null || objcompanyid == DBNull.Value)
        //        return "";
        //    int _companyid = 0;
        //    int.TryParse(objcompanyid.ToString(), out _companyid);
        //    if (_companyid > 0)
        //    {
        //        List<UserInfo> users = BLL.UsersBLL.GetList(1, "companyid=" + objcompanyid.ToString(), "userid asc");
        //        if (users != null && users.Count > 0)
        //        {
        //            UserInfo userinfo = users[0];
        //            return userinfo.UserName + "【" + userinfo.DisplayName + "】";
        //        }
        //    }
        //    return "";
        //}
    }
}