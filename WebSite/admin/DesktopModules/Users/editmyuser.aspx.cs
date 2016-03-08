using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.Users
{
    public partial class editmyuser : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "all";
                userid = Request["userid"] != null ? Convert.ToInt32(Request["userid"]) : 0;
                bind();

            }
        }
        protected int userid
        {
            get
            {
                try
                {
                    return ViewState["userid"] != null ? Convert.ToInt32(ViewState["userid"]) : 0;
                }
                catch { }
                return 0;
            }
            set { ViewState["userid"] = value; }
        }
        private void bind()
        {
            if (userid > 0)
            {

                hfuserid.Value = userid.ToString();
                Model.UserInfo info = BLL.UsersBLL.GetModel(userid);
                if (info == null || info.UserID != userid)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }

                lbusername.Text = info.UserName;
                txbEmail.Text = info.Email;
                txbDisplayName.Text = info.DisplayName;
                lbIsLockedOut.Text = info.IsLock ? "<span style='color:green;'>正常</span>" : "<span style='color:red;'>锁定</span>";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
        protected void save()
        {
            try
            {
                int id = int.Parse(hfuserid.Value);
                if (id<=0)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                Model.UserInfo info = BLL.UsersBLL.GetModel(id);
                if (info == null || info.UserID != id)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                info.Email = txbEmail.Text.Trim();
                info.DisplayName = txbDisplayName.Text.Trim();
                int result = BLL.UsersBLL.Update(info);
                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改成功');location.href='companys.aspx';", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改失败');", true);
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
    }
}