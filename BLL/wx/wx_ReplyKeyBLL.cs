using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class wx_ReplyKeyBLL : CommonBLL<wx_ReplyKeyInfo>
    {
        public static int add(wx_ReplyKeyInfo info, ref string resultMsg)
        {
            bool isexist = IsExist("[Name]='" + info.Name + "'");
            if (isexist)
            {
                resultMsg = "关键字已存在";
                return 0;
            }
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }
        /// <summary>
        /// 根据规则ID晒关键字串
        /// </summary>
        /// <param name="replyid"></param>
        /// <returns></returns>
        public static string getkeyword(object obj_replyid)
        {
            try
            {
                if (obj_replyid == null || obj_replyid.ToString().Trim().Length == 0)
                    return "";
                int replyid = Convert.ToInt32(obj_replyid);
                List<wx_ReplyKeyInfo> list = GetList(-1, "replyid=" + replyid, "");
                string result = "";
                if (list != null && list.Count > 0)
                {
                    foreach (wx_ReplyKeyInfo info in list)
                    {
                        result = result + info.Name + ",";
                    }
                }
                if (result.EndsWith(","))
                    result = result.Remove(result.Length - 1);
                return result;
            }
            catch { }
            return "";
        }
    }
}
