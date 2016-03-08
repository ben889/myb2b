using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.goods
{
    public partial class goods_category : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "goods";
                Repeater1bind(); // 绑定
            }
        }

        /// <summary>
        /// 绑定
        /// </summary>
        private void Repeater1bind()
        {
            DataTable dt = BLL.publicBLL.GetDt("goods_category", -1, "", "sort asc,goods_category_id desc");
            DataTable list = new BLL.publicBLL().MakeTree_Dt(dt, "parentid", "0", "goods_category_id", "goods_category_name", -1);
            Repeater1.DataSource = list;
            Repeater1.DataBind();
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
                Model.goods_categoryInfo info = BLL.goods_categoryBLL.GetModel(id);
                if (info == null)
                {
                    return;
                }
                string oldimg = info.img; // 图片URL
                string resultMsg = "";
                int b = BLL.goods_categoryBLL.delete(id, ref resultMsg);
                if (b > 0)
                {
                    if (oldimg != null && oldimg.Trim().Length > 0)
                        File.Delete(Server.MapPath(oldimg)); // 删除图片
                    Repeater1bind();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }

            }
        }
    }
}