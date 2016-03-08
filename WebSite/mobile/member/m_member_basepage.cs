using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.UI;

namespace WebSite.mobile.member
{
    public class m_member_basepage : m_basepage
    {
        public m_member_basepage()
        {
            getmemberinfo(uid);
            //if (memberinfo != null)
            //    getcompany(memberinfo.companyid);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (uid <= 0 || memberinfo == null)
            {
                Response.Write("<script language='javascript'>window.location = '/mobile/member/login.aspx?fromurl=" + HttpContext.Current.Request.Url.AbsoluteUri + "';</script>");
                Response.End();
                return;
            }
            if (memberinfo.isdeleted)
            {
                Response.Write("<script language='javascript'>alert('当前帐号已被删除!');window.location = '/mobile/member/login.aspx?fromurl=" + HttpContext.Current.Request.Url.AbsoluteUri + "';</script>");
                Response.End();
                return;
            }
            if (memberinfo.islock)
            {
                Response.Write("<script language='javascript'>alert('当前帐号已被锁定!');window.location = '/mobile/member/login.aspx?fromurl=" + HttpContext.Current.Request.Url.AbsoluteUri + "';</script>");
                Response.End();
                return;
            }
            base.OnLoad(e);
        }


        #region 当前登录会员信息
        public long uid
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["uid"] != null)
                {
                    try
                    {
                        string uid_str = HttpContext.Current.Request.Cookies["uid"].Value;
                        return int.Parse(uid_str);
                    }
                    catch { }
                }
                return 0;
            }
        }
        /// <summary>
        /// 帐号ID
        /// </summary>
        public string uname { get; set; }
        public int utype { get; set; }
        public string displayname { get; set; }
        public string mobile { get; set; }
        //public string sourceid { get; set; }
        public memberInfo memberinfo;
        public void getmemberinfo(long uid)
        {
            if (uid > 0)
            {
                memberinfo = BLL.memberBLL.GetModel(uid);
                if (memberinfo != null && memberinfo.uid == uid)
                {
                    uname = memberinfo != null ? memberinfo.uname : "";
                    utype = memberinfo != null ? memberinfo.utype : 0;
                    mobile = memberinfo != null && memberinfo.mobile != null ? memberinfo.mobile : "";
                }
            }
        }
        #endregion


        #region 代理商
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
        //public void getcompany(int _companyid)
        //{
        //    if (_companyid > 0)
        //    {
        //        //string url = HttpContext.Current.Request.Url.Authority;
        //        //companysinfo = BLL.CompanysBLL.GetModel_Byurl(url);
        //        companysinfo = BLL.CompanysBLL.GetModel(_companyid);
        //        if (companysinfo != null && companysinfo.CompanyID == _companyid)
        //        {
        //            companyid = companysinfo != null ? companysinfo.CompanyID : 0;
        //            companyname = companysinfo != null && companysinfo.CompanyName != null ? companysinfo.CompanyName : "";
        //            phone = companysinfo != null && companysinfo.Phone != null ? companysinfo.Phone : "";
        //        }
        //    }
        //}
        #endregion
    }
}