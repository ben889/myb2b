using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class wx_Material : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx";
                Repeater1bind();
            }
        }


        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "parentid=0";
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.wx_MaterialBLL.GetPager(PageSize, CurrentPage, where, "CreateTime asc", "*", "wx_Material", ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
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
                string resutlmsg = "";
                int b = BLL.wx_MaterialBLL.delete(id, ref resutlmsg);
                if (b > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！" + resutlmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }

            }
        }
    }
}