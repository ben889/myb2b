using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Web;
using com.weixin.Model;
using BLL;
using com.weixin.Utility;

namespace com.weixin.Data
{
    public class Reply
    {
        #region  关键字回复
        /// <summary>
        /// 关键字回复
        /// </summary>
        /// <param name="em">事件类型</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SetReply_KeyWord(Text em, string content)
        {
            List<wx_ReplyKeyInfo> keylist = BLL.wx_ReplyKeyBLL.GetList(1, " [Name] like '%" + content + "%'", "");
            if (keylist != null && keylist.Count > 0)
            {
                wx_ReplyMesageInfo Message = wx_ReplyMesageBLL.GetModel(keylist[0].ReplyID);
                //设置欢迎语句
                if (Message != null && Message.ReplyID == keylist[0].ReplyID)
                {
                    return setReply(em.FromUserName, em.ToUserName, Message.ReplyID);
                }
            }
            return "";

            #region
            //Companys_PayConfigInfo cinfo = Companys_PayConfigBLL.GetModel(companyid);
            //string AppId = ""; string AppSecret = "";
            //if (cinfo != null && cinfo.CompanyId.Equals(companyid))
            //{
            //    AppId = cinfo.AppId;
            //    AppSecret = cinfo.AppSecret;
            //}
            //string strhtml = string.Empty;
            //try
            //{
            //    //FileUtility.WriteLog("companyid:" + companyid + " content：" + content + "\r\n");
            //    List<wx_ReplyKeyInfo> keylist = BLL.wx_ReplyKeyBLL.GetList(1, BLL.DataPermissionBLL.getclientsql(companyid, "") + " AND [Name] like '%" + content + "%'", "");
            //    if (keylist != null && keylist.Count > 0)
            //    {
            //        wx_ReplyMesageInfo Message = wx_ReplyMesageBLL.GetModel(keylist[0].ReplyID);
            //        //设置欢迎语句
            //        if (Message != null && Message.ReplyID == keylist[0].ReplyID)
            //        {
            //            StringBuilder strHtml = new StringBuilder();
            //            string host = "http://" + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port);
            //            //FileUtility.WriteLog("host：" + host + "\r\n");
            //            if (Message.RefType == 1)
            //            {
            //                strhtml = string.Format(Template.TextTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Message.Body);
            //            }
            //            else
            //            {
            //                //FileUtility.WriteLog("Message.RefID：" + Message.RefID + "\r\n");
            //                //string strlist = wx_MaterialBLL.getjson_appmsg(Message.RefID);
            //                //FileUtility.WriteLog("strlist：" + strlist + "\r\n");
            //                IList<wx_MaterialInfo> list = wx_MaterialBLL.getlist_appmsg(Message.RefID);
            //                //设置欢迎语句
            //                //IList<wx_MaterialInfo> list = JSONHelper.JsonToObject<IList<wx_MaterialInfo>>(strlist);
            //                if (list != null && list.Count > 0)
            //                {
            //                    //FileUtility.WriteLog("list.Count：" + list.Count + "\r\n");
            //                    //1文字，2图片，3图文，4音频，5视频
            //                    switch (list[0].Type)
            //                    {
            //                        case 1:
            //                            strhtml = string.Format(Template.TextTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), list[0].Body);
            //                            break;
            //                        case 2:
            //                            strhtml = string.Format(Template.ImageTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "image", list[0].Url));
            //                            break;
            //                        case 3:
            //                            foreach (wx_MaterialInfo m in list)
            //                            {
            //                                strHtml.Append(string.Format(Template.ItemTemplate, m.Name, m.Paper, host + m.ImgUrl, host + "/mobile/wx/wx_appmsg.aspx?id=" + m.wx_MaterialID));
            //                            }
            //                            strhtml = string.Format(Template.NewsTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), list.Count, strHtml.ToString());
            //                            break;
            //                        case 4:
            //                            strhtml = string.Format(Template.VoiceTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "voice", list[0].Url));
            //                            break;
            //                        case 5:
            //                            strhtml = string.Format(Template.VideoTemplate, em.FromUserName, em.ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "video", list[0].Url), list[0].Name, list[0].Paper);
            //                            break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            ////FileUtility.WriteLog("文本回复：" + strhtml + "\r\n");
            //return strhtml;
            #endregion
        }
        #endregion
        /// <summary>
        /// 关注事件回复
        /// </summary>
        /// <param name="em">事件类型</param>
        /// <param name="companyid">companyid</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SetReply_Event_subscribe(Event em)
        {

            List<wx_ReplyMesageInfo> Message_list = wx_ReplyMesageBLL.GetList(1, "replytype=1", "");
            if (Message_list == null || Message_list.Count == 0)
                return "";
            wx_ReplyMesageInfo Message = Message_list[0];
            //设置欢迎语句
            if (Message != null && Message.ReplyID > 0)
            {
                return setReply(em.FromUserName, em.ToUserName, Message.ReplyID);
            }

            return "";
        }

