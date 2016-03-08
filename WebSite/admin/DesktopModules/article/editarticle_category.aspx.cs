using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
using System.Collections;
using BLL;
using Web.UI;

namespace WebSite.admin.DesktopModules.article
{
    public partial class editarticle_category : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "article";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                parentid = Request["parentid"] != null ? Convert.ToInt32(Request["parentid"]) : 0;

                bind();
            }
        }
        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }
        protected int parentid
        {
            get { return ViewState["parentid"] != null ? Convert.ToInt32(ViewState["parentid"]) : 0; }
            set { ViewState["parentid"] = value; }
        }
        private void bind()
        {
            ddlarticle_categorybind();
            if (id > 0)
            {
                hfid.Value = id.ToString();
                article_categoryInfo info = BLL.article_categoryBLL.GetModel(id);
                txbtitle.Text = info.title;
                txborderby.Text = info.orderby.ToString();

                try { ddlarticle_category.SelectedValue = info.parentid.ToString(); }
                catch { }
            }
            else
            {
                txborderby.Text = "99";
            }
        }
        protected void ddlarticle_categorybind()
        {
            ddlarticle_category.Items.Clear();
            ddlarticle_category.Items.Add(new ListItem("无父级分类", "0"));
            string where = "";
            if (id > 0)
                where = "id<>" + id;
            DataTable dt = article_categoryBLL.GetDt(-1, where, "");
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "id", "title", ddlarticle_category, -1);
            if (parentid > 0)
            {
                try { ddlarticle_category.SelectedValue = parentid.ToString(); }
                catch { }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            int id = hfid.Value != null ? int.Parse(hfid.Value) : 0;
            string title = txbtitle.Text;
            int orderby = txborderby.Text.Trim().Length == 0 ? 0 : int.Parse(txborderby.Text.Trim());
            Model.article_categoryInfo model = new Model.article_categoryInfo();
            if (id > 0)
            {
                model = BLL.article_categoryBLL.GetModel(id);
                if (model == null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('id错误');", true);
                    return;
                }
            }
            model.id = id;
            model.title = title;
            model.parentid = int.Parse(ddlarticle_category.SelectedValue);
            model.orderby = orderby;
            int result = 0;
            string resultMsg = "";
            if (id > 0)
            { result = BLL.article_categoryBLL.Update(model, ref resultMsg); }
            else
                result = BLL.article_categoryBLL.Add(model, ref resultMsg);
            if (result > 0)
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交成功！');", true);
                Response.Redirect("article_category.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("article_category.aspx");
        }
    }
}