using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin.DesktopModules.wx
{
    /// <summary>
    /// 关键字回复
    /// </summary>
    public partial class edit_wx_ReplyMesage : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_replymesage";
                string ajaxmethod = Common.Utils.ObjectToStr(Request["ajaxmethod"]);
                id = Common.Utils.ObjectToint(Request["id"]);
                if (ajaxmethod.Trim().Length > 0)
                {
                    if (ajaxmethod.Equals("getjson_appmsg"))
                    {
                        int refid = Common.Utils.ObjectToint(Request["refid"]);
                        Response.Write(getjson_appmsg(refid));
                        Response.End();
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

        /// <summary>
        /// 图文消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getjson_appmsg(int id)
        {
            string json = BLL.wx_MaterialBLL.getjson_appmsg(id);
            return json;
        }


        protected int refid;
        protected int reftype;
        private void bind()
        {
            if (id > 0)
            {
                hfid.Value = id.ToString();
                wx_ReplyMesageInfo info = BLL.wx_ReplyMesageBLL.GetModel(id);

                if (info == null || info.ReplyID != id)
                {
                    Response.Write("<script>alert('不存在对应的数据');history.go(-1);</script>");
                    return;
                }
                txbName.Text = info.Name;
                ddlState.SelectedValue = info.State.ToString();
                refid = info.RefID;
                reftype = info.RefType;
                txbBody.Text = info.Body;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                int State = int.Parse(ddlState.SelectedValue);
                if (State != 0 && State != 1)
                {
                    Response.Write("<script>parent.fail('状态错误！');</script>");
                    return;
                }


                wx_ReplyMesageInfo model = new wx_ReplyMesageInfo();
                if (id > 0)
                {
                    model = BLL.wx_ReplyMesageBLL.GetModel(id);
                    if (model == null || model.ReplyID != id)
                    {
                        Response.Write("<script>parent.fail('参数id错误！');</script>");
                        return;
                    }
                }
                model.ReplyType = 2;
                model.Name = txbName.Text.Trim();
                model.State = int.Parse(ddlState.SelectedValue);
                model.RefType = Common.Utils.ObjectToint(Request["reftype"]);
                model.Body = "";
                model.RefID = 0;

                if (model.RefType == 1)
                {
                    model.Body = txbBody.Text;
                }
                else if (model.RefType == 2)
                {
                    model.RefID = Common.Utils.ObjectToint(Request["refid"]);
                }
                else if (model.RefType == 3)
                {
                    model.RefID = Common.Utils.ObjectToint(Request["refid"]);
                }
                else
                {
                    Response.Write("<script>parent.fail('回复类型错误！');</script>");
                    return;
                }


                int saveresult = 0;
                string resultmsg = "";
                if (id > 0)
                {
                    saveresult = BLL.wx_ReplyMesageBLL.update(model, ref resultmsg);
                }
                else
                {
                    model.companyid = "";
                    model.CreateTime = DateTime.Now;
                    saveresult = BLL.wx_ReplyMesageBLL.add(model, ref resultmsg);

                }
                if (saveresult > 0)
                {
                    Response.Write("<script>parent.success('提交成功！');</script>");
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