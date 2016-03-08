using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebSite.seller
{
    public partial class index : seller_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ajaxmethod = Common.Utils.ObjectToStr(Request["ajaxmethod"]);
                if (ajaxmethod.Trim().Length > 0)
                {
                    switch (ajaxmethod)
                    {
                        case "bindmenu":
                            Response.Write(getmenu());
                            Response.End();
                            break;
                        case "bindsubmenu":
                            //int id = Common.Utils.ObjectToint(Request["id"]);
                            int parentid = Common.Utils.ObjectToint(Request["parentid"]);
                            Response.Write(getsubmenu(parentid));
                            Response.End();
                            break;
                    }
                }
            }
        }

        protected string getmenu()
        {
            string result = "[";
            XmlNodeList nodelist = XMLHelper.GetXmlNodeList(Server.MapPath("menu.xml"), @"menu/item");
            foreach (XmlNode xmlNode in nodelist)
            {
                string id = xmlNode.Attributes["id"].Value;
                string name = xmlNode.Attributes["name"].Value;
                string _url = xmlNode.Attributes["url"].Value;

                result += "{\"url\":\"" + _url + "\",\"id\":\"" + id + "\",\"name\":\"" + name + "\",\"submenu\":[]},";
            }
            if (result.EndsWith(","))
                result = result.Remove(result.Length - 1);
            result += "]";
            return result;
        }
        protected string getsubmenu(int parentid)
        {
            try
            {
                string result = "[";
                XmlNodeList nodelist = XMLHelper.GetXmlNodeList(Server.MapPath("menu.xml"), @"menu/item");
                //XmlNodeList list = XMLHelper.GetXmlNodeList(Server.MapPath("menu.xml"), @"menu/item/menu/item");
                foreach (XmlNode xmlNode in nodelist)
                {
                    string id = xmlNode.Attributes["id"].Value;
                    string name = xmlNode.Attributes["name"].Value;
                    if (parentid.ToString().Equals(id.Trim()))
                    {
                        XmlNodeList subnodelist = xmlNode.ChildNodes;
                        foreach (XmlNode node in subnodelist)
                        {
                            string _id = node.Attributes["id"].Value;
                            string _name = node.Attributes["name"].Value;
                            string _url = node.Attributes["url"].Value;
                            result += "{\"id\":\"" + _id + "\",\"name\":\"" + _name + "\",\"url\":\"" + _url + "\"},";
                        }
                    }
                }
                if (result.EndsWith(","))
                    result = result.Remove(result.Length - 1);
                result += "]";
                return result;
            }
            catch { }
            return "[]";
        }
    }
}