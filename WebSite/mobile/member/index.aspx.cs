using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.mobile.member
{
    public partial class index : m_member_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //uid = BLL.memberBLL.getLogin_uid(companyid);
                //string url = Request.Url.ToString();
                //xw_userlogin(uid, url);
                bindmember();
            }
        }
        //protected string uid;

        protected string address;
        protected string Balance;
        protected string head;
        protected int notpay_g_lease_order_count;

        protected void bindmember()
        {
            //Common.LogUtil.WriteLog("", "个人中心_", "uid=" + uid + " openid=" + openid);
            if (uid <= 0)
                return;
            memberInfo info = BLL.memberBLL.GetModel(uid);
            if (info == null || !info.uid.Equals(uid))
                return;
            //Common.LogUtil.WriteLog("", "个人中心_", "displayname=" + info.displayname);

            uname = info.uname;

            address = info.address;
            displayname = info.displayname;
        }



    }
}