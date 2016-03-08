using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using Web.UI;

namespace WebSite.admin.DesktopModules.member
{
    public partial class member : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "member";
                //utype = Common.Utils.ObjectToint(Request["utype"]);
                Repeater1bind();
            }
        }

        //protected int utype
        //{
        //    get
        //    {
        //        return ViewState["utype"] != null ? Convert.ToInt32(ViewState["utype"]) : 0;
        //    }
        //    set { ViewState["utype"] = value; }
        //}

        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "1=1";// +(int)Common.enumutype.owner; //BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O") + " and O.utype=" + (int)Common.enumutype.owner;
            if (txbfieldval.Text.Trim().Length > 0)
            {
                Condition += " and " + ddlfield.SelectedValue + " like '%" + txbfieldval.Text.Trim() + "%'";
            }
            //Condition += " and utype=" + utype.ToString();
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.memberBLL.GetPagemember(where, "O.uid desc", CurrentPage, PageSize, ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "islock")
            {
                string str = e.CommandArgument.ToString();
                string[] arrstr = str.Split('|');
                int id = Convert.ToInt32(arrstr[0]);
                bool islockval = Convert.ToBoolean(arrstr[1]);
                if (!islockval)
                    islockval = true;
                else
                    islockval = false;
                int result = BLL.publicBLL.UpdateTableValue("member", "[islock]='" + islockval + "'", "uID=" + id);
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
            Response.Redirect("editmember.aspx");
        }

        protected string islock(object objislock)
        {
            if (objislock == null)
                return "正常";
            if (objislock.ToString().Trim().ToLower().Equals("true"))
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
                LinkButton lbtnislock = (LinkButton)e.Item.FindControl("lbtnislock");

                DataRowView dv = (DataRowView)e.Item.DataItem;
                bool islock = dv["islock"] != DBNull.Value ? Convert.ToBoolean(dv["islock"]) : false;
                lbtnislock.Text = !islock ? "<span style='color:red;'>锁定</span>" : "解锁";
                if (base.UserType != Common.enumUserType.admin.ToString() && base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.company.ToString())
                { lbtnislock.Enabled = false; }
            }
        }

    }
}