using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using BLL;
using Model;
using WebSite.admin;

namespace Permission
{
    public partial class TabsPermission : basePage
    {
        /// <summary>
        /// 前一page的URL
        /// </summary>
        public string lastpage
        {
            get { try { return ViewState["lastpage"].ToString(); } catch { return ""; } }
            set { ViewState["lastpage"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckModulePermission("Permission", "view");
            if (!IsPostBack)
            {
                base.TabKey = "all";
                try { lastpage = Request.ServerVariables["HTTP_REFERER"].ToString(); }
                catch { }
                rolebind();
            }
        }
        private int roleid
        {
            get
            {
                try
                {
                    if (Request["roleid"] != null)
                    {
                        ViewState["roleid"] = Request["roleid"].ToString();
                        return Convert.ToInt32(ViewState["roleid"]);
                    }
                    else return 0;
                }
                catch { return 0; }
            }
        }
        private void rolebind()
        {
            if (roleid > 0)
            {
                Model.RoleInfo rinfo = BLL.RolesBLL.GetModel(roleid);
                if (rinfo != null)
                {
                    ltrRoles.Text = "<span style='color:red;'>" + rinfo.RoleName + "</span>";
                    //try { rblDataPermissionType.SelectedValue = rinfo.DataPermissionType.ToString(); }
                    //catch { }
                    rpTabslistbind();
                }
            }
        }


        protected void rpTabslistbind()
        {
            DataTable dt = BLL.TabsBLL.GetDataTable();// TabsController.GetListTabs("", where);
            ArrayList arrlist = new BLL.TabsBLL().MakeTree2(dt, "ParentID", "0", "TabID", "TabName", -1);
            rpTabslist.DataSource = arrlist;
            rpTabslist.DataBind();
            ViewState["moveid"] = null;
        }

        private void bindlist(Literal Literal1, int TabID)
        {
            List<PermissionInfo> list = PermissionBLL.GetList(-1, "PermissionCode='SYSTEM_TAB' AND (TabID=0 OR TabID is NULL or TabID=" + TabID + ")", "");//.GetListTabsPermission(TabID);
            string str = "";


            DataTable dt = BLL.TabPermissionBLL.GetAllTabPermission();// PermissionController.GetDataTableAllTabPermission();
            DataView dv = new DataView(dt);


            foreach (PermissionInfo info in list)
            {
                string ck = "";
                dv.RowFilter = "RoleID=" + roleid + " and PermissionID=" + info.PermissionID + " and TabID=" + TabID.ToString();
                if (dv.Count > 0)
                    ck = "checked=\"checked\"";

                str += "<label><input type=\"checkbox\" name=\"PermissionBox\" id=\"Permission" + info.PermissionID + "\" value=\"" + info.PermissionID + "|" + TabID + "\" " + ck + " />&nbsp;" + info.PermissionName + "</label>&nbsp;&nbsp;";
            }
            Literal1.Text = str;
        }

        protected void rpTabslist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfTabID = (HiddenField)e.Item.FindControl("hfTabID");
                Literal ltrlistpaermission = (Literal)e.Item.FindControl("ltrlistpaermission");
                int TabID = Convert.ToInt32(hfTabID.Value);
                bindlist(ltrlistpaermission, TabID);
            }
        }

        /// <summary>
        /// 获取选择权限的ID串
        /// </summary>
        /// <returns></returns>
        private string getselectPermission()
        {
            try
            {
                return Request["PermissionBox"].ToString();
            }
            catch { return ""; }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (roleid > 0)
            {
                try
                {
                    string Permissionstr = getselectPermission();
                    //if (Permissionstr.Length > 0)
                    //{
                    int deleterows = BLL.TabPermissionBLL.Delete("roleid=" + roleid);// PermissionController.DeleteTabPermissionByRoleID(roleid);

                    string[] idstr = Permissionstr.Split(',');
                    for (int i = 0; i < idstr.Length; i++)
                    {
                        if (idstr[i].Trim().Length == 0)
                            continue;
                        int CreatedByUserID = base.UserID;
                        string[] ids = idstr[i].Split('|');
                        int PermissionId = Convert.ToInt32(ids[0]);
                        int TabID = Convert.ToInt32(ids[1]);
                        int RoleId = roleid;
                        //short DataPermissionType = 0;
                        //int CompanyID = 0;
                        //int result = PermissionController.UpdateTabPermissionByRoleID(TabID, PermissionId, RoleId, CreatedByUserID, DataPermissionType, CompanyID);
                        TabPermissionInfo info = new TabPermissionInfo();
                        info.TabID = TabID;
                        info.PermissionID = PermissionId;
                        info.RoleID = RoleId;
                        BLL.TabPermissionBLL.Add(info);
                    }

                    //}
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存成功');", true);
                    rolebind();

                }
                catch (Exception exc)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存失败!" + exc.Message.Replace("\"", "").Replace("'", "") + "');", true);
                }
            }
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            if (lastpage != null && lastpage.Length > 0)
                Response.Redirect(lastpage);
        }
    }
}
