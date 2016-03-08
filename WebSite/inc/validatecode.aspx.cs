using Common.ValidatedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.inc
{
    public partial class validatecode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validatedcode v = new validatedcode();
            string code = v.CreateVerifyCode();            //取随机码 
            v.CreateImageOnPage(code, this.Context);       // 输出图片 
            Session["checkcode"] = code;                   //Session 取出验证码 
        }
    }
}