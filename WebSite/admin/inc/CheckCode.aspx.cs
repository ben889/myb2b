using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using Common.ValidatedCode;

namespace admin.Inc
{
    public partial class CheckCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkcode v = new checkcode();
                string code = v.CreateRandomNum(4);            //取随机码 
                v.CreateImage(code, this.Context);       // 输出图片 
                Session["ValidateNum"] = code;                   //Session 取出验证码 
            }
           
        }

    }
}
