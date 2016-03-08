using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.mobile.goods
{
    public partial class goodsdetail : m_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Common.Utils.ObjectToint(Request["id"]);
                bind();
            }
        }

        protected int id;
        protected string name;
        protected goodsInfo info = null; // 产品
        protected SellerInfo sInfo = null; // 商家
        protected void bind()
        {
            if (id <= 0)
            {
                Response.Write("<script>alert('参数错误');history.go(-1);</script>");
                Response.End();
            }
            info = BLL.goodsBLL.GetModel(id);
            if (info == null || info.GoodsId != id)
            {
                Response.Write("<script>alert('无对应的商品');history.go(-1);</script>");
                Response.End();
            }
            name = info.GoodsName;
            if (info.sellerid <= 0)
            {
                Response.Write("<script>alert('无对应的商家信息');history.go(-1);</script>");
                Response.End();
            }
            sInfo = BLL.SellerBLL.GetModel(info.sellerid);
            if (sInfo == null || sInfo.sellerid != info.sellerid)
            {
                Response.Write("<script>alert('无对应的商家信息');history.go(-1);</script>");
                Response.End();
            }
        }
    }
}