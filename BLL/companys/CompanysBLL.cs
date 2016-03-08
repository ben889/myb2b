using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Model;

using Common;
using System.Web;
using DAL;
namespace BLL
{
    //Companys
    public class CompanysBLL : CommonBLL<CompanysInfo>
    {
        /// <summary>
        /// 代理商后台帐号登录的cookies key
        /// </summary>
        public static string COOKIES_COMPANY = "company_id";
        /// <summary>
        /// 用户当前选择的companyid cookies key
        /// </summary>
        public static string COOKIE_MEMBER_CURRENT_COMPNAYID = "member_current_companyid";
        private static DAL.CompanysDAL dal = new DAL.CompanysDAL();
        public CompanysBLL()
        { }



        public static int add(string username, string password, string companyname, string email, int distid
            , ref string resultMsg)
        {
            try
            {
                if (username.Trim().Length < 3)
                {
                    resultMsg = "帐号必须为三位以上";
                    return -1;
                }
                if (password.Trim().Length < 6 || !Common.RegexHelper.IsLettersOrNumber(password))
                {
                    resultMsg = "帐号必须为三位以上英文和数字组成";
                    return -1;
                }
                password = Common.Utility.MD5Encrypt(password.Trim());
                int companyid = getmaxid() + 1;
                CompanysInfo cinfo = new CompanysInfo();
                cinfo.CompanyID = companyid;
                cinfo.username = username;
                cinfo.password = password;
                cinfo.qrcode = ""; // 二维码
                cinfo.wxqrcode = ""; // 微信二维码 name
                cinfo.Email = "";
                cinfo.Website = "";
                cinfo.CompanyName = companyname;
                cinfo.Contact = "";
                cinfo.Phone = "";
                cinfo.Mobile = "";
                cinfo.Fax = "";
                cinfo.Address = "";
                cinfo.CreateTime = DateTime.Now;
                cinfo.domain = "";
                cinfo.distid = distid;
                int result = Insert(cinfo, BS.Components.Data.Entity.ReturnTypes.EffectRow);
                return result;
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message;
            }
            return 0;
        }
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="totalamount"></param>
        /// <param name="CompanyID"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int updatetotalamount(decimal totalamount, int CompanyID, int userid, ref string resultMsg)
        {
            if (userid <= 0)
            {
                resultMsg = "无效的操作员ID";
                return -1;
            }
            UserInfo userinfo = UsersBLL.GetModel(userid);
            if (userinfo == null || userinfo.UserID != userid)
            {
                resultMsg = "无效的操作员ID";
                return -1;
            }
            if (userinfo.UserType != Common.enumUserType.host.ToString() && userinfo.UserType != Common.enumUserType.admin.ToString())
            {
                resultMsg = "当前帐号不是管理员帐号";
                return -1;
            }
            if (CompanyID <= 0)
            {
                resultMsg = "无效的代理商id";
                return -1;
            }
            if (totalamount == 0)
            {
                resultMsg = "充值金额不能为0";
                return -1;
            }
            if (totalamount > 100000)
            {
                resultMsg = "充值金额不能大于100000";
                return -1;
            }
            if (totalamount < -100000)
            {
                resultMsg = "充值金额不能小于-100000";
                return -1;
            }
            return dal.updatetotalamount(totalamount, CompanyID, ref resultMsg);
        }


