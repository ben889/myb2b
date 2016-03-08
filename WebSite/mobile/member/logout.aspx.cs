using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.mobile.member
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri Url = HttpContext.Current.Request.UrlReferrer;
                BLL.memberBLL.Exit();
                string url = Url.ToString();
                Response.Redirect(url);
            }
        }
    }
}