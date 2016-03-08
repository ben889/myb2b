using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;

namespace Common
{
    public class JsonHelper
    {
        #region JSON操作

        #region 对象转JSON
        /// <summary> 
        /// 对象转JSON //table请用DataTableToJson方法
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ToJson(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("JsonHelper.ToJson(): " + ex.Message);
            }
        }
        #endregion

        #region + DataTable转键值对集合
        /// <summary> 
        /// DataTable转键值对集合 
        /// 把DataTable转成 List集合, 存每一行 
        /// 集合中放的是键值对字典,存每一列 
        /// </summary> 
        /// <param name="dt">数据表</param> 
        /// <returns>哈希表数组</returns> 
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }
        #endregion

        #region + DataTable转JSON
        /// <summary> 
        /// 数据表转JSON 
        /// </summary> 
        /// <param name="dataTable">数据表</param> 
        /// <returns>JSON字符串</returns> 
        public static string DataTableToJson(DataTable dt)
        {
            return ToJson(DataTableToList(dt));
        }
        #endregion

        #region + JSON文本转对象,泛型方法
        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JsonToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JsonHelper.ToObject(): " + ex.Message);
            }
        }
        #endregion

        #region + 将JSON文本转换为数据表数据
        /// <summary> 
        /// 将JSON文本转换为数据表数据 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据表字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> JsonToDataTable(string jsonText)
        {
            return JsonToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }

        #endregion

        #region + 将JSON文本转换成数据行
        /// <summary> 
        /// 将JSON文本转换成数据行 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据行的字典</returns> 
        public static Dictionary<string, object> JsonToDataRow(string jsonText)
        {
            return JsonToObject<Dictionary<string, object>>(jsonText);
        }
        #endregion

        #endregion
    }
}
