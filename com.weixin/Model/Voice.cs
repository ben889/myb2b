using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using com.weixin.Utility;

namespace com.weixin.Model
{
    public class Voice
    {
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取该媒体
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式：amr
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 语音识别结果，UTF8编码
        /// </summary>
        public string Recognition { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Voice LoadFromXml(string xml)
        {
            Voice tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Voice();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.MediaId = element.Element("MediaId").Value;
                    tm.Format = element.Element("Format").Value;
                    try
                    {
                        if (element.Element("Recognition") != null)
                        {
                            tm.Recognition = element.Element("Recognition").Value;
                        }
                    }
                    catch { }
                    tm.MsgId = element.Element("MsgId").Value;
                }
            }

            return tm;
        }
    }
}
