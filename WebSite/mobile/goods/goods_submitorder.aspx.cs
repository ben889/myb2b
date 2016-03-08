using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.mobile.member;

namespace WebSite.mobile.goods
{
    public partial class goods_submitorder : m_member_basepage
    {
        public Model.goodsInfo gi = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                goodsid = Common.Utils.ObjectToint(Request.QueryString["id"]);
                string selectname = Request.Form["selectname"] as string + "";
               
                switch (selectname)
                {
                    case "tijiaodata":
                        addorder();
                        break;
                }
                binding();
            }
        }
        public int goodsid = 0;
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void binding()
        {
            gi = BLL.goodsBLL.GetModel(goodsid, "GoodsId", "");
        }


        /// <summary>
        /// 添加订单
        /// </summary>
        public void addorder()
        {
            
            BLL.g_orderBLL gorderbll = new BLL.g_orderBLL();
            Model.g_orderInfo gorder = new Model.g_orderInfo();
            
            int  overwritegoodsid = Common.Utils.ObjectToint(Request.Form["hidoosid"]);
            if (overwritegoodsid <= 0)
            {
                Response.Write("<script>parent.successful('商品ID错误');</script>");
                return;
            }
            goodsInfo goodsinfo = BLL.goodsBLL.GetModel(overwritegoodsid);
            if (goodsinfo == null || goodsinfo.GoodsId != overwritegoodsid)
            {
                Response.Write("<script>parent.successful('不存在对应的商品');</script>");
                return;
            }

            int count = Common.Utils.ObjectToint(Request.Form["inputcount"]);
            if (count<=0)
            {
                Response.Write("<script>parent.successful('至少要购买1份');</script>");
                return;
            }
            gorder.goodsid = overwritegoodsid;
            gorder.ordertype = goodsinfo.GoodsType;
            //gorder.pay_price = Common.Utils.ObjectTodecimal(Request.Form["h_moneysum"], 2);
            //gorder.totalprice = Common.Utils.ObjectTodecimal(Request.Form["h_moneysum"], 2);
            gorder.goods_count = count;
            gorder.uid = base.uid;

            decimal orderprice = goodsinfo.Price * gorder.goods_count;
            gorder.totalprice = orderprice;
            gorder.pay_price = orderprice;

            string resultMeg = "";
            int result = gorderbll.add(gorder, ref resultMeg);
            
            if (result > 0)
            {
                if (gorder.ordertype == (int)Common.enum_goodstype.goodstype_2)
                {
                    Response.Write("<script>parent.successful('" + result + "');</script>");
                }
                else {
                    Response.Write("<script>parent.successful2('" + result + "');</script>");
                }
                
                return;
            }
            else
            {
                Response.Write("<script>parent.fail('" + resultMeg.Replace("'", "").Replace("\n", "").Replace("\r", "") + "');</script>");
                return;
            }
        }
        

    }
}