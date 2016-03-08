using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.mobile.wx
{
    /// <summary>
    /// 微信图文文章
    /// </summary>
    public partial class wx_appmsg : m_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Common.Utils.ObjectToint(Request["id"]);
                bind(id);
            }
        }
        protected int id;
        protected string Name;
        protected string ImgUrl;
        protected string Body;
        protected string CreateTime;
        protected void bind(int id)
        {
            if (id <= 0)
            {
                Response.Write("<script>alert('无效的参数');history.go(-1);</script>");
                return;
            }
            string where = "wx_MaterialID=" + id;
            List<wx_MaterialInfo> list = BLL.wx_MaterialBLL.GetList(1, where, "");
            if (list == null || list.Count == 0)
            {
                Response.Write("<script>alert('无对应的数据');history.go(-1);</script>");
                return;
            }
            wx_MaterialInfo info = list[0];
            Name = info.Name;
            Body = info.Body;
            CreateTime = info.CreateTime.ToString("yyyy-MM-dd");
            if (info.ImgUrl.Trim().Length > 0)
            {
                ImgUrl = "<img src=\"" + info.ImgUrl + "\"/>";
            }
        }
    }
}