        public static string setReply(string FromUserName, string ToUserName, int ReplyID)
        {
            string AppId = ""; string AppSecret = "";
            wx_configInfo cinfo = wx_configBLL.getInfo();
            if (cinfo != null)
            {
                AppId = cinfo.AppId;
                AppSecret = cinfo.AppSecret;
            }
            string strhtml = string.Empty;
            try
            {

                wx_ReplyMesageInfo Message = wx_ReplyMesageBLL.GetModel(ReplyID);
                //设置欢迎语句
                if (Message != null && Message.ReplyID == ReplyID)
                {
                    StringBuilder strHtml = new StringBuilder();
                    string host = "http://" + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port);
                    //FileUtility.WriteLog("host：" + host + "\r\n");
                    if (Message.RefType == 1)
                    {
                        strhtml = string.Format(Template.TextTemplate, FromUserName, ToUserName, Common.GetNowTime(), Message.Body);
                    }
                    else
                    {
                        //FileUtility.WriteLog("Message.RefID：" + Message.RefID + "\r\n");
                        IList<wx_MaterialInfo> list = wx_MaterialBLL.getlist_appmsg(Message.RefID);
                        //设置欢迎语句
                        //IList<wx_MaterialInfo> list = JSONHelper.JsonToObject<IList<wx_MaterialInfo>>(strlist);
                        if (list != null && list.Count > 0)
                        {
                            //FileUtility.WriteLog("list.Count：" + list.Count + "\r\n");
                            //1文字，2图片，3图文，4音频，5视频
                            switch (list[0].Type)
                            {
                                case 1:
                                    strhtml = string.Format(Template.TextTemplate, FromUserName, ToUserName, Common.GetNowTime(), list[0].Body);
                                    break;
                                case 2:
                                    strhtml = string.Format(Template.ImageTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "image", list[0].Url));
                                    break;
                                case 3:
                                    foreach (wx_MaterialInfo m in list)
                                    {
                                        string url = host + "/mobile/wx/wx_appmsg.aspx?id=" + m.wx_MaterialID;
                                        if (m.Url.Trim().Length > 0)
                                            url = m.Url;
                                        strHtml.Append(string.Format(Template.ItemTemplate, m.Name, m.Paper, host + m.ImgUrl, url));
                                    }
                                    strhtml = string.Format(Template.NewsTemplate, FromUserName, ToUserName, Common.GetNowTime(), list.Count, strHtml.ToString());
                                    break;
                                case 4:
                                    strhtml = string.Format(Template.VoiceTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "voice", list[0].Url));
                                    break;
                                case 5:
                                    strhtml = string.Format(Template.VideoTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "video", list[0].Url), list[0].Name, list[0].Paper);
                                    break;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //FileUtility.WriteLog("文本回复：" + strhtml + "\r\n");
            return strhtml;
        }

        public static string setRely_wx_Material(string AppId, string AppSecret, string FromUserName, string ToUserName, int MaterialID)
        {
            IList<wx_MaterialInfo> list = wx_MaterialBLL.getlist_appmsg(MaterialID);
            StringBuilder strHtml = new StringBuilder();
            string strhtml = string.Empty;
            string host = "http://" + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port);
            switch (list[0].Type)
            {
                case 1:
                    strhtml = string.Format(Template.TextTemplate, FromUserName, ToUserName, Common.GetNowTime(), list[0].Body);
                    break;
                case 2:
                    strhtml = string.Format(Template.ImageTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "image", list[0].Url));
                    break;
                case 3:
                    foreach (wx_MaterialInfo m in list)
                    {
                        string url = host + "/mobile/wx/wx_appmsg.aspx?id=" + m.wx_MaterialID;
                        if (m.Url.Trim().Length > 0)
                            url = m.Url;
                        strHtml.Append(string.Format(Template.ItemTemplate, m.Name, m.Paper, host + m.ImgUrl, url));
                    }
                    strhtml = string.Format(Template.NewsTemplate, FromUserName, ToUserName, Common.GetNowTime(), list.Count, strHtml.ToString());
                    break;
                case 4:
                    strhtml = string.Format(Template.VoiceTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "voice", list[0].Url));
                    break;
                case 5:
                    strhtml = string.Format(Template.VideoTemplate, FromUserName, ToUserName, Common.GetNowTime(), Media.GetMediaId(AppId, AppSecret, "video", list[0].Url), list[0].Name, list[0].Paper);
                    break;
            }
            return strhtml;
        }

    }
}
