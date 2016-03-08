using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace com.weixin.Utility
{
    public class MassMessages
    {
        [Serializable]
        public partial class WeiXinUserCookies
        {
            public WeiXinUserCookies() { }
            public string UserName { set; get; }
            public string UserPassword { set; get; }
        }
        /// <summary>
        /// 保存登陆后返回的信息
        /// </summary>
        public static class LoginInfo//保存登陆后返回的信息
        {
            /// <summary>
            /// 登录后得到的令牌
            /// </summary>        
            public static string Token { get; set; }
            /// <summary>
            /// 登录后得到的cookie
            /// </summary>
            public static CookieContainer LoginCookie { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public static DateTime CreateDate { get; set; }
            public static string Err { get; set; }
        }
        /// <summary>
        ///WeiXinRetInfo 的摘要说明
        /// </summary>
        public class WeiXinRetInfo//保存登录失败微信公众平台网页返回的信息
        {
            public string Ret { get; set; }
            public string ErrMsg { get; set; }
            public string ShowVerifyCode { get; set; }
            public string ErrCode { get; set; }
        }
        /// <summary>
        /// 登陆微信公众平台函数
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public static bool GoToLogin(string name, string pass)//登陆微信公众平台函数
        {
            bool result = false;
            string password = SecurityUtility.Md5EncryptStr32(pass).ToUpper();
            string padata = "username=" + name + "&pwd=" + password + "&imgcode=&f=json";
            string url = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN ";//请求登录的URL
            try
            {
                CookieContainer cc = new CookieContainer();//接收缓存
                byte[] byteArray = Encoding.UTF8.GetBytes(padata); // 转化
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);  //新建一个WebRequest对象用来请求或者响应url
                webRequest2.CookieContainer = cc;                                      //保存cookie  
                webRequest2.Method = "POST";                                          //请求方式是POST
                webRequest2.ContentType = "application/x-www-form-urlencoded";       //请求的内容格式为application/x-www-form-urlencoded
                webRequest2.ContentLength = byteArray.Length;
                webRequest2.Referer = "https://mp.weixin.qq.com/";
                Stream newStream = webRequest2.GetRequestStream();           //返回用于将数据写入 Internet 资源的 Stream。
                // Send the data.
                newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
                newStream.Close();
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
                string text2 = sr2.ReadToEnd();
                //此处用到了newtonsoft来序列化
                LoginInfo.Err = text2;
                WeiXinRetInfo retinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiXinRetInfo>(text2);//新版返回JSon更改
                string token = string.Empty;
                if (retinfo.ErrMsg.Length > 0)
                {
                    if (retinfo.ErrMsg.Contains("ok"))
                    {
                        token = retinfo.ErrMsg.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString();//取得令牌
                        LoginInfo.LoginCookie = cc;
                        LoginInfo.CreateDate = DateTime.Now;
                        LoginInfo.Token = token;
                        result = true;
                    }
                    else
                    {

                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.StackTrace);
            }
            return result;
        }
        /// <summary>
        /// 群发消息 
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="fakeid"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string SendMessage(string Message, string fakeid, int flag)//发送消息
        {
            string result = string.Empty;
            CookieContainer cookie = null;
            string token = null;
            cookie = LoginInfo.LoginCookie;//取得cookie
            token = LoginInfo.Token;//取得token
            string strMsg = "";
            string padate = "";
            if (flag == 0)//发送文字
            {
                strMsg = Message;
                padate = "type=1&content=" + strMsg + "&sex=0&groupid=-1&synctxweibo=0&synctxnews=0&country=&province=&city=&imgcode=&token=" + token + "&lang=zh_CN&random=" + new Random().NextDouble().ToString() + "&f=json&ajax=1&t=ajax-response";
            }
            if (flag == 1)//发送图文
            {
                padate = "type=10&app_id=" + Message + "&tofakeid=" + fakeid + "&appmsgid=" + Message + "&imgcode=&token=" + token + "&lang=zh_CN&random=0.22518408996984363&f=json&ajax=1&t=ajax-response";

            }
            //  string url = "https://mp.weixin.qq.com/cgi-bin/singlesend";
            string url = "https://mp.weixin.qq.com/cgi-bin/masssend";
            byte[] byteArray = Encoding.UTF8.GetBytes(padate); // 转化
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);
            //webRequest2.KeepAlive = false;
            //webRequest2.ProtocolVersion = HttpVersion.Version10;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            webRequest2.CookieContainer = cookie; //登录时得到的缓存
            webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&action=index&tofakeid=" + fakeid + "&token=" + token + "&lang=zh_CN";
            webRequest2.Method = "POST";
            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            // Send the data.            
            newStream.Write(byteArray, 0, byteArray.Length);    //写入参数    
            newStream.Close();
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            result = sr2.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 获取群发历史记录
        /// </summary>
        /// <returns></returns>
        public static string GetMassMessagesHistory()
        {
            CookieContainer cookie = null;
            string token = null;
            cookie = LoginInfo.LoginCookie;//取得cookie
            token = LoginInfo.Token;//取得token    
            string Url = "https://mp.weixin.qq.com/cgi-bin/masssendpage?t=mass/list&action=history&begin=0&count=100&token="+token+"&lang=zh_CN";
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            webRequest2.CookieContainer = cookie;
            webRequest2.ContentType = "text/html; charset=UTF-8";
            webRequest2.Method = "GET";
            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string text2 = sr2.ReadToEnd();
            MatchCollection mcJsonData;
            Regex rexJsonData = new Regex(@"(?<=friendsList : \({""contacts"":).*(?=}\).contacts)");
            mcJsonData = rexJsonData.Matches(text2);
            if (mcJsonData.Count != 0)
            {
                 

            }

            return "";
        }
       
    }
}
