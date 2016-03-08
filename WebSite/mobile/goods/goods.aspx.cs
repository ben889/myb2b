using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.mobile.goods
{
    public partial class goods : m_basepage
    {
        protected int page;
        protected void Page_Load(object sender, EventArgs e)
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
                        //typeid = Common.Utils.ObjectToint(Request["typeid"]);
                        //Response.Write(bindgoods(_companyid, pageindex, pagesize));
                        Response.Write(bindgoods( pageindex, pagesize));
                        Response.End();
                        break;
                }
            }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        ///// protected string bindgoods( int companyid, int PageIndex, int PageSize)
        protected string bindgoods( int PageIndex, int PageSize)
        {
            int TotalRows = 0;
            goodsInfo goodsinfo = new goodsInfo();
            //string where = BLL.DataPermissionBLL.getclientsql(companyid, "");
            string where = "";
            DataTable dt = goodsBLL.GetPager(PageSize, PageIndex, where, "GoodsId desc"
                , "GoodsId,GoodsName,Img,Price,TotalCount,ExchCount,Status,description"
                , ref TotalRows);

            string json = MyJSONHelper.GetJson_Pager(dt, TotalRows);

            //string json = "[{\"TotalRows\":" + TotalRows + ",\"rows\":[";
            //if (dt != null && dt.Rows.Count > 0)
            //{

                
            //    decimal price;

            //    string imgurl;
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        price = (decimal)Common.Utils.ChinaRound(Convert.ToDouble(dr["Price"]), 2);
            //        //market = (decimal)Common.Utils.ChinaRound(Convert.ToDouble(dr["market"]), 2);

            //        imgurl = dr["Img"].ToString();
            //        json += "{" +
            //            "\"GoodsId\":\"" + dr["GoodsId"].ToString() + "\"" +
            //            ",\"GoodsName\":\"" + Common.Utils.jsonReplace(dr["GoodsName"].ToString()) + "\"" +
            //            ",\"img\":\"" + dr["Img"].ToString() + "\"" +
            //            ",\"TotalCount\":\"" + dr["TotalCount"].ToString() + "\"" +
            //            ",\"ExchCount\":\"" + Common.Utils.jsonReplace(dr["ExchCount"].ToString()) + "\"" +
            //            ",\"Status\":\"" + dr["Status"].ToString() + "\"" +
            //            ",\"Price\":\"" + price + "\"" +
            //            //",\"StartDate\":\"" + dr["StartDate"].ToString() +"\"" +
            //            //",\"EndDate\":\"" + dr["EndDate"].ToString() + "\"" +
            //            ",\"description\":\"" + dr["description"].ToString() + "\"" +
            //            "},";
            //    }
            //}
            //if (json.Trim().Length > 0 && json.Trim().EndsWith(","))
            //    json = json.Remove(json.Length - 1);
            //json += "]}]";
            return json;
        }
    }
}