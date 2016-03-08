using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebSite.mobile;
using System.Data;

namespace WebSite.api
{
    /// <summary>
    /// member 的摘要说明
    /// </summary>
    public class member : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                string method = context.Request["method"].ToString().ToLower();
                string uname = Common.Utils.ObjectToStr(context.Request["uname"]);
                string password = Common.Utils.ObjectToStr(context.Request["password"]);
                string uid = Common.Utils.ObjectToStr(context.Request["uid"]);
                switch (method)
                {
                    //case "login":
                    //    context.Response.Write(clientlogin(uname, password));
                    //    context.Response.End();
                    //    break;
                    case "reg":
                        string displayname = Common.Utils.ObjectToStr(context.Request["displayname"]);
                        string mobile = Common.Utils.ObjectToStr(context.Request["mobile"]);
                        int parentid = Common.Utils.ObjectToint(context.Request["parentid"]);
                        context.Response.Write(reg(uname, password, displayname, mobile, parentid));
                        context.Response.End();
                        break;
                    case "get_memberinfo":
                        context.Response.Write(get_memberinfo(uid));
                        context.Response.End();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
            }
        }
        //public string clientlogin(string uname, string password)
        //{
        //    if (uname.Trim().Length == 0)
        //        return "{\"result\":0,\"msg\":\"帐号不能为空\"}";
        //    password = Common.Utility.MD5Encrypt(password);
        //    //string url = HttpContext.Current.Request.Url.Authority;
        //    //string companyid = BLL.CompanysBLL.GetCompanyId(url);
        //    memberInfo info = BLL.memberBLL.getModel(uname, password);
        //    if (info == null || info.uid  <= 0)
        //    {
        //        return "{\"result\":0,\"msg\":\"帐号/密码错误\"}";
        //    }
        //    if (info.isdeleted)
        //    {
        //        return "{\"result\":0,\"msg\":\"帐号已被删除，请联系管理员\"}";
        //    }
        //    if (info.islock)
        //    {
        //        return "{\"result\":0,\"msg\":\"帐号已被锁定，请联系管理员\"}";
        //    }

        //    return "{\"result\":1,\"msg\":\"\",\"uid\":\"" + info.uid + "\",\"uname\":\"" + info.uname + "\",\"prov\":\"" + info.prov + "\",\"city\":\"" + info.city + "\",\"companyid\":\"" + info.companyid + "\"}";
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="displayname"></param>
        /// <param name="mobile"></param>
        /// <param name="pid">介绍人ID</param>
        /// <returns></returns>
        public string reg(string uname, string password, string displayname, string mobile, int parentid)
        {
            string resultmsg = "";
            long result = BLL.memberBLL.reg(uname, password, mobile, displayname, parentid, ref resultmsg);
            if (result > 0)
            {
                //return new { success = "1", error = "" };
                return "{\"result\":1,\"msg\":\"\"}";
            }
            else { return "{\"result\":0,\"msg\":\"" + resultmsg.Replace("\"", "").Replace("\r", "").Replace("\n", "") + "\"}"; }
        }
        public string get_memberinfo(string uid)
        {
            try
            {
                if (uid.Trim().Length <= 0)
                    return "{}";
                string where = "uid='" + uid + "'";
                memberInfo info = BLL.memberBLL.GetModel(uid);

                //Dictionary<string, object> di = new Dictionary<string, object>();
                //di.Add("info", info);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string json = jss.Serialize(info);
                return json;
            }
            catch { }
            return "{}";
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}