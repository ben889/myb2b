using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Utility;
using com.weixin.Model;
using System.Data;
using BLL;
using Model;
using System.Web;
using com.weixin.User;
using com.weixin.Data;


namespace com.weixin.Handlers
{
    /// <summary>
    /// 文本信息处理类
    /// </summary>
    public class TextHandler : IHandler
    {
        /// <summary>
        /// 请求的XML
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml">请求的xml</param>
        public TextHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }


        //protected string domain;
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns></returns>
        public string HandleRequest()
        {
            //if (companyid.Trim().Length == 0)
            //    return "";
            //CompanysInfo cinfo = BLL.CompanysBLL.GetModel(companyid);
            //if (cinfo == null || !cinfo.CompanyId.Equals(companyid))
            //{
            //    return "";
            //}
            //domain = cinfo.domain;
            string response = string.Empty;
            try
            {
                try
                {
                    Text tm = Text.LoadFromXml(RequestXml);
                    string content = tm.Content.Trim();
                    int wx_userid = com.weixin.Data.wx_Users.CreateUser(tm.FromUserName, "", "", 1, "");
                    response = Reply.SetReply_KeyWord(tm, content);

                    //string url = Constant.URL_mobilesite();// System.Configuration.ConfigurationManager.AppSettings["WeiXinWebUrl"].ToString();
                    //StringBuilder strTgHtml = new StringBuilder();
                    //strTgHtml.Append("您好，请点击进入 <a href=\"" + url + "\">系统首页</a>");
                    //response = string.Format(Template.TextTemplate, tm.FromUserName, tm.ToUserName, Common.GetNowTime(), strTgHtml.ToString());

                }
                catch (Exception ex)
                {
                    FileUtility.WriteLog("记录用户文本消息错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
                }


                return response;
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("记录用户文本消息错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }

            return response;
        }


       

        #region  获取上传素材MediaId
        //private string GetMediaId(string companid, string type, string url)
        //{
        //    Companys_PayConfigInfo cinfo = Companys_PayConfigBLL.GetModel(companid);
        //    //获取AccessToken
        //    string AccessToken = Context.GetAccessToken(cinfo.AppId, cinfo.AppSecret);
        //    string DataXml = com.weixin.User.UserManager.UploadFile(AccessToken, type, System.Web.HttpContext.Current.Server.MapPath(url), "");
        //    CallBackMassMessages mediaModel = JSONHelper.ToModel<CallBackMassMessages>(DataXml);
        //    if (mediaModel != null && !string.IsNullOrEmpty(mediaModel.media_id))
        //    {
        //        return mediaModel.media_id;
        //    }
        //    else
        //    {
        //        AccessToken = Context.IsFailure(DataXml, cinfo.AppId, cinfo.AppSecret);
        //        if (!UserManager.IsJson(AccessToken))
        //        {
        //            DataXml = com.weixin.User.UserManager.UploadFile(AccessToken, type, System.Web.HttpContext.Current.Server.MapPath(url), "");
        //            mediaModel = JSONHelper.ToModel<CallBackMassMessages>(DataXml);
        //            if (mediaModel != null && !string.IsNullOrEmpty(mediaModel.media_id))
        //            {
        //                return mediaModel.media_id;
        //            }
        //        }
        //    }
        //    return "";
        //}

        //[Serializable]
        //private class CallBackMassMessages
        //{
        //    public CallBackMassMessages() { }
        //    public string access_token { set; get; }
        //    public string errcode { set; get; }
        //    public string errmsg { set; get; }
        //    public string msg_id { set; get; }
        //    public string type { set; get; }
        //    public string media_id { set; get; }
        //    public string created_at { set; get; }
        //}
        #endregion
    }
}
