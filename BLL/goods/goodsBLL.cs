using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    public class goodsBLL : CommonBLL<goodsInfo>
    {
        public static int add(goodsInfo info, ref string resultMsg)
        {
            //if (info.siteid.Trim().Length == 0)
            //{
            //    resultMsg = "siteid错误！";
            //    return 0;
            //}
            if (info.GoodsName.Trim().Length == 0)
            {
                resultMsg = "名称不能为空！";
                return 0;
            }
            //if (info.companyid <= 0)
            //{
            //    resultMsg = "代理商ID错误！";
            //    return 0;
            //}
            if (info.EndDate < info.StartDate)
            {
                resultMsg = "结束日期不能小于开始日期！";
                return 0;
            }
            if (info.EndDate < DateTime.Now)
            {
                resultMsg = "结束日期不能小于当前日期！";
                return 0;
            }
            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //if (files != null && files.Count > 0)
            //{
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        System.Web.HttpPostedFile file = files[i];
            //        if (file.ContentLength > 500 * 1024)
            //        {
            //            resultMsg = "图片大小不能超过500K";
            //            return 0;
            //        }
            //        string filename = "";
            //        string loadresult = "";
            //        bool b = Common.FileHelper.UploadFile(file, HttpContext.Current.Server.MapPath(Common.Constant.URL_goods(info.companyid)), ref filename, ref loadresult);
            //        if (b && filename.Trim().Length > 0)
            //            info.Img = Common.Constant.URL_goods(info.companyid) + filename;
            //    }
            //}


            info.CreateTime = DateTime.Now;
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }



        public static string get_client_SQL(string distid, string tablename)
        {
            if (tablename.Trim().Length > 0)
                tablename = tablename + ".";
            string sql = "(" + tablename + "distid in (select distid from District where parentids like '%," + distid + ",%') or " + tablename + "distid=" + distid + ")";
            return sql;
        }


        public static string get_client_sellerid_in_SQL(string distid, string tablename)
        {
            string sql = "select sellerid from seller where " + get_client_SQL(distid, tablename);
            return sql;
        }




        public static int update(goodsInfo info, ref string resultMsg)
        {
            if (info.GoodsName.Trim().Length == 0)
            {
                resultMsg = "名称不能为空！";
                return 0;
            }
            //判断创建时间如果为 0001-1-1 格式 就给当前时间
            if (Common.Utils.ObjectToint(info.CreateTime.ToString().Substring(0, 1)) <= 0)
            {
                info.CreateTime = DateTime.Now;
            }
            //if (info.companyid <= 0)
            //{
            //    resultMsg = "代理商ID错误！";
            //    return 0;
            //}
            if (info.EndDate < info.StartDate)
            {
                resultMsg = "结束日期不能小于开始日期！";
                return 0;
            }
            if (info.EndDate < DateTime.Now)
            {
                resultMsg = "结束日期不能小于当前日期！";
                return 0;
            }
            //==============上传
            //string oldimg = info.Img;
            //string newimg = "";
            //bool b = false;
            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //if (files != null && files.Count > 0)
            //{
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        System.Web.HttpPostedFile file = files[i];
            //        if (file.ContentLength > 500 * 1024)
            //        {
            //            resultMsg = "图片大小不能超过500K";
            //            return 0;
            //        }

            //        string loadresult = "";
            //        b = Common.FileHelper.UploadFile(file, HttpContext.Current.Server.MapPath(Common.Constant.URL_goods(info.companyid)), ref newimg, ref loadresult);
            //        if (b && newimg.Trim().Length > 0)
            //            info.Img = Common.Constant.URL_goods(info.companyid) + newimg;
            //    }
            //}
            //==========================

            int result = Update(info);
            if (result > 0)
            {
                //if (b && !oldimg.Equals(newimg))
                //{
                //    File.Delete(HttpContext.Current.Server.MapPath(newimg));
                //}
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WhereClause"></param>
        /// <param name="OrderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalRows"></param>
        /// <param name="lng">当前用户的经度</param>
        /// <param name="lat">当前用户的纬度</param>
        /// <returns></returns>
        public static DataTable GetPager(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows, string lng, string lat)
        {
            return new goodsDAL().GetPager(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows, lng, lat);
        }

        /// <summary>
        /// 1体验卷，2付费商品
        /// </summary>
        /// <param name="objGoodsType"></param>
        /// <returns></returns>
        public static string get_GoodsType_Str(object objGoodsType)
        {
            if (objGoodsType == null || objGoodsType == DBNull.Value || objGoodsType.ToString().Trim().Length == 0)
                return "";
            if (objGoodsType.ToString().Trim().Equals("1"))
                return "体验卷";
            else if (objGoodsType.ToString().Trim().Equals("2"))
                return "付费商品";
            return "";
        }
    }
}
