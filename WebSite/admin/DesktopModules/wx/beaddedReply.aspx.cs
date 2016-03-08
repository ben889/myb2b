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
    /// 关注时回复
    /// </summary>
    public partial class beaddedReply : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    base.TabKey = "wx_replymesage";
                    string ajaxmethod = Common.Utils.ObjectToStr(Request["ajaxmethod"]);
                    if (ajaxmethod.Trim().Length > 0)
                    {
                    }
                    else
                    {
                        bind();
                    }
                }
            }
        }

        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }
        protected int refid;
        protected int reftype;
        private void bind()
        {
            string where = "replytype=1";
            List<wx_ReplyMesageInfo> list = BLL.wx_ReplyMesageBLL.GetList(1, where, "");
            if (list != null && list.Count > 0)
            {
                wx_ReplyMesageInfo info = list[0];
                id = info.ReplyID;
                refid = info.RefID;
                reftype = info.RefType;
                txbBody.Text = info.Body;
            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
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
                model.ReplyType = 1;
                model.Name = "关注后自动回复";
                model.State = 1;
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