using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using com.weixin.Model;

namespace com.weixin.Utility
{
    public class XmlUtility
    {
        /// <summary>
        /// 把Json格式数据转化为XML
        /// </summary>
        /// <param name="json"></param>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }

        /// <summary>
        /// 把Json格式数据转化为UserInfo实体
        /// </summary>
        /// <param name="jsonText">JSON文本</param>
        /// <returns></returns>
        public static UserInfo JsonToUserInfo(string jsonText)
        {
            return JsonToObject<UserInfo>(jsonText);
        }

        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        private static T JsonToObject<T>(string jsonText)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JsonHelper.ToObject(): " + ex.Message);
            }
        }
    }
}
