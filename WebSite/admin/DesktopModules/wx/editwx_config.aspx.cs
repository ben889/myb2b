using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class editwx_config : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_config";
                bind();
            }
        }

        private void bind()
        {
            if (base.e_usertype != Common.enumUserType.host && base.e_usertype != Common.enumUserType.admin)
            {
                Response.Write("<script>alert('你没有编辑此分站信息的权限');history.go(-1);</script>");
                Response.End();
            }
            wx_configInfo pinfo = wx_configBLL.getInfo();
            if (pinfo != null)
            {
                txbAppId.Text = pinfo.AppId;
                txbMchId.Text = pinfo.MchId;
                txbAppKey.Text = pinfo.AppKey;
                txbAppSecret.Text = pinfo.AppSecret;
                txbToken.Text = pinfo.Token;
                //string zm = DESEncrypt.Encrypt(id).ToLower();
                //string jm = DESEncrypt.Decrypt(zm);
                //str = "companyid:" + id + "  加密后：" + zm + " 解密后：" + jm;
                txbwxapiurl.Text = Common.Constant.Get_Host() + "/api/weixin.ashx";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (base.e_usertype != Common.enumUserType.host && base.e_usertype != Common.enumUserType.admin)
            {
                    Response.Write("<script>alert('你没有编辑此分站信息的权限');history.go(-1);</script>");
                    return;
            }
            wx_configInfo pinfo = new wx_configInfo();
            pinfo.AppId = txbAppId.Text.Trim();
            pinfo.MchId = txbMchId.Text.Trim();
            pinfo.AppKey = txbAppKey.Text.Trim();
            pinfo.AppSecret = txbAppSecret.Text.Trim();
            string resultmsg = "";
            int result = wx_configBLL.edit(pinfo, ref resultmsg);
            if (result > 0)
            {
                bind();
                Response.Write("<script>alert('保存成功');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存失败，" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
    }
}