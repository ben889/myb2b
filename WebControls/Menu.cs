using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using System.Web.UI;

namespace WebControls
{
    public class Menu : System.Web.UI.WebControls.WebControl
    {


        protected override void Render(HtmlTextWriter writer)
        {


            //HTML字符串
            //StringBuilder sb = new StringBuilder();
            string menustr = Menubind();
            writer.Write(menustr);
            //base.Render(writer);

        }


        public string CurrentTabUrl = "";
        /// <summary>
        /// 当前tabid
        /// </summary>
        public string CurrentTabID;



        /// <summary>
        /// 框架名
        /// </summary>
        [DefaultValue(""), Category("打开方式"), Description("打开方式")]
        public string target
        {
            get
            {
                if (ViewState["target"] != null && ViewState["target"].ToString().Trim().Length > 0)
                    return ViewState["target"].ToString();
                else
                    return "";
            }
            set { ViewState["target"] = value; }
        }

        [DefaultValue(""), Category("XML格式的菜单内容"), Description("XML格式的菜单内容")]
        public string XML
        {
            get
            {
                if (ViewState["XML"] != null && ViewState["XML"].ToString().Trim().Length > 0)
                    return ViewState["XML"].ToString();
                else
                    return "";
            }
            set { ViewState["XML"] = value; }
        }


        private string Menubind()
        {
            try
            {
                if (XML.Trim().Length == 0)
                    return "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XML);
                string result = readMenu(doc);
                return result;
            }
            catch { }
            return "";
        }
        private string readMenu(XmlDocument doc)
        {
            if (doc == null)
                return "";
            try
            {
                string result = "";

                XmlElement root = doc.DocumentElement;
                XmlNodeList nodelist = root.ChildNodes;

                if (nodelist != null && nodelist.Count > 0)
                {
                    result += "<ul>";
                    int i = 0;
                    foreach (XmlNode node in nodelist)
                    {
                        string nodename = node.Name;
                        result += GetNodes(node);
                        if (i == 0)
                        {
                            string id = node.Attributes[FieldID] != null ? node.Attributes[FieldID].Value : "";
                            CurrentTabID = id;
                            string text = node.Attributes[FieldText] != null ? node.Attributes[FieldText].Value : "";
                            string url = node.Attributes[FieldNavigateUrl] != null ? node.Attributes[FieldNavigateUrl].Value : "";
                            CurrentTabUrl = url;
                            string img = node.Attributes[FieldImg] != null ? node.Attributes[FieldImg].Value : "";
                        }
                        i++;
                    }
                    result += "</ul>";
                }
                return result;
            }
            catch { }
            return "";
        }

        /// <summary>
        /// ID字段名
        /// </summary>
        [DefaultValue("ID"), Category("ID字段名"), Description("ID字段名")]
        public string FieldID
        {
            get
            {
                if (ViewState["FieldID"] != null && ViewState["FieldID"].ToString().Trim().Length > 0)
                    return ViewState["FieldID"].ToString();
                else
                    return "ID";
            }
            set { ViewState["FieldID"] = value; }
        }
        /// <summary>
        /// 显示文本字段名
        /// </summary>
        [DefaultValue("Text"), Category("显示文本字段名"), Description("显示文本字段名")]
        public string FieldText
        {
            get
            {
                if (ViewState["FieldText"] != null && ViewState["FieldText"].ToString().Trim().Length > 0)
                    return ViewState["FieldText"].ToString();
                else
                    return "Text";
            }
            set { ViewState["FieldText"] = value; }
        }
        /// <summary>
        /// 链接字段名
        /// </summary>
        [DefaultValue("NavigateUrl"), Category("链接字段名"), Description("链接字段名")]
        public string FieldNavigateUrl
        {
            get
            {
                if (ViewState["FieldNavigateUrl"] != null && ViewState["FieldNavigateUrl"].ToString().Trim().Length > 0)
                    return ViewState["FieldNavigateUrl"].ToString();
                else
                    return "NavigateUrl";
            }
            set { ViewState["FieldNavigateUrl"] = value; }
        }

        [DefaultValue("Img"), Category("图片字段名"), Description("图片字段名")]
        public string FieldImg
        {
            get
            {
                if (ViewState["FieldImg"] != null && ViewState["FieldImg"].ToString().Trim().Length > 0)
                    return ViewState["FieldImg"].ToString();
                else
                    return "Img";
            }
            set { ViewState["FieldImg"] = value; }
        }

        [DefaultValue("Class"), Category("样式字段名"), Description("li标签使用的样式字段名")]
        public string FieldClass
        {
            get
            {
                if (ViewState["FieldClass"] != null && ViewState["FieldClass"].ToString().Trim().Length > 0)
                    return ViewState["FieldClass"].ToString();
                else
                    return "Class";
            }
            set { ViewState["FieldClass"] = value; }
        }
        private string GetNodes(XmlNode xmlNode)
        {


            string result = "";

            string id = xmlNode.Attributes[FieldID] != null ? xmlNode.Attributes[FieldID].Value : "";
            string text = xmlNode.Attributes[FieldText] != null ? xmlNode.Attributes[FieldText].Value : "";
            string url = xmlNode.Attributes[FieldNavigateUrl] != null ? xmlNode.Attributes[FieldNavigateUrl].Value : "";
            string img = xmlNode.Attributes[FieldImg] != null ? xmlNode.Attributes[FieldImg].Value : "";
            if (img.Trim().Length > 0)
                img = "<img src=\"" + img + "\" border=\"0\" />";

            string css = xmlNode.Attributes[FieldClass] != null ? xmlNode.Attributes[FieldClass].Value : "";
            if (css.Trim().Length > 0)
                css = " class=\"" + css + "\"";
            //string ParentID = xmlNode.Attributes["ParentID"] != null ? xmlNode.Attributes["ParentID"].Value : "";

            result += "<li" + css + ">";
            result += "<a href='" + url + "' id=\"" + id + "\" target=\"" + target + "\">" + img + text + "</a>";

            XmlElement xe = (XmlElement)xmlNode;
            XmlNodeList nodelist = xe.ChildNodes;
            if (nodelist != null && nodelist.Count > 0)
            {
                result += "<ul>";
                foreach (XmlNode node in nodelist)
                {
                    result += GetNodes(node);
                }
                result += "</ul>";
            }
            result += "</li>";
            return result;
        }
    }
}
