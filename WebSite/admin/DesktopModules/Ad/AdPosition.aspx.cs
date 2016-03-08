using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin.DesktopModules.Ad
{
    public partial class AdPosition : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "adposition";
                Repeater1bind();
            }
        }
        private void Repeater1bind()
        {
            List<AdPositionInfo> list = BLL.AdPositionBLL.GetList(-1, "", "");
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = BLL.AdPositionBLL.Delete(id, "");
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
            Response.Redirect("editAdPosition.aspx");
        }
    }
}