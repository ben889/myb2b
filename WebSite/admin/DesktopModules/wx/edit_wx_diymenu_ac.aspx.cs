using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class edit_wx_diymenu_ac : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_diymenu";

                id = Common.Utils.ObjectToint(Request["id"]);

                string ac = Common.Utils.ObjectToStr(Request["ac"]);

                if (ac.Trim().Length > 0)
                {
                    if (ac.Equals("updateurl"))
                    {
                        string URL = Common.Utils.ObjectToStr(Request["URL"]);
                        updateurl(URL);
                    }
                    else if (ac.Equals("update_text"))
                    {
                        string body = Common.Utils.ObjectToStr(Request["Body"]);
                        update_text(body);
                    }
                    else if (ac.Equals("updateimg_text"))
                    {
                        int refid = Common.Utils.ObjectToint(Request["refid"]);
                        //int reftype = Common.Utils.ObjectToint(Request["reftype"]);
                        update_imgtext(refid);
                    }
                }
                else
                {
                    bind();
                }
            }
        }
        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }
        protected int RefID
        {
            get { return ViewState["RefID"] != null ? Convert.ToInt32(ViewState["RefID"]) : 0; }
            set { ViewState["RefID"] = value; }
        }
        protected int RefType
        {
            get { return ViewState["RefType"] != null ? Convert.ToInt32(ViewState["RefType"]) : 0; }
            set { ViewState["RefType"] = value; }
        }
        protected string Name;
        protected string URL;
        protected string Body;
        private void bind()
        {
            if (id > 0)
            {
                wx_diymenuInfo info = BLL.wx_diymenuBLL.GetModel(id);
                Name = info.Name;
                RefID = info.RefID;
                RefType = info.RefType;
                URL = info.URL;
                Body = info.Body;
            }
        }


        #region 更改
        /// <summary>
        /// 更改成链接
        /// </summary>
        /// <param name="url"></param>
        protected void updateurl(string url)
        {
            try
            {
                if (id <= 0)
                {
                    Response.Write("<script>parent.fail('id 错误');</script>");
                    return;
                }
                if (url.Trim().Length == 0)
                {
                    Response.Write("<script>parent.fail('请填写链接地址');</script>");
                    return;
                }
                wx_diymenuInfo model = BLL.wx_diymenuBLL.GetModel(id);
                if (model == null || model.MenuId != id)
                {
                    Response.Write("<script>parent.fail('无对应的数据');</script>");
                    return;
                }
                model.URL = url;
                model.RefType = 0;
                model.RefID = 0;
                model.Body = "";
                int result = BLL.wx_diymenuBLL.Update(model);
                if (result > 0)
                {
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！');</script>");
                }
            }
            catch (Exception exc)
            { Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>"); }
        }

        /// <summary>
        /// 更改成文本动作
        /// </summary>
        /// <param name="body"></param>
        protected void update_text(string body)
        {
            try
            {
                if (id <= 0)
                {
                    Response.Write("<script>parent.fail('id 错误');</script>");
                    return;
                }
                if (body.Trim().Length == 0)
                {
                    Response.Write("<script>parent.fail('文本内容不能为空');</script>");
                    return;
                }
                wx_diymenuInfo model = BLL.wx_diymenuBLL.GetModel(id);
                if (model == null || model.MenuId != id)
                {
                    Response.Write("<script>parent.fail('无对应的数据');</script>");
                    return;
                }

                //if (refid <= 0)
                //{
                //    Response.Write("<script>parent.fail('refid 错误');</script>");
                //    return;
                //}
                model.URL = "";
                model.RefType = 1;
                model.RefID = 0;
                model.Body = body;
                int result = BLL.wx_diymenuBLL.Update(model);
                if (result > 0)
                {
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！');</script>");
                }
            }
            catch (Exception exc)
            { Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>"); }
        }
        /// <summary>
        /// 更改成图文动作
        /// </summary>
        /// <param name="refid"></param>
        /// <param name="reftype"></param>
        protected void update_imgtext(int refid)
        {
            try
            {
                if (id <= 0)
                {
                    Response.Write("<script>parent.fail('id 错误');</script>");
                    return;
                }

                wx_diymenuInfo model = BLL.wx_diymenuBLL.GetModel(id);
                if (model == null || model.MenuId != id)
                {
                    Response.Write("<script>parent.fail('无对应的数据');</script>");
                    return;
                }
                //if (reftype != 3)
                //{
                //    Response.Write("<script>parent.fail('reftype 错误');</script>");
                //    return;
                //}
                model.URL = "";
                model.RefType = 3;
                model.RefID = refid;
                model.Body = "";
                int result = BLL.wx_diymenuBLL.Update(model);
                if (result > 0)
                {
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！');</script>");
                }
            }
            catch (Exception exc)
            { Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>"); }
        }
        #endregion
    }
}