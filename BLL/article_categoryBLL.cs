using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Collections;

namespace BLL
{
    //article_category
    public class article_categoryBLL
    {
        private static DAL.article_categoryDAL dal = new DAL.article_categoryDAL();
        public article_categoryBLL()
        { }

        public static int Add(article_categoryInfo info, ref string resultMsg)
        {
            return dal.Add(info, ref resultMsg);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(article_categoryInfo model, ref string resultMsg)
        {
            return dal.Update(model, ref resultMsg);
        }

        /// <summary>
        /// 删除一条数据包括删除所有子级
        /// </summary>
        public static bool Delete(int typeid)
        {
            List<int> listid = GetSubListID(typeid);
            if (listid != null && listid.Count > 0)
            {
                foreach (int id in listid)
                {
                    Delete(id);
                }
            }
            return dal.Delete(typeid);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static article_categoryInfo GetModel(int id)
        {

            return dal.GetModel(id);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<article_categoryInfo> GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        public static List<int> GetSubListID(int id)
        { return dal.GetSubListID(id); }


        public static DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            return dal.GetDt(Top, strWhere, filedOrder);
        }

        ArrayList list = new ArrayList();
        /// <summary>
        /// 树结构
        /// </summary>
        /// <param name="dtNodeSets">菜单记录数据所在的表</param>
        /// <param name="strParentColumn">表中用于标记父记录的字段</param>
        /// <param name="strRootValue">第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录</param>
        /// <param name="strIndexColumn">索引字段，也就是放在DropDownList的Value里面的字段</param>
        /// <param name="strTextColumn">显示文本字段，也就是放在DropDownList的Text里面的字段</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        public ArrayList MakeTreeList(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, int i)
        {

            //每向下一层，多一个缩入单位
            i++;

            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符



            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
            for (int j = 0; j < i; j++)
                strPading += "　　";//如果要增加缩入的长度，改成两个全角的空格就可以了

            foreach (DataRowView drv in dvNodeSets)
            {
                article_categoryInfo info = new article_categoryInfo();
                string title = drv[strTextColumn] != DBNull.Value ? drv[strTextColumn].ToString() : "";
                if (i > 0)
                    title = strPading + "&nbsp;&nbsp;├&nbsp;&nbsp;&nbsp;" + (drv[strTextColumn] != DBNull.Value ? drv[strTextColumn].ToString() : "");
                info.id = drv["id"] != DBNull.Value ? Convert.ToInt32(drv["id"]) : 0;
                info.orderby = drv["orderby"] != DBNull.Value ? Convert.ToInt32(drv["orderby"]) : 0;
                info.title = title;
                info.parentid = drv["parentid"] != DBNull.Value ? Convert.ToInt32(drv["parentid"]) : 0;
                info.companyname = drv["companyname"] != DBNull.Value ? drv["companyname"].ToString() : "";
                list.Add(info);
                MakeTreeList(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, i);
            }


            //递归结束，要回到上一层，所以缩入量减少一个单位
            i--;
            return list;
        }
    }
}
