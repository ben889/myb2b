using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Utility;
using System.IO;
using System.Net;
using com.weixin.Model;
using System.Diagnostics;
using Newtonsoft.Json;
using Common;
namespace com.weixin.User
{
    /// <summary>
    /// 用户管理类
    /// </summary>
    public class UserManager
    {
        #region 分组管理接口
        /// <summary>
        /// 创建分组(一个公众账号，最多支持创建500个分组)
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">分组名称（例子：{"group":{"name":"test"}}）</param> 
        /// <returns>{"group": { "id": 107,  "name": "test"}} （id:分组id，由微信分配；name:分组名字，UTF8编码）</returns>
        public static string CreateGroup(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <returns>{"groups": { "id": 107,  "name": "test"，"count": 72596}} （id:分组id，由微信分配；name:分组名字，UTF8编码；count：分组内用户数量）</returns>
        public static string GetAllGroup(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", AccessToken);
            return HttpUtility.GetData(url);
        }

        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">用户的OpenID(例子：{"openid":"od8XIjsmk6QdVTETa9jLtGWA6KBc"})</param>
        /// <returns>{"groupid": 102} （groupid：用户所属的groupid）</returns>
        public static string GetGroupByOpenId(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">分组ID和名称 (例子：{"group":{"id":108,"name":"test2_modify2"}})</param>
        /// <returns>{"errcode": 0, "errmsg": "ok"}</returns>
        public static string UpdateGroup(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">  用户的OpenID和分组ID (例子：{"openid":"oDF3iYx0ro3_7jD4HFRDfrjdCM58","to_groupid":108})</param>
        /// <returns>{"errcode": 0, "errmsg": "ok"}</returns>
        public static string MoveGroup(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }
        #endregion

        #region 用户基本信息接口

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="AppSecret"></param>
        /// <param name="curr_url"></param>
        /// <param name="mid"></param>
        public static void wxlogin(string AppId, string AppSecret, string curr_url, string uid)
        {
            
            if (AppId.Trim().Length == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('AppId错误');</script>");
                return;
            }
            if (AppSecret.Trim().Length == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('AppSecret错误');</script>");
                return;
            }
            //State_Str = curr_url;
            string AuthorizeBack_url = Constant.Get_Host() + "/api/wxlogin.ashx";

            //string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect"
            //    , AppId, AuthorizeBack_url, curr_url);
            string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect"
                , AppId, AuthorizeBack_url, curr_url + "@" + uid);
            FileUtility.WriteLog(code_url);
            System.Web.HttpContext.Current.Response.Redirect(code_url);

            //string code = System.Web.HttpContext.Current.Request.QueryString["code"] != null ? System.Web.HttpContext.Current.Request.QueryString["code"] : "";
            //if (string.IsNullOrEmpty(code))
            //{
            //    string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect"
            //        , AppId, curr_url, State_Str);
            //    //FileUtility.WriteLog("code_url：" + code_url + "\r\n");
            //    System.Web.HttpContext.Current.Response.Redirect(code_url);
            //}
            //else
            //{
            //    //获取ACCESS_TOKEN与OPENID

            //    #region 获取支付用户 OpenID================
            //    string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppId, AppSecret, code);
            //    string returnStr = HttpUtility.SendHttpRequest(url, "");
            //    //LogUtil.WriteLog("Send 页面  returnStr 第一个：" + returnStr);

            //    var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

            //    url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", AppId, obj.refresh_token);
            //    returnStr = HttpUtility.SendHttpRequest(url, "");
            //    obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);


            //    //url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
            //    //returnStr = HttpUtility.SendHttpRequest(url, "");

            //    openid = obj.openid;
            //    //FileUtility.WriteLog("UserOpenId：" + openid + "\r\n");
            //    //System.Web.HttpContext.Current.Response.Redirect(next_url + "?openid=" + UserOpenId);
            //    #endregion
            //}
        }

        /// <summary>
        /// 通过access_token和openid获取用户信息
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="openid">用户的OpenID</param>
        /// <returns>
        ///     subscribe	 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        ///     openid	 用户的标识，对当前公众号唯一
        ///     nickname	 用户的昵称
        ///     sex	 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        ///     city	 用户所在城市
        ///     country	 用户所在国家
        ///     province	 用户所在省份
        ///     language	 用户的语言，简体中文为zh_CN
        ///     headimgurl	 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        ///     subscribe_time	 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        ///</returns>
        public static string GetUserInfoByAccessToken(string AccessToken, string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", AccessToken, openid);
            return HttpUtility.GetData(url);
        }

        /// <summary>
        /// 通过code换取网页授权access_token和openid获取用户信息
        /// </summary>
        /// <param name="accesstoken">网页授权access_token</param>
        /// <param name="openid">用户的OpenID</param>
        /// <returns>
        ///     openid	 用户的唯一标识
        ///     nickname	 用户昵称
        ///     sex	 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        ///     province	 用户个人资料填写的省份
        ///     city	 普通用户个人资料填写的城市
        ///     country	 国家，如中国为CN
        ///     headimgurl	 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        ///     privilege	 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </returns>
        public static string GetUserInfoByAuthorizeAccessToken(string AccessToken, string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", AccessToken, openid);
            return HttpUtility.GetData(url);
        }

        #endregion

        #region  关注者列表接口
        /// <summary>
        ///   获取关注者列表
        ///   当公众号关注者数量超过10000时，可通过填写next_openid的值，从而多次拉取列表的方式来满足需求。
        ///   具体而言，就是在调用接口时，将上一次调用得到的返回中的next_openid值，作为下一次调用中的next_openid值。
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="NextOpenid">第一个拉取的OPENID，不填默认从头开始拉取</param> 
        /// <returns>
        ///    total	 关注该公众账号的总用户数
        ///    count	 拉取的OPENID个数，最大值为10000
        ///    data	 列表数据，OPENID的列表
        ///    next_openid	 拉取列表的后一个用户的OPENID
        /// </returns>
        public static string GetAttention(string AccessToken, string NextOpenid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", AccessToken, NextOpenid);
            return HttpUtility.GetData(url);
        }
        #endregion

        #region 发送客服消息接口
        /// <summary>
        ///    发送客服消息
        ///    当用户主动发消息给公众号的时候（包括发送信息、点击自定义菜单click事件、订阅事件、扫描二维码事件、支付成功事件、用户维权），
        ///    微信将会把消息数据推送给开发者，开发者在一段时间内（目前修改为48小时）可以调用客服消息接口，通过POST一个JSON数据包来发送消息给普通用户，
        ///    在48小时内不限制发送次数。此接口主要用于客服等有人工消息处理环节的功能，方便开发者为用户提供更加优质的服务。
        ///    各消息类型所需的JSON数据包如下：
        ///                                  发送文本消息
        ///                                  发送图片消息
        ///                                  发送语音消息
        ///                                  发送视频消息
        ///                                  发送音乐消息
        ///                                  发送图文消息
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <returns></returns>
        public static string SendCustomerMessage(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }
        #endregion

        #region 生成带参数的二维码接口
        /// <summary>
        ///     生成带参数的二维码
        ///     目前有2种类型的二维码，分别是临时二维码和永久二维码，
        ///     前者有过期时间，最大为1800秒，但能够生成较多数量，
        ///     后者无过期时间，数量较少（目前参数只支持1--100000）。
        ///     参数说明：
        ///              expire_seconds	 该二维码有效时间，以秒为单位。 最大不超过1800。
        ///              action_name	 二维码类型，QR_SCENE为临时,QR_LIMIT_SCENE为永久
        ///              action_info	 二维码详细信息
        ///              scene_id	 场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">例子：{"expire_seconds": 1800, "action_name": "QR_SCENE", "action_info": {"scene": {"scene_id": 123}}}</param>
        /// <returns></returns>
        public static string CreateCodeTicket(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 通过ticket换取二维码(TICKET记得进行UrlEncode)
        /// </summary>
        /// <param name="Ticket">Ticket</param>
        /// <param name="type">展示还是下载（1下载，2展示）</param>
        /// <param name="dic">存放在本地的绝对路径</param>
        /// <param name="UserKey">用来区别此用户有没有生成二维码</param>
        /// <returns>是一张图片，可以直接展示或者下载。</returns>
        public static string GetCodeTicket(string Ticket, int type, string dic, string UserKey)
        {
            string result = string.Empty;
            string url = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", Ticket);
            if (type == 1)
            {
                if (!Directory.Exists(dic))
                {
                    Directory.CreateDirectory(dic);
                }
                result = DownloadFile(url, dic, UserKey);
            }
            else
            {
                //System.Web.HttpContext.Current.Response.Write("<script>window.open('" + url + "')</script>");
                result = url;
            }
            return result;
        }
        #endregion

        #region 上传下载多媒体文件接口
        /// <summary>
        /// 服务号：上传多媒体文件
        /// </summary>
        /// <param name="accesstoken">调用接口凭据</param>
        /// <param name="type">图片（image）、语音（voice）、视频（video）和缩略图（thumb）</param>
        /// <param name="filename">文件路径</param>
        /// <param name="contenttype">文件Content-Type类型(例如：image/jpeg、audio/mpeg)</param>
        /// <returns></returns>
        public static string UploadFile(string accesstoken, string type, string filename, string contenttype)
        {
            //文件
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            byte[] buffer = br.ReadBytes(Convert.ToInt32(fileStream.Length));

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            //请求
            WebRequest req = WebRequest.Create(@"http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=" + accesstoken + "&type=" + type);
            req.Timeout = 1000 * 60 * 5;
            req.Method = "POST";
            req.ContentType = "multipart/form-data; boundary=" + boundary;
            //组织表单数据
            StringBuilder sb = new StringBuilder();
            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"media\"; filename=\"" + filename + "\"; filelength=\"" + fileStream.Length + "\"");
            sb.Append("\r\n");
            //sb.Append("Content-Type: " + contenttype);
            sb.Append("Content-Type: application/octet-stream");
            sb.Append("\r\n\r\n");
            string head = sb.ToString();
            byte[] form_data = Encoding.UTF8.GetBytes(head);

            //结尾
            byte[] foot_data = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            //post总长度
            long length = form_data.Length + fileStream.Length + foot_data.Length;

            req.ContentLength = length;

            Stream requestStream = req.GetRequestStream();
            //这里要注意一下发送顺序，先发送form_data > buffer > foot_data
            //发送表单参数
            requestStream.Write(form_data, 0, form_data.Length);
            //发送文件内容
            requestStream.Write(buffer, 0, buffer.Length);
            //结尾
            requestStream.Write(foot_data, 0, foot_data.Length);

            requestStream.Close();
            fileStream.Close();
            fileStream.Dispose();
            br.Close();
            br.Dispose();
            //响应
            WebResponse pos = req.GetResponse();
            StreamReader sr = new StreamReader(pos.GetResponseStream(), Encoding.UTF8);
            string html = sr.ReadToEnd().Trim();
            sr.Close();
            sr.Dispose();
            if (pos != null)
            {
                pos.Close();
                pos = null;
            }
            if (req != null)
            {
                req = null;
            }
            return html;
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



        /// <summary>  
        /// 转换函数  
        /// </summary>  
        /// <param name="exe">ffmpeg程序</param>  
        /// <param name="arg">执行参数</param>       
        private static void ExcuteProcess(string exe, string arg)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = arg;
                p.StartInfo.UseShellExecute = false;    //输出信息重定向  
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();                    //启动线程  
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();//等待进程结束    
            }
        }
        #endregion

        #region  高级群发接口

        /// <summary>
        /// 上传图文消息素材
        /// 参数说明:
        ///     Articles	            图文消息，一个图文消息支持1到10条图文；
        ///     thumb_media_id	        图文消息缩略图的media_id，可以在基础支持-上传多媒体文件接口中获得；
        ///     author	                图文消息的作者；
        ///     title	                图文消息的标题；
        ///     content_source_url	    在图文消息页面点击“阅读原文”后的页面；
        ///     content	                图文消息页面的内容，支持HTML标签；
        ///     digest	                图文消息的描述；
        ///
        /// 示例：
        /// {
        ///    "articles": [
        ///	                 {
        ///                      "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
        ///                      "author":"xxx",
        ///	                	 "title":"Happy Day",
        ///	                	 "content_source_url":"www.qq.com",
        ///	                	 "content":"content",
        ///	                	 "digest":"digest"
        ///	                 },
        ///                  {
        ///                      "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
        ///                      "author":"xxx",
        ///               	     "title":"Happy Day",
        ///               	     "content_source_url":"www.qq.com",
        ///               	     "content":"content",
        ///               	     "digest":"digest"
        ///                 }
        ///            ]
        /// }
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">上传的Json格式数据</param>
        /// <returns></returns>
        public static string UploadNews(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 群发视频时视频media_id需要重新处理方法
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">Json格式数据如：{"media_id": "rF4UdIMfYK3efUfyoddYRMU50zMiRmmt_l0kszupYh_SzrcW5Gaheq05p_lHuOTQ","title": "TITLE", "description": "Description"}</param>
        /// <returns></returns>
        public static string ConversionVideoMediaID(string AccessToken, string data)
        {
            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 根据分组进行群发
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">Json格式数据</param>
        /// <returns></returns>
        public static string SendGroupMessage(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 根据OpenID列表群发
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">Json格式数据</param>
        /// <returns></returns>
        public static string SendOpenIDMessage(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }

        /// <summary>
        /// 删除群发
        /// </summary>
        /// <param name="AccessToken">调用接口凭证</param>
        /// <param name="data">Json格式数据如：{"msgid":3012}（发送出去的消息ID）</param>
        /// <returns></returns>
        public static string DeleteMessage(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com//cgi-bin/message/mass/delete?access_token={0}", AccessToken);
            return HttpUtility.SendHttpRequest(url, data);
        }
        #endregion

        #region  下载文件

        //private void DownFile()
        //{
        //    //获取文件路径
        //    string file_url = Request.QueryString["url"];
        //    if (file_url == null)
        //    {
        //        return;
        //    }


        //    string ext_name = Path.GetExtension(file_url);
        //    string file_name = Path.GetFileName(file_url);

        //    //组织存储路径和存储文件名
        //    string up_folder = System.Configuration.ConfigurationManager.AppSettings["hj_up_img"].ToString();
        //    up_folder = up_folder + HJ_DAL.ImgFolder._cls_space;
        //    string time_span = HJ_DAL.ImgFolder.GetTimeStamp();

        //    //获取远程文件的数据流
        //    FileStream fs = new FileStream(up_folder + time_span + ext_name, FileMode.Create);
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(file_url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream stream = response.GetResponseStream();

        //    int bufferSize = 2048;
        //    byte[] bytes = new byte[bufferSize];

        //    try
        //    {
        //        int length = stream.Read(bytes, 0, bufferSize);

        //        while (length > 0)
        //        {
        //            fs.Write(bytes, 0, length);
        //            length = stream.Read(bytes, 0, bufferSize);
        //        }
        //        stream.Close();
        //        fs.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        /// <summary>        
        /// 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// <param name="dic">下载后的存放地址绝对路径 如：c:\122\</param> 
        /// <param name="Filename">文件名(没后辍) 如：123</param> 
        public static string DownloadFile(string URL, string dic, string fileName)
        {

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            request.Timeout = 30000;
            System.Net.HttpWebResponse response = null;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                fileName = dic + fileName + ".jpg";
                img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();
                response.Close();
                img.Dispose();
                stream.Dispose();
                return fileName;
            }
            catch (System.Exception)
            {
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
        }
        #endregion

    }
}
