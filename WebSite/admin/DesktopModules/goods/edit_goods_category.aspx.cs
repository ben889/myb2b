using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.goods
{
    public partial class edit_goods_category : basePage
    {
        protected int goods_category_id = 0;
        protected int parentid = 0;
        protected string imgview = "";
        protected string img = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "goods";
                goods_category_id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                parentid = Request["parentid"] != null ? Convert.ToInt32(Request["parentid"]) : 0;
                bind();
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        private void bind()
        {
            ddlgoods_categorybind();
            if (goods_category_id > 0)
            {
                hfgoods_category_id.Value = goods_category_id.ToString();
                goods_categoryInfo info = BLL.goods_categoryBLL.GetModel(goods_category_id);
                txbgoods_category_name.Text = info.goods_category_name;
                txbsort.Text = info.sort.ToString();
                imgview = info.img != null && info.img.Trim().Length > 0 ? "<img src=\"" + info.img + "\" height=\"100\" />" : "";
                img = info.img != null && info.img.Trim().Length > 0 ? info.img : "";

                try { ddlgoods_category.SelectedValue = info.parentid.ToString(); }
                catch { }
            }
            else
            {
                txbsort.Text = "99";
            }
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        protected void ddlgoods_categorybind()
        {
            ddlgoods_category.Items.Clear();
            ddlgoods_category.Items.Add(new ListItem("无父级分类", "0"));
            string where = "";
            if (goods_category_id > 0)
                where = "goods_category_id<>" + goods_category_id;
            DataTable dt = publicBLL.GetDt("goods_category", -1, where, "");
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "goods_category_id", "goods_category_name", ddlgoods_category, -1);
            if (parentid > 0)
            {
                try { ddlgoods_category.SelectedValue = parentid.ToString(); }
                catch { }
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {

            int goods_category_id = hfgoods_category_id.Value != null ? int.Parse(hfgoods_category_id.Value) : 0;
            string goods_category_name = txbgoods_category_name.Text;
            int sort = txbsort.Text.Trim().Length == 0 ? 0 : int.Parse(txbsort.Text.Trim());
            Model.goods_categoryInfo model = new Model.goods_categoryInfo();
            model.goods_category_id = goods_category_id;
            model.goods_category_name = goods_category_name;
            model.parentid = int.Parse(ddlgoods_category.SelectedValue);
            model.sort = sort;
            model.img = Common.Utils.ObjectToStr(Request["txbimg"]); // 图片
            int result = 0;
            string resultMsg = "";
            if (goods_category_id > 0)
            { result = BLL.goods_categoryBLL.update(model, ref resultMsg); }
            else
                result = BLL.goods_categoryBLL.add(model, ref resultMsg);
            if (result > 0)
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交成功！');", true);
                Response.Redirect("goods_category.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }
    }
}