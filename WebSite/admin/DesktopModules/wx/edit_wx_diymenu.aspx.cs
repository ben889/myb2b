using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class edit_wx_diymenu : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_diymenu";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                parentid = Common.Utils.ObjectToint(Request["parentid"]);
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
            ddlparentidbind();
            if (id > 0)
            {
                wx_diymenuInfo info = BLL.wx_diymenuBLL.GetModel(id);
                txbName.Text = info.Name;
                txbSort.Text = info.Sort.ToString();

                try { ddlparentid.SelectedValue = info.ParentId.ToString(); }
                catch { }
            }
            else
            {
                txbSort.Text = "99";
            }
        }
        protected void ddlparentidbind()
        {
            ddlparentid.Items.Clear();
            ddlparentid.Items.Add(new ListItem("无父级分类", "0"));
            string where = "1=1";
            if (id > 0)
                where = "[MenuId]<>" + id;
            DataTable dt = publicBLL.GetDt("wx_diymenu", -1, where, "");
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "MenuId", "name", ddlparentid, -1);
            if (parentid > 0)
            {
                try { ddlparentid.SelectedValue = parentid.ToString(); }
                catch { }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txbName.Text.Trim();
                int Sort = txbSort.Text.Trim().Length == 0 ? 0 : int.Parse(txbSort.Text.Trim());
                int State = int.Parse(ddlState.SelectedValue);
                Model.wx_diymenuInfo model = new Model.wx_diymenuInfo();
                if (id > 0)
                {
                    model = BLL.wx_diymenuBLL.GetModel(id);
                    if (model == null || model.MenuId != id)
                    {
                        Response.Write("<script>parent.fail('无对应的数据');</script>");
                        return;
                    }
                }
                model.Name = Name;
                model.ParentId = int.Parse(ddlparentid.SelectedValue);
                model.Sort = Sort;
                model.State = State;
                int result = 0;
                string resultMsg = "";
                if (id > 0)
                { result = BLL.wx_diymenuBLL.Update(model); }
                else
                {
                    model.companyid = "";
                    model.CreateTime = DateTime.Now;
                    result = BLL.wx_diymenuBLL.add(model, ref resultMsg);
                }
                if (result > 0)
                {
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                }
            }
            catch (Exception exc) { Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>"); }

        }
    }
}