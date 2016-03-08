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
    public partial class exch : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1bind(string where)
        {
            //string _where = BLL.DataPermissionBLL.getclientsql(companyid, "D") + " and O.sellerid=" + sellerid;
            string _where = "O.sellerid=" + sellerid;
            if (where.Trim().Length > 0)
                _where = _where + " and " + where; ;
            DataTable dt = BLL.goodsExchBLL.GetDt(-1, _where, "");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
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
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('兑换成功！');location.href='goodsexch.aspx';", true);
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
        public static string btn_status_str(object objstatus)
        {
            if (objstatus == null)
                return "";
            if (objstatus.ToString().Trim().Equals("1"))
            {
                return "<span style=\"color:green;\">已使用</span>";
            }
            else if (objstatus.ToString().Trim().Equals("0"))
            {
                return "<span style=\"color:#f60;\">点击确定使用</span>";
            }
            else if (objstatus.ToString().Trim().Equals("-1"))
            {
                return "<span style=\"color:red;\">作废</span>";
            }
            return "";
        }
        protected void lbtn_search_Click(object sender, EventArgs e)
        {
            string Keywords = txtKeywords.Value.Trim();
            if (Keywords.Trim().Length > 0)
            {
                string where = "O.status<>1 and O.Sequence='" + Keywords + "'";
                Repeater1bind(where);
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbtn_status = (LinkButton)e.Item.FindControl("lbtn_status");

                DataRowView dv = (DataRowView)e.Item.DataItem;
                int status = Common.Utils.ObjectToint(dv["status"]);
                if (status != 0)
                    lbtn_status.Visible = false;
            }
        }
    }
}