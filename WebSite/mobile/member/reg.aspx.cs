using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Model;

namespace WebSite.mobile.member
{
    public partial class reg : m_basepage
    {
        protected string openid;
        protected string owner_sell_id;//所属分销商
        protected string owner_sell_displayname;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string method = Common.Utils.ObjectToStr(Request["method"]).ToLower();
                if (method.Trim().Length > 0)
                {
                    string uname = Common.Utils.ObjectToStr(Request.Form["uname"]);
                    string password = Common.Utils.ObjectToStr(Request.Form["password"]);
                    switch (method)
                    {
                        case "reg":
                            string displayname = Common.Utils.ObjectToStr(Request.Form["displayname"]);
                            string agreement = Common.Utils.ObjectToStr(Request.Form["agreement"]);
                            string validatecode = Common.Utils.ObjectToStr(Request.Form["validatecode"]);
                            string auth_code = Common.Utils.ObjectToStr(Request.Form["auth_code"]);
                            string pid = Common.Utils.ObjectToStr(Request.Form["pid"]);
                            m_reg(uname, password, displayname, agreement, validatecode, auth_code, pid);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="displayname"></param>
        /// <param name="agreement">用户协议</param>
        /// <param name="validatecode">图形验证码</param>
        /// <param name="auth_code">手机验证码</param>
        /// <param name="pid">介绍人</param>
        protected void m_reg(string uname, string password, string displayname, string agreement, string validatecode, string auth_code, string pid)
        {
            try
            {
                int parentid = 0;
                if (pid != null && pid.Trim().Length > 0)
                {
                    bool isnumber = int.TryParse(pid, out parentid);
                    if (!isnumber)
                    {
                        Response.Write("<script>parent.fail('介绍人ID错误');</script>");
                        return;
                    }
                }
                if (agreement.Trim().Length == 0 || !agreement.Trim().Equals("1"))
                {
                    Response.Write("<script>parent.fail('您未接受用户协议，不能注册！');</script>");
                    return;
                }
                string check_msg = "";
                bool checkcode_b = checkcode(auth_code, validatecode, ref check_msg);
                if (!checkcode_b)
                {
                    Response.Write("<script>parent.fail('" + check_msg + "');</script>");
                    return;
                }
                string mobile = uname;
                password = Common.Utility.MD5Encrypt(password);
                string str = new WebSite.api.member().reg(uname, password, displayname, mobile, parentid);
                //var jser = new JavaScriptSerializer();
                //var json = jser.Serialize(result);
                JObject jo = (JObject)JsonConvert.DeserializeObject(str);
                string result = jo["result"].ToString();
                string msg = jo["msg"].ToString();
                if (result.Equals("1"))
                    Response.Write("<script>parent.success('注册成功');</script>");
                else
                {
                    Response.Write("<script>parent.fail('注册失败，" + msg.Replace("\r", "").Replace("\n", "").Replace("'", "") + "');</script>");
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.fail('注册失败，" + exc.Message.Replace("\r", "").Replace("\n", "").Replace("'", "") + "');</script>");
            }
        }
    }
}