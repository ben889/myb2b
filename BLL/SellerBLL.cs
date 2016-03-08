using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Model;
using Common;
using System.Web;

namespace BLL
{
    /// <summary>
    /// 商家
    /// </summary>
    public class SellerBLL : CommonBLL<SellerInfo>
    {
        private static DAL.SellerDAL dal = new DAL.SellerDAL();
        public SellerBLL()
        { }



        #region

        public static int sellerlogin(int sellerid, ref string resultMsg)
        {
            if (sellerid <= 0)
            {
                resultMsg = "sellerid 错误";
                return -1;
            }
            SellerInfo sellerinfo = GetModel(sellerid);
            if (sellerinfo == null || sellerinfo.sellerid != sellerid)
            {
                resultMsg = "不存在对应的商家信息";
                return -1;
            }
            return login(sellerinfo.uname, sellerinfo.password, ref resultMsg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password">密码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int login(string uname, string password, ref string resultMsg)
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
            //password = Common.Utility.MD5Encrypt(password);
            SellerInfo info = getModel(uname, password);
            if (info != null && info.sellerid > 0)
            {
                try
                {
                    //if (info.isdeleted)
                    //{
                    //    resultMsg = "帐号已被删除，请联系管理员";
                    //    return -2;
                    //}
                    //if (info.islock)
                    //{
                    //    resultMsg = "帐号已被锁定，请联系管理员";
                    //    return -1;
                    //}
                    //判断客户端是否存在该cookie，若存在则清除
                    if (HttpContext.Current.Request.Cookies["seller_id"] != null)
                    {
                        HttpContext.Current.Response.Cookies["seller_id"].Expires = DateTime.Now.AddSeconds(-1);
                    }

                    //向客户端浏览器加入
                    HttpCookie hcseller_id = new HttpCookie("seller_id");
                    hcseller_id.Expires = DateTime.Now.AddDays(7);
                    hcseller_id.Value = info.sellerid.ToString();

                    HttpContext.Current.Response.Cookies.Add(hcseller_id);

                }
                catch { }
                return info.sellerid;
            }
            resultMsg = "帐号/密码错误";
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pass">明码</param>
        /// <param name="companyid"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        //public static int sellerlogin(string uname, string pass, int companyid, ref string resultMsg)
        //{
        //    pass = Common.Utility.MD5Encrypt(pass.Trim());
        //    return login(uname, pass, companyid, ref resultMsg);
        //}
        public static void Exit()
        {
            HttpContext.Current.Response.Cookies["seller_id"].Expires = DateTime.Now.AddSeconds(-1);
        }
        #endregion

        /// <summary>
        /// 添加商家
        /// </summary>
        /// <param name="uname">帐号</param>
        /// <param name="password">明码</param>
        /// <param name="name">商家名称</param>
        /// <param name="address">地址</param>
        /// <param name="ctype">商家类型</param>
        /// <param name="companyid">所属代理商</param>
        /// <param name="tel">电话</param>
        /// <param name="fax">传真</param>
        /// <param name="qq">QQ</param>
        /// <param name="wx">微信公众号</param>
        /// <param name="wxqrcode">公众号二维码</param>
        /// <param name="business">主要经营范围</param>
        /// <param name="curruserid">添加人userid</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int AddTran(string uname, string password, string name, string address, string description
            , string ctype, int companyid, string tel, string fax, string qq, string wx
            , string wxqrcode, string business
            , int curruserid
            , int category_id
            , bool islock
            , bool recommend
            , int orderby
            , int distid
            ,string lng,string lat
            , ref string resultMsg)
        {
            if (curruserid <= 0)
            {
                resultMsg = "userid错误";
                return -1;
            }
            UserInfo userinfo = UsersBLL.GetModel(curruserid);
            if (userinfo == null || userinfo.UserID != curruserid)
            {
                resultMsg = "userid错误";
                return -1;
            }
            if (userinfo.UserType != Common.enumUserType.admin.ToString()
                && userinfo.UserType != Common.enumUserType.host.ToString()
                && userinfo.UserType != Common.enumUserType.site.ToString())
            {
                resultMsg = "只有系统管理员或者代理商管理员才可以操作";
                return -1;
            }
            //if (distid.Trim().Length == 0)
            //{
            //    resultMsg = "distid错误！";
            //    return 0;
            //}
            //if (companyid <= 0)
            //{
            //    resultMsg = "请选择对应的代理商代理商";
            //    return -1;
            //}
            if (uname.Trim().Length < 3)
            {
                resultMsg = "帐号必须为3位以上的英文或数字";
                return -1;
            }
            if (password.Trim().Length < 6)
            {
                resultMsg = "密码必须为6位以上";
                return -1;
            }
            if (name.Trim().Length == 0)
            {
                resultMsg = "商家名称不能为空";
                return -1;
            }
            if (tel.Trim().Length == 0)
            {
                resultMsg = "商家电话不能为空";
                return -1;
            }
            //memberInfo minfo = new memberInfo();
            //minfo.companyid = companyid;
            //minfo.uname = uname;
            //minfo.password = Common.Utility.MD5Encrypt(password.Trim());
            //minfo.mobile = "";
            //minfo.identitycard = "";
            //minfo.email = "";
            //minfo.displayname = name;
            //minfo.addtime = DateTime.Now;
            //minfo.utype = (int)Common.enumutype.merchant;
            //minfo.address = "";
            //minfo.tel = tel;
            SellerInfo info = new SellerInfo();
            //info.uid = uid;
            info.uname = uname;
            info.password = Common.Utility.MD5Encrypt(password.Trim());
            info.name = name;
            info.address = address;
            info.description = description;
            info.ctype = ctype;
            info.companyid = companyid;
            info.tel = tel;
            info.fax = fax;
            info.qq = qq;
            info.wx = wx;
            info.wxqrcode = wxqrcode;
            info.business = business;
            info.category_id = category_id;
            info.distid = distid;
            info.lng = lng;
            info.lat = lat;
            return dal.AddTran(info, ref resultMsg);
        }



        public static int Update(int sellerid, string name, string address, string description
            , string ctype, string tel, string fax, string qq, string wx
            , string wxqrcode, string business
            , int curruserid
            , int category_id
            , bool islock
            , bool recommend
            , int orderby
            , int distid
            , string lng, string lat
            , ref string resultMsg)
        {
            if (curruserid <= 0)
            {
                resultMsg = "userid错误";
                return -1;
            }
            if (sellerid <= 0)
            {
                resultMsg = "sellerid错误";
                return -1;
            }
            if (name.Trim().Length == 0)
            {
                resultMsg = "商家名称不能为空";
                return -1;
            }
            if (tel.Trim().Length == 0)
            {
                resultMsg = "商家电话不能为空";
                return -1;
            }
            UserInfo userinfo = UsersBLL.GetModel(curruserid);
            if (userinfo == null || userinfo.UserID != curruserid)
            {
                resultMsg = "userid错误";
                return -1;
            }
            if (userinfo.UserType != Common.enumUserType.admin.ToString()
                && userinfo.UserType != Common.enumUserType.host.ToString()
                && userinfo.UserType != Common.enumUserType.company.ToString())
            {
                resultMsg = "当前帐号不是系统管理员帐号";
                return -1;
            }

            //memberInfo minfo = memberBLL.GetModel(uid);
            //minfo.mobile = "";
            //minfo.identitycard = "";
            //minfo.email = "";
            
            SellerInfo model = GetModel(sellerid);
            if (model == null || model.sellerid != sellerid)
            {
                resultMsg = "id error";
                return -1;
            }
            model.islock = islock;
            model.orderby = orderby;
            model.recommend = recommend; 
            model.name = name;
            model.address = address;
            model.description = description;
            model.ctype = ctype;
            model.tel = tel;
            model.fax = fax;
            model.qq = qq;
            model.wx = wx;
            model.wxqrcode = wxqrcode;
            model.business = business;
            model.category_id = category_id;
            model.distid = distid;
            model.lng = lng;
            model.lat = lat;
            return dal.UpdateTran(model, ref resultMsg);
        }


        public static SellerInfo getModel(string uname, string password)
        {
            //if (companyid <= 0)
            //    return null;
            return dal.getModel(uname, password);
        }


        public static DataTable GetPageSeller(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            //string where = "M.isdeleted<>1";
            //if (WhereClause.Trim().Length > 0)
            //    where = where + " and (" + WhereClause + ")";
            return GetPager(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows, "Seller_GetPageSeller");
        }


        /// <summary>
        /// 锁
        /// </summary>
        /// <param name="objislock"></param>
        /// <returns></returns>
        public static string initlock(object objislock)
        {
            if (objislock == null)
                return "";
            if (objislock.ToString().Trim().ToLower().Equals("true"))
                return "<span style='color:red;'>已锁定</span>";
            else
                return "正常";
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="objislock"></param>
        /// <returns></returns>
        public static string initrecommend(object recommend)
        {
            if (recommend == null)
                return "";
            if (recommend.ToString().Trim().ToLower().Equals("true"))
                return "<span style='color:green;'>已推荐</span>";
            else
                return "不推荐";
        }


        /// <summary>
        /// 商家类型
        /// </summary>
        /// <param name="objseller_type"></param>
        /// <returns></returns>
        public static string get_seller_type(object objseller_type)
        {
            try
            {
                if (objseller_type == null || objseller_type == DBNull.Value)
                    return "";
                int s = Convert.ToInt32(objseller_type);
                return Common.EnumHelper.GetEnumDescription(typeof(enum_seller_type), s);
            }
            catch { }
            return "";
        }
    }
}