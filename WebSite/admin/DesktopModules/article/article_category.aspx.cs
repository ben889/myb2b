using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using System.Collections;
using Web.UI;

namespace WebSite.admin.DesktopModules.article
{
    public partial class article_category : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "article";
                listbind();
            }
        }

        private void listbind()
        {
            string where = "1=1";
            //if (companyid.Trim().Length > 0)
            //{
            //    where += " and O.companyid='" + companyid + "'";
            //}
            DataTable dt = BLL.article_categoryBLL.GetDt(-1, where, "orderby asc,id desc");
            ArrayList list = new BLL.article_categoryBLL().MakeTreeList(dt, "parentid", "0", "id", "title", -1);
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                bool b = BLL.article_categoryBLL.Delete(id);
                if (b)
                { listbind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarticle_category.aspx");
        }
    }
}