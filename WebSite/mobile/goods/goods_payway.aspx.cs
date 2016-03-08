using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.mobile.member;

namespace WebSite.mobile.goods
{
    public partial class goods_payway : m_member_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                orderid = Common.Utils.ObjectToint(Request.QueryString["orderid"]);
                Initdata(orderid);
            }
        }
        public Model.g_orderInfo go = new Model.g_orderInfo();
        public Model.goodsInfo goods = new Model.goodsInfo();
        public int orderid { get; set; }
        public void Initdata(int oid) 
        {
            go = BLL.g_orderBLL.GetModel(oid, "orderid", "orderno,goodsid,pay_price,totalprice");
            if (go != null && go.goodsid > 0) 
            {
                goods = BLL.goodsBLL.GetModel(go.goodsid, "GoodsId", "GoodsName");
            }
        }
    }
}