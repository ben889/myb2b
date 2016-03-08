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
    public partial class cart : m_member_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Common.Utils.ObjectToint(Request["id"]);
                string ajaxmethod = Request.Form["ajaxmethod"] as string + "";
                if (ajaxmethod != null && ajaxmethod.Trim().Length > 0)
                {
                    if (ajaxmethod.Equals("addcart"))
                    {
                        string result = addcart(id);
                        Response.Write(result);
                        Response.End();
                    }
                }
                else
                {
                    bind();
                }
            }

            else
            {

            }
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        protected string addcart(int spid)
        {
            try
            {
                if (spid <= 0)
                {
                    return "{\"result\":0,\"msg\":\"id错误\"}";
                }
                Model.goodsInfo go = BLL.goodsBLL.GetModel(spid);
                if (go != null && go.GoodsId == spid)
                {
                    Model.g_orderInfo gor = new g_orderInfo();
                    gor.uid = uid;
                    gor.companyid = 0;
                    gor.goods_count = Convert.ToInt32(Request.Form["number"]);
                    gor.goodsid = spid;
                    gor.totalprice = Convert.ToDecimal(Request.Form["total_price"]);
                    gor.ordertype = go.GoodsType;
                    string resultMsg = "";
                    int result = new BLL.g_orderBLL().add(gor, ref resultMsg);
                    if (result > 0)
                        return "{\"result\":" + result + ",\"msg\":\"\"}";
                    return "{\"result\":" + result + ",\"msg\":\"" + resultMsg.Replace("\"", "").Replace("\r", "").Replace("\n", "") + "\"}";
                }
                return "{\"result\":0,\"msg\":\"无对应的商品信息\"}";
            }
            catch (Exception exc) {
                return "{\"result\":0,\"msg\":\"" + exc.Message.Replace("\"", "").Replace("\r", "").Replace("\n", "") + "\"}";
            }
        }
        protected int id;
        protected string name;
        protected string price;
        protected goodsInfo info = null; // 产品
        //protected SellerInfo sInfo = null; // 商家
        protected void bind()
        {
            if (id <= 0)
            {
                Response.Write("<script>alert('参数错误');history.go(-1);</script>");
                return;
            }
            info = BLL.goodsBLL.GetModel(id);
            if (info == null || info.GoodsId != id)
            {
                Response.Write("<script>alert('无对应的商品');history.go(-1);</script>");
                return;
            }
            name = info.GoodsName;
            price = Common.Utils.decimalObjectToStr(info.Price);
            if (info.sellerid <= 0)
            {
                Response.Write("<script>alert('无对应的商家信息');history.go(-1);</script>");
                return;
            }
            //sInfo = BLL.SellerBLL.GetModel(info.sellerid);
            //if (sInfo == null || sInfo.sellerid != info.sellerid)
            //{
            //    Response.Write("<script>alert('无对应的商家信息');history.go(-1);</script>");
            //    return;
            //}
        }

    }
}