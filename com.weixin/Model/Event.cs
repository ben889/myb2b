using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace com.weixin.Model
{
    public class Event
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
        /// 事件类型，CLICK
        /// </summary>
        public string Events { get; set; }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public string Precision { get; set; }

        /// <summary>
        /// 群发的消息ID
        /// </summary>
        public string MsgID { get; set; }

        /// <summary>
        /// 群发的结构，为“send success”或“send fail”或“err(num)”。但send success时，也有可能因用户拒收公众号的消息、系统错误等原因造成少量用户接收失败。err(num)是审核失败的具体原因，可能的情况如下：
        ///    err(10001), //涉嫌广告 err(20001), //涉嫌政治 err(20004), //涉嫌社会 err(20002), //涉嫌色情 err(20006), //涉嫌违法犯罪 err(20008), //涉嫌欺诈 err(20013), //涉嫌版权 err(22000), //涉嫌互推(互相宣传) err(21000), //涉嫌其他 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// group_id下粉丝数；或者openid_list中的粉丝数
        /// </summary>
        public string TotalCount { get; set; }

        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount + ErrorCount
        /// </summary>
        public string FilterCount { get; set; }

        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public string SentCount { get; set; }

        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public string ErrorCount { get; set; }

        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static Event LoadFromXml(string xml)
        {
            Event tm = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    tm = new Event();
                    tm.FromUserName = element.Element("FromUserName").Value;
                    tm.ToUserName = element.Element("ToUserName").Value;
                    tm.CreateTime = element.Element("CreateTime").Value;
                    tm.Events = element.Element("Event").Value;
                    if (element.Element("EventKey") != null)
                    {
                        tm.EventKey = element.Element("EventKey").Value;
                    }
                    if (element.Element("Ticket") != null)
                    {
                        tm.Ticket = element.Element("Ticket").Value;
                    }
                    if (element.Element("Latitude") != null)
                    {
                        tm.Latitude = element.Element("Latitude").Value;
                    }
                    if (element.Element("Longitude") != null)
                    {
                        tm.Longitude = element.Element("Longitude").Value;
                    }
                    if (element.Element("Precision") != null)
                    {
                        tm.Precision = element.Element("Precision").Value;
                    }

                    if (element.Element("MsgID") != null)
                    {
                        tm.MsgID = element.Element("MsgID").Value;
                    }
                    if (element.Element("Status") != null)
                    {
                        tm.Status = element.Element("Status").Value;
                    }
                    if (element.Element("TotalCount") != null)
                    {
                        tm.TotalCount = element.Element("TotalCount").Value;
                    }
                    if (element.Element("FilterCount") != null)
                    {
                        tm.FilterCount = element.Element("FilterCount").Value;
                    }
                    if (element.Element("SentCount") != null)
                    {
                        tm.SentCount = element.Element("SentCount").Value;
                    }

                    if (element.Element("ErrorCount") != null)
                    {
                        tm.ErrorCount = element.Element("ErrorCount").Value;
                    }
                }
            }

            return tm;
        }
    }
}
