using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class wx_MaterialBLL : CommonBLL<wx_MaterialInfo>
    {
        public static int delete(int id, ref string resultMsg)
        {
            try
            {
                if (id <= 0)
                {
                    resultMsg = "";
                    return 0;
                }
                int result = Delete(id, "wx_MaterialID");
                if (result > 0)
                {
                    //删除子级
                    Delete("parentid=" + id);
                }
                return result;
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return 0;
        }

        /// <summary>
        /// 图文消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getjson_appmsg(int id)
        {
            List<wx_MaterialInfo> list = GetList(1, "wx_MaterialID=" + id, "CreateTime asc");
            if (list == null || list.Count == 0)
                return "[]";
            wx_MaterialInfo info = list[0];
            string json = "[";
            json = json + "{\"id\":\"" + info.wx_MaterialID + "\",\"name\":\"" + info.Name + "\",\"img\":\"" + info.ImgUrl + "\"}";
            List<wx_MaterialInfo> list2 = GetList(-1, "parentid=" + info.wx_MaterialID, "CreateTime asc");
            if (list2 != null && list.Count > 0)
            {
                foreach (wx_MaterialInfo info2 in list2)
                {
                    json = json + ",{\"id\":\"" + info2.wx_MaterialID + "\",\"name\":\"" + info2.Name + "\",\"img\":\"" + info2.ImgUrl + "\"}";
                }
            }
            json = json + "]";
            return json;
        }


        
        /// <summary>
        /// 根据ID查素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<wx_MaterialInfo> getlist_appmsg(int id)
        {
            List<wx_MaterialInfo> result_list = new List<wx_MaterialInfo>();
            List<wx_MaterialInfo> list = GetList(1, "wx_MaterialID=" + id, "CreateTime asc");
            if (list == null || list.Count == 0)
                return list;
            wx_MaterialInfo info = list[0];
            result_list.Add(info);
            if (info.Type != 3)//如果不是图文就不用查子级
                return list;
            List<wx_MaterialInfo> list2 = GetList(-1, "parentid=" + info.wx_MaterialID, "CreateTime asc");
            if (list2 != null && list.Count > 0)
            {
                foreach (wx_MaterialInfo info2 in list2)
                {
                    result_list.Add(info2);
                }
            }
            return result_list;
        }
    }
}
