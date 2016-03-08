using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Model;
using com.weixin.Utility;
using com.weixin.User;
using System.Data;
using System.Text.RegularExpressions;
using Model;
using BLL;
using System.Web;
using com.weixin.Data;

namespace com.weixin.Handlers
{
    class EventHandler : IHandler
    {
        /// <summary>
        /// 请求的xml
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml"></param>
        public EventHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }

        #region 处理请求
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns></returns>
        public string HandleRequest()
        {
            string response = string.Empty;
            Event em = Event.LoadFromXml(RequestXml);

            if (em != null)
            {
                switch (em.Events.ToLower())
                {
                    case "subscribe":
                        response = SubscribeEventHandler(em);
                        break;
                    case "unsubscribe":
                        response = UnSubscribeEventHandler(em);
                        break;
                    case "scan": //扫描带参数二维码事件(2.用户已关注时的事件推送)
                        response = ScanEventHandler(em);
                        break;
                    case "click":
                        response = ClickEventHandler(em);
                        break;
                    case "location": //上报地理位置
                        response = SetLocation(em);
                        break;
                    case "masssendjobfinish": //推送群发结果反馈
                        response = SetMassSendJobFinish(em);
                        break;
                }
            }
            return response;
        }
        #endregion

        #region  推送群发结果反馈
        /// <summary>
        /// 推送群发结果反馈
        /// </summary>
        /// <param name="em"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string SetMassSendJobFinish(Event em)
        {
            string strhtml = string.Empty;

            return strhtml;
        }
        #endregion

