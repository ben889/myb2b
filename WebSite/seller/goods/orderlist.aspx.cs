using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.seller.goods
{
    public partial class orderlist : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1bind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Repeater1bind()
        {
            string where = "ordertype=" + (int)Common.enum_goodstype.goodstype_2;
            string orderBy = "O.createtime desc";
            if (base.sellerid > 0)
            {
                where += " and O.sellerid=" + base.sellerid.ToString();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('商家ID有误！');", true);
                return;
            }
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.g_orderBLL.GetPager(where, orderBy, CurrentPage, PageSize, ref total, "g_order_GetPageg_order");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                g_orderInfo info = BLL.g_orderBLL.GetModel(id);
                if (info == null || info.orderid != id)
                {
                    return;
                }
                int b = BLL.g_orderBLL.Delete(id, "orderid");
                if (b > 0)
                {
                    Repeater1bind();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }
    }
}