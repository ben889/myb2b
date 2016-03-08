using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.mobile.member
{
    public partial class login : m_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                header1.title = "登陆";
                fromurl = Request["fromurl"] != null ? Request["fromurl"].ToString() : "index.aspx";
                string ac = Request["ac"] != null ? Request["ac"].ToString() : "";
                if (ac.Trim().Equals("login"))
                {
                    //string uname;// 用户名
                    //string password;// 密码

                    //判断是否存在cookie
                    //if (Request.Cookies["uname"] != null && Request.Cookies["password"] != null)
                    //{
                    //    uname = Request.Cookies["uname"].Value.ToString(); 
                    //    password = Request.Cookies["password"].Value.ToString();
                    //}
                    //else
                    //{

                    //如果在cookie中取不到值，就使用用户填写的用户名及密码
                    string uname = Request["uname"] != null ? Request["uname"].ToString() : "";
                    string password = Request["password"] != null ? Request["password"].ToString() : "";
                    //}
                    bool remember = true;// Request["remember"] == "1" ? true : false;// 是否选择了记住密码
                    memberlogin(uname, password, remember);
                }
            }
        }
        protected string fromurl;
        protected void memberlogin(string uname, string password, bool remember)
        {

            string resultMsg = "";
            long result = BLL.memberBLL.login(uname, password, ref resultMsg);
            if (result > 0)
            {
                Response.Write("<script>parent.success('');</script>");
            }
            else
            {
                Response.Write("<script>parent.fail('" + resultMsg.Replace("'", "").Replace("\n", "").Replace("\r", "") + "');</script>");
            }


            //if (remember && (result > 0)) // 选择了记住密码，确定登陆成功后、再保存cookie
            //{
            //    //判断客户端是否存在该cookie，若存在则清除
            //    if (HttpContext.Current.Request.Cookies["uname"] != null &&
            //        HttpContext.Current.Request.Cookies["password"] != null &&
            //        HttpContext.Current.Request.Cookies["companyid"] != null)
            //    {
            //        HttpContext.Current.Response.Cookies["uname"].Expires = DateTime.Now.AddSeconds(-1);
            //        HttpContext.Current.Response.Cookies["password"].Expires = DateTime.Now.AddSeconds(-1);
            //        HttpContext.Current.Response.Cookies["companyid"].Expires = DateTime.Now.AddSeconds(-1);
            //    }

            //    //向客户端浏览器加入username Cookie
            //    HttpCookie hcUserName1 = new HttpCookie("uname");
            //    hcUserName1.Expires = DateTime.Now.AddDays(7);
            //    hcUserName1.Value = uname;

            //    //向客户端浏览器加入password Cookie
            //    HttpCookie hcPassword1 = new HttpCookie("password");
            //    hcPassword1.Expires = DateTime.Now.AddDays(7);
            //    hcPassword1.Value = password;

            //    //向客户端浏览器加入companyid Cookie
            //    HttpCookie hcCompanyid1 = new HttpCookie("companyid");
            //    hcCompanyid1.Expires = DateTime.Now.AddDays(7);
            //    hcCompanyid1.Value = base.companyid.ToString();

            //    HttpContext.Current.Response.Cookies.Add(hcUserName1);
            //    HttpContext.Current.Response.Cookies.Add(hcPassword1);
            //    HttpContext.Current.Response.Cookies.Add(hcCompanyid1);
            //}
        }
    }
}