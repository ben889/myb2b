using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.seller
{
    public partial class editseller : seller_basepage
    {
        protected string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                title = "修改商家信息";
                bind();
            }
        }

        protected string wxqrcode; // 二维码
        protected string sellerimg; // 商家图片
        protected string wxqrcodeimgview; // 二维码图片显示
        protected string sellerimgview;//商家背景图显示


        /// <summary>
        /// 数据绑定
        /// </summary>
        private void bind()
        {
            if (sellerid > 0)
            {
                Model.SellerInfo info = BLL.SellerBLL.GetModel(sellerid);
                if (info == null) return;
                txbname.Text = info.name.Trim().ToString(); //商家名称
                txbctype.Text = info.ctype.Trim().ToString();//商家类型
                txbbusiness.Text = info.business.Trim().ToString();//经营范围
                txbtel.Text = info.tel.Trim().ToString();//电话
                txbfax.Text = info.fax.Trim().ToString();//传真
                txbqq.Text = info.qq.Trim().ToString();//QQ
                txbwx.Text = info.wx.Trim().ToString();//微信
                txbDescription.Text = info.description.Trim().ToString();//描述
                wxqrcodeimgview = "<img src=\"" + info.wxqrcode + "\" style=\"max-width:200px;\">";//二维码
                sellerimgview = "<img src=\"" + info.sellerimg + "\" style=\"max-width:200px;\">";//商家背景图
                wxqrcode = info.wxqrcode;
                sellerimg = info.sellerimg;
                txbAddress.Text = info.address.Trim().ToString();//地址
            }
            else
            {
                Response.Write("<script>alert(\"参数错误，信息绑定失败\");</script>");
                return;
            }

        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (sellerid <= 0)
            {
                Response.Write("<script>alert(\"参数错误\");</script>");
                return;
            }

            Model.SellerInfo info = BLL.SellerBLL.GetModel(sellerid);
            info.name = txbname.Text.Trim().ToString();
            info.ctype = txbctype.Text.Trim().ToString();
            info.address = txbAddress.Text.Trim().ToString();
            info.tel = txbtel.Text.Trim().ToString();
            info.fax = txbfax.Text.Trim().ToString();
            info.qq = txbqq.Text.Trim().ToString();
            info.wx = txbwx.Text.Trim().ToString();
            info.wxqrcode = Request["wxqrcode"] != null ? Request["wxqrcode"].ToString() : "";
            info.sellerimg = Request["txbsellerimg"] != null ? Request["txbsellerimg"].ToString() : "";
            info.business = txbbusiness.Text.Trim().ToString();
            info.description = txbDescription.Text.Trim().ToString();

            int result = BLL.SellerBLL.Update(info);
            if (result <= 0)
            {
                Response.Write("<script>alert(\"保存失败\");</script>");
            }
            Response.Write("<script>alert(\"保存成功\");window.parent.location.href=\"editseller.aspx\";</script>");

        }
    }
}