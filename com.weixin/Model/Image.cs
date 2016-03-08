using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace com.weixin.Model
{
    public class Image
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
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Image LoadFromXml(string xml)
        {
            Image tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Image();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.PicUrl = element.Element("PicUrl").Value;
                    tm.MediaId = element.Element("MediaId").Value;
                    tm.MsgId = element.Element("MsgId").Value;
                }
            }

            return tm;
        }
    }
}
