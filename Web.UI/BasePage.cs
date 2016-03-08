using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePage()
        {
            ShowPage();
        }
        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            //虚方法代码
            
        }

        public Common.enumUserType e_usertype;

        protected override void OnLoad(EventArgs e)
        {
            if (userinfo == null || UserID <= 0)
            {
                return;
            }

           

            e_usertype = (Common.enumUserType)Enum.Parse(typeof(Common.enumUserType), UserType);
            base.OnLoad(e);
            if (this.UserType != Common.enumUserType.host.ToString() && this.UserType != Common.enumUserType.admin.ToString())
            {
                if (TabKey != null && TabKey.Length > 0)
                {

                    if (!TabKey.Trim().ToLower().Equals("all"))
                    {
                        bool isVIEW = PermissionBLL.GetPermission(TabKey, this.UserID, enum_userpermission.VIEW.ToString());
                        if (!isVIEW)
                        {
                            //Response.Write("<script language='javascript'>alert('无查看此页面权限！');</script>");
                            Response.Write("<div style='color:red;font-size:14px;text-align:center;margin-top:10px;'>无查看权限！</div>");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.Write("<div style='color:red;font-size:14px;text-align:center;margin-top:10px;'>无查看权限！</div>");
                    Response.End();
                }
            }
        }

        #region 帐号信息
        public UserInfo userinfo
        {
            get
            {
                UserInfo Entity = BLL.UsersBLL.UserEntity;
                if (Entity != null && Entity.UserID > 0)
                {
                    return Entity;
                }
                else
                    return null;
            }
        }
        public int UserID
        {
            get
            {
                if (userinfo != null && userinfo.UserID > 0)
                {
                    return userinfo.UserID;
                }
                else
                    return 0;
            }
        }
        public string UserName
        {
            get
            {
                if (userinfo != null && userinfo.UserID > 0)
                {
                    return userinfo.UserName;
                }
                else
                    return "";
            }
        }
        public string UserType
        {
            get
            {
                if (userinfo != null && userinfo.UserID > 0)
                {
                    return userinfo.UserType;
                }
                else
                    return "";
            }
        }
        #endregion

        public string TabKey
        {
            get
            {
                try
                {
                    return ViewState["TabKey"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                ViewState["TabKey"] = value;
            }
        }

        #region 页面通用方法==========================================
        /// <summary>
        /// 返回URL链接地址
        /// </summary>
        public string linkurl(string url, params string[] _params)
        {
            string langQuery = HttpContext.Current.Request["lang"] != null ? HttpContext.Current.Request["lang"].ToString() : "";

            for (int i = 0; i < _params.Length; i++)
            {
                if (_params[i].Trim().Length == 0)
                    continue;
                if (i == 0)
                {
                    if (url.IndexOf("?") == -1)
                        url += "?" + _params[i];
                    else
                        url += "&" + _params[i];
                }
                else
                    url += "&" + _params[i];

            }
            if (langQuery.Trim().Length > 0)
            {
                if (url.IndexOf("?") == -1)
                    url += "?lang=" + langQuery.Trim();
                else
                    url += "&lang=" + langQuery.Trim();
            }
            return url;
        }
        #endregion
    }
}
