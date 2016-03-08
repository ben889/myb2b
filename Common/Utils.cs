using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Utils
    {
        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的string类型结果</returns>
        public static string ObjectToStr(object obj)
        {
            if (obj == null)
                return "";
            return obj.ToString().Trim();
        }
        /// <summary>
        /// 将decimal对象转换为字符串
        /// </summary>
        /// <param name="decimalval"></param>
        /// <returns></returns>
        public static string decimalObjectToStr(object decimalobj)
        {
            try
            {
                decimal decimalval = Convert.ToDecimal(decimalobj);
                return Math.Round(decimalval, 2, MidpointRounding.AwayFromZero).ToString();
            }
            catch { }
            return "0";
        }
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static double ChinaRound(double value, int decimals)
        {
            if (value < 0)
            {
                return Math.Round(value + 5 / Math.Pow(10, decimals + 1), decimals, MidpointRounding.AwayFromZero);
            }
            else
            {
                return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
            }
        }
        public static decimal ObjectTodecimal(object obj, int decimals)
        {
            try
            {
                if (obj == null || obj == DBNull.Value)
                    return 0;
                decimal result = 0;
                decimal.TryParse(obj != null ? obj.ToString() : "0", out result);
                return Math.Round(result, decimals, MidpointRounding.AwayFromZero);
            }
            catch { }
            return 0;
        }
        public static int ObjectToint(object obj)
        {
            try
            {
                if (obj == null || obj == DBNull.Value)
                    return 0;
                int result = 0;
                int.TryParse(obj != null ? obj.ToString() : "0", out result);
                return result;
            }
            catch { }
            return -1;
        }


        #region 显示分页
        /// <summary>
        /// 
        /// </summary>
        /// <param name="total"></param>
        /// <param name="page_index"></param>
        /// <param name="page_size"></param>
        /// <param name="strings">传递参数 如 "id=1","name=lishi"</param>
        /// <returns></returns>
        public static string pagination(int total, int page_index, int page_size, params string[] strings)
        {
            string paginationHTML = "";
            if (total <= 0)
                return "";

            //参数
            string paramstr = "";
            for (int i = 0; i < strings.Length; i++)
            {
                //if (i == 0)
                //{
                //    if (paramstr.IndexOf("?") == -1)
                //        paramstr += "?" + strings[i];
                //    else
                //        paramstr += "&" + strings[i];
                //}
                //else
                paramstr += "&" + strings[i];

            }
            //end


            paginationHTML = "<ul class=\"page-nav\">";

            int showpagecount = 10;
            int pagecount = (int)total / page_size;//总页数
            if ((total % page_size) > 0)
            {
                pagecount = pagecount + 1;
            }


            int j = page_index / showpagecount;
            if (page_index % showpagecount > 0)
                j = j + 1;
            int Startpage = showpagecount * j - showpagecount + 1;


            int lastpage = page_index > 1 ? (page_index - 1) : 1;
            //paginationHTML = paginationHTML + "<li class=\"previous\" ><a href=\"?page=" + lastpage + paramstr + "\">上一页</a></li>";

            if ((Startpage - showpagecount) > 0)
            {
                paginationHTML = paginationHTML + "<li><a href='?page=" + (Startpage - showpagecount) + paramstr + "' >...</a></li>";
            }

            for (int i = Startpage; i < pagecount + 1; i++)
            {

                if (i == (Startpage + showpagecount))
                {
                    paginationHTML = paginationHTML + "<li><a href='?page=" + i + paramstr + "' >...</a></li>";

                    break;
                }

                if (page_index == i)
                {
                    paginationHTML = paginationHTML + "<li class=\"current\"><a>" + i + "</a></li>";
                }
                else
                {
                    paginationHTML = paginationHTML + "<li><a href=\"?page=" + i + paramstr + "\">" + i + "</a></li>";
                }

            }
            int nextpage = page_index >= pagecount ? pagecount : (page_index + 1);
            //paginationHTML = paginationHTML + "<li class=\"previous\" ><a href=\"?page=" + nextpage + paramstr + "\">下一页</a></li>";

            paginationHTML = paginationHTML + "</ul>";
            return paginationHTML;

        }
        #endregion
    }
}
