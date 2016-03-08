using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.mobile
{
    public partial class article : m_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string call_index = Request["callindex"] != null ? Request["callindex"].ToString() : "";
                bind(call_index);
            }
        }

        protected string title;
        protected string content;
        protected void bind(string call_index)
        {
            if (call_index.Trim().Length == 0)
                return;
            string where =  "  call_index='" + call_index + "'";
            //string where = "companyid=" + base.companyid + " and call_index='" + call_index + "'";
            List<articleInfo> list = BLL.articleBLL.GetList(1, where, "");
            if (list == null || list.Count == 0)
                return;
            articleInfo info = list[0];
            title = info.title;
            content = info.content;
            header.title = title;
        }
    }
}