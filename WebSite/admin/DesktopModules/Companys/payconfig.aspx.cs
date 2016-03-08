using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace WebSite.admin.DesktopModules.Companys
{
    public partial class payconfig : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "companys";
                id = Common.Utils.ObjectToStr(Request["id"]);
                bind();

            }
        }
        protected string id
        {
            get { return ViewState["id"] != null ? ViewState["id"].ToString() : ""; }
            set { ViewState["id"] = value; }
        }

        protected string title = "";
        private void bind()
        {
            if (id.Trim().Length > 0)
            {
                CompanysInfo info = BLL.CompanysBLL.GetModel(id);
                if (info == null || !info.CompanyID.ToString().Equals(id))
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
                {
                    if (!base.Equals(id))
                    {
                        Response.Write("<script>alert('你没有编辑此信息的权限');history.go(-1);</script>");
                        return;
                    }
                }
                title = info.CompanyName + " - ";
                Companys_PayConfigInfo pinfo = Companys_PayConfigBLL.GetModel(id);
                if (pinfo != null && pinfo.CompanyId.Equals(id))
                {
                    txbAppId.Text = pinfo.AppId;
                    txbMchId.Text = pinfo.MchId;
                    txbAppKey.Text = pinfo.AppKey;
                    txbAppSecret.Text = pinfo.AppSecret;
                    txbToken.Text = pinfo.Token;
                    //string zm = DESEncrypt.Encrypt(id).ToLower();
                    //string jm = DESEncrypt.Decrypt(zm);
                    //str = "companyid:" + id + "  加密后：" + zm + " 解密后：" + jm;
                    txbwxapiurl.Text = "http://" + info.domain + "/api/weixin.ashx?s=" + id;
                }

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
            {
                //if (!base.siteid.Equals(id))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('你没有编辑此信息的权限');", true);
                //    return;
                //}
            }
            Companys_PayConfigInfo pinfo = new Companys_PayConfigInfo();
            pinfo.CompanyId = id;
            pinfo.AppId = txbAppId.Text.Trim();
            pinfo.MchId = txbMchId.Text.Trim();
            pinfo.AppKey = txbAppKey.Text.Trim();
            pinfo.AppSecret = txbAppSecret.Text.Trim();
            string resultmsg = "";
            int result = Companys_PayConfigBLL.edit(pinfo, ref resultmsg);
            if (result > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "location.href='companys.aspx';", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存失败，" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
    }
}