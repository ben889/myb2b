using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BS.Components.Data.Entity;
using Model;

namespace BLL
{
    public class AdBLL : CommonBLL<Model.AdInfo>
    {
        private static DAL.AdDAL dal = new DAL.AdDAL();

        public static int Add(Model.AdInfo info)
        {
            return Insert(info, ReturnTypes.Identity);
        }
        /// <summary>
        /// 广告调用
        /// </summary>
        /// <param name="call_index">调用分类别名</param>
        /// <returns></returns>
        public static DataTable GetDt(string call_index)
        {
            return dal.GetDt(-1, "A.call_index='" + call_index + "'", "");
        }
        public static DataTable GetDt(int Top, string strWhere, string filedOrder)
        { return dal.GetDt(Top, strWhere, filedOrder); }


        public static string showad(string adimg, string suffix, int adblank, string adlink, int width, int height)
        {
            if (adimg != null && adimg.Trim().Length > 0)
            {
                if (suffix.Trim().ToLower().EndsWith("jpg") || suffix.Trim().ToLower().EndsWith("gif") || suffix.Trim().ToLower().EndsWith("bmp") || suffix.Trim().ToLower().EndsWith("png"))
                {
                    string target = "";
                    if (adblank == 1)
                    {
                        target = "target='_blank'";
                    }
                    string widthstr = "";
                    if (width > 0)
                        widthstr = "width='" + width + "'";
                    string heightstr = "";
                    if (height > 0)
                        heightstr = "height='" + height + "'";
                    return "<a href='" + adlink + "' " + target + ">" + "<img name='' src='" + adimg + "' " + widthstr + " " + heightstr + " border='0'/></a>";

                }
                else if (suffix.Trim().ToLower().EndsWith("swf"))
                {
                    return "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" + width + "' height='" + height + "'>" +
                        //"<param name='movie' value='" + Common.Constant.URL_ad(companyid) + adimg + "' />" +
                              "<param name='movie' value='" + adimg + "' />" +
                            "</object>";
                }
                return "";

            }
            return "";
        }
        /// <summary>
        /// 显示广告
        /// </summary>
        /// <param name="adpositionid">广告位ID</param>
        /// <returns></returns>
        public static string showad(int adpositionid)
        {
            //List<AdInfo> list = GetList(-1, "adpositionid=" + adpositionid, "");
            DataTable dt = GetDt(-1, "O.adpositionid=" + adpositionid, "");
            if (dt == null || dt.Rows.Count == 0)
                return "";
            DataRow dow = dt.Rows[0];
            string adimg = dow["adimg"] != DBNull.Value ? dow["adimg"].ToString() : "";
            string suffix = dow["suffix"] != DBNull.Value ? dow["suffix"].ToString() : "";
            int adblank = dow["adblank"] != DBNull.Value ? Convert.ToInt32(dow["adblank"]) : 0;
            string adlink = dow["adlink"] != DBNull.Value ? dow["adlink"].ToString() : "";
            int width = dow["width"] != DBNull.Value ? Convert.ToInt32(dow["width"]) : 0;
            int height = dow["height"] != DBNull.Value ? Convert.ToInt32(dow["height"]) : 0;

            return showad(adimg, suffix, adblank, adlink, width, height);
        }

        public static string showad(string call_index)
        {
            DataTable dt = GetDt(call_index);
            if (dt == null || dt.Rows.Count == 0)
                return "";
            DataRow dow = dt.Rows[0];
            string adimg = dow["adimg"] != DBNull.Value ? dow["adimg"].ToString() : "";
            string suffix = dow["suffix"] != DBNull.Value ? dow["suffix"].ToString() : "";
            int adblank = dow["adblank"] != DBNull.Value ? Convert.ToInt32(dow["adblank"]) : 0;
            string adlink = dow["adlink"] != DBNull.Value ? dow["adlink"].ToString() : "";
            int width = dow["width"] != DBNull.Value ? Convert.ToInt32(dow["width"]) : 0;
            int height = dow["height"] != DBNull.Value ? Convert.ToInt32(dow["height"]) : 0;

            return showad(adimg, suffix, adblank, adlink, width, height);
        }


        public static string showimg(string call_index)
        {
            DataTable dt = GetDt(call_index);
            if (dt == null || dt.Rows.Count == 0)
                return "";
            DataRow dow = dt.Rows[0];
            string adimg = dow["adimg"] != DBNull.Value ? dow["adimg"].ToString() : "";
            string suffix = dow["suffix"] != DBNull.Value ? dow["suffix"].ToString() : "";
            //int adblank = dow["adblank"] != DBNull.Value ? Convert.ToInt32(dow["adblank"]) : 0;
            //string adlink = dow["adlink"] != DBNull.Value ? dow["adlink"].ToString() : "";
            int width = dow["width"] != DBNull.Value ? Convert.ToInt32(dow["width"]) : 0;
            int height = dow["height"] != DBNull.Value ? Convert.ToInt32(dow["height"]) : 0;
            if (suffix.Trim().ToLower().EndsWith("jpg") || suffix.Trim().ToLower().EndsWith("gif") || suffix.Trim().ToLower().EndsWith("bmp") || suffix.Trim().ToLower().EndsWith("png"))
            {
                string widthstr = "";
                if (width > 0)
                    widthstr = "width='" + width + "'";
                string heightstr = "";
                if (height > 0)
                    heightstr = "height='" + height + "'";
                return "<img name='' src='" + adimg + "' " + widthstr + " " + heightstr + " border='0'/>";
            }
            return "";
        }
    }
}
