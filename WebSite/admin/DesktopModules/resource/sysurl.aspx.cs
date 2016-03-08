using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.resource
{
    public partial class sysurl : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "url";
                Repeater1bind();
                //if (base.UserType == Common.enumUserType.host || base.UserType == (int)Common.enumUserType.host)
                //{
                //    exec = true;
                //}
            }
        }
        //protected bool exec
        //{
        //    get
        //    {

        //        return ViewState["exec"] != null ? Convert.ToBoolean(ViewState["exec"]) : false;
        //    }
        //    set { ViewState["exec"] = value; }
        //}
        private void Repeater1bind()
        {
            string where = "sys=1";
            List<UrlInfo> list = BLL.UrlBLL.GetList(-1, where, "");
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                //int id = Convert.ToInt32(e.CommandArgument);
                //bool b = BLL.UrlBLL.Delete(id);
                //if (b)
                //{ Repeater1bind(); }
                //else
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                //}

            } if (e.CommandName == "update")
            {
                //int id = Convert.ToInt32(e.CommandArgument);
                //UrlInfo info = BLL.UrlBLL.GetModel(id);
                //if (info != null && info.id == id)
                //{
                //    txbname.Text = info.name;
                //    txburl.Text = info.url;
                //    hfid.Value = info.id.ToString();
                //}
                //else
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('无效的id！');", true);
                //}

            }
        }

        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    int id = int.Parse(hfid.Value);
        //    string name = txbname.Text.Trim();
        //    string url = txburl.Text.Trim();
        //    if (name.Trim().Length == 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请填写名称！');", true);
        //        return;
        //    }
        //    if (url.Trim().Length == 0)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请填写url！');", true);
        //        return;
        //    }
        //    int result = 0;
        //    if (id > 0)
        //    {
        //        string resultMsg = "";
        //        result = BLL.UrlBLL.Update(id, name, url, true, ref resultMsg);
        //        if (result > 0)
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "location.href = location.href;", true);
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
        //        }
        //    }
        //    else
        //    {
        //        string resultMsg = "";
        //        result = BLL.UrlBLL.Add(name, url, true, ref resultMsg);
        //        if (result > 0)
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "location.href = location.href;", true);
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
        //        }
        //    }
        //}
    }
}