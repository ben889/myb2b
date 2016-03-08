using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.console
{
    public partial class datainit : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "datainit";
            }
        }

        protected void btn_init_Click(object sender, EventArgs e)
        {
            try
            {
                new BLL.DataInit();
                Response.Write("<script>parent.success(\"完成初始化\");</script>");
            }
            catch (Exception exc)
            {

                Response.Write("<script>parent.fail('" + exc.Message.Replace("\"", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }
    }
}