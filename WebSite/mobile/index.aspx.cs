using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;
using Model;
namespace WebSite.mobile
{
    public partial class index : m_basepage
    {
        protected long uid = BLL.memberBLL.getLogin_uid();
        protected int page;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ajaxmethod = Request["ajaxmethod"] != null ? Request["ajaxmethod"].ToString().ToLower() : "";
                if (ajaxmethod.Trim().Length > 0)
                {
                    switch (ajaxmethod)
                    {
                        case "bindmessgaelist":
                            if (page <= 0)
                                page = 1;
                            //Response.Write(bindmessgaelist());
                            //Response.End();
                            break;
                    }
                }

            }
        }

        protected string bindSellerMessage()
        {
            List<SellerInfo> l_SellerInfo = BLL.SellerBLL.GetList(3, "", "");
            return "";
        }

    }


}