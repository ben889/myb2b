using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.admin.DesktopModules.seller
{
    public partial class seller_category : basePage
    {
        protected string img = ""; // 图片
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "seller";
                Repeater1bind(); // 绑定
            }
        }

        #region 权限设置
        protected bool add;
        protected bool update;
        protected bool del;
        protected void setPermission()
        {
            add = BLL.PermissionBLL.GetPermission(base.TabKey, base.UserID, Common.enum_userpermission.ADD.ToString());
            update = BLL.PermissionBLL.GetPermission(base.TabKey, base.UserID, Common.enum_userpermission.UPDATE.ToString());
            del = BLL.PermissionBLL.GetPermission(base.TabKey, base.UserID, Common.enum_userpermission.DELETE.ToString());
        }
        #endregion
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Repeater1bind()
        {
            setPermission(); // 权限
            //List<ProductTypeInfo> list = BLL.ProductTypeBLL.GetList(-1, "", "");
            DataTable dt = BLL.Seller_categoryBLL.GetDt(-1, "");
            DataTable list = new BLL.publicBLL().MakeTree_Dt(dt, "parentid", "0", "id", "name", -1);
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
                Model.Seller_categoryInfo info = BLL.Seller_categoryBLL.GetModel(id);
                if(info == null)
                {
                    return;
                }
                string oldimg = info.img;
                int b = BLL.Seller_categoryBLL.Delete(id);
                if (b > 0)
                {
                    if (oldimg != null && oldimg.Trim().Length > 0)
                        File.Delete(Server.MapPath(oldimg)); // 删除图片
                    Repeater1bind(); 
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

    }
}