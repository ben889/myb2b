using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin.DesktopModules.Ad
{
    public partial class editAdPosition : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "adposition";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                bind();

            }
        }

        protected int id = 0;
        protected int parentid;
        private void bind()
        {
            if (id > 0)
            {
                hfid.Value = id.ToString();
                AdPositionInfo info = BLL.AdPositionBLL.GetModel(id);
                txbname.Text = info.name;
                txbcall_index.Text = info.call_index;
                txbwidth.Text = info.width.ToString();
                txbheight.Text = info.height.ToString();
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            int id = hfid.Value != null ? int.Parse(hfid.Value) : 0;
            string name = txbname.Text;
            int width = txbwidth.Text.Trim().Length == 0 ? 0 : int.Parse(txbwidth.Text.Trim());
            int height = txbheight.Text.Trim().Length == 0 ? 0 : int.Parse(txbheight.Text.Trim());
            Model.AdPositionInfo model = new Model.AdPositionInfo();
            model.id = id;
            model.name = name;
            model.width = width;
            model.height = height;
            model.call_index = txbcall_index.Text.Trim();
            int result = 0;
            string resultMsg = "";
            if (id > 0)
            { result = BLL.AdPositionBLL.Update(model); }
            else
                result = BLL.AdPositionBLL.Add(model);
            if (result > 0)
            {
                Response.Redirect("AdPosition.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdPosition.aspx");
        }
    }
}