using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using com.weixin.Handlers;
using com.weixin.Utility;
using System.Configuration;
using Model;

namespace com.weixin
{
    public class WeiXinService
    {
        /// <summary>
        /// TOKEN
        /// </summary>
        //private static string TOKEN = "token";
        /// <summary>
        /// 签名
        /// </summary>
        private const string SIGNATURE = "signature";
        /// <summary>
        /// 时间戳
        /// </summary>
        private const string TIMESTAMP = "timestamp";
        /// <summary>
        /// 随机数
        /// </summary>
        private const string NONCE = "nonce";
        /// <summary>
        /// 随机字符串
        /// </summary>
        private const string ECHOSTR = "echostr";
        /// <summary>
        /// 
        /// </summary>
        private HttpRequest Request { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request"></param>
        public WeiXinService(HttpRequest request)
        {
            this.Request = request;
        }

        private wx_configInfo cinfo;
        /// <summary>
        /// 处理请求，产生响应
        /// </summary>
        /// <returns></returns>
        public string Response()
        {
            cinfo = BLL.wx_configBLL.getInfo();
            if (cinfo == null)
            {
                return "微信配置参数未填写";
            }
            string method = Request.HttpMethod.ToUpper();
            //验证签名
            if (method == "GET")
            {
                if (CheckSignature())
                {
                    return Request.QueryString[ECHOSTR];
                }
                else
                {
                    return "error";
                }
            }

            //处理消息
            if (method == "POST")
            {
                return ResponseMsg();
            }
            else
            {
                return "无法处理";
            }
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns></returns>
        private string ResponseMsg()
        {
            string requestXml = Common.ReadRequest(this.Request);

            //Library.WriteTxt(requestXml, HttpContext.Current.Server.MapPath("/log/"), "微信接口调试" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

            IHandler handler = HandlerFactory.CreateHandler(requestXml);
            if (handler != null)
            {
                return handler.HandleRequest();
            }

            return string.Empty;
        }

        /// <summary>
        ///  获取Token值
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        private string GetToken()
        {
            string strhtml = string.Empty;
            strhtml = ConfigurationManager.AppSettings["wxtoken"] != null ? ConfigurationManager.AppSettings["wxtoken"].ToString() : cinfo.Token;
            //strhtml = cinfo.Token;
            return strhtml;
        }

        /// <summary>
        /// 检查签名
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = Request.QueryString[SIGNATURE];
            string timestamp = Request.QueryString[TIMESTAMP];
            string nonce = Request.QueryString[NONCE];

            List<string> list = new List<string>();
            list.Add(GetToken());
            list.Add(timestamp);
            list.Add(nonce);
            //排序
            list.Sort();
            //拼串
            string input = string.Empty;
            foreach (var item in list)
            {
                input += item;
            }
            //加密
            string new_signature = SecurityUtility.SHA1Encrypt(input);
            //验证
            if (new_signature == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
