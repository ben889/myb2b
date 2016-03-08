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
    public partial class goodsExch : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init_bind();
            }
        }

        protected void init_bind()
        {
            string where = "";
            Repeater1bind(where);
        }

        protected void Repeater1bind(string where)
        {
            //string _where = BLL.DataPermissionBLL.getclientsql(companyid, "D") + " and O.status=1 and O.sellerid=" + sellerid;
            string _where = "O.status=1 and O.sellerid=" + sellerid;
            if (where.Trim().Length > 0)
                _where = _where + " and " + where; ;
            string orderby = "O.ExchTime desc";
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.goodsExchBLL.GetPager(_where, orderby, CurrentPage, PageSize, ref total, "[goodsExch_GetPagegoodsExch]");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "status")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                goodsExchInfo info = BLL.goodsExchBLL.GetModel(id);
                if (info == null || info.ExchId != id)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('id错误！');", true);
                    return;
                }
                if (info.status != 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('此兑换单已处理，不能再次处理！');", true);
                    return;
                }
                string resultMsg = "";
                int b = BLL.goodsExchBLL.exch(id, sellerid, ref resultMsg);
                if (b > 0)
                {
                    init_bind();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('兑换成功！');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('兑换失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }

            }
        }

        protected string bind_goodsimg(object objimg)
        {
            if (objimg == null)
                return "";
            return "<img src=\"" + objimg.ToString() + "\" height=\"80px\"/>";
        }

        protected void lbtn_search_Click(object sender, EventArgs e)
        {
            string Keywords = txtKeywords.Value.Trim();
            if (Keywords.Trim().Length > 0)
            {
                string where = "O.Sequence='" + Keywords + "'";
                Repeater1bind(where);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            init_bind();
        }
    }
}