        #region  关注
        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string SubscribeEventHandler(Event em)
        {
            //回复欢迎消息
            string strhtml = string.Empty;

            try
            {
                string AppId = ""; string AppSecret = "";
                wx_configInfo cinfo = BLL.wx_configBLL.getInfo();
                if (cinfo == null)
                {
                    AppId = cinfo.AppId;
                    AppSecret = cinfo.AppSecret;
                }

                int SourceType = 1;//用户来源：1平台自然发展，2用户分销发展
                string SourceID = "";//用户来源ID：SourceType=1时为0，SourceType=2时为分销商ID
                if (cinfo != null && em != null)
                {
                    //FileUtility.WriteLog("用户关注 em.EventKey：" + em.EventKey + "\r\n");
                    if (em.EventKey != null && em.EventKey.Length > 0)
                    {
                        string id = "";
                        id = em.EventKey.Replace("qrscene_", "");//扫描带二维码白事件关注，取ID
                        if (id.Trim().Contains("did_"))//带参数二维码
                        {

                            id = id.Replace("did_", "");

                            //SourceType = 2;
                            //SourceID = id;


                            //关联产品
                        }

                    }

                    strhtml = Reply.SetReply_Event_subscribe(em);
                }
                com.weixin.Data.wx_Users.CreateUser(em.FromUserName, "", "", SourceType, SourceID);

                //if (SourceType == 2 && SourceID.Trim().Length > 0)
                //{
                //    //==========如果是已有记录，则更改介绍人
                //    string resultMsg = "";
                //    BLL.sell_sellerBLL.update_parentid(em.FromUserName, SourceID, ref resultMsg);
                //    //====================
                //}


            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("用户关注错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return strhtml;
        }
        #endregion

        #region 替换A标签中href内
        string LinkHtml = string.Empty;
        /// <summary>
        /// 替换A标签中href内
        /// </summary>
        /// <param name="matchStr"></param>
        /// <returns></returns>
        private string SetLinkStyle(string matchStr)
        {
            string strhtml = string.Empty;
            try
            {
                //正则  
                Regex reg = new Regex("<[aA]\\s+((\\w+\\s*=\\s*(\"([^\"]*)\"|'([^']*)'|([^'\">\\s]+))\\s+)*)(href\\s*=\\s*(\"([^\"]*)\"|'([^']*)'|([^'\">\\s]+)))((\\s+\\w+\\s*=\\s*(\"([^\"]*)\"|'([^']*)'|([^'\">\\s]+)))*)\\s*>(.*?)</[aA]\\s*>");
                //此处可以完成任务（利用委托）  
                MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceCC);
                strhtml = reg.Replace(matchStr, myEvaluator);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strhtml;
        }
        //在这里单独处理每一个匹配项  
        private string ReplaceCC(Match m)
        {
            string temp = m.Groups[9].Value + m.Groups[10].Value + m.Groups[11].Value;
            string g18 = m.Groups[18].Value;
            if (temp.IndexOf("?") > 0) { temp += LinkHtml; } else { temp += "?" + LinkHtml.Substring(0, LinkHtml.Length - 1); }
            return "<a " + m.Groups[1].Value + " href=\" " + temp + "\" " + m.Groups[12].Value + ">" + g18 + "</a>";
        }
        #endregion

        #region 取消关注
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string UnSubscribeEventHandler(Event em)
        {
            string strhtml = string.Empty;

            try
            {

            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("用户取消关注错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return strhtml;

        }
        #endregion

        #region 用户已关注时的事件推送
        //用户已关注时的事件推送
        private string ScanEventHandler(Event em)
        {
            string strhtml = string.Empty;
            try
            {
                if (em != null && em.EventKey != null)
                {
                    int pid = 0;
                    int.TryParse(em.EventKey.Replace("qrscene_", ""), out pid);

                }
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("用户已关注时的事件推送错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }
            return strhtml;
        }
        #endregion

        #region 处理自定义菜单点击事件
        /// <summary>
        /// 处理自定义菜单点击事件
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string ClickEventHandler(Event em)
        {

            string AppId = ""; string AppSecret = "";
            wx_configInfo cinfo = BLL.wx_configBLL.getInfo();
            if (cinfo == null)
            {
                AppId = cinfo.AppId;
                AppSecret = cinfo.AppSecret;
            }

            int wx_userid = com.weixin.Data.wx_Users.CreateUser(em.FromUserName, "", "", 1, "");

            //FileUtility.WriteLog("菜单事件回复：AppId=" + AppId + " AppSecret=" + AppSecret + "\r\n");
            string result = string.Empty;
            try
            {
                if (em != null && em.EventKey != null)
                {
                    //FileUtility.WriteLog("菜单事件回复：em.EventKey=" + em.EventKey + "\r\n");
                    string[] arr = em.EventKey.Split('_');
                    //FileUtility.WriteLog("菜单事件回复：arr[0]=" + arr[0] + "\r\n");
                    //FileUtility.WriteLog("菜单事件回复：arr[1]=" + arr[1] + "\r\n");
                    if (arr[0].ToUpper().Contains("IMGTEXT"))//如果是图文回复
                    {
                        int MaterialID = 0;
                        int.TryParse(arr[1], out MaterialID);
                        return Reply.setRely_wx_Material(AppId, AppSecret, em.FromUserName, em.ToUserName, MaterialID);
                    }
                    if (arr[0].ToUpper().Equals("TEXT"))//如果是文本回复
                    {
                        int MenuId = 0;
                        int.TryParse(arr[1], out MenuId);
                        if (MenuId > 0)
                        {
                            wx_diymenuInfo wx_diymenuinfo = BLL.wx_diymenuBLL.GetModel(MenuId);
                            if (wx_diymenuinfo != null && wx_diymenuinfo.MenuId == MenuId)
                            {
                                //return wx_diymenuinfo.Body;
                                return string.Format(Template.TextTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), wx_diymenuinfo.Body);
                            }
                        }
                    }


                    //StringBuilder strHtml = new StringBuilder();
                    //string host = "http://" + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port);
                    //IList<wx_MaterialInfo> list = wx_MaterialBLL.getlist_appmsg(MaterialID);
                    ////FileUtility.WriteLog("菜单事件回复：list.Count=" + list.Count + "\r\n");
                    ////设置欢迎语句
                    //if (list != null && list.Count > 0)
                    //{
                    //    //1文字，2图片，3图文，4音频，5视频
                    //    switch (list[0].Type)
                    //    {
                    //        case 1:
                    //            result = string.Format(Template.TextTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), list[0].Body);
                    //            break;
                    //        case 2:
                    //            result = string.Format(Template.ImageTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "image", list[0].Url));
                    //            break;
                    //        case 3:
                    //            foreach (wx_MaterialInfo m in list)
                    //            {
                    //                strHtml.Append(string.Format(Template.ItemTemplate, m.Name, m.Paper, host + m.ImgUrl, host + "/mobile/wx/wx_appmsg.aspx?id=" + m.wx_MaterialID));
                    //            }
                    //            result = string.Format(Template.NewsTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), list.Count, strHtml.ToString());
                    //            break;
                    //        case 4:
                    //            result = string.Format(Template.VoiceTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "voice", list[0].Url));
                    //            break;
                    //        case 5:
                    //            result = string.Format(Template.VideoTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "video", list[0].Url), list[0].Name, list[0].Paper);
                    //            break;
                    //    }
                    //}
                }
            }

            catch (Exception ex)
            {
                FileUtility.WriteLog("用户点击事件错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }
            //FileUtility.WriteLog("菜单事件回复：" + result + "\r\n");
            return result;
        }
        #endregion

        #region  上报地理位置
        /// <summary>
        /// 上报地理位置
        /// </summary>
        /// <param name="em"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string SetLocation(Event em)
        {
            try
            {
                decimal lon = 0;
                decimal lat = 0;
                decimal.TryParse(em.Longitude, out lon);
                decimal.TryParse(em.Latitude, out lat);
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("上报地理位置错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }
            return null;
        }
        #endregion
    }
}
