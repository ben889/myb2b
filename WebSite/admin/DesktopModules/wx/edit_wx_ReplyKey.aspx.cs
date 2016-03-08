using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class edit_wx_ReplyKey : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx";
                replyid = Common.Utils.ObjectToint(Request["replyid"]);
                bind();
            }
        }

        protected int replyid
        {
            get { return ViewState["replyid"] != null ? Convert.ToInt32(ViewState["replyid"]) : 0; }
            set { ViewState["replyid"] = value; }
        }
        protected string title
        {
            get { return ViewState["title"] != null ? ViewState["title"].ToString() : ""; }
            set { ViewState["title"] = value; }
        }
        private void bind()
        {
            if (replyid <= 0)
            {
                Response.Write("<script>alert('replyid错误');history.go(-1);</script>");
                return;
            }
            wx_ReplyMesageInfo info = BLL.wx_ReplyMesageBLL.GetModel(replyid);

            if (info == null || info.ReplyID != replyid)
            {
                Response.Write("<script>alert('不存在对应的数据');history.go(-1);</script>");
                return;
            }
            title = info.Name;
            Repeater1bind();
        }

        private void Repeater1bind()
        {
            string where = "replyid=" + replyid;
            List<wx_ReplyKeyInfo> list = BLL.wx_ReplyKeyBLL.GetList(-1, where, "createtime desc");
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                int result = BLL.wx_ReplyKeyBLL.Delete(id, "wx_ReplyKeyID");
                if (result > 0)
                { 
                    //Repeater1bind();
                    Response.Write("<script>parent.success('');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('删除失败！');</script>");
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！');", true);
                }

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            string name = txbName.Text.Trim();
            if (name.Trim().Length == 0)
            {
                Response.Write("<script>parent.fail('关键字不能为空');</script>");
                return;
            }
            wx_ReplyKeyInfo info = new wx_ReplyKeyInfo();
            info.Name = name;
            info.ReplyID = replyid;
            info.CreateTime = DateTime.Now;
            info.State = 1;
            info.wx_ReplyKeyType = 1;
            info.companyid = "";
            string resultMsg = "";
            int result = BLL.wx_ReplyKeyBLL.add(info, ref resultMsg);
            if (result > 0)
            {
                Repeater1bind();
                Response.Write("<script>parent.success('提交成功！');</script>");
            }
            else
            {
                Response.Write("<script>parent.fail('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }
    }
}