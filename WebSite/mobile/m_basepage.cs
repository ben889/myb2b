using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebSite.mobile
{
    public class m_basepage : System.Web.UI.Page
    {
        public m_basepage()
        {
        }
        protected override void OnLoad(EventArgs e)
        {

            //if (companyid <= 0)
            //{
            //    Response.Write("<script language='javascript'>alert('当前代理商未开通');</script>");
            //    Response.End();
            //}
            base.OnLoad(e);
        }

        public string site_title = "网站名称";//网站名称

        #region 
        //private int _companyid;

        //public int companyid
        //{
        //    get { return _companyid; }
        //    set { _companyid = value; }
        //}
        //private string _companyname;

        //public string companyname
        //{
        //    get { return _companyname; }
        //    set { _companyname = value; }
        //}
        //public string phone { get; set; }

        //public CompanysInfo companysinfo;
        //public void getcompany()
        //{
        //    string url = HttpContext.Current.Request.Url.Authority;

        //    companysinfo = BLL.CompanysBLL.GetModel_Byurl(url);
        //    companyid = companysinfo != null ? companysinfo.CompanyID : 0;
        //    companyname = companysinfo != null && companysinfo.CompanyName != null ? companysinfo.CompanyName : "";
        //    phone = companysinfo != null && companysinfo.Phone != null ? companysinfo.Phone : "";
        //}
        #endregion

        #region 注册时验证码验证/统一一个方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth_code">手机验证码</param>
        /// <param name="validatecode">图形验证码</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool checkcode(string auth_code, string validatecode, ref string msg)
        {
            //=========================
            //if (auth_code == null || auth_code.Trim().Length == 0)
            //{
            //    msg = "请填写手机验证码！";
            //    return false;
            //}
            //if (Session["mobilecode"] == null)
            //{
            //    msg = "手机验证码已过期，请重新点击获取验证码按钮发送！";
            //    return false;
            //}
            //if (!auth_code.Trim().ToLower().Equals(Session["mobilecode"].ToString().ToLower()))
            //{
            //    msg = "手机验证码不正确，请重新填写！";
            //    return false;
            //}
            //==========================
            if (validatecode == null || validatecode.Trim().Length == 0)
            {
                msg = "请填写图形验证码！";
                return false;
            }
            if (Session["checkcode"] == null)
            {
                msg = "图形验证码已过期，请点击刷新！";
                return false;
            }
            if (!validatecode.Trim().ToLower().Equals(Session["checkcode"].ToString().ToLower()))
            {
                msg = "图形验证码不正确，请重新填写！";
                return false;
            }
            return true;
        }
        #endregion

    }
}
