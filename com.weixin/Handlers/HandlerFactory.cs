using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using com.weixin.Utility;

namespace com.weixin.Handlers
{
    /// <summary>
    /// 处理器工厂类
    /// </summary>
    public class HandlerFactory
    {
        /// <summary>
        /// 创建处理器
        /// </summary>
        /// <param name="requestXml">请求的xml</param>
        /// <returns>IHandler对象</returns>
        public static IHandler CreateHandler(string requestXml)
        {
            IHandler handler = null;
            if (!string.IsNullOrEmpty(requestXml))
            {
                //解析数据
                XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(requestXml);
                XmlNode node = doc.SelectSingleNode("/xml/MsgType");
                if (node != null)
                {
                    XmlCDataSection section = node.FirstChild as XmlCDataSection;
                    if (section != null)
                    {
                        string msgType = section.Value;
                        switch (msgType)
                        {
                            case "text":    //文本消息
                                handler = new TextHandler(requestXml);
                                break;
                            case "image":   //图片消息
                                handler = new ImageHandler(requestXml);
                                break;
                            case "voice":    //语音消息
                                handler = new VoiceHandler(requestXml);
                                break;
                            case "video":    //视频消息
                                handler = new VideoHandler(requestXml);
                                break;
                            case "location":  //地理位置消息
                                handler = new LocationHandler(requestXml);
                                break;
                            case "link":      //链接消息
                                handler = new LinkHandler(requestXml);
                                break;
                            case "event":    //事件推送
                                handler = new EventHandler(requestXml);
                                break;
                        }
                    }
                }
            }

            return handler;
        }
    }
}
