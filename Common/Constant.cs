using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class Constant
    {

        public const string URL_userfiles = "/userfiles/";


        public static string URL_productType()
        {
            return URL_userfiles + "/producttype/";
        }
        /// <summary>
        /// 产品图的相对路径
        /// </summary>
        /// <param name="sellerid">商家ID</param>
        /// <returns></returns>
        public static string URL_product(int sellerid)
        {
            return URL_userfiles + "seller_" + sellerid + "/product/";
        }
        public static string URL_goods(int sellerid)
        {
            return URL_goods() + "seller_" + sellerid + "/";
        }
        public static string URL_goods()
        {
            return URL_userfiles + "goods/";
        }
        /// <summary>
        /// 评论图片存放路径
        /// </summary>
        /// <param name="sellerid"></param>
        /// <returns></returns>
        public static string URL_goods_evaluation(int sellerid)
        {
            return URL_userfiles + "seller_" + sellerid + "/goods/evaluation/";
        }
        /// <summary>
        /// 评论图片存放路径(预存的原图片需要压缩后删除)
        /// </summary>
        /// <param name="sellerid"></param>
        /// <returns></returns>
        public static string URL_goods_evaluation_prestore(int sellerid)
        {
            return URL_userfiles + "seller_" + sellerid + "/goods/evaluation/prestore/";
        }
        /// <summary>
        /// 评论图片存放路径
        /// </summary>
        /// <param name="sellerid"></param>
        /// <returns></returns>
        public static string URL_product_evaluation(int sellerid)
        {
            return URL_userfiles + "seller_" + sellerid + "/product/evaluation/";
        }
        /// <summary>
        /// 文章图相对路径
        /// </summary>
        public static string URL_article()
        {
            return URL_userfiles + "article/";
        }
        /// <summary>
        /// 广告文件相对路径
        /// </summary>
        public static string URL_ad()
        {
            return URL_userfiles + "ad/";
        }
        /// <summary>
        /// 链接图片相对路径
        /// </summary>
        public static string URL_link(int companyid)
        {
            return URL_userfiles + companyid + "/link/";
        }
        /// <summary>
        /// 维修图片
        /// </summary>
        public static string URL_repair(int companyid)
        {
            return URL_userfiles + companyid + "/repair/";
        }
        /// <summary>
        /// 投诉图片
        /// </summary>
        public static string URL_complaints(int companyid)
        {
            return URL_userfiles + companyid + "/complaints/";
        }
        /// <summary>
        /// 便民服务
        /// </summary>
        public static string URL_fastdelivery(int companyid)
        {
            return URL_userfiles + companyid + "/fastdelivery/";
        }

        /// <summary>
        /// 获取当前网站主机部分
        /// </summary>
        /// <returns></returns>
        public static string Get_Host()
        {
            string result = "http://" + HttpContext.Current.Request.Url.Host +
                (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port);
            return result;
        }

        /// <summary>
        /// 二维码相对路径
        /// </summary>
        public static string URL_QRCode()
        {
            return URL_userfiles + "qrcode/";
        }

        /// <summary>
        /// 上传临时路径
        /// </summary>
        public static string URL_Temp()
        {
            return URL_userfiles + "temp/";
        }
        public static string URL_seller()
        {
            return URL_userfiles + "seller/";
        }

        /// <summary>
        /// 朋友圈图片
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string URL_zone(int companyid, long uid)
        {
            return URL_userfiles + "zone/" + companyid + "/" + uid + "/";
        }
        /// <summary>
        /// 朋友圈图片
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public static string URL_zone(int companyid)
        {
            return URL_userfiles + "zone/" + companyid + "/";
        }
        /// <summary>
        /// 朋友圈图片
        /// </summary>
        /// <returns></returns>
        public static string URL_zone()
        {
            return URL_userfiles + "/zone/";
        }
        /// <summary>
        /// 朋友圈用户头像
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string URL_zonehead(int companyid, string uid)
        {
            return URL_userfiles + "zone/" + companyid + "/" + "zoneuserimg/" + uid + "/";
        }
    }
}
