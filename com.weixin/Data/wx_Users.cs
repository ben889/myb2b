using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Utility;
using com.weixin.Model;
using System.IO;
using BLL;
using Model;
using Common;
using com.weixin.User;
using System.Web;

namespace com.weixin.Data
{
    public class wx_Users
    {
        #region  判断用户是否已经创建，如果创建则修改账户的状态，没有则创建新用户
        /// <summary>
        /// 判断用户是否已经创建，如果创建则修改账户的状态，没有则创建新用户
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="SourceType">用户来源：1平台自然发展，2分销商发展</param>
        /// <param name="SourceID">用户来源ID：SourceType=1时为0，SourceType=2时为分销商ID</param>
        /// <returns></returns>
        public static int CreateUser(string FromUserName, string lng, string lat, int SourceType, string SourceID)
        {
            wx_configInfo cinfo = wx_configBLL.getInfo();
            if (cinfo != null)
            {
                FileUtility.WriteLog("获取分站信息错误：" + DateTime.Now.ToString() + " \r\n");
                return 0;
            }
            string AccessToken = Context.GetAccessToken(cinfo.AppId, cinfo.AppSecret);
            if (AccessToken.Trim().Length == 0)
            {
                FileUtility.WriteLog("创建用户失败AccessToken为空 \r\n");
                return 0;
            }
            return CreateUser(FromUserName, AccessToken, cinfo.AppId, cinfo.AppSecret, lng, lat, SourceType, SourceID);
        }
        /// <summary>
        /// 判断用户是否已经创建，如果创建则修改账户的状态，没有则创建新用户
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="AccessToken"></param>
        /// <param name="AppId"></param>
        /// <param name="AppSecret"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="SourceType">用户来源：1平台自然发展，2分销商发展</param>
        /// <param name="SourceID">用户来源ID：SourceType=1时为0，SourceType=2时为分销商ID</param>
        /// <returns></returns>
        public static int CreateUser(string FromUserName, string AccessToken, string AppId, string AppSecret, string lng, string lat, int SourceType, string SourceID)
        {
            //FileUtility.WriteLog("创建新用户参数：FromUserName=" + FromUserName + " SourceType=" + SourceType + " SourceID=" + SourceID + "\r\n");
            int userid = 0;
            //Companys_PayConfigInfo model = Companys_PayConfigBLL.GetModel(companyid);
            //if (model == null || !model.CompanyId.Equals(companyid))
            //{
            //    FileUtility.WriteLog("获取分站信息错误：" + DateTime.Now.ToString() + " 分站信息不存在companyid=" + companyid + " \r\n");
            //    return 0;
            //}
            //string AppId = ""; string AppSecret = "";
            //AppId = model.AppId;
            //AppSecret = model.AppSecret;


            try
            {
                //判断用户是否已经创建，如果创建则修改账户的状态，没有则创建新用户
                wx_UsersInfo openEntity = wx_UsersBLL.GetModel(FromUserName, "OpenId", "*");
                if (openEntity != null)
                {
                    if (lng.Trim().Length > 0)
                    {
                        openEntity.Lng = lng;
                    }
                    if (lat.Trim().Length > 0)
                    {
                        openEntity.Lat = lat;
                    }

                    openEntity.State = 1;
                    openEntity.LastTime = DateTime.Now;

                    //获取AccessToken
                    //string AccessToken = Context.GetAccessToken(model.AppId, model.AppSecret);
                    //FileUtility.WriteLog("更改微信user信息-AccessToken编码：" + AccessToken + "\r\n");
                    //用户基本信息
                    string result = UserManager.GetUserInfoByAccessToken(AccessToken, FromUserName);
                    //FileUtility.WriteLog("更改微信user信息-GetUserInfoByAccessToken结果：" + result + "\r\n");
                    result = Context.IsFailure(result, AppId, AppSecret);
                    //FileUtility.WriteLog("更改微信user信息-IsFailure结果：" + result + "\r\n");
                    if (!IsJson(result))
                    {
                        //FileUtility.WriteLog("result编码111~：" + DateTime.Now.ToString() + " 企业ID:" + type.ToString() + " | " + result + "\r\n");
                        result = UserManager.GetUserInfoByAccessToken(result, FromUserName);
                        //FileUtility.WriteLog("更改微信user信息!IsJson - GetUserInfoByAccessToken：" + result + "\r\n");
                    }
                    com.weixin.Model.UserInfo entity = XmlUtility.JsonToUserInfo(result);
                    if (entity != null)
                    {
                        int sex = 0;
                        int.TryParse(entity.Sex, out sex);
                        openEntity.Sex = sex;
                        if (!string.IsNullOrEmpty(entity.Nickname))
                        {
                            openEntity.NickName = entity.Nickname;
                        }
                        if (!string.IsNullOrEmpty(entity.Headimgurl))
                        {
                            openEntity.Head = entity.Headimgurl;
                        }

                        //if (string.IsNullOrEmpty(openEntity.SourceID))
                        //{
                        //    openEntity.SourceID = SourceID;
                        //}
                    }
                    wx_UsersBLL.update(openEntity);
                    userid = openEntity.wx_userid;
                }
                else
                {
                    //获取AccessToken
                    //string AccessToken = Context.GetAccessToken(model.AppId, model.AppSecret);
                    //FileUtility.WriteLog("AccessToken编码：" + AccessToken + "\r\n");
                    //用户基本信息
                    string result = UserManager.GetUserInfoByAccessToken(AccessToken, FromUserName);
                    //FileUtility.WriteLog("GetUserInfoByAccessToken结果：" + result + "\r\n");
                    result = Context.IsFailure(result, AppId, AppSecret);
                    //FileUtility.WriteLog("IsFailure结果：" + result + "\r\n");
                    if (!IsJson(result))
                    {
                        //FileUtility.WriteLog("result编码111：" + DateTime.Now.ToString() + " 企业ID:" + type.ToString() + " | " + result + "\r\n");
                        result = UserManager.GetUserInfoByAccessToken(result, FromUserName);
                        //FileUtility.WriteLog("!IsJson - GetUserInfoByAccessToken：" + result + "\r\n");
                    }
                    com.weixin.Model.UserInfo entity = XmlUtility.JsonToUserInfo(result);

                    int sex = 0;
                    string name = "";
                    string Headimgurl = "";

                    if (entity != null)
                    {
                        int.TryParse(entity.Sex, out sex);
                        if (!string.IsNullOrEmpty(entity.Nickname))
                        {
                            name = entity.Nickname;
                        }
                        if (!string.IsNullOrEmpty(entity.Headimgurl))
                        {
                            Headimgurl = entity.Headimgurl;
                        }
                    }

                    //创建普通用户
                    wx_UsersInfo UserEntity = new wx_UsersInfo()
                    {
                        OpenId = FromUserName,
                        companyid = "",
                        Head = Headimgurl,
                        NickName = name,
                        Lng = lng,
                        Lat = lat,
                        QRCode = "",
                        Sex = sex,
                        State = 1,
                        LastTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        SourceType = SourceType,
                        SourceID = SourceID
                    };
                    string resultMsg = "";
                    userid = wx_UsersBLL.add(UserEntity, ref resultMsg);
                    if (userid <= 0)
                    {
                        FileUtility.WriteLog("创建与修改用户错误：FromUserName=" + FromUserName + " err：" + resultMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("创建与修改用户错误：FromUserName=" + FromUserName + " err：" + ex.ToString());
            }


            return userid;
        }
        #endregion


        #region 自定义生成带参数的二维码
        /// <summary>
        /// 自定义生成带参数的二维码
        /// </summary>
        /// <param name="TypeID">类型ID（1：分销商）</param>
        /// <param name="id">相对应于类型的ID</param>
        /// <param name="CodeType">二维码类型：1临时二维码，2永久二维码</param>
        /// <returns></returns>
        public static string CreateQRCode(int TypeID, string id, int CodeType)
        {
            string revalue = string.Empty;
            string qrcodeURL = Constant.URL_QRCode();
            try
            {
                
                string AppId = ""; string AppSecret = "";
                wx_configInfo model = wx_configBLL.getInfo();
                if (model != null)
                {
                    AppId = model.AppId;
                    AppSecret = model.AppSecret;
                }
                if (model != null)
                {
                    //获取AccessToken
                    string AccessToken = Context.GetAccessToken(model.AppId, model.AppSecret);
                    string data = string.Empty;
                    if (CodeType == 1)
                    {
                        data = " {\"expire_seconds\": \"1800\", \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + id + "}}}";
                    }
                    else
                    {
                        //data = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + id + "}}}";
                        string scene_str = id;
                        if (TypeID == 1)//如果是用户
                            scene_str = "member_" + id;
                        data = "{\"action_name\": \"QR_LIMIT_STR_SCENE\", \"action_info\": {\"scene\": {\"scene_str\": \"" + scene_str + "\"}}}";
                    }
                    string code = com.weixin.User.UserManager.CreateCodeTicket(AccessToken, data);
                    code = Context.IsFailure(code, model.AppId, model.AppSecret);

                    if (!IsJson(code))
                    {
                        code = com.weixin.User.UserManager.CreateCodeTicket(code, data);
                    }

                    if (!string.IsNullOrEmpty(code))
                    {
                        QRCode QRCodeModel = JSONHelper.JsonToObject<QRCode>(code);
                        if (QRCodeModel != null && !string.IsNullOrEmpty(QRCodeModel.ticket))
                        {
                            //string dirPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"].ToString();

                            switch (TypeID)
                            {
                                case 1:
                                    if (CodeType == 2) { qrcodeURL += "Forever/"; }
                                    break;
                            }

                            int type = 1;//展示还是下载（1下载，2展示）
                            //绝对路径，要截取,用用户ID+产品ID来区别此产品有没有生成二维码
                            string QRImg = com.weixin.User.UserManager.GetCodeTicket(System.Web.HttpUtility.UrlDecode(QRCodeModel.ticket), type, System.Web.HttpContext.Current.Server.MapPath(qrcodeURL), id.ToString());
                            if (!string.IsNullOrEmpty(QRImg) && type == 1)
                            {
                                string tmpRootDir = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
                                QRImg = QRImg.Replace(tmpRootDir, "").Replace("\\", "/"); //转换成相对路径
                                if (QRImg.Substring(0, 1) != "/")
                                {
                                    QRImg = "/" + QRImg;
                                }

                            }
                            revalue = QRImg;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("自定义生成带参数的二维码错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }
            return revalue;
        }

        /// <summary>
        /// 判断是否已经生成了自定义生成带参数的二维码错误
        /// </summary>
        /// <param name="TypeID">类型ID（1：用户）</param>
        /// <param name="id">相对应于类型的ID</param>
        /// <param name="CodeType">二维码类型：1临时二维码，2永久二维码</param>
        /// <returns>返回二维码的绝对路径</returns>
        public static string IsExistsQRCode(int TypeID, string id, int CodeType)
        {
            string str = string.Empty;
            try
            {
                string qrcodeURL = Constant.URL_QRCode();
                switch (TypeID)
                {
                    case 1:
                        if (CodeType == 2) { qrcodeURL += "Forever/"; }
                        break;
                }
                qrcodeURL += id + ".jpg";

                if (File.Exists(HttpContext.Current.Server.MapPath(qrcodeURL)))
                {
                    str = qrcodeURL;
                }
                else
                {
                    str = CreateQRCode(TypeID, id, CodeType);
                    //UserManager.DownloadFile(str, HttpContext.Current.Server.MapPath(Constant.URL_QRCode()), id + ".jpg");
                }
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("获取自定义生成带参数的二维码错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
            }
            //FileUtility.WriteLog("获取自定义生成带参数的二维码地址：" + str + " \r\n");
            return str;
        }

        /// <summary>
        /// 判断是否为Json格式数据
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns></returns>
        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
        #endregion
    }
}
