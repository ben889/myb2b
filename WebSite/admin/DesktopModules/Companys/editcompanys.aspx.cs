using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using Web.UI;

namespace WebSite.admin.DesktopModules.Companys
{
    public partial class editcompanys : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "companys";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                //flsh(id);//加载页面时，先刷新二维码
                bind();

            }
        }

        protected int id = 0;
        protected string title = "添加";
        protected string qrcodeimg; // 二维码
        protected string wxqrcodeimg; // 微信二维码

        protected string dist_json;//
        protected int ProvinceId;
        protected int CityId;
        protected int AreaId;
        protected int DistrictId;
        private void bind()
        {
            dist_json = new WebSite.api.dist().getjson_dist();
            if (id > 0)
            {

                hfCompanyID.Value = id.ToString();
                CompanysInfo info = BLL.CompanysBLL.GetModel(id);
                if (info == null || info.CompanyID != id)
                {
                    Response.Write("<script>alert('无效的id');history.go(-1);</script>");
                    return;
                }
                title = "修改-" + info.CompanyName;
                txbEmail.Text = info.Email;
                txbWebsite.Text = info.Website;
                txbCompanyName.Text = info.CompanyName;
                txbContact.Text = info.Contact;
                txbPhone.Text = info.Phone;
                txbMobile.Text = info.Mobile;
                txbFax.Text = info.Fax;
                txbAddress.Text = info.Address;
                ltrstatus.Text = info.status == -1 ? "<span style='color:red;'>关闭</span>" : "正常";
                ltrtotalamount.Text = info.totalamount.ToString();
                //txbdomain.Text = info.domain;

                if (info.qrcode != null && info.qrcode.Trim().Length > 0)
                    qrcodeimg = "<img src=\"" + info.qrcode + "\" height=\"50\"/><br/>";

                if (info.wxqrcode != null && info.wxqrcode.Trim().Length > 0)
                    wxqrcodeimg = "<img src=\"" + Common.Constant.URL_QRCode() + info.wxqrcode + "\" height=\"50\"/><br/>";

                DistrictInfo dinfo = BLL.DistrictBLL.GetModel(info.distid);
                if (dinfo != null)
                {
                    ProvinceId = dinfo.ProvinceId;
                    CityId = dinfo.CityId;
                    AreaId = dinfo.AreaId;
                    DistrictId = dinfo.DistrictId;
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    System.Web.HttpPostedFile file = files[i];
                    if (file.ContentLength > 500 * 1024)
                    {
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('图片大小不能超过300K！');", true);
                        //Response.Write("<script>alert('图片大小不能超过500K！');</script>");
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('图片大小不能超过500K！');", true);
                        return;
                    }
                }
            }

            try
            {
                string CompanyName = txbCompanyName.Text.Trim();
                string UserName = txbUserName.Text.Trim();
                string PassWord = txbPassWord.Text.Trim();
                if (CompanyName.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('名称不能为空');", true);
                    return;
                }


                //CompanysInfo model = new CompanysInfo();
                int id = int.Parse(hfCompanyID.Value);

                if (id <= 0)
                {
                    if (UserName.Trim().Length == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('帐号不能为空');", true);
                        return;
                    }
                    if (PassWord.Trim().Length < 6)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('密码必须为6位以上');", true);
                        return;
                    }
                }
                string email = txbEmail.Text.Trim();
                string Website = txbWebsite.Text.Trim();
                string Contact = txbContact.Text.Trim();
                string Phone = txbPhone.Text.Trim();
                string Mobile = txbMobile.Text.Trim();
                string Fax = txbFax.Text.Trim();
                string Address = txbAddress.Text.Trim();
                //string domain = txbdomain.Text.Trim();

                int distid = 0;
                int select1 = Common.Utils.ObjectToint(Request["Select1"]);
                if (select1 > 0)
                    distid = select1;
                int select2 = Common.Utils.ObjectToint(Request["Select2"]);
                if (select2 > 0)
                    distid = select2;

                int result = 0;
                string resultmsg = "";
                if (id > 0)
                {
                    result = BLL.CompanysBLL.Update(id, CompanyName, email, Contact, Mobile, Phone, Fax, Address, distid, ref resultmsg);
                }
                else
                {
                    //Components.UserInfo uinfo = new Components.UserInfo();
                    //uinfo.UserName = txbUserName.Text.Trim();
                    //uinfo.DisplayName = txbCompanyName.Text.Trim();
                    //uinfo.PassWord = Common.Utility.MD5Encrypt(txbPassWord.Text.Trim());
                    //uinfo.FirstName = "";
                    //uinfo.LastName = "";
                    //uinfo.Email = txbEmail.Text.Trim();
                    //uinfo.IsLockedOut = false;
                    //uinfo.LastLoginDate = DateTime.Now;
                    //uinfo.LastPasswordChangedDate = DateTime.Now;
                    //uinfo.LastLockoutDate = DateTime.Now;
                    //uinfo.LastModifiedOnDate = DateTime.Now;
                    //uinfo.UserType = (int)enumUserType.company;

                    //result = BLL.CompanysBLL.AddTran(uinfo, model, ref resultmsg);
                    result = BLL.CompanysBLL.add(UserName, PassWord, CompanyName, email, distid, ref resultmsg);
                }

                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "location.href='companys.aspx';", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('保存失败" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
                }

            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('提交失败" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btqrcode_Click(object sender, EventArgs e)
        {
            string url = Common.Constant.Get_Host() + "/mobile/index.aspx";
            bool b = new Common.QRCode.QRCodeHandler().CreateQRCode("", url, "qrcode_" + ".jpg", "", "");
            if (b)
            {
                string _cid = hfCompanyID.Value;
                int cid = 0;
                int.TryParse(_cid, out cid);
                if (cid > 0)
                {
                    qrcodeimg = Common.Constant.URL_QRCode() + "qrcode_" + "" + ".jpg";
                    BLL.publicBLL.UpdateTableValue("Companys", "qrcode='" + qrcodeimg + "'", "CompanyID=" + cid);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('刷新成功！');location.href='editcompanys.aspx?id=" + cid + "';", true);
                    bind();
                    //Response.Write("<script>parent.success('刷新成功！');location.href='editcompanys.aspx?id=" + cid + "';</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('刷新失败！');", true);
            }
        }

        ///// <summary>
        ///// 刷新二维码的方法
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //protected bool flsh(int id)
        //{
        //    bool isflsh = false;
        //    string url = Common.Constant.GetSite_Host() + "/mobile/index.aspx";
        //    bool b = new Common.QRCode.QRCodeHandler().CreateQRCode("", url, "qrcode_" + base.companyid.ToString() + ".jpg", "");
        //    if (b)
        //    {
        //        //string _cid = hfCompanyID.Value;
        //        //int cid = 0;
        //        //int.TryParse(_cid, out cid);
        //        if (id > 0)
        //        {
        //            qrcodeimg = Common.Constant.URL_QRCode + "qrcode_" + base.companyid.ToString() + ".jpg";
        //            BLL.publicBLL.UpdateTableValue("Companys", "qrcode='" + qrcodeimg + "'", "CompanyID=" + id);
        //            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('刷新成功！');location.href='editcompanys.aspx?id=" + cid + "';", true);
        //            bind();
        //            //Response.Write("<script>parent.success('刷新成功！');location.href='editcompanys.aspx?id=" + cid + "';</script>");
        //           isflsh = true;
        //           return isflsh;
        //        }
        //    }
        //    return isflsh;
        //}
    }
}