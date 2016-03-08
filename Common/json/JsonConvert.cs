using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
namespace Common
{
    public class JsonConvert
    {
        /// <summary>
        /// 序列化单个对象或者list
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public string GetJson(object ob)
        {
            if (ob == null)
                return "{}";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return (string)jss.Serialize(ob);
        }
        /// <summary>
        /// 序列化单个对象或者list
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public string GetJson(object ob, int sum)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> di = new Dictionary<string, object>();
            if (ob == null)
                di.Add("rows", "");
            else
                di.Add("rows", ob);
            di.Add("TotalRows", sum);
            return (string)jss.Serialize(di);
        }
        /// <summary>
        /// 序列化单个对象或者list
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public string GetJson(object ob, object ob1)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> di = new Dictionary<string, object>();
            di.Add("rows", ob);
            di.Add("rows1", ob1);
            return (string)jss.Serialize(di);
        }
        /// <summary>
        /// 序列化datatable 类型数据 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public string GetJsonDataTable(DataTable dt, int sum = 0)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            if (dt == null)
            {
                di.Add("content", "");
                di.Add("pagesize", sum);
                return jss.Serialize(di);
            }
            foreach (DataRow dr in dt.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);
            }
            di.Add("content", dic);
            di.Add("pagesize", sum);
            return jss.Serialize(di);

        }




        //根据朋友圈的之前使用过返回数据格式不同所以写死以下方法，以后不会调用
        public string GetJsonDataTable(int sum, DataTable dt)
        {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            if (dt == null)
                return "";
            foreach (DataRow dr in dt.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);
            }
            if (sum > 0)
            {
                di.Add("content", dic);
                di.Add("pagesize", sum);
                return jss.Serialize(di);
            }
            else
            {
                return jss.Serialize(dic);
            }
        }







        /// <summary>
        /// 序列化datatable 类型数据 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public string GetJsonDataTable(DataTable dt, object ob, int sum = 0)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }

            di.Add("content", dic);
            di.Add("pagesize", sum);
            return jss.Serialize(di);

        }


    }
}
