using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace com.weixin.Model
{
    public class Text
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
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Text LoadFromXml(string xml)
        {
            Text tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Text();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.Content = element.Element("Content").Value;
                    tm.MsgId = element.Element("MsgId").Value;
                }
            }

            return tm;
        }
    }
}
