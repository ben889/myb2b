using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using BLL;
using com.weixin.User;

namespace com.weixin.Utility
{
    public class Media
    {
        #region  获取上传素材MediaId
        public static string GetMediaId(string AppId, string AppSecret, string type, string url)
        {
            //获取AccessToken
            string AccessToken = Context.GetAccessToken(AppId, AppSecret);
            string DataXml = com.weixin.User.UserManager.UploadFile(AccessToken, type, System.Web.HttpContext.Current.Server.MapPath(url), "");
            CallBackMassMessages mediaModel = JSONHelper.ToModel<CallBackMassMessages>(DataXml);
            if (mediaModel != null && !string.IsNullOrEmpty(mediaModel.media_id))
            {
                return mediaModel.media_id;
            }
            else
            {
                AccessToken = Context.IsFailure(DataXml, AppId, AppSecret);
                if (!UserManager.IsJson(AccessToken))
                {
                    DataXml = com.weixin.User.UserManager.UploadFile(AccessToken, type, System.Web.HttpContext.Current.Server.MapPath(url), "");
                    mediaModel = JSONHelper.ToModel<CallBackMassMessages>(DataXml);
                    if (mediaModel != null && !string.IsNullOrEmpty(mediaModel.media_id))
                    {
                        return mediaModel.media_id;
                    }
                }
            }
            return "";
        }

        [Serializable]
        private class CallBackMassMessages
        {
            public CallBackMassMessages() { }
            public string access_token { set; get; }
            public string errcode { set; get; }
            public string errmsg { set; get; }
            public string msg_id { set; get; }
            public string type { set; get; }
            public string media_id { set; get; }
            public string created_at { set; get; }
        }
        #endregion


    }
}
