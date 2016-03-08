using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.UI;
/*
 *  
 *  2015年5月15日15:44:22
 */
namespace WebSite.seller
{
    public class seller_basepage : System.Web.UI.Page
    {
        public SellerInfo sellerinfo;
        protected override void OnLoad(EventArgs e)
        {
            sellerinfo = getsellerinfo(sellerid);
            if (sellerinfo == null || sellerid <= 0)
            {

                Response.Write("<script language='javascript'>window.location.href = '/seller/login.html?fromurl=" + HttpContext.Current.Request.Url.AbsoluteUri + "';</script>");
                Response.End();
            }
            uname = sellerinfo.uname;
            name = sellerinfo.name;
            base.OnLoad(e);
        }

        public string uname { get; set; }
        public string name { get; set; }
        public int sellerid
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["seller_id"] != null)
                {
                    try
                    {
                        //string uid_str = HttpContext.Current.Request.Cookies["seller_id"].Value;
                        string uid_str = CookiesHelper.GetCookie("seller_id");
                        return int.Parse(uid_str);
                    }
                    catch { }
                }
                return 0;
            }
        }

        public SellerInfo getsellerinfo(int sellerid)
        {
            //memberInfo Entity = memberBLL.memberEntity;
            //if (Entity != null && Entity.uid.Trim().Length > 0)
            //{
            //    return Entity;
            //}
            if (sellerid > 0)
            {
                SellerInfo Entity = BLL.SellerBLL.GetModel(sellerid);
                return Entity;
            }
            return null;
        }
    }
}