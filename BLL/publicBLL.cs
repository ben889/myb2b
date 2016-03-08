
using DAL;
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Collections;



namespace BLL
{
    public class publicBLL
    {
        //static ArrayList list = new ArrayList();
        /// <summary>
        /// 绑定生成一个有树结构的下拉菜单
        /// </summary>
        /// <param name="dtNodeSets">菜单记录数据所在的表</param>
        /// <param name="strParentColumn">表中用于标记父记录的字段</param>
        /// <param name="strRootValue">第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录</param>
        /// <param name="strIndexColumn">索引字段，也就是放在DropDownList的Value里面的字段</param>
        /// <param name="strTextColumn">显示文本字段，也就是放在DropDownList的Text里面的字段</param>
        /// <param name="drpBind">需要绑定的DropDownList</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        public static void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, DropDownList drpBind, int i)
        {
            //每向下一层，多一个缩入单位
            i++;

            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符

            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
            for (int j = 0; j < i; j++)
                strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了

            foreach (DataRowView drv in dvNodeSets)
            {
                ListItem li = new ListItem(strPading + "├ " + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
                drpBind.Items.Add(li);
                MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, drpBind, i);
            }

            //递归结束，要回到上一层，所以缩入量减少一个单位
            i--;
        }


        //public static void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, int i)
        //{
        //    //每向下一层，多一个缩入单位
        //    i++;

        //    DataView dvNodeSets = new DataView(dtNodeSets);
        //    dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

        //    string strPading = ""; //缩入字符

        //    //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
        //    for (int j = 0; j < i; j++)
        //        strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了

        //    foreach (DataRowView drv in dvNodeSets)
        //    {
        //        ListItem li = new ListItem(strPading + "├ " + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
        //        MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, i);
        //    }


        //    //递归结束，要回到上一层，所以缩入量减少一个单位
        //    i--;
        //}
        private DataTable newdt(DataTable dt)
        {
            DataTable newdt = new DataTable();
            if (dt == null)
                return null;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                newdt.Columns.Add(new DataColumn() { ColumnName = dt.Columns[i].ColumnName, DataType = dt.Columns[i].DataType });
            }
            return newdt;
        }
        DataTable returndt = null;
        public DataTable MakeTree_Dt(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, int i)
        {
            if (i == -1)
                returndt = newdt(dtNodeSets);
            if (returndt == null)
                return null;
            //每向下一层，多一个缩入单位
            i++;

            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符

            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
            for (int j = 0; j < i; j++)
                strPading += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";//如果要增加缩入的长度，改成两个全角的空格就可以了

            //int k = 0;
            foreach (DataRowView drv in dvNodeSets)
            {
                DataRow dow = returndt.NewRow();

                for (int u = 0; u < returndt.Columns.Count; u++)
                {
                    if (drv[strTextColumn] == drv[u])
                    {
                        string newname = strPading + "├─ " + drv[strTextColumn].ToString();
                        dow[u] = newname;
                    }
                    else
                        dow[u] = drv[u];
                }
                //ListItem li = new ListItem(strPading + "├ " + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());

                returndt.Rows.Add(dow);
                //k++;
                MakeTree_Dt(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, i);

            }


            //递归结束，要回到上一层，所以缩入量减少一个单位
            i--;
            return returndt;
        }


        #region 省份城市

        public static int GetProvinceIDByProvinceName(string ProvinceName)
        {
            return new publicDAL().GetProvinceIDByProvinceName(ProvinceName);
        }
        public static int GetCityIDByCityName(string CityName)
        {
            return new publicDAL().GetCityIDByCityName(CityName);
        }

        #endregion



        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        //public static string ObjectToJSON(object obj)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    //jss.MaxJsonLength();
        //    try
        //    {
        //        string jsonStr = jss.Serialize(obj);
        //        return jsonStr;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
        //    }
        //}

        /// <summary>
        /// 根据条件更新数据库表的内容
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="SetContent">更新内容 如：id=1,name='abc'</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static int UpdateTableValue(string TableName, string SetContent, string strWhere)
        {
            return new DAL.publicDAL().Update(TableName, SetContent, strWhere);
        }

        /// <summary>
        /// 查数量
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetCount(string TableName, string where)
        {
            return new DAL.publicDAL().GetCount(TableName, where);
        }
        public static DataTable GetDt(string table, int Top, string strWhere, string filedOrder)
        {
            return new DAL.publicDAL().GetDt(table, Top, strWhere, filedOrder);
        }
    }
}
