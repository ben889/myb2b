using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using System.Xml;

namespace WebSite.admin.DesktopModules.Ad
{
    public partial class ad_call_index : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "ad_call_index";
                call_index = Common.Utils.ObjectToStr(Request["call_index"]);
                if (call_index.Trim().Length == 0)
                {
                    Response.Write("<script>alert('无效的参数call_index!');history.go(-1);</script>");
                }
                bindAdPosition();
                Repeater1bind();
            }
        }

        protected string title;
        protected string call_index
        {
            get
            {
                return ViewState["call_index"] != null ? ViewState["call_index"].ToString() : "";
            }
            set { ViewState["call_index"] = value; }
        }

        protected void bindAdPosition()
        {
            if (call_index.Trim().Length > 0)
            {
                List<AdPositionInfo> list = BLL.AdPositionBLL.GetList(1, "call_index='" + call_index + "'", "");
                if (list != null && list.Count > 0)
                {
                    AdPositionInfo info = list[0];
                    title = info.name;
                }
            }
            else
            {
                title = "广告";
            }
        }
        /// <summary>
        /// 获取条件串
        /// </summary>
        /// <returns></returns>
        string GetCondition()
        {
            string Condition = "1=1";
            if (call_index.Trim().Length > 0)
            {
                Condition += " and A.[call_index]='" + call_index.Trim() + "'";
            }
            if (txbfieldval.Text.Trim().Length > 0)
            {
                if (ddlfield.SelectedValue == "O.[adname]")
                {
                    Condition += " and O.[adname] like '%" + txbfieldval.Text.Trim() + "%'";
                }
            }
            return Condition;
        }
        private void Repeater1bind()
        {
            string where = GetCondition();
            DataTable dt = BLL.AdBLL.GetDt(-1, where, "O.adid desc");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected string showimg(object objimg, object objfuffix, object objadlink)
        {
            //if (obj != null && obj.ToString().Trim().Length > 0)
            //{
            //    return "<img src='" + Common.Constant.URL_ad +  obj.ToString() + "' height='50' />";
            //}
            //return "";
            return BLL.AdBLL.showad(objimg.ToString(), objfuffix.ToString(), 1, objadlink.ToString(), 50, 50);
        }
        protected string status(object objstatus)
        {
            if (objstatus == null && objstatus.ToString().Trim().Length == 0)
            {
                return "<span style='color:red;'>关闭</span>";
            }
            int status = Convert.ToInt32(objstatus);
            if (status == 0)
                return "<span style='color:red;'>关闭</span>";
            else
                return "<span style='color:green;'>开通</span>";
        }

        protected void Pagination1_PageChanged(object sender, CommandEventArgs e)
        {
            Repeater1bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int b = BLL.AdBLL.Delete(id, "");
                if (b > 0)
                { Repeater1bind(); }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editad.aspx?call_index=" + call_index);
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Repeater1bind();
        }

        protected void btn_Release_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BLL.AdBLL.GetDt(-1, "call_index='" + call_index + "'", "O.adid desc");
                if (dt != null && dt.Rows.Count > 0)
                {

                    XmlDocument xd = new XmlDocument();//表示XML文档  
                    XmlDeclaration xde;//表示 XML 声明节点：<?xml version='1.0'...?>  
                    xde = xd.CreateXmlDeclaration("1.0", "UTF-8", null);//参数的第二项为编码方式  
                    //standalone定义了是否可以在不读取任何其它文件的情况下处理该文档,默认为no  
                    xd.AppendChild(xde);//<?xml version="1.0" encoding="UTF-8" standalone="yes"?>生成结束  
                    XmlElement xe = xd.CreateElement("root");//创建一个Root根元素  
                    xd.AppendChild(xe);//Root根元素创建完成  
                    XmlNode root = xd.SelectSingleNode("root");//查找<Root>  
                    foreach (DataRow dr in dt.Rows)
                    {
                        string id = dr["adid"] != DBNull.Value ? dr["adid"].ToString() : "0";
                        string name = dr["adname"] != DBNull.Value ? dr["adname"].ToString() : "";
                        string img = dr["adimg"] != DBNull.Value ? dr["adimg"].ToString() : "";
                        if (img.Trim().Length > 0)
                            img = Common.Constant.Get_Host() + img;

                        XmlElement xe1 = xd.CreateElement("ad");//在<Root>之下创建元素<Tree>  
                        xe1.SetAttribute("id", id);//指定属性的属性值  
                        xe1.SetAttribute("name", name);//指定属性的属性值  
                        xe1.SetAttribute("img", img);//指定属性的属性值  
                        //xe1.InnerText = "类型1";//指定属性文本节点  
                        root.AppendChild(xe1);//完成子节点<Tree>  
                    }
                    xd.Save(Server.MapPath("/api/ad_" + call_index + ".xml"));
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('发布成功！');", true);
                }
            }
            catch(Exception exc) {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('发布失败！" + exc.Message.Replace("\r", "").Replace("\n", "").Replace("\'", "") + "');", true);
            }
        }
    }
}