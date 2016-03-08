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
using System.IO;
using BLL;
using Model;
using WebSite.admin;
namespace Roles
{
    public partial class ViewRoles : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindicon();
                Repeater1bind();
            }
        }

        private void Repeater1bind()
        {
            List<Model.RoleInfo> list = BLL.RolesBLL.GetList(-1, "", "RoleID desc"); //RolesController.GetListRolesByWhere("", "", "O.RoleID desc");
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 绑定icon
        /// </summary>
        //private void bindicon()
        //{
        //    List<string> list = proList();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        lbiconlist.Text += "<a href=\"javascript:selectimg('" + list[i] + "');\" title=\"单击选择\"><img src=\"/admin/icon/" + list[i] + "\" border=\"0\" /></a>";
        //    }
        //    lbiconlist.Text += "<div style='clear:both;'></div>";
        //}
        /// <summary>
        /// 遍历所有icon
        /// </summary>
        /// <returns></returns>
        private List<string> proList()
        {
            List<string> list = new List<string>();
            try
            {
                //从config中获取文件上传路径 
                string strFileUpladPath = "../../icon/";
                //将虚拟路径转换为物理路径 
                string strFilePath = Server.MapPath(strFileUpladPath);
                //读取上传文件夹下所有文件 
                FileInfo[] arrFile = new DirectoryInfo(strFilePath).GetFiles();
                //把文件名逐一添加到列表框控件 
                foreach (FileInfo fi in arrFile)
                {
                    string filestr = "jpg,gif,png,bmp";
                    string filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1, fi.Name.Length - (fi.Name.LastIndexOf(".") + 1));
                    if (filestr.ToLower().Contains(filetype))
                    {
                        list.Add(fi.Name);
                    }
                }
            }
            catch { }
            return list;
        }

        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RoleInfo info = new RoleInfo();
        //        info.RoleID = Convert.ToInt32(hfRoleID.Value);
        //        info.RoleName = txbRoleName.Text.Trim();
        //        info.Description = txbDescription.Text.Trim();
        //        info.IconFile = hfIconFile.Value;
        //        info.LastModifiedOnDate = DateTime.Now;
        //        info.LastModifiedByUserID = base.UserID;
        //        info.CompanyID = -1;
        //        if (info.RoleID > 0)
        //        {
        //            int returnval = RolesController.UpdateRole(info);
        //            if (returnval > 0)
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "editrole", "alert('修改成功！');", true);
        //                Repeater1bind();
        //                defaultform();
        //            }
        //            else
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "editrole", "alert('修改失败！');", true);
        //            }
        //        }
        //        else
        //        {
        //            int returnval = RolesController.AddRole(info);
        //            if (returnval > 0)
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrole", "alert('添加成功！');", true);
        //                Repeater1bind();
        //            }
        //            else
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrole", "alert('添加失败！');", true);
        //            }
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrele", "alert('提交失败," + exc.Message + "！');", true);
        //    }
        //}

        protected void btnclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewRoles.aspx");
        }
        /// <summary>
        /// 菜单权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnTabsRoles_Click(object sender, EventArgs e)
        {
            string RoleID = "";
            int selectcount = 0;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfRoleID = (HiddenField)Repeater1.Items[i].FindControl("hfRoleID");
                    RoleID += hfRoleID.Value;
                    selectcount++;
                }
            }
            if (selectcount != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择一个角色！');", true);
                return;
            }
            if (RoleID.Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择角色！');", true);
                return;
            }
            Response.Redirect("../Permission/TabsPermission.aspx?roleid=" + RoleID);
        }
        /// <summary>
        /// 模块权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnModulesRoles_Click(object sender, EventArgs e)
        {
            string RoleID = "";
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfRoleID = (HiddenField)Repeater1.Items[i].FindControl("hfRoleID");
                    RoleID += hfRoleID.Value;
                    break;
                }
            }
            if (RoleID.Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择角色！');", true);
                return;
            }
            Response.Redirect("../Permission/ModulesPermission.aspx?roleid=" + RoleID);
        }

        //private void bindform(int roleid)
        //{
        //    if (roleid > 0)
        //    {
        //        RoleInfo info = RolesController.GetInfoRoleByRoleID(roleid);
        //        if (info != null)
        //        {
        //            lbtitle.Text = "修改";
        //            hfRoleID.Value = info.RoleID.ToString();
        //            txbRoleName.Text = info.RoleName;
        //            txbDescription.Text = info.Description;
        //            txbIconFile.Text = info.IconFile;
        //            hfIconFile.Value = info.IconFile;
        //        }
        //    }
        //}
        //private void defaultform()
        //{
        //    lbtitle.Text = "添加";
        //    hfRoleID.Value = "0";
        //    txbRoleName.Text = "";
        //    txbDescription.Text = "";
        //    txbIconFile.Text = "";
        //    hfIconFile.Value = "";
        //}

        protected void lbtndelete_Click(object sender, EventArgs e)
        {
            int excs1 = 0;
            int excs2 = 0;

            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfRoleID = (HiddenField)Repeater1.Items[i].FindControl("hfRoleID");
                    //HiddenField hfCompanyID = (HiddenField)Repeater1.Items[i].FindControl("hfCompanyID");
                    //int CompanyID = int.Parse(hfCompanyID.Value);
                    //if (CompanyID <= 0)
                    //{
                    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('系统角色不能删除，请重新选择！');", true);
                    //    return;
                    //}
                    int excrows = BLL.RolesBLL.Delete(hfRoleID.Value, "RoleID");
                    excs1++;
                    if (excrows > 0)
                        excs2++;
                }
            }
            if (excs1 != excs2)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('" + (excs1 - excs2) + "个删除失败！角色已被引用！');", true);
            }
            Repeater1bind();
        }

        protected void lbtnedit_Click(object sender, EventArgs e)
        {
            string RoleID = "";
            int selectcount = 0;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                //if (i > 0)
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择一个角色！');", true);
                //    return;
                //}
                if (((CheckBox)Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    HiddenField hfRoleID = (HiddenField)Repeater1.Items[i].FindControl("hfRoleID");
                    RoleID += hfRoleID.Value;
                    selectcount++;
                    //break;
                }
            }
            if (selectcount != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择一个角色！');", true);
                return;
            }
            if (RoleID.Length == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('请选择角色！');", true);
                return;
            }
            //bindform(Int32.Parse(RoleID));
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "$(document).ready(function(){showdiv2('adddiv');});", true);
            Response.Redirect("editRoles.aspx?roleid=" + RoleID);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltrCompanyName = (Literal)e.Item.FindControl("ltrCompanyName");

                //RoleInfo roleInfo = (RoleInfo)e.Item.DataItem;

                //if (roleInfo.CompanyID > 0)
                //{
                //    CompanysInfo companysInfo = CompanysBLL.GetCompanysInfoByCompanyID(roleInfo.CompanyID);
                //    ltrCompanyName.Text = companysInfo.CompanyName;
                //}
                //else
                //{
                //    ltrCompanyName.Text = "系统角色";
                //}

            }
        }
    }
}
