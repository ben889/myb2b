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
    public partial class EditUsers : basePage
    {
        /// <summary>
        /// 前一page的URL
        /// </summary>
        public string lastpage
        {
            get { try { return ViewState["lastpage"].ToString(); } catch { return ""; } }
            set { ViewState["lastpage"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckModulePermission("Users", "view");

            #region //ajax处理
            try
            {
                switch (Request["ajaxmethod"].ToString().ToLower().Trim())
                {
                    case "checkusername":
                        Response.Write(CheckUserName(Convert.ToInt32(Request["userid"].ToString().Trim()), Request["username"].ToString().Trim()).ToString());
                        Response.End();
                        break;
                }
            }
            catch
            {

            }
            #endregion
            if (!IsPostBack)
            {
                base.TabKey = "all";
                try { lastpage = Request.ServerVariables["HTTP_REFERER"].ToString(); }
                catch { }
                userid = Common.Utils.ObjectToint(Request.QueryString["userid"]);
                bind();
            }
            //setpagestyle();
        }

        protected int userid
        {
            get { try { return ViewState["userid"] != null ? Convert.ToInt32(ViewState["userid"]) : 0; } catch { return 0; } }
            set { ViewState["userid"] = value; }
        }

        private void bind()
        {
            if (userid > 0)
            {
                bindform();
            }
        }
        /// <summary>
        /// 控制页面导行选择卡样式
        /// </summary>
        //private void setpagestyle()
        //{
        //    if (userid > 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "$(document).ready(function(){settingnav(true);});", true);
        //    }
        //    else
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "$(document).ready(function(){settingnav(false);});", true);
        //}

        /// <summary>
        /// 验证帐号是否存在(1为存在0为不存在-1异常)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private int CheckUserName(int userid, string username)
        {
            //return Components.UsersController.CheckUserName(userid, username);
            bool b = BLL.UsersBLL.IsExist("userid=" + userid + " and username='" + username + "'");
            return b ? 1 : 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (userid <= 0)
                {
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
                }
                Model.UserInfo info = new Model.UserInfo();
                if (userid > 0)
                {
                    info = BLL.UsersBLL.GetModel(userid);
                    if (info == null || info.UserID != userid)
                        return;
                }
                info.UserName = txbUserName.Text.Trim();
                info.DisplayName = txbDisPlayName.Text.Trim();
                
                info.FirstName = txbFirstName.Text.Trim();
                info.LastName = txbLastName.Text.Trim();
                info.Email = txbEmail.Text.Trim();
                info.IsLock = rbNoIsLockedOut.Checked == true ? false : true;
                

                int returnval = 0;
                string resultMsg = "";
                if (info.UserID > 0)
                {
                    returnval = BLL.UsersBLL.Update(info);
                    if (returnval > 0)
                    {
                        bindform();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改成功！');", true);
                    }
                    else
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('修改失败！');", true);
                }
                else
                {
                    if (info.PassWord.Trim().Length < 6)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('密码必须6位以上！');", true);
                        return;
                    }
                    info.PassWord = Common.Utility.MD5Encrypt(txbPassWord2.Text.Trim());
                    info.UserType = Common.enumUserType.company.ToString();
                    info.CreatedOnDate = DateTime.Now;
                    info.LastLoginDate = DateTime.Now;
                    returnval = BLL.UsersBLL.Add(info, ref resultMsg);
                    if (returnval > 0)
                    {
                        defaultform();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('添加成功！');", true);
                    }
                    else
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('添加失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败," + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnreturn_Click(object sender, EventArgs e)
        {

            if (lastpage != null && lastpage.Length > 0)
                Response.Redirect(lastpage);
            //else
            //    Response.Redirect("ViewUsers.aspx");
        }

        private void bindform()
        {
            if (userid > 0)
            {
                Model.UserInfo info = BLL.UsersBLL.GetModel(userid);
                if (info != null && info.UserID > 0)
                {
                    hfUserId.Value = info.UserID.ToString();
                    txbUserName.Text = info.UserName;
                    txbUserName.Enabled = false;
                    txbDisPlayName.Text = info.DisplayName;
                    passrow.Visible = false;
                    txbFirstName.Text = info.FirstName;
                    txbLastName.Text = info.LastName;
                    txbEmail.Text = info.Email;
                    if (!info.IsLock)
                    {
                        rbNoIsLockedOut.Checked = true;
                        rbIsLockedOut.Checked = false;
                    }
                    else
                    {
                        rbNoIsLockedOut.Checked = false;
                        rbIsLockedOut.Checked = true;
                    }

                    if (info.UserType == Common.enumUserType.host.ToString())
                    {
                        rbNoIsLockedOut.Enabled = rbIsLockedOut.Enabled = false;
                    }
                    btnsave.Enabled = true;
                    btnsave.Text = "修改";
                }
            }
        }

        private void defaultform()
        {
            hfUserId.Value = "0";
            txbUserName.Text = "";
            txbDisPlayName.Text = "";
            passrow.Visible = true;
            txbPassWord.Text = "";
            txbPassWord2.Text = "";
            txbFirstName.Text = "";
            txbLastName.Text = "";
            txbEmail.Text = "";
            rbNoIsLockedOut.Checked = true;
            rbIsLockedOut.Checked = false;
            btnsave.Enabled = false;
            btnsave.Text = "添加";
        }
    }
}
