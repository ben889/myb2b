using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
namespace WebSite.admin.DesktopModules.Ad
{
    public partial class ad : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "ad";
                call_index = Common.Utils.ObjectToStr(Request["call_index"]);
                bindAdPosition();
                Repeater1bind();
            }
        }
        protected string title;
        protected string call_index
        {
            get
            {
                return ViewState["call_index"] != null ? ViewState["call_index"].ToString() : "";
            }
            set { ViewState["call_index"] = value; }
        }

        protected void bindAdPosition()
        {
            if (call_index.Trim().Length > 0)
            {
                List<AdPositionInfo> list = BLL.AdPositionBLL.GetList(1, "call_index='" + call_index + "'", "");
                if (list != null && list.Count > 0)
                {
                    AdPositionInfo info = list[0];
                    title = info.name;
                }
            }
            else
            {
                title = "广告";
            }
        }
        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "1=1";
            if (call_index.Trim().Length > 0)
            {
                Condition += " and T.[call_index]='" + call_index.Trim() + "'";
            }
            if (txbfieldval.Text.Trim().Length > 0)
            {
                if (ddlfield.SelectedValue == "O.[adname]")
                {
                    Condition += " and O.[adname] like '%" + txbfieldval.Text.Trim() + "%'";
                }
            }
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            int PageSize = Pagination1.PageSize;
            int CurrentPage = Pagination1.CurrentPage;
            int total = 0;
            DataTable dt = BLL.AdBLL.GetPager(where, "O.adid desc", CurrentPage, PageSize, ref total, "Ad_GetPageAd");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Pagination1.TotalRecords = total;
        }

        protected string showimg(object objimg, object objfuffix, object objadlink)
        {
            //if (obj != null && obj.ToString().Trim().Length > 0)
            //{
            //    return "<img src='" + Common.Constant.URL_ad +  obj.ToString() + "' height='50' />";
            //}
            //return "";
            return BLL.AdBLL.showad(objimg.ToString(), objfuffix.ToString(), 1, objadlink.ToString(), 50, 50);
        }
        protected string status(object objstatus)
        {
            if (objstatus == null && objstatus.ToString().Trim().Length == 0)
            {
                return "<span style='color:red;'>关闭</span>";
            }
            int status = Convert.ToInt32(objstatus);
            if (status == 0)
                return "<span style='color:red;'>关闭</span>";
            else
                return "<span style='color:green;'>开通</span>";
        }

        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = BLL.AdBLL.Delete(id, "");
                if (b > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editad.aspx");
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }
    }
}