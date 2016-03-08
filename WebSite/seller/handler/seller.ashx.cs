using BLL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebSite.seller.handler
{
    /// <summary>
    /// member 的摘要说明
    /// </summary>
    public class seller : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                string method = context.Request["method"].ToString().ToLower();
                //int isCookies = context.Request["isCookies"] != null ? Convert.ToInt32(context.Request["isCookies"]) : 0;
                switch (method)
                {
                    case "login"://
                        context.Response.Write(login(context.Request["uname"].ToString(), context.Request["upass"].ToString(), context.Request["checkcode"].ToString().ToLower()).ToString());
                        break;
                    case "getcookies"://
                        context.Response.Write(getcookies());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                //QueuesName = e.Message;
                context.Response.Write(e.Message.Replace("\r", "").Replace("\n", ""));

            }
            finally
            {
                context.Response.End();
            }
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="checkcode"></param>
        /// <returns></returns>
        public string login(string uname, string password, string checkcode)
        {
            if (HttpContext.Current.Session["checkcode"] == null)
            {
                return "验证码已过期！";//无验证码信息
            }
            if (HttpContext.Current.Session["checkcode"] != null && !checkcode.Trim().ToLower().Equals(HttpContext.Current.Session["checkcode"].ToString().ToLower()))
            {
                return "验证码不正确！"; //验证码不正确
            }
            if (uname.Trim().Length == 0)
            {
                return "帐号不能为空";
            }
            if (password.Trim().Length == 0)
            {
                return "密码不能为空";
            }
            string resultMsg = "";
            //string url = HttpContext.Current.Request.Url.Authority;
            //int companyid = CompanysBLL.GetCompanyID(url);
            //long uid = BLL.SellerBLL.sellerlogin(uname, password, companyid, ref resultMsg);
            password = Common.Utility.MD5Encrypt(password);
            long uid = BLL.SellerBLL.login(uname, password, ref resultMsg);
            if (uid > 0)
                return "1";

            return "登陆失败！" + resultMsg;
        }

        public string getcookies()
        {
            string result = "[{";
            result += "\"uname\":\"" + (HttpContext.Current.Request.Cookies["seller_uname"] != null ? HttpContext.Current.Request.Cookies["seller_uname"].Value : "") + "\"";
            result += ",\"upass\":\"" + (HttpContext.Current.Request.Cookies["seller_upass"] != null ? HttpContext.Current.Request.Cookies["seller_upass"].Value : "") + "\"";
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