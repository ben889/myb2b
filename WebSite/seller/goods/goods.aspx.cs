using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;
using Common;
namespace WebSite.seller.goods
{
    public partial class goods : seller_basepage
    {
        protected List<goodsInfo> l_good = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1bind();
            }
        }

        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = " 1=1"; //BLL.DataPermissionBLL.getserversql(siteid, base.UserType, "O");
            //if (base.UserType != Common.enumUserType.host.ToString() && base.UserType != Common.enumUserType.admin.ToString())
            //{
            //    Condition = "C.companyid=" + base.user_companyid;
            //}
            if (txbfieldval.Text.Trim().Length > 0)
            {
                Condition += " and " + ddlfield.SelectedValue + " like '%" + txbfieldval.Text.Trim() + "%'";
            }
            return Condition;
        }
        protected void Repeater1bind()
        {

            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            goodsInfo goodsinfo = new goodsInfo();
            //string where = BLL.DataPermissionBLL.getclientsql(companyid, "") + " and sellerid=" + sellerid;
            string where = GetCondition() + " and sellerid=" + sellerid;
            DataTable dt = goodsBLL.GetPager(PageSize, CurrentPage, where, "GoodsId desc"
                , "GoodsId,GoodsName,GoodsType,Img,Price,TotalCount,ExchCount,Status,StartDate,EndDate,purchase"
                , ref total);
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
                goodsInfo info = BLL.goodsBLL.GetModel(id);
                if (info == null || info.GoodsId != id)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('无对应的信息！');", true);
                    return;
                }
                int b = BLL.goodsBLL.Delete(id, "GoodsId");
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
        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }
        protected string getGoodsType(object objGoodsType)
        {
            if (objGoodsType == null || objGoodsType == DBNull.Value)
                return "";
            int gt = Convert.ToInt32(objGoodsType);
            return Common.EnumHelper.GetEnumDescription(typeof(enum_goodstype), gt);
        }
    }
}