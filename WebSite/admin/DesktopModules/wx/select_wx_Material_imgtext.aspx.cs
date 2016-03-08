using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class select_wx_Material_imgtext : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx";
                bindlist();
            }
        }
        protected List<wx_MaterialInfo> list;
        private void bindlist()
        {
            string where = "parentid=0";
            list = BLL.wx_MaterialBLL.GetList(-1, where, "CreateTime asc");
        }
    }
}