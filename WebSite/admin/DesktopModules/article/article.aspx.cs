using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web.UI;
namespace WebSite.admin.DesktopModules.article
{
    public partial class article : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "article";
                Repeater1bind();
            }
        }

        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "1=1";
            if (txbfieldval.Text.Trim().Length > 0)
            {
                if (ddlfield.SelectedValue == "O.[title]")
                {
                    Condition += " and O.[title] like '%" + txbfieldval.Text.Trim() + "%'";
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
            DataTable dt = BLL.articleBLL.GetPagearticle(where, "O.orderby asc,O.id desc", CurrentPage, PageSize, ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected string showimg(object obj)
        {
            if (obj != null && obj.ToString().Trim().Length > 0)
            {
                return "<img src='" + obj.ToString() + "' height='50' />";
            }
            return "";
        }

        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = BLL.articleBLL.Delete(id, "id");
                if (b > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarticle.aspx");
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }
    }
}