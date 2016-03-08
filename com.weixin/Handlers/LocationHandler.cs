using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Model;
using com.weixin.Utility;
using com.weixin.User;

namespace com.weixin.Handlers
{
    class LocationHandler : IHandler
    {
        /// <summary>
        /// 请求的XML
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml">请求的xml</param>
        public LocationHandler(string requestXml)
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
            Location tm = Location.LoadFromXml(RequestXml);

            try
            {
                decimal lon = 0;
                decimal lat = 0;
                decimal.TryParse(tm.Location_X, out lat);
                decimal.TryParse(tm.Location_Y, out lon);
                 }
            catch (Exception ex)
            {
                FileUtility.WriteLog("接收地理位置错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return response;
        }
    }
}