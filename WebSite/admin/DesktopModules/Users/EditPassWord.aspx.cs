using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebSite.admin;

namespace Users
{
    public partial class EditPassWord : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckModulePermission("Users", "view");
            base.TabKey = "all";
            if (!IsPostBack)
            {
                try { ComeUrl = Request.ServerVariables["HTTP_REFERER"].ToString(); }
                catch { }
                userid = Common.Utils.ObjectToint(Request["userid"]);
                bind();
            }
        }
        /// <summary>
        /// 前一page的URL
        /// </summary>
        public string ComeUrl
        {
            get { try { return ViewState["ComeUrl"].ToString(); } catch { return ""; } }
            set { ViewState["ComeUrl"] = value; }
        }
        protected int userid
        {
            get { return ViewState["userid"] != null ? Convert.ToInt32(ViewState["userid"]) : 0; }
            set { ViewState["userid"] = value; }
        }
        private void bind()
        {
            if (userid > 0)
            {
                Model.UserInfo info = BLL.UsersBLL.GetModel(userid);
                if (info != null && info.UserID > 0)
                {
                    hfUserId.Value = info.UserID.ToString();
                    lbUserName.Text = info.UserName;
                    txbPassWord.Text = info.PassWord;
                    txbPassWord2.Text = info.PassWord;
                }
            }
        }
        /// <summary>
        /// 控制页面样式
        /// </summary>
        //private void setpagestyle()
        //{
        //    if (userid > 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "$(document).ready(function(){settingnav(true);});", true);
        //    }
        //    else
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "$(document).ready(function(){settingnav(false);});", true);
        //}
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (userid <= 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('id错误');", true);
                    return;
                }
                string password = txbPassWord.Text.Trim();
                string password2 = txbPassWord2.Text.Trim();
                if (password.Trim().Length < 6)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('密码必须6位以上！');", true);
                    return;
                }
                if (!password2.Equals(password))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('密码不一致！');", true);
                    return;
                }
                string newPassWord = Common.Utility.MD5Encrypt(password2);
                //int returnval = BLL.UsersBLL.Update("Users", "PassWord='" + newPassWord + "'", "userid=" + hfUserId.Value); //Components.UsersController.UpdatePassWord(newPassWord, Convert.ToInt32(hfUserId.Value));
                Model.UserInfo user = new Model.UserInfo();
                user.UserID = int.Parse(hfUserId.Value);
                user.PassWord = newPassWord;
                int returnval = BLL.UsersBLL.Update(user, "PassWord");
                if (returnval > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改成功！');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改失败！');", true);
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改失败," + exc.Message.Replace("'", "").Replace("\n", "").Replace("\r", "") + "！');", true);
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnreturn_Click(object sender, EventArgs e)
        {
            if (ComeUrl.Length > 0)
                Response.Redirect(ComeUrl);
        }
    }
}
