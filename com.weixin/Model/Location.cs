using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace com.weixin.Model
{
    public class Location
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
        /// 地理位置维度
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Location LoadFromXml(string xml)
        {
            Location tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Location();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.Location_X = element.Element("Location_X").Value;
                    tm.Location_Y = element.Element("Location_Y").Value;
                    tm.Scale = element.Element("Scale").Value;
                    tm.Label = element.Element("Label").Value;
                    tm.MsgId = element.Element("MsgId").Value;
                }
            }

            return tm;
        }
    }
}
