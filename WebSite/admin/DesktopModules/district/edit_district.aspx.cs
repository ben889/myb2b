using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.district
{
    public partial class edit_district : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "district";
                if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
                {
                    Response.Write("<script>alert('超级帐号才有编辑权限');history.go(-1);</script>");
                    Response.End();
                }
                id = Common.Utils.ObjectToint(Request.QueryString["id"]);
                parentid = Common.Utils.ObjectToint(Request.QueryString["parentid"]);
                bind();
                ddldistrictbind();
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
        protected string title="添加省份";
        protected void bind()
        {
            if (id > 0 && parentid > 0)
            {
                Response.Write("<script>alert('参数错误');history.go(-1);</script>");
                Response.End();
            }
            if (id > 0)
            {
                hfid.Value = id.ToString();
                DistrictInfo info = BLL.DistrictBLL.GetModel(id);
                if (info == null || info.DistId!=id)
                {
                    Response.Write("<script>alert('不存在对应的数据');history.go(-1);</script>");
                    Response.End();
                }
                this.txbName.Text = info.Name;
                txbcall_index.Text = info.call_index;
                txbSort.Text = info.Sort.ToString();
                parentid = info.ParentId;
                if (parentid == 0)
                {
                    title = "修改省份";
                }
            }
            else {
                if (parentid == 0)
                {
                    title = "添加省份";
                }
                else {
                    DistrictInfo model = BLL.DistrictBLL.GetModel(parentid);
                    if (model == null || model.DistId != parentid)
                    {
                        Response.Write("<script>alert('参数parentid错误');history.go(-1);</script>");
                        Response.End();
                    }
                    if (model.ParentId==0)
                        title = "添加城市";
                    else
                        title = "添加(区、县)";
                }
            }
        }

        protected void ddldistrictbind()
        {
            ddldistrict.Items.Clear();
            ddldistrict.Items.Add(new ListItem("无父级区域", "0"));
            string where = "";
            if (id > 0)
                where = "DistId<>" + id;
            DataTable dt = publicBLL.GetDt("District", -1, where, "");
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "DistId", "name", ddldistrict, -1);
            if (parentid > 0)
            {
                try { ddldistrict.SelectedValue = parentid.ToString(); }
                catch { }
            }
            ddldistrict.Enabled = false;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbName.Text;
                int sort = txbSort.Text.Trim().Length == 0 ? 0 : int.Parse(txbSort.Text.Trim());
                Model.DistrictInfo model = new Model.DistrictInfo();
                if (id > 0)
                {
                    model = BLL.DistrictBLL.GetModel(id);
                    if (model == null || model.DistId != id)
                    {
                        Response.Write("<script>parent.fail('id错误');</script>");
                        return;
                    }
                }
                model.Name = name;
                model.call_index = txbcall_index.Text.Trim();
                model.Sort = sort;
                int result = 0;
                string resultMsg = "";
                if (id > 0)
                { 
                    result = BLL.DistrictBLL.update(model, ref resultMsg);
                }
                else
                {
                    model.ParentId = int.Parse(ddldistrict.SelectedValue);
                    result = BLL.DistrictBLL.add(model, ref resultMsg);
                }
                if (result > 0)
                {
                    Response.Write("<script>parent.success('保存成功');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('保存失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.fail('保存失败！" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }
    }
}