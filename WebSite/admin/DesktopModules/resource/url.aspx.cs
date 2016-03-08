using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;

namespace WebSite.admin.DesktopModules.resource
{
    public partial class url : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "url";
                Repeater1bind();
            }
        }

        private void Repeater1bind()
        {
            string where = "sys=0";
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.UrlBLL.GetPager(PageSize, CurrentPage, where, "id desc", "*", ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = BLL.UrlBLL.Delete(id, "id");
                if (b > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
            if (e.CommandName == "update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                UrlInfo info = BLL.UrlBLL.GetModel(id);
                if (info != null && info.id == id)
                {
                    txbname.Text = info.name;
                    txburl.Text = info.url;
                    hfid.Value = info.id.ToString();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('无效的id！');", true);
                }

            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hfid.Value);
            string name = txbname.Text.Trim();
            string url = txburl.Text.Trim();
            if (name.Trim().Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请填写名称！');", true);
                return;
            }
            if (url.Trim().Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请填写url！');", true);
                return;
            }
            UrlInfo info = new UrlInfo();
            if (id > 0)
            {
                info = BLL.UrlBLL.GetModel(id);
                if (info == null || info.id != id)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('参数错误，无对应的数据！');", true);
                    return;
                }
            }
            else
            {
                info.companyid = "";
            }
            info.name = name;
            info.url = url;

            if (info.companyid == null || info.companyid.Trim().Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('分站ID错误！');", true);
                return;
            }


            int result = 0;
            if (id > 0)
            {
                string resultMsg = "";
                result = BLL.UrlBLL.Update(info);
                if (result > 0)
                {
                    Repeater1bind();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交成功！');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }
            }
            else
            {


                string resultMsg = "";
                result = BLL.UrlBLL.Add(name, url, false, "", ref resultMsg);
                if (result > 0)
                {
                    Repeater1bind();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交成功！');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }
            }
        }
    }
}