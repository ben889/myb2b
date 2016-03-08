using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebSite.admin.DesktopModules.Roles
{
    public partial class editRoles : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                roleid = Request["roleid"] != null ? Convert.ToInt32(Request["roleid"]) : 0;
                bindicon();
                bind();
            }
        }


        protected int roleid;
        protected void bind()
        {
            if (roleid > 0)
            {
                Model.RoleInfo info = BLL.RolesBLL.GetModel(roleid);
                if (info != null && info.RoleID == roleid)
                {
                    hfRoleID.Value = info.RoleID.ToString();
                    txbRoleName.Text = info.RoleName;
                    txbDescription.Text = info.Description;
                    txbIconFile.Text = hfIconFile.Value = info.IconFile;
                }
            }
        }




        protected string iconlist;
        /// <summary>
        /// 绑定icon
        /// </summary>
        private void bindicon()
        {
            List<string> list = proList();
            for (int i = 0; i < list.Count; i++)
            {
                iconlist += "<a href=\"javascript:selectimg('" + list[i] + "');\" title=\"单击选择\"><img src=\"/admin/icon/" + list[i] + "\" border=\"0\" /></a>";
            }
            iconlist += "<div style='clear:both;'></div>";
        }
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.RoleInfo info = new Model.RoleInfo();
                info.RoleID = Convert.ToInt32(hfRoleID.Value);
                info.RoleName = txbRoleName.Text.Trim();
                info.Description = txbDescription.Text.Trim();
                info.IconFile = hfIconFile.Value;
                info.LastModifiedOnDate = DateTime.Now;
                info.LastModifiedByUserID = base.UserID;
                if (info.RoleID > 0)
                {
                    int returnval = BLL.RolesBLL.Update(info);
                    if (returnval > 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "editrole", "alert('修改成功！');location.href='ViewRoles.aspx';", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "editrole", "alert('修改失败！');", true);
                    }
                }
                else
                {
                    info.RoleID = BLL.RolesBLL.GetMaxId() + 1;
                    int returnval = BLL.RolesBLL.Add(info);
                    if (returnval > 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrole", "alert('添加成功！');closediv();", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrole", "alert('添加失败！');", true);
                    }
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "addrele", "alert('提交失败," + exc.Message + "！');", true);
            }
        }
    }
}