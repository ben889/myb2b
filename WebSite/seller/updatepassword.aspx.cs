using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.seller
{
    public partial class updatepassword : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            string oldpass = txboldpass.Text.Trim();
            if (oldpass.Trim().Length == 0)
            {
                Response.Write("<script>alert(\"请输入旧密码\");</script>");
                return;
            }
            string newpass = txbpassword.Text.Trim();
            string newpass2 = txbpassword2.Text.Trim();
            if (newpass.Trim().Length < 6)
            {
                Response.Write("<script>alert(\"请输入6位以上的新密码\");</script>");
                return;
            }
            if (!newpass2.Equals(newpass))
            {
                Response.Write("<script>alert(\"密码不一至\");</script>");
                return;
            }
            Model.SellerInfo info = BLL.SellerBLL.GetModel(sellerid);
            if (!Common.Utility.MD5Encrypt(oldpass.Trim()).Equals(info.password))
            {
                Response.Write("<script>alert(\"旧密码不正确\");</script>");
                return;
            }
            info.password = Common.Utility.MD5Encrypt(newpass2);
            int result = BLL.SellerBLL.Update(info);
            if (result <= 0)
            {
                Response.Write("<script>alert(\"保存失败\");</script>");
            }
            Response.Write("<script>alert(\"保存成功\");window.parent.location.href=\"editseller.aspx\";</script>");

        }
    }
}