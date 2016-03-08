using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.admin
{
    public class basePage : Web.UI.BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            
            if (userinfo == null || UserID <= 0)
            {
                Response.Write("<script language='javascript'>window.top.location = '/admin/login.html';</script>");
                Response.End();
                //Response.Redirect(SystemURL + "login.htm");
                return;
            }

            base.OnLoad(e);
        }
    }
}