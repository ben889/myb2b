using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class CookiesHelper
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="cookieName">名称</param>
        /// <param name="expires">过期时间(分钟)</param>
        /// <param name="domain">域</param>
        /// <param name="obj">值</param>
        public static void WriteCookie(string cookieName, int expires, string domain, object obj)
        {
            //判断客户端是否存在该cookie，若存在则清除
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddMinutes(-1);
            }
            HttpCookie cookie = new HttpCookie(cookieName);
            if (expires != 0) { cookie.Expires = DateTime.Now.AddMinutes(expires); }
            if (obj == null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(-1 * 60 * 24 * 30);
            }
            else
            {
                cookie.Value = obj.ToString();  //将cookie的Value值设置为temp
            }
            if (!string.IsNullOrEmpty(domain)) { cookie.Domain = domain; }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookie(string cookieName)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null)
                {
                    return HttpContext.Current.Request.Cookies[cookieName].Value.ToString();
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            return "";
        }
        public static void ClearCookie(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddSeconds(-1);
            }
        }
    }
}
