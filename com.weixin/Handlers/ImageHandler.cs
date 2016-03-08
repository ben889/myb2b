using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Model;
using com.weixin.Utility;
using com.weixin.User;

namespace com.weixin.Handlers
{
    class ImageHandler : IHandler
    {
        /// <summary>
        /// 请求的XML
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml">请求的xml</param>
        public ImageHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns></returns>
        public string HandleRequest()
        {
            string response = string.Empty;


            try
            {
                Image image = Image.LoadFromXml(RequestXml);
                string MediaId = image.MediaId.Trim();

                //string url = Constant.URL_mobilesite();// System.Configuration.ConfigurationManager.AppSettings["WeiXinWebUrl"].ToString();
                StringBuilder strTgHtml = new StringBuilder();
                //strTgHtml.Append("您好，您上传了图片，图片地址是：" + image.PicUrl + " 请点击进入 <a href=\"" + image.PicUrl + "\">查看图片</a>");
                //response = string.Format(Template.TextTemplate, image.FromUserName, image.ToUserName, Common.GetNowTime(), strTgHtml.ToString());
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("记录用户图片消息错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return response;
        }
    }
}
