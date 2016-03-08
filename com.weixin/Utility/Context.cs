using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.Web;

namespace com.weixin.Utility
{
    /// <summary>
    /// 获取access_token值类
    /// </summary>
    public class Context
    {
        private static DateTime GetAccessToken_Time;
        /// <summary>
        /// 过期时间为7200秒
        /// </summary>
        private static int Expires_Period = 7200;
        /// <summary>
        /// 
        /// </summary>
        private static string mAccessToken;

        /// <summary>
        /// 
        /// </summary>
        private static string AccessToken
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(mAccessToken) || HasExpired())
                {
                    //获取
                    mAccessToken = GetAccessToken(AppID, AppSecret);
                }

                return mAccessToken;
            }
        }

        private static string AppID { get; set; }

        private static string AppSecret { get; set; }

        //private static int ComID { get; set; }
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="appId">应用ID</param>
        /// <param name="appSecret">应用密匙</param>
        /// <returns></returns>
        public static string GetAccessToken(string appId, string appSecret)
        {
            try
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
                string result = HttpUtility.GetData(url);

                XDocument doc = XmlUtility.ParseJson(result, "root");
                XElement root = doc.Root;
                if (root != null)
                {
                    XElement access_token = root.Element("access_token");
                    if (access_token != null)
                    {
                        GetAccessToken_Time = DateTime.Now;
                        if (root.Element("expires_in") != null)
                        {
                            Expires_Period = int.Parse(root.Element("expires_in").Value);
                        }

                        return access_token.Value;
                    }
                    else
                    {
                        if (root.Element("errcode") != null)
                        {
                            return root.Element("errcode").Value;
                        }
                        GetAccessToken_Time = DateTime.MinValue;
                    }
                }
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("获取access_token错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
                return "";
            }

            return "";
        }

        /// <summary>
        /// 判断access_token是否无效
        /// </summary>
        /// <param name="result"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static string IsFailure(string result, string appId, string appSecret)
        {
            System.Xml.Linq.XDocument doc = com.weixin.Utility.XmlUtility.ParseJson(result, "root");
            System.Xml.Linq.XElement root = doc.Root;
            if (root != null)
            {
                if (root.Element("errcode") != null)
                {
                    string errcode = root.Element("errcode").Value;
                    //FileUtility.WriteLog("errcode编码：" + DateTime.Now.ToString() + " 企业ID:" + ComID.ToString() + " | " + errcode + "\r\n");
                    if (errcode.ToString() == "40001" || errcode.ToString() == "40002" || errcode.ToString() == "40013" || errcode.ToString() == "40014" || errcode.ToString() == "41001" || errcode.ToString() == "42001")
                    {
                        result = com.weixin.Utility.Context.GetAccessToken(appId, appSecret);
                        //FileUtility.WriteLog("result编码：" + DateTime.Now.ToString() + " 企业ID:" + ComID.ToString() + " | " + result + "\r\n");
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 返回错误值
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ComID"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static string GetRrrCode(string result)
        {
            System.Xml.Linq.XDocument doc = com.weixin.Utility.XmlUtility.ParseJson(result, "root");
            System.Xml.Linq.XElement root = doc.Root;
            if (root != null)
            {
                if (root.Element("errcode") != null)
                {
                    return root.Element("errcode").Value;
                }
            }
            return null;
        }
        /// <summary>
        /// 通过网页授权access_token
        /// </summary>
        /// <param name="appId">应用ID</param>
        /// <param name="appSecret">应用密匙</param>
        /// <param name="code">用户同意授权，获取的code</param>
        /// <returns></returns>
        public static string GetAuthorizeAccessToken(string appId, string appSecret, string code)
        {
            string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appId, appSecret, code);
            string result = HttpUtility.GetData(url);
            return result;
        }

        /// <summary>
        /// 判断Access_token是否过期
        /// </summary>
        /// <returns>bool</returns>
        private static bool HasExpired()
        {
            if (GetAccessToken_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                if (DateTime.Now > GetAccessToken_Time.AddSeconds(Expires_Period).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
