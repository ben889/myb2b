using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.weixin;

namespace WebSite.api
{
    /// <summary>
    /// weixin 的摘要说明
    /// </summary>
    public class weixin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //if (context.Request["s"] != null)
                //{
                //    companyid = DESEncrypt.Decrypt(context.Request["s"]);
                //}
                //由微信服务接收请求，具体处理请求
                WeiXinService wxService = new WeiXinService(context.Request);
                string responseMsg = wxService.Response();
                context.Response.Clear();
                context.Response.Charset = "UTF-8";
                context.Response.Write(responseMsg);
                //Common.Library.WriteTxt(responseMsg, HttpContext.Current.Server.MapPath("/log/"), "微信接口调试" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                
            }
            catch (Exception exc)
            {
                Common.Library.WriteTxt(exc.Message, HttpContext.Current.Server.MapPath("/log/"), "微信接口调试" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            }
            finally {
                context.Response.End();
            }
            
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