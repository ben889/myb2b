using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class wx_ReplyMesage : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_replymesage";
                Repeater1bind();
            }
        }
        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = " replytype=2";
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            //List<wx_ReplyMesageInfo> list = BLL.wx_ReplyMesageBLL.GetList(-1, where, "createtime desc");
            DataTable dt = BLL.wx_MaterialBLL.GetPager(PageSize, CurrentPage, where, "createtime asc", "*", "wx_ReplyMesage", ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                int result = BLL.wx_ReplyMesageBLL.delete(id);
                if (result > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }
    }
}