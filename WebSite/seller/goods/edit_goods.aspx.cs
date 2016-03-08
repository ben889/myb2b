using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.seller.goods
{
    public partial class edit_goods : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Common.Utils.ObjectToint(Request["id"]);
                bind();
            }
        }

        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }

        protected string img;
        protected string imgview;
        protected string content;
        /// <summary>
        /// 绑定
        /// </summary>
        protected void bind()
        {
            ddlgoods_category_bind();
            if (id > 0)
            {
                Model.goodsInfo info = BLL.goodsBLL.GetModel(id);
                txbDescription.Text = info.Description;
                content = info.Content;
                txbTotalCount.Text = info.TotalCount.ToString();
                txbExchCount.Text = info.ExchCount.ToString();
                //txbViewCount.Text = info.ViewCount.ToString();
                txbPurchase.Text = info.Purchase.ToString();
                txbGoodsName.Text = info.GoodsName;
                txbPrice.Text = info.Price.ToString();
                StartDate.Value = info.StartDate.ToString("yyyy-MM-dd");
                EndDate.Value = info.EndDate.ToString("yyyy-MM-dd");
                cbxStatus.Checked = info.Status == 1 ? true : false;
                img = info.Img;
                if (info.Img.Trim().Length > 0)
                    imgview = "<img src=\"" + info.Img + "\" height=\"100px\" />";
                try { ddlGoodsType.SelectedValue = info.GoodsType.ToString(); }
                catch { }
                if (info.goods_category_id > 0)
                {
                    try
                    {
                        ddlgoods_category.SelectedValue = info.goods_category_id.ToString();
                    }
                    catch { }
                }
            }

        }
        protected void ddlgoods_category_bind()
        {
            ddlgoods_category.Items.Clear();
            ddlgoods_category.Items.Add(new ListItem("商品类别", "0"));
            string where = "";

            DataTable dt = publicBLL.GetDt("goods_category", -1, where, "");
            //ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "goods_category_id", "goods_category_name", ddlgoods_category, -1);
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                if (files != null && files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        System.Web.HttpPostedFile file = files[i];
                        if (file.ContentLength > 500 * 1024)
                        {
                            Response.Write("<script>parent.fail('图片大小不能超过500K！');</script>");
                            return;
                        }
                    }
                }

                Model.goodsInfo info = new Model.goodsInfo();
                if (id > 0)
                {
                    info = BLL.goodsBLL.GetModel(id);
                    if (info == null || info.GoodsId != id)
                    {
                        return;
                    }
                }
                info.sellerid = sellerid;
                //info.companyid = 0;// companyid;
                info.GoodsName = this.txbGoodsName.Text;
                info.Price = Convert.ToDecimal(this.txbPrice.Text);
                info.Description = this.txbDescription.Text;
                info.Content = Common.Utils.ObjectToStr(Request["content"]);
                info.TotalCount = Convert.ToInt32(this.txbTotalCount.Text);
                info.ExchCount = Convert.ToInt32(this.txbExchCount.Text);
                //info.ViewCount = Convert.ToInt32(this.txbViewCount.Text);
                info.Status = cbxStatus.Checked ? 1 : 0;//
                info.Purchase = Convert.ToInt32(this.txbPurchase.Text);
                info.GoodsType = Convert.ToInt32(this.ddlGoodsType.SelectedValue);
                info.StartDate = Convert.ToDateTime(this.StartDate.Value);
                info.EndDate = Convert.ToDateTime(this.EndDate.Value);
                info.Img = Common.Utils.ObjectToStr(Request["txbimg"]);
                //info.siteid = sellerinfo.siteid;
                string result = "";
                int resultnum = 0;
                if (id > 0)
                {
                    resultnum = BLL.goodsBLL.update(info, ref result);
                }
                else
                {
                    resultnum = BLL.goodsBLL.add(info, ref result);
                }
                if (resultnum > 0)
                {
                    Response.Write("<script>parent.success('');</script>");
                }
                else
                    Response.Write("<script>parent.fail('添加失败！" + result.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }

        }



    }
}