using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// 商品类别
    /// </summary>
    public class goods_categoryBLL : CommonBLL<goods_categoryInfo>
    {
        public static int delete(int id, ref string resultMsg)
        {
            try
            {
                if (id <= 0)
                {
                    resultMsg = "id错误";
                    return 0;
                }
                bool isexists = IsExist("parentid=" + id);
                if (isexists)
                {
                    resultMsg = "已存在子级分类";
                    return 0;
                }
                return Delete(id, "goods_category_id");
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message;
            }
            return 0;
        }
        public static int add(goods_categoryInfo info, ref string resultMsg)
        {
            if (info.parentid > 0)
            {
                info.parentids = "," + info.parentid + get_parentids(info.parentid);
            }
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }
        public static int update(goods_categoryInfo info, ref string resultMsg)
        {
            info.parentids = get_parentids(info.goods_category_id);
            return Update(info);
        }
        /// <summary>
        /// 递归查父ID
        /// </summary>
        /// <param name="goods_category_id"></param>
        /// <returns></returns>
        public static string get_parentids(int goods_category_id)
        {
            string result = "";
            if (goods_category_id > 0)
            {
                int parentid = new goods_categoryDAL().get_parentid(goods_category_id);
                if (parentid > 0)
                {
                    result = result + "," + parentid;
                    string pid = get_parentids(parentid);
                    if (pid.Trim().Length > 0)
                        result = result + pid;
                }
            }
            if (result.Trim().Length > 0 && !result.EndsWith(","))
                result = result + ",";
            return result;
        }
    }
}
