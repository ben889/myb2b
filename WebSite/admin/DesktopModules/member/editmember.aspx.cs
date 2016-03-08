using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using Web.UI;

namespace WebSite.admin.DesktopModules.member
{
    public partial class editmember : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "member";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                utype = Common.Utils.ObjectToint(Request["utype"]);
                bind();

            }
        }
        protected int id = 0;
        protected int utype
        {
            get
            {
                return ViewState["utype"] != null ? Convert.ToInt32(ViewState["utype"]) : 0;
            }
            set { ViewState["utype"] = value; }
        }
        protected string title = "添加";
        private void bind()
        {
            if (id > 0)
            {
                hfuid.Value = id.ToString();
                memberInfo info = BLL.memberBLL.GetModel(id);
                if (info == null || info.uid != id)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                title = "修改-" + info.uname;
                txbemail.Text = info.email;
                txbmobile.Text = info.mobile;
                txbtel.Text = info.tel;
                lbbalance.Text = info.balance.ToString();
                txbuname.Text = info.uname;
                txbpassword.Text = info.password;
                lbaddtime.Text = info.addtime.ToString();
                chkislock.Checked = info.islock;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }



        private void save()
        {
            try
            {
                string uname = txbuname.Text.Trim();
                string password = txbpassword.Text.Trim();
                memberInfo model = new memberInfo();
                long id = 0;
                model.uid = int.Parse(hfuid.Value);
                id = model.uid;
                if (id <= 0)
                {
                    if (uname.Trim().Length < 3)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('帐号必须为3位以上');", true);
                        return;
                    }
                    if (password.Trim().Length < 6)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('密码必须为6位以上');", true);
                        return;
                    }
                }
                model.email = txbemail.Text;
                model.mobile = txbmobile.Text;
                model.tel = txbtel.Text;
                model.uname = txbuname.Text;
                model.password = txbpassword.Text;
                model.vip = 0;
                model.utype = utype;
                model.addtime = DateTime.Now;
                model.displayname = "";
                model.islock = chkislock.Checked;
                long result = 0;
                string resultmsg = "";
                if (id > 0)
                {
                    result = BLL.memberBLL.update(model, ref resultmsg);
                }
                else
                {
                    result = BLL.memberBLL.Add(model, ref resultmsg);
                }

                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存成功');location.href='view.aspx';", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存失败" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }

            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

    }
}