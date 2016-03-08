using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Web;
using System.IO;
using System.Drawing;

namespace BLL
{
    public class memberBLL : CommonBLL<memberInfo>
    {
        /// <summary>
        /// 会员提成日志
        /// </summary>
        public static string LOG_TC_DIR = "会员提成";

        private static DAL.memberDAL dal = new DAL.memberDAL();
        public memberBLL()
        { }


        public static long init()
        {
            if (!IsExist("1=1"))
            {
                memberInfo info = new memberInfo();
                info.uid = 100001;
                info.uname = "13713082205";
                info.password = Common.Utility.MD5Encrypt("111111");
                string resultMsg = "";
                return Add(info, ref resultMsg);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="uname"></param>
        /// <param name="password">密码</param>
        /// <param name="displayname"></param>
        /// <param name="openid"></param>
        /// <param name="parentid"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static long reg(string uname, string password, string displayname, string openid, long parentid, ref string resultMsg)
        {
            if (parentid <= 0)
            {
                resultMsg = "介绍人不能为空";
                return -1;
            }
            if (uname.Trim().Length == 0)
            {
                resultMsg = "帐号不能为空";
                return -1;
            }
            if (password.Trim().Length == 0)
            {
                resultMsg = "密码不能为空";
                return -1;
            }
            //password = Common.Utility.MD5Encrypt(password.Trim());
            memberInfo info = new memberInfo();
            info.uname = uname;
            info.password = password;
            info.parentid = parentid;
            info.mobile = uname;
            info.displayname = displayname;
            info.addtime = DateTime.Now;
            info.utype = (int)Common.enumutype.member;
            info.openid = openid;
            long result = Add(info, ref resultMsg);
            return result;
        }

        //public static int Add_merchant(int companyid, string uname, string password, string fromuno, ref string resultMsg)
        //{
        //    password = Common.Utility.MD5Encrypt(password.Trim());
        //    memberInfo info = new memberInfo();
        //    info.companyid = companyid;
        //    info.uname = uname;
        //    info.password = password;
        //    info.owneruid = 0;
        //    info.addtime = DateTime.Now;
        //    info.utype = (int)Common.enumutype.merchant;
        //    return Add(info, ref resultMsg);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static long Add(memberInfo info, ref string resultMsg)
        {
            if (info == null)
            {
                resultMsg = "无效的数据";
                return -1;
            }
            if (info.uname == null || info.uname.Trim().Length < 3)
            {
                resultMsg = "帐号必须为手机号";
                return -1;
            }
            if (!Common.RegexHelper.IsMobile(info.uname))
            {
                resultMsg = "帐号必须为手机号";
                return -1;
            }
            //if (info.companyid <= 0)
            //{
            //    resultMsg = "companyid错误";
            //    return -1;
            //}

            if (info.password.Trim().Length == 0)
            {
                resultMsg = "密码不能为空";
                return -1;
            }
            //info.password = Common.Utility.MD5Encrypt(info.password);
            info.addtime = DateTime.Now;
            return dal.AddTran(info, ref resultMsg);
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password">明码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static long login(string uname, string password, ref string resultMsg)
        {
            if (uname.Trim().Length == 0)
            {
                resultMsg = "帐号不能为空";
                return -1;
            }
            if (password.Trim().Length == 0)
            {
                resultMsg = "密码不能为空";
                return -1;
            }
            password = Common.Utility.MD5Encrypt(password);
            memberInfo info = getModel(uname, password);
            if (info != null && info.uid > 0)
            {
                if (info.isdeleted)
                {
                    resultMsg = "帐号已被删除，请联系管理员";
                    return -2;
                }
                if (info.islock)
                {
                    resultMsg = "帐号已被锁定，请联系管理员";
                    return -1;
                }
                try
                {
                    //判断客户端是否存在该cookie，若存在则清除
                    if (HttpContext.Current.Request.Cookies["uid"] != null)
                    {
                        HttpContext.Current.Response.Cookies["uid"].Expires = DateTime.Now.AddSeconds(-1);
                    }

                    //向客户端浏览器加入
                    HttpCookie hcuid = new HttpCookie("uid");
                    hcuid.Expires = DateTime.Now.AddDays(7);
                    hcuid.Value = info.uid.ToString();

                    HttpContext.Current.Response.Cookies.Add(hcuid);

                    Update("member", "login_count=(case when login_count IS NULL then 0 else login_count end)+1", "uid=" + info.uid);
                    return 1;
                }
                catch { }
                return info.uid;
            }
            resultMsg = "帐号/密码错误";
            return 0;
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int update(memberInfo model, ref string resultMsg)
        {
            if (model.uname.Trim().Length <= 0)
            {
                resultMsg = "帐号不能为空";
                return 0;
            }
            if (model.password.Trim().Length <= 0)
            {
                resultMsg = "密码不能为空";
                return 0;
            }
            return Update(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="password">密码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int Updatepassword(long uid, string password, ref string resultMsg)
        {
            //password = Common.Utility.MD5Encrypt(password);
            return dal.Updatepassword(uid, password, ref resultMsg);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static memberInfo getModel(long uid)
        {
            return dal.GetModel(uid);
        }
        public static memberInfo getModel(string uname, string password)
        {
            return dal.getModel(uname, password);
        }

        public static int Getidbyuno(string uno)
        { return dal.Getidbyuno(uno); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">明码</param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int Getidbypassword(string password, long uid)
        {
            if (uid <= 0)
                return -1;
            password = Common.Utility.MD5Encrypt(password);
            string where = "uid=" + uid.ToString() + " and password='" + password + "'";
            return dal.Getidbywhere(where);
        }
        /// <summary>
        /// 查会员余额
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static decimal Getbalance(long uid)
        { return dal.Getbalance(uid); }


        public static DataTable GetPagemember(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            return dal.GetPagemember(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows);
        }



        #region 当前登录信息
        /// <summary>
        /// 当前登录帐号
        /// </summary>
        /// <returns></returns>
        public static long getLogin_uid()
        {

            if (HttpContext.Current.Request.Cookies["uid"] != null)
            {
                try
                {
                    string uid_str = HttpContext.Current.Request.Cookies["uid"].Value;
                    return long.Parse(uid_str);
                }
                catch { }
            }
            return 0;

        }
        //public static memberInfo memberEntity()
        //{
        //    long uid = getcurr_login_uid();
        //    if (uid > 0)
        //    {
        //        memberInfo Entity = BLL.memberBLL.GetModel(uid);
        //        return Entity;
        //    }
        //    return null;
        //}
        public static void Exit()
        {
            //HttpContext.Current.Session.Remove("member");
            //HttpContext.Current.Session["member"] = null;

            //HttpContext.Current.Response.Cookies["uname"].Expires = DateTime.Now.AddSeconds(-1);
            //HttpContext.Current.Response.Cookies["upass"].Expires = DateTime.Now.AddSeconds(-1);

            HttpContext.Current.Response.Cookies["uid"].Expires = DateTime.Now.AddSeconds(-1);
        }
        #endregion


        /// <summary>
        /// 会员操作验证
        /// </summary>
        /// <param name="uid">当前帐号ID</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static bool MemberSubmitCheck(long uid, ref string resultMsg)
        {
            if (uid <= 0)
            {
                resultMsg = "帐号ID错误";
                return false;
            }
            memberInfo info = GetModel(uid);
            if (info == null || info.uid != uid)
            {
                resultMsg = "帐号ID错误";
                return false;
            }
            if (info.isdeleted)
            {
                resultMsg = "帐号已被删除";
                return false;
            }
            if (info.islock)
            {
                resultMsg = "帐号已被锁定";
                return false;
            }
            return true;
        }


        public static int Getutype(long uid)
        {
            return new DAL.memberDAL().Getutype(uid);
        }

        public static List<long> Getuidlist(string where)
        {
            return new DAL.memberDAL().Getuidlist(where);
        }

        #region 收支
        private static object asyncLock = new object();
        /// <summary>
        /// 给介绍人返提成，支持六级
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="uid">当前支付的uid</param>
        /// <param name="order_amount">订单金额</param>
        /// <param name="remark"></param>
        /// <param name="resultmsg"></param>
        /// <returns></returns>
        public static int give_cash_to_parent(long uid, decimal order_amount, string remark, ref string resultmsg)
        {
            lock (asyncLock)
            {
                int results = 0;
                try
                {

                    if (order_amount != 99)
                    {
                        resultmsg = "订单金额错误";
                        return 0;
                    }
                    if (uid <= 0)
                    {
                        resultmsg = "帐号ID错误";
                        return 0;
                    }

                    memberInfo info = GetModel(uid);
                    if (info == null || !info.uid.Equals(uid))
                    {
                        resultmsg = "帐号ID错误";
                        return 0;
                    }

                    long curr_uid = info.parentid;
                    if (curr_uid <= 0)
                        return 0;
                    //入会99元，平台赚9元，产品供应商=20元，第一层：20元 第二层：15元 第三层：10，第四层：10，第五层：10，第六层：5元
                    for (int i = 1; i < 7; i++)
                    {
                        decimal amount = 10;
                        if (i == 1)
                            amount = 20;
                        else if (i == 2)
                            amount = 15;
                        else if (i == 6)
                            amount = 5;

                        memberInfo memberinfo = GetModel(curr_uid);
                        if (memberinfo == null || memberinfo.uid != uid)
                        {
                            continue;
                        }
                        if (memberinfo.parentid <= 0)
                        {
                            continue;
                        }
                        int result = new DAL.memberDAL().member_cash(curr_uid, amount, memberinfo.balance + amount, remark, 1, ref resultmsg);
                        if (result > 0)
                            results++;
                        curr_uid = memberinfo.parentid;
                    }

                }
                catch (Exception exc)
                {
                    Common.LogUtil.WriteLog(LOG_TC_DIR, LOG_TC_DIR + "_", exc.Message);
                }
                return results;
            }
        }

        /// <summary>
        /// 查父6级
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<memberInfo> getparentids(long uid)
        {
            memberInfo info = GetModel(uid);
            if (info == null || info.uid != uid)
                return null;

            List<memberInfo> listmember = new List<memberInfo>();
            long curr_uid = info.parentid;
            if (curr_uid <= 0)
                return listmember;
            for (int i = 1; i < 7; i++)
            {
                if (curr_uid <= 0)
                    break;
                memberInfo memberinfo = GetModel(curr_uid);
                if (memberinfo == null || memberinfo.uid != uid)
                {
                    continue;
                }
                listmember.Add(memberinfo);
                curr_uid = memberinfo.parentid;
            }
            return listmember;
        }
        //public class member_parent {
        //    public long uid;
        //    public int level;
        //    public string displanyname;
        //}
        #endregion

        #region 生成二维码海报
        public static string create_rqcode(string url, string uid)
        {
            try
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode())))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode()));
                }

                string rqcode_base = HttpContext.Current.Server.MapPath("/mobile/images/rqcode_base.jpg");
                Common.Download.downloadImg(url, HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode()), "temp_rqcode_" + uid + ".jpg");

                string temp_rqcode_file = "temp_rqcode_" + uid + ".jpg";
                string writepath = HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode()) + "rqcode_" + uid + ".jpg";//保存路径(包含完整路径,文件名及其扩展名)
                string temp_rqcode = HttpContext.Current.Server.MapPath(Common.Constant.URL_QRCode() + temp_rqcode_file);
                if (File.Exists(temp_rqcode))
                {

                    Bitmap sBitmap = new Bitmap(rqcode_base);//原图 System.Drawing.Bitmap 对象: System.Drawing.Bitmap
                    Bitmap wBitmap = new Bitmap(temp_rqcode);//水印 System.Drawing.Bitmap 对象: System.Drawing.Bitmap
                    Graphics g = Graphics.FromImage(sBitmap);
                    int x = 38;
                    int y = 0;
                    int width = 263;
                    int height = 263;
                    g.DrawImage(wBitmap, new Rectangle(x, y, width, height));
                    g.Dispose();
                    wBitmap.Dispose();
                    sBitmap.Save(writepath);
                    sBitmap.Dispose();
                    File.Delete(temp_rqcode);
                }
                return Common.Constant.URL_QRCode() + "rqcode_" + uid + ".jpg";
            }
            catch { }
            return "";
        }
        #endregion
    }
}