        public static int Update(int companyid, string CompanyName, string Email, string Contact, string Mobile, string Phone, string Fax, string Address, int distid, ref string resultMsg)
        {
            if (companyid <= 0)
            {
                resultMsg = "companyid错误";
                return -1;
            }
            if (CompanyName == null || CompanyName.Trim().Length == 0)
            {
                resultMsg = "代理商名称不能为空";
                return -1;
            }
            //if (domain.Trim().Length == 0)
            //{
            //    resultMsg = "请正确填写域名";
            //    return -1;
            //}
            //int cid = Getid(domain, "companyid<>" + companyid);
            //if (cid > 0)
            //{
            //    resultMsg = "已存在相同的域名";
            //    return -1;
            //}

            HttpFileCollection files = HttpContext.Current.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].ContentLength > 10234 * 500)
                {
                    resultMsg = "上传图片不能大于500k";
                    return -1;
                }
            }

            string url = HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode());
            string wxqrcodename = ""; // 微信二维码name
            bool wxqrcodeupload = false;

            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    System.Web.HttpPostedFile file = files[i];
                    wxqrcodename = "wxqrcode_" + companyid.ToString();
                    wxqrcodeupload = FileHelper.UploadImgFile(file, url, "", 351, 213, "", ref wxqrcodename);
                    break;
                }
            }

            //CompanysInfo model = new CompanysInfo();
            CompanysInfo model = BLL.CompanysBLL.GetModel(companyid);
            if (model == null || model.CompanyID != companyid)
            {
                resultMsg = "companyid错误";
                return -1;
            }
            string oldwxqrcodeimg = model.wxqrcode;// 获取旧的二维码图片
            model.CompanyID = companyid;
            model.Email = Email;
            //model.Website = Website;
            model.CompanyName = CompanyName;
            model.Contact = Contact;
            model.Phone = Phone;
            model.Mobile = Mobile;
            model.Fax = Fax;
            model.Address = Address;
            //model.UserID = UserID;
            model.CreateTime = DateTime.Now;
            //model.domain = domain;
            model.wxqrcode = wxqrcodeupload ? wxqrcodename : ""; // 添加新的微信二维码
            model.distid = distid;
            int result = Update(model);

            //删除旧的二维码图片文件
            if (result > 0)
            {

            }
            return result;
        }


        public static int Getid(int CompanyID)
        { return dal.Getid(CompanyID); }

        public static int Getid(string domain, string where)
        {
            return dal.Getid(domain, where);
        }

        /// <summary>
        /// 查余额
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public static decimal Gettotalamount(int CompanyID)
        {
            return dal.Gettotalamount(CompanyID);
        }



        public static DataTable GetPageCompanys(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            return dal.GetPageCompanys(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows);
        }

        public static int getmaxid()
        {
            return dal.getmaxid();
        }

        /// <summary>
        /// 生成代理商代理商html控件
        /// </summary>
        /// <param name="userid">当前登陆帐号</param>
        /// <param name="updatecompanyid">修改时取得的id,用在下拉框选择</param>
        /// <returns></returns>
        public static string CreateCompanyHTML_Controls(int userid, int updatecompanyid)
        {
            string result = "";
            if (userid <= 0)
                return "";
            UserInfo userinfo = UsersBLL.GetModel(userid);
            if (userinfo == null || userinfo.UserID != userid)
                return "";
            if (userinfo.UserType == Common.enumUserType.admin.ToString() || userinfo.UserType == Common.enumUserType.host.ToString())
            {

                List<CompanysInfo> list = GetList(-1, "", "");

                result += "<select name=\"companyid\" id=\"companyid\" class=\"select\">";
                result += "<option value=\"0\">选择代理商</option>";
                if (list != null)
                {
                    foreach (CompanysInfo info in list)
                    {
                        string selected = "";
                        if (updatecompanyid == info.CompanyID)
                            selected = "selected=\"selected\"";
                        result += "<option value=\"" + info.CompanyID + "\" " + selected + " >" + info.CompanyName + "</option>";
                    }
                }
                //result += "<option value=\"s\">sss</option>"
                //    + "<option value=\"a\" selected=\"selected\">aaa</option>";
                result += "</select>";
            }
            else
            {
                int companyid = UsersBLL.GetCompanyID(userid);
                if (companyid <= 0)
                    return "";
                CompanysInfo cinfo = GetModel(companyid);
                if (cinfo == null || cinfo.CompanyID != companyid)
                    return "";
                result = cinfo.CompanyName + "<input type=\"hidden\" name=\"companyid\" id=\"companyid\" value=\"" + companyid + "\" />";
            }
            return result;
        }

        #region 代理商后台帐号登录
        public static int company_login(int companyid, ref string resultMsg)
        {
            if (companyid <= 0)
            {
                resultMsg = "companyid 错误";
                return -1;
            }
            CompanysInfo info = GetModel(companyid);
            if (info == null || info.CompanyID != companyid)
            {
                resultMsg = "不存在对应的代理商信息";
                return -1;
            }
            return login(info.username, info.password, ref resultMsg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">密码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int login(string username, string password, ref string resultMsg)
        {
            if (username.Trim().Length == 0)
            {
                resultMsg = "帐号不能为空";
                return -1;
            }
            if (password.Trim().Length == 0)
            {
                resultMsg = "密码不能为空";
                return -1;
            }
            //password = Common.Utility.MD5Encrypt(password);
            CompanysInfo info = new CompanysDAL().getModel(username, password);
            if (info != null && info.CompanyID > 0)
            {
                try
                {

                    if (info.status == -1)
                    {
                        resultMsg = "帐号已被锁定，请联系管理员";
                        return -1;
                    }
                    int minite = 60 * 24 * 7;//一星期

                    CookiesHelper.WriteCookie(COOKIES_COMPANY, minite, "", info.CompanyID.ToString());
                    //判断客户端是否存在该cookie，若存在则清除
                    //if (HttpContext.Current.Request.Cookies[COOKIES_COMPANY] != null)
                    //{
                    //    HttpContext.Current.Response.Cookies[COOKIES_COMPANY].Expires = DateTime.Now.AddSeconds(-1);
                    //}
                    ////向客户端浏览器加入
                    //HttpCookie hccompany_id = new HttpCookie(COOKIES_COMPANY);
                    //hccompany_id.Expires = DateTime.Now.AddDays(7);
                    //hccompany_id.Value = info.CompanyID.ToString();

                    //HttpContext.Current.Response.Cookies.Add(hccompany_id);

                }
                catch { }
                return info.CompanyID;
            }
            resultMsg = "帐号/密码错误";
            return 0;
        }
        public static void Exit()
        {
            HttpContext.Current.Response.Cookies[COOKIES_COMPANY].Expires = DateTime.Now.AddSeconds(-1);
        }
        #endregion

    }
}