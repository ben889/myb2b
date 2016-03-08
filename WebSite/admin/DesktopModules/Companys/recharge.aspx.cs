using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Web.UI;

namespace WebSite.admin.DesktopModules.Companys
{
    public partial class recharge : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
                {
                    Response.Write("<script>alert('只能管理员帐号才能使用此功能');history.go(-1);</script>");
                    return;
                }
                base.TabKey = "companys-recharge";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                bind();

            }
        }
        protected int id
        {
            get { 
                try{
                    return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0;
                }catch{}
                return 0;
            }
            set { ViewState["id"] = value; }
        }
        private void bind()
        {
            if (id > 0)
            {

                hfCompanyID.Value = id.ToString();
                CompanysInfo info = BLL.CompanysBLL.GetModel(id);
                if (info == null || info.CompanyID != id)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                
                lbcompanyname.Text = info.CompanyName;
                string totalamount = Math.Round(info.totalamount, 2, MidpointRounding.AwayFromZero).ToString();
                lbtotalamount.Text = "￥" + totalamount;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
        protected void save()
        {
            try
            {
                decimal amount = decimal.Parse(txbamount.Text.Trim());
                string resultmsg = "";
                int result = CompanysBLL.updatetotalamount(amount, id, base.UserID, ref resultmsg);
                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('充值成功');location.href='companys.aspx';", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('充值失败" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
    }
}