using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace WebSite.admin.API
{
    /// <summary>
    /// UserLogin 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            try
            {
                string method = context.Request["method"].ToString().ToLower();
                int isCookies = context.Request["isCookies"] != null ? Convert.ToInt32(context.Request["isCookies"]) : 0;
                switch (method)
                {
                    case "login"://
                        context.Response.Write(login(context.Request["username"].ToString(), context.Request["password"].ToString(), context.Request["checkcode"].ToString().ToLower(), isCookies));
                        context.Response.End();
                        break;
                    case "getcookies"://
                        context.Response.Write(getcookies());
                        context.Response.End();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                //QueuesName = e.Message;
            }
        }


        /// <summary>
        /// 登陆 返回>0为成功 0为失败 -1为帐号被锁定 -2无验证码信息 -3验证码不正确
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="checkcode"></param>
        /// <returns></returns>
        public string login(string username, string password, string checkcode, int isCookies)
        {
            if (HttpContext.Current.Session["ValidateNum"] == null)
            {
                return "{\"result\":\"-5\",\"msg\":\"验证码已过期\"}";//无验证码信息
            }
            if (HttpContext.Current.Session["ValidateNum"] != null && !checkcode.Trim().ToLower().Equals(HttpContext.Current.Session["ValidateNum"].ToString().ToLower()))
            {
                return "{\"result\":\"-3\",\"msg\":\"验证码不正确\"}";
            }
            string resultmsg = "";
            //string companyid = BLL.CompanysBLL.GetCompanyId(HttpContext.Current.Request.Url.Authority);
            int userid = BLL.UsersBLL.Login(username, Utility.MD5Encrypt(password), ref resultmsg);
            int result = 0;
            if (userid > 0)
                result = 1;
            if (isCookies == 1)
            {
                //HttpCookie cookieusername = new HttpCookie("username");
                //cookieusername.Value = username;
                //HttpContext.Current.Response.Cookies.Add(cookieusername);
                //HttpCookie cookiepassword = new HttpCookie("password");
                //cookiepassword.Value = password;
                //HttpContext.Current.Response.Cookies.Add(cookiepassword);
                if (userid > 0)
                {
                    HttpContext.Current.Response.Cookies["username"].Value = username;
                    HttpContext.Current.Response.Cookies["password"].Value = password;
                }
            }
            else
            {
                if (HttpContext.Current.Request.Cookies["username"] != null)
                    HttpContext.Current.Response.Cookies["username"].Value = null;
                if (HttpContext.Current.Request.Cookies["password"] != null)
                    HttpContext.Current.Response.Cookies["password"].Value = null;
                //if (HttpContext.Current.Request.Cookies["companyid"] != null)
                //    HttpContext.Current.Response.Cookies["companyid"].Value = null;
            }
            return "{\"result\":\"" + result + "\",\"msg\":\"" + resultmsg + "\"}";
        }

        public string getcookies()
        {
            string result = "[{";
            result += "\"username\":\"" + (HttpContext.Current.Request.Cookies["username"] != null ? HttpContext.Current.Request.Cookies["username"].Value : "") + "\"";
            result += ",\"password\":\"" + (HttpContext.Current.Request.Cookies["password"] != null ? HttpContext.Current.Request.Cookies["password"].Value : "") + "\"";
            result += "}]";
            return result;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}