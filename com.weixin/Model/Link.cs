using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace com.weixin.Model
{
    public class Link
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
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Link LoadFromXml(string xml)
        {
            Link tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Link();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.Title = element.Element("Title").Value;
                    tm.Description = element.Element("Description").Value;
                    tm.Url = element.Element("Url").Value;
                    tm.MsgId = element.Element("MsgId").Value;
                }
            }

            return tm;
        }
    }
}
