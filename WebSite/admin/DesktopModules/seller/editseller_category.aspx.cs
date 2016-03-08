using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.admin.DesktopModules.seller
{
    public partial class editseller_category : basePage
    {
        protected int id = 0; // 类型ID
        protected int parentid = 0; // 父级ID
        protected string imgview = ""; // 显示图片
        protected string img = ""; //图片路径

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "seller";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                parentid = Request["parentid"] != null ? Convert.ToInt32(Request["parentid"]) : 0;
                bind();
            }
        }

        /// <summary>
        /// 绑定
        /// </summary>
        private void bind()
        {
            ddlproducttypebind();

            if (id > 0)
            {
                hftypeid.Value = id.ToString();
                Model.Seller_categoryInfo info = BLL.Seller_categoryBLL.GetModel(id);
                txbtypename.Text = info.name;
                txborderby.Text = info.orderby.ToString();
                imgview = info.img != null && info.img.Trim().Length > 0 ? "<img src=\"" + info.img + "\" height=\"100\" />" : "";
                img = info.img != null && info.img.Trim().Length > 0 ? info.img : "";

                try { ddlproducttype.SelectedValue = info.parentid.ToString(); }
                catch { }
            }
            else
            {
                txborderby.Text = "99";
            }
        }

        /// <summary>
        /// 下拉
        /// </summary>
        protected void ddlproducttypebind()
        {
            ddlproducttype.Items.Clear();
            ddlproducttype.Items.Add(new ListItem("无父级分类", "0"));
            string where = "";
            if (id > 0)
                where = "id<>" + id;
            DataTable dt = BLL.Seller_categoryBLL.GetDt(-1, where);
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "id", "name", ddlproducttype, -1);
            if (parentid > 0)
            {
                try { ddlproducttype.SelectedValue = parentid.ToString(); }
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

            int id = hftypeid.Value != null ? int.Parse(hftypeid.Value) : 0;
            string name = txbtypename.Text;
            int orderby = txborderby.Text.Trim().Length == 0 ? 0 : int.Parse(txborderby.Text.Trim());

            Model.Seller_categoryInfo model = new Model.Seller_categoryInfo();
            model.id = id;
            model.name = name;
            model.parentid = int.Parse(ddlproducttype.SelectedValue);
            model.orderby = orderby;
            model.img = Common.Utils.ObjectToStr(Request["txbimg"]); // 图片

            int result = 0;
            string resultMsg = "";
            if (id > 0)
            { result = BLL.Seller_categoryBLL.Update(model); }
            else
                result = BLL.Seller_categoryBLL.Insert(model, ref resultMsg);
            if (result > 0)
            {
                Response.Redirect("seller_category.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnreturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("seller_category.aspx");
        }
    }
   
}