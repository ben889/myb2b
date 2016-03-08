using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    public class Seller_categoryBLL : CommonBLL<Seller_categoryInfo>
    {
        public static int Insert(Seller_categoryInfo info, ref string resultMsg)
        {
            if (info.name.Trim().Length == 0)
            {
                resultMsg = "名称不能为空";
                return 0;
            }
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
        }

        public static DataTable GetDt(int top, string where)
        {
            string _top = "";
            if (top > 0)
                _top = " top " + top;
            string sql = "select " + _top + " * from Seller_category";
            if (where.Trim().Length > 0)
                sql = sql + " where " + where;
            return GetTable(sql);
        }
        /// <summary>
        /// 删除当前行，和所有对应的子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            List<Seller_categoryInfo> sublist = GetList(-1, "parentid=" + id, "");
            if (sublist != null && sublist.Count > 0)
            {
                foreach (Seller_categoryInfo subinfo in sublist)
                {
                    Delete(subinfo.id);
                }
            }
            Seller_categoryInfo info = GetModel(id);

            string img = "";
            if (info != null && info.id == id)
            {
                img = info.img;
            }
            int result = Delete(id, "id");
            if (result > 0)
            {
                string url = HttpContext.Current.Server.MapPath(Common.Constant.URL_seller());
            }

            return result;
        }
    }
}
