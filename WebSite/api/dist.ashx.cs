using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebSite.api
{
    /// <summary>
    /// dist 的摘要说明
    /// </summary>
    public class dist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                string method = context.Request["method"].ToString().ToLower();
                switch (method)
                {
                    case "getjson_dist":
                        context.Response.Write(getjson_dist());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
            }
        }
        #region 区域json
        public string getjson_dist()
        {
            StringBuilder json_text = new System.Text.StringBuilder();
            json_text.Append("{");
            json_text.Append("\"省份\": {val: \"0\", items: {\"城市\": {val: \"0\", items: {\"区县\": {val: \"0\", items: {\"乡镇\": \"0\"}}}}}}");

            List<DistrictInfo> list = BLL.DistrictBLL.GetList(-1, "parentid=0", "sort asc");
            if (list != null && list.Count > 0)
            {
                foreach (DistrictInfo info in list)
                {
                    json_text.Append(",\"" + info.Name + "\": {val: \"" + info.DistId + "\", items: {");
                    json_text.Append(get_josn_dist(info.DistId, info.Level));
                    json_text.Append("}}");
                }
            }
            json_text.Append("}");
            return json_text.ToString();
        }
        protected string get_josn_dist(int parentid, int parentLevel)
        {

            StringBuilder builder = new System.Text.StringBuilder();
            if (parentLevel == 3)
            { builder.Append("\"...\": \"\","); }
            else
            {
                builder.Append("\"...\": {val: \"\", items: {}},");
            }
            List<DistrictInfo> list = BLL.DistrictBLL.GetList(-1, "parentid=" + parentid, "sort asc");
            if (list != null && list.Count > 0)
            {
                foreach (DistrictInfo info in list)
                {
                    if (parentLevel == 3)
                    {
                        builder.Append("\"" + info.Name + "\": \"" + info.DistId + "\",");
                    }
                    else
                    {
                        builder.Append("\"" + info.Name + "\": {val: \"" + info.DistId + "\", items: {");
                        builder.Append(get_josn_dist(info.DistId, info.Level));
                        builder.Append("}},");
                    }
                }
            }
            if (builder.ToString().EndsWith(","))
                builder.Remove(builder.ToString().Length - 1, 1);
            return builder.ToString();
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}