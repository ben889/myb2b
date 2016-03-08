using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class wx_diymenuBLL : CommonBLL<wx_diymenuInfo>
    {
        public static int add(wx_diymenuInfo info, ref string resultMsg)
        {
            //if (info.companyid.Trim().Length == 0)
            //{
            //    resultMsg = "分站ID错误";
            //    return 0;
            //}
            if (info.Name.Trim().Length == 0)
            {
                resultMsg = "名称不能为空";
                return 0;
            }
            string where = "ParentId=" + info.ParentId;
            List<wx_diymenuInfo> list = GetList(-1, where, "");
            if (info.ParentId == 0)
            {

                if (list != null && list.Count >= 3)
                {
                    resultMsg = "一级菜单不能超过3个";
                    return 0;
                }
            }
            else
            {
                if (list != null && list.Count >= 5)
                {
                    resultMsg = "子菜单不能超过5个";
                    return 0;
                }
            }
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }
        public static int delete(int id, ref string resultMsg)
        {
            bool b = IsExist("parentid=" + id);
            if (b)
            {
                resultMsg = "存在子菜单，不能删除";
                return -1;
            }
            return Delete(id, "MenuId");
        }


        /// <summary>
        /// 拼成微信使用的JSON菜单数据
        /// </summary>
        /// <returns></returns>
        public static string getjson()
        {
            StringBuilder strHtml = new StringBuilder();

            List<wx_diymenuInfo> list = GetList(-1, "ParentId=0 and State=1", "");
            if (list != null && list.Count > 0)
            {
                strHtml.Append("{\"button\":[");
                foreach (wx_diymenuInfo info in list)
                {
                    strHtml.Append("{\"name\":\"" + info.Name + "\",");
                    strHtml.Append(get_item_type_str(info) + ",");
                    strHtml.Append("\"sub_button\":[");
                    List<wx_diymenuInfo> list2 = GetList(-1, "ParentId=" + info.MenuId + " and State=1", "");
                    if (list2 != null && list2.Count > 0)
                    {
                        //strHtml.Append("{\"name\":\"" + info.Name + "\",");
                        //strHtml.Append("\"sub_button\":[");

                        foreach (wx_diymenuInfo info2 in list2)
                        {
                            strHtml.Append(get_item_json_str(info2));
                        }

                        if (strHtml.Length > 0 && strHtml.ToString().EndsWith(","))
                        {
                            //strHtml.Append(strHtml.ToString(0, strHtml.Length - 1));
                            strHtml.Remove(strHtml.ToString().LastIndexOf(','), 1);
                        }
                    }
                    if (strHtml.Length > 0 && strHtml.ToString().EndsWith(","))
                    {
                        strHtml.Remove(strHtml.ToString().LastIndexOf(','), 1);
                    }
                    strHtml.Append("]},");
                }

                if (strHtml.Length > 0 && strHtml.ToString().EndsWith(","))
                {
                    strHtml.Remove(strHtml.ToString().LastIndexOf(','), 1);
                }
                strHtml.Append("]}");
            }
            return strHtml.ToString();
        }

        private static string get_item_json_str(wx_diymenuInfo info)
        {
            //switch (info.RefType.ToString()) //类型：0自定义链接，1文字，2图片，3图文，4音频，5视频
            //{
            //    case "0":
            //        return "{\"type\":\"view\",\"name\":\"" + info.Name + "\", \"url\":\"" + info.URL + "\",\"sub_button\":[]},";
            //    case "1":
            //        return "{\"type\":\"click\",\"name\":\"" + info.Name + "\", \"key\":\"TEXT_" + info.MenuId + "\",\"sub_button\":[]},";
            //    case "2":
            //    case "3":
            //        return "{\"type\":\"click\",\"name\":\"" + info.Name + "\", \"key\":\"IMGTEXT_" + info.RefID + "\",\"sub_button\":[]},";
            //    case "4":
            //        return "{\"type\":\"click\",\"name\":\"" + info.Name + "\", \"key\":\"AUDIO_" + info.RefID + "\",\"sub_button\":[]},";
            //    case "5":
            //        return "{\"type\":\"click\",\"name\":\"" + info.Name + "\", \"key\":\"VIDEO_" + info.RefID + "\",\"sub_button\":[]},";
            //    case "6":
            //    default:
            //        return "{\"type\":\"view\",\"name\":\"" + info.Name + "\", \"url\":\"\",\"sub_button\":[]},";
            //}
            return "{\"name\":\"" + info.Name + "\"," + get_item_type_str(info) + ",\"sub_button\":[]},";
        }

        private static string get_item_type_str(wx_diymenuInfo info)
        {
            switch (info.RefType.ToString()) //类型：0自定义链接，1文字，2图片，3图文，4音频，5视频
            {
                case "0":
                    return "\"type\":\"view\",\"url\":\"" + info.URL + "\"";
                case "1":
                    return "\"type\":\"click\",\"key\":\"TEXT_" + info.MenuId + "\"";
                case "2":
                case "3":
                    return "\"type\":\"click\",\"key\":\"IMGTEXT_" + info.RefID + "\"";
                case "4":
                    return "\"type\":\"click\",\"key\":\"AUDIO_" + info.RefID + "\"";
                case "5":
                    return "\"type\":\"click\",\"key\":\"VIDEO_" + info.RefID + "\"";
                case "6":
                default:
                    return "\"type\":\"view\",\"url\":\"\"";
            }
            //return "{\"type\":\"view\",\"name\":\"" + info.Name + "\", \"url\":\"\"},";
        }


        public static string getState_Str(object ojbState)
        {
            if (ojbState == null || ojbState == DBNull.Value)
                return "";
            if (ojbState.ToString().Trim().Equals("1"))
            {
                return "<span style=\"color:green;\">可用</span>";
            }
            else if (ojbState.ToString().Trim().Equals("0"))
            {
                return "<span style=\"color:red;\">不可用</span>";
            }
            return "";
        }
    }
}
