using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace com.weixin.Utility
{
    /// <summary>
    ///  JSON操作
    /// </summary>
    public class JSONHelper
    {
        #region Json转换为Model
        /// <summary>
        /// Json转换为Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToModel<T>(string obj)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                T p1 = jss.Deserialize<T>(obj);
                return p1;
            }
            catch { return default(T); }
        }
        /// <summary>
        /// Json转换为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IList<T> ToListModel<T>(string obj)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                IList<T> p1 = jss.Deserialize<IList<T>>(obj);
                return p1;
            }
            catch { return null; }
        }
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToObject<T>(string obj)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                T user = (T)jss.DeserializeObject(obj);
                return user;
            }
            catch
            {
                return default(T); ;
            }
        }
        #endregion

        #region Model转换为Json
        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ToJson(object obj)
        {

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch
            {
                return "";
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
    }
}
