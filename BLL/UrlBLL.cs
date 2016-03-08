using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Web;
using Common;

namespace BLL
{
    public class UrlBLL : CommonBLL<UrlInfo>
    {
        /// <summary>
        /// 初始化系统URL
        /// </summary>
        public static void initsysUrl()
        {
            string _currurl = HttpContext.Current.Request.Url.Authority;
            //string current_companyid = BLL.CompanysBLL.GetCompanyId(_currurl);
            //if (current_companyid == null || current_companyid.Trim().Length == 0)
            //    return;

            Delete("sys=1");
            string resultMsg = "";
            Add("首页", Common.Constant.Get_Host() + "/mobile/index.aspx", true, enum_SysUrl.m_index.ToString(), ref resultMsg);
            //Add("会员中心", Common.Constant.Get_Host() + "/mobile/member/index.aspx", true, enum_SysUrl.member.ToString(), ref resultMsg);
            //Add("微相册", Common.Constant.Get_Host() + "/mobile/album/index.aspx", true, enum_SysUrl.album_index.ToString(), ref resultMsg);

            //Add("二维码分享", Common.Constant.Get_Host() + "/mobile/getopenid.aspx?fromurl=/mobile/member/share.aspx", true, enum_SysUrl.map.ToString(), ref resultMsg);
            //Add("大转盘", Common.Constant.Get_Host() + "/weixin/dzp/index.aspx", true, enum_SysUrl.dzp.ToString(), ref resultMsg);

            //==========================微站设置
            //Add("一键拨号", "tel:{$tel}", true, enum_SysUrl.tel.ToString(), ref resultMsg);
            //============================================
        }


        public static int Add(string name, string url, bool sys, string call_index, ref string resultMsg)
        {
            //if (companyid == null || companyid.Trim().Length == 0)
            //{
            //    resultMsg = "分站ID错误";
            //    return 0;
            //}
            UrlInfo info = new UrlInfo();
            info.name = name.Trim();
            info.url = url.Trim();
            info.sys = sys;
            info.call_index = call_index;
            //info.companyid = companyid;
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }


        /// <summary>
        /// 生成一个下拉列表
        /// </summary>
        /// <param name="selectid">控件ID</param>
        /// <param name="selectedval">选择项</param>
        /// <returns></returns>
        public static string get_select(string selectid, string selectedval)
        {
            string options = "<select name=\"" + selectid + "\" id=\"" + selectid + "\" class=\"select\">";
            options += "<option value=\"\">原文</option>";
            options += "<optgroup label=\"------------------系统URL------------------\"></optgroup>";
            options += get_select_options(selectedval, -1, "sys=1", "id desc");
            options += "<optgroup label=\"------------------自定义URL------------------\"></optgroup>";
            options += get_select_options(selectedval, -1, "sys=0 or sys is null", "id desc");
            options += "</select>";
            return options;
        }
        /// <summary>
        /// 生成下拉项列表
        /// </summary>
        /// <param name="selectedval">选择项</param>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public static string get_select_options(string selectedval, int Top, string strWhere, string filedOrder)
        {
            string options = "";
            List<UrlInfo> list = GetList(Top, strWhere, filedOrder);
            if (list != null && list.Count > 0)
            {

                foreach (UrlInfo info in list)
                {

                    string selected = "";
                    if (selectedval.Trim().Length > 0 && selectedval.Equals(info.url))
                    {
                        selected = "selected=\"selected\"";
                    }
                    options += "<option value=\"" + info.url + "\" " + selected + ">" + info.name + "(" + info.url + ")</option>";
                }
            }
            return options;
        }
    }
}
