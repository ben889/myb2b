﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Model;
using com.weixin.Utility;
using com.weixin.User;

namespace com.weixin.Handlers
{
    class VideoHandler : IHandler
    {
        /// <summary>
        /// 请求的XML
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml">请求的xml</param>
        public VideoHandler(string requestXml)
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
            Video tm = Video.LoadFromXml(RequestXml);

            try
            {
               }
            catch (Exception ex)
            {
                FileUtility.WriteLog("记录用户视频消息错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return response;
        }
    }
}
