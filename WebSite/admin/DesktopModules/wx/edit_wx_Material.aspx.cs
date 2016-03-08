using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class edit_wx_Material : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx";
                parentid = Common.Utils.ObjectToint(Request["parentid"]);
                add = Common.Utils.ObjectToStr(Request["add"]);
                id = Common.Utils.ObjectToint(Request["id"]);

                string ac = Common.Utils.ObjectToStr(Request["ac"]);
                if (ac.Trim().Length > 0)
                {
                    if (ac.Equals("del"))
                    {
                        del(id);
                    }
                }
                else
                {

                    if (id > 0 && add.Trim().Length > 0)
                    {
                        Response.Write("<script>alert('参数冲突');history.go(-1);</script>");
                        return;
                    }
                    bindlist();
                    bind();
                }
            }
        }


        protected int parentid
        {
            get { return ViewState["parentid"] != null ? Convert.ToInt32(ViewState["parentid"]) : 0; }
            set { ViewState["parentid"] = value; }
        }

        protected string add
        {
            get { return ViewState["add"] != null ? ViewState["add"].ToString() : ""; }
            set { ViewState["add"] = value; }
        }
        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }

        protected wx_MaterialInfo info;
        protected List<wx_MaterialInfo> list;
        protected void bindlist()
        {
            if (parentid > 0)
            {
                info = BLL.wx_MaterialBLL.GetModel(parentid);
                list = BLL.wx_MaterialBLL.GetList(-1, "parentid=" + parentid, "CreateTime asc");
            }
        }

        protected string Name;
        protected string Paper;
        protected string Body;
        protected string ImgUrl;
        protected string selecturl;
        private void bind()
        {
            string link_url = "";
            if (id > 0)
            {
                wx_MaterialInfo info = BLL.wx_MaterialBLL.GetModel(id);

                if (info == null || info.wx_MaterialID != id)
                {
                    Response.Write("<script>alert('不存在对应的数据');history.go(-1);</script>");
                    return;
                }
                Name = info.Name;
                Paper = info.Paper;
                Body = info.Body;
                ImgUrl = info.ImgUrl;
                link_url = info.Url;

            }
            selecturl = BLL.UrlBLL.get_select("url", link_url);
        }

        protected void del(int id)
        {
            if (id <= 0)
            {
                Response.Write("<script>parent.fail('id错误');</script>");
                return;
            }
            string resultMsg = "";
            int result = BLL.wx_MaterialBLL.delete(id, ref resultMsg);
            if (result > 0)
            {
                Response.Write("<script>parent.del_success();</script>");
            }
            else
            {
                Response.Write("<script>parent.fail('删除失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        { save(); }
        protected void save()
        {
            try
            {


                wx_MaterialInfo model = new wx_MaterialInfo();
                if (id > 0)
                {
                    model = BLL.wx_MaterialBLL.GetModel(id);
                    if (model == null || model.wx_MaterialID != id)
                    {
                        Response.Write("<script>parent.fail('参数id错误！');</script>");
                        return;
                    }
                }
                model.Name = Common.Utils.ObjectToStr(Request.Form["Name"]);
                model.Paper = Common.Utils.ObjectToStr(Request.Form["Paper"]);
                model.Body = Common.Utils.ObjectToStr(Request.Form["Body"]);
                model.ImgUrl = Common.Utils.ObjectToStr(Request.Form["ImgUrl"]);
                model.Url = Common.Utils.ObjectToStr(Request.Form["url"]);
                //if (model.Url.Trim().Length == 0)
                //{
                //    model.Url = Common.Constant.Get_Host() + "/mobile/wx/wx_appmsg.aspx?id=";
                //}
                int saveresult = 0;
                string resultmsg = "";
                if (id > 0)
                {
                    saveresult = BLL.wx_MaterialBLL.Update(model);
                }
                else
                {
                    model.companyid = "";
                    model.CreateTime = DateTime.Now;
                    model.ParentID = parentid;
                    model.Type = 3;
                    saveresult = BLL.wx_MaterialBLL.Insert(model, BS.Components.Data.Entity.ReturnTypes.Identity);
                }
                if (saveresult > 0)
                {
                    if (parentid <= 0)
                        parentid = saveresult;
                    Response.Write("<script>parent.success('" + parentid + "');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！" + resultmsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.fail('提交失败！" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }
    }
}