using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;
using Common;
using WebSite.mobile.member;
namespace WebSite.mobile.goods
{
    public partial class goodsStuff : m_member_basepage
    {
        protected int page;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string method = Request["method"] != null ? Request["method"].ToString().ToLower() : "";
                if (method.Trim().Length > 0)
                {
                    switch (method.Trim().ToLower())
                    {
                        case "bindgoods":
                            if (page <= 0)
                                page = 1;
                            int pageindex = Common.Utils.ObjectToint(Request["pageindex"]);
                            int pagesize = Common.Utils.ObjectToint(Request["pagesize"]);
                            //int _companyid = Common.Utils.ObjectToint(Request["companyid"]);
                            string status = Common.Utils.ObjectToStr(Request["status"]);
                            binding(pageindex, pagesize, status);
                            break;
                    }
                }
            }
        }

        protected void binding(int PageIndex, int PageSize, string status)
        {
            int total = 0;
            string where = "O.uid='" + base.uid + "' and O.status=" + status;
            DataTable dt = BLL.goodsExchBLL.GetPager(where, " O.exchid desc", PageIndex, PageSize, ref total, "goodsExch_GetPagegoodsExch");
            string json = "";
            if (dt != null)
                json = new JsonConvert().GetJsonDataTable(dt, total);
            Response.Write(json);
            Response.End();
        }
    }
}