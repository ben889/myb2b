using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Web.UI;
using Common;
namespace WebSite.admin.DesktopModules.seller
{
    public partial class Seller : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "Seller";
                Repeater1bind();
            }
        }

        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "";//BLL.DataPermissionBLL.getserversql(base.siteid, base.UserType, "O");
            if (txbfieldval.Text.Trim().Length > 0)
            {
                if (ddlfield.SelectedValue == "O.[ProductName]")
                {
                    Condition = "O.[ProductName] like '%" + txbfieldval.Text.Trim() + "%'";
                }
            }
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();//BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O");

            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.SellerBLL.GetPageSeller(where, "O.orderby asc,O.sellerid desc", CurrentPage, PageSize, ref total);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }


        //del
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                //int sellerid = Convert.ToInt32(e.CommandArgument);
                //string where = " sellerid=" + sellerid.ToString();
                //int b = BLL.SellerBLL.Delete(id, "");
                //int result = BLL.publicBLL.UpdateTableValue("member", "isdeleted=1", where);
                //if (result > 0 && b > 0)
                //{ Repeater1bind(); }
                //else
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                //}

            }
            else if (e.CommandName == "gotoseller")
            {
                if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('只有系统管理员/才有进入商家系统的权限！');", true);
                    return;
                }
                int sellerid = Convert.ToInt32(e.CommandArgument);
                if (sellerid <= 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('sellerid错误！');", true);
                    return;
                }
                string resultMsg = "";
                int result = BLL.SellerBLL.sellerlogin(sellerid, ref resultMsg);
                if (result > 0)
                {
                    Response.Write("<script>top.location.href='/seller/index.aspx';</script>");
                }
            }
            else if (e.CommandName == "islock") //锁
            {
                string str = e.CommandArgument.ToString();
                string[] arrstr = str.Split('|');
                int sellerid = Convert.ToInt32(arrstr[1]);
                bool islock = arrstr[0].Equals("") ? false : Convert.ToBoolean(arrstr[0]);
                string islocknum = (islock ? 0 : 1).ToString();
                string where = "sellerid='" + sellerid + "'";//BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "") + " and sellerid= " + sellerid;
                int result = BLL.SellerBLL.Update("Seller", " islock =" + islocknum, where);
                if (result > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！');", true);
                }

            }
            else if (e.CommandName == "LBtrecommend") //推荐
            {
                string str = e.CommandArgument.ToString();
                string[] arrstr = str.Split('|');
                int sellerid = Convert.ToInt32(arrstr[1]);
                bool recommend = arrstr[0].Equals("") ? false : Convert.ToBoolean(arrstr[0]);
                string recommendnum = (recommend ? 0 : 1).ToString();
                string where = "sellerid='" + sellerid + "'";// BLL.DataPermissionBLL.getserversql(base.siteid, base.UserType, "") + " and sellerid= " + sellerid;
                int result = BLL.SellerBLL.Update("Seller", " recommend =" + recommendnum, where);
                if (result > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！');", true);
                }
            }
        }

        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

    }
}