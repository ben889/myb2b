using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.goods
{
    public partial class goods : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "goods";
                Repeater1bind();
            }
        }
        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "1=1";//BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O");
            if (txbfieldval.Text.Trim().Length > 0)
            {
                Condition += " and " + txbfieldval.Text + " like '%" + txbfieldval.Text.Trim() + "%'";
            }
            return Condition;
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Repeater1bind()
        {
            string where = GetCondition();// BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O");
            string orderBy = "";
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            //DataTable dt = BLL.GoodsBLL.GetPageGoods(where, orderBy, CurrentPage, PageSize, ref total);
            DataTable dt = BLL.goodsBLL.GetPager(where, orderBy, CurrentPage, PageSize, ref total, "goods_GetPagegoods_2");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "isred")
            {
                try
                {
                    string str = e.CommandArgument != null ? e.CommandArgument.ToString() : "";
                    if (str.Trim().Length == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('参数错误！');", true);
                        return;
                    }
                    string[] arr = str.Split(',');
                    int Goodsid = Convert.ToInt32(arr[0]);
                    int is_red = Convert.ToInt32(arr[1]);

                    int update_is_red = 0;
                    if (is_red == 0)
                        update_is_red = 1;
                    int result = BLL.goodsBLL.Update("Goods", "is_red=" + update_is_red, "Goodsid=" + Goodsid);
                    if (result > 0)
                        Repeater1bind();
                    else
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！');", true);
                }
                catch (Exception exc)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败！" + exc.Message.Replace("\r", "").Replace("\n", "").Replace("\'", "") + "');", true);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }
        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }
        protected string is_red(object objis_red)
        {
            int _is_red = Common.Utils.ObjectToint(objis_red);
            if (_is_red == 1)
                return "<p style=\"color:red;\">已推荐</p>";
            return "<p style=\"color:#000000;\">未推荐</p>";
        }
    }
}