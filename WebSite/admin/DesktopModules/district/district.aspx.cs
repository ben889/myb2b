using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.district
{
    public partial class district : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "district";
                string ac = Common.Utils.ObjectToStr(Request["ac"]);
                if (ac.Trim().Length > 0)
                {
                    if (ac.Equals("del"))
                    {
                        int id = Common.Utils.ObjectToint(Request["id"]);
                        string resultMsg = "";
                        int result = BLL.DistrictBLL.delete(id, ref resultMsg);
                        if (result > 0)
                        {
                            Response.Write("<script>location.href=location.href;</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('删除失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');location.href=location.href;</script>");
                        }
                    }
                }
                else
                {
                    bindlist();
                }
            }
        }
        protected void bindlist()
        {
            System.Text.StringBuilder text = new System.Text.StringBuilder();
            string where = "";
            DataTable dt = BLL.publicBLL.GetDt("District", -1, where, "Sort asc,DistId desc");
            DataTable newdt = new BLL.publicBLL().MakeTree_Dt(dt, "parentid", "0", "DistId", "Name", -1);
            if (newdt != null && newdt.Rows.Count > 0)
            {
                foreach (DataRow dr in newdt.Rows)
                {
                    int id = Common.Utils.ObjectToint(dr["DistId"]);
                    int sort = Common.Utils.ObjectToint(dr["Sort"]);
                    string name = Common.Utils.ObjectToStr(dr["Name"]);
                    int parentid = Common.Utils.ObjectToint(dr["parentid"]);
                    int cityid = Common.Utils.ObjectToint(dr["cityid"]);
                    int areaid = Common.Utils.ObjectToint(dr["areaid"]);
                    int districtid = Common.Utils.ObjectToint(dr["DistrictId"]);

                    string addstr = "";
                    if (parentid <= 0)//是省份
                    {
                        addstr = "添加城市";
                    }
                    else
                    {
                        if (areaid <= 0)//如果当前行是城市
                        {
                            addstr = "添加(区、县)";
                        }
                        else {
                            addstr = "添加商区";
                        }
                    }
                    text.Append("<div style=\"height:26px;line-height:26px;margin-bottom:2px;\" onmouseover=\"this.style.background='#f2f2f2'\" onmouseout=\"this.style.background='#ffffff'\">");
                    text.Append("<div style=\"float:left;text-align:left;height:26px;line-height:26px;margin-right:20px;\">");
                    text.Append("<div style=\"float:left;width:40px;\">" + sort + "</div><div style=\"float:left;\">&nbsp;&nbsp;" + name + "</div><div style=\"clear:both;\"></div>");
                    text.Append("</div>");
                    text.Append("<div style=\"width:200px;float:left;text-align:left;height:26px;line-height:26px;\">");
                    text.Append("<a href=\"edit_district.aspx?id=" + id + "\">修改</a>");
                    text.Append("&nbsp;|&nbsp;<a href=\"javascript:void();\" onclick=\"del(" + id + ");\">删除</a>");
                    if (districtid <= 0)
                        text.Append("&nbsp;|&nbsp;<a href=\"edit_district.aspx?parentid=" + id + "\">" + addstr + "</a>");
                    text.Append("</div>");
                    text.Append("<div style=\"clear:both;\">");
                    text.Append("</div>");
                    text.Append("</div>");
                }
            }
            listHTML = text.ToString();
        }
        protected string listHTML;
    }
}