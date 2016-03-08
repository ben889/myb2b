using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Collections;
using System.Data;
using Model;
using Web.UI;

namespace WebSite.admin.DesktopModules.article
{
    public partial class editarticle : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "article";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                ddlcategorybind();
                bind();

            }
        }

        protected int id
        {
            get { return ViewState["id"] != null ? Convert.ToInt32(ViewState["id"]) : 0; }
            set { ViewState["id"] = value; }
        }

        protected int category_id;


        protected void ddlcategorybind()
        {
            ddlcategory.Items.Add(new ListItem("选择分类", "0"));
            DataTable dt = article_categoryBLL.GetDt(-1, "", "");
            ArrayList arrlist = new ArrayList();
            //arrlist = MakeTree2(dt, "ParentID", "0", "TabID", "TabName", -1);
            publicBLL.MakeTree(dt, "parentid", "0", "id", "title", ddlcategory, -1);
            if (category_id > 0)
                ddlcategory.SelectedValue = category_id.ToString();
        }

        protected string img;
        protected string img_url;
        protected string content;
        protected string CompanyControls;
        private void bind()
        {
            if (id > 0)
            {
                string where = "id=" + id;
                List<articleInfo> list = BLL.articleBLL.GetList(1, where, "");
                if (list == null || list.Count == 0)
                {
                    Response.Write("<script>alert('无对应的数据！');history.go(-1);</script>");
                    return;
                }
                articleInfo info = list[0];
                hfid.Value = info.id.ToString();
                txbtitle.Text = info.title;
                txblink_url.Text = info.link_url;
                txbseo_description.Text = info.seo_description;
                txbzhaiyao.Text = info.zhaiyao;
                content = info.content;
                txborderby.Text = info.orderby.ToString();
                txbclick.Text = info.click.ToString();
                //txbstatus.Text = info.status;//0正常1未审核2锁定
                if (info.status == 0)
                    rbtnstatus0.Checked = true;
                else if (info.status == 1)
                    rbtnstatus1.Checked = true;
                else if (info.status == 2)
                    rbtnstatus2.Checked = true;
                ckbis_top.Checked = info.is_hot == 1 ? true : false;

                ckbis_red.Checked = info.is_red == 1 ? true : false;
                ckbis_hot.Checked = info.is_hot == 1 ? true : false;
                ckbis_slide.Checked = info.is_slide == 1 ? true : false;
                try
                {
                    ddlcategory.SelectedValue = info.category_id.ToString();
                }
                catch { }
                txbcall_index.Text = info.call_index;
                if (info.img_url != null && info.img_url.Trim().Length > 0)
                    img = "<img src=\"" + info.img_url + "\" height=\"50\"/><br/>";
                img_url = info.img_url;
                txbseo_title.Text = info.seo_title;
                txbseo_keywords.Text = info.seo_keywords;
            }
            else
            {
                txbclick.Text = "1";
                txborderby.Text = "99";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //HttpFileCollection files = HttpContext.Current.Request.Files;

            //if (files != null && files.Count > 0)
            //{
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        System.Web.HttpPostedFile file = files[i];
            //        if (file.ContentLength > 500 * 1024)
            //        {
            //            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('图片大小不能超过300K！');", true);
            //            Response.Write("<script>parent.fail('图片大小不能超过500K！');</script>");
            //            return;
            //        }
            //    }
            //}


            articleInfo model = new articleInfo();
            model.id = id;
            id = model.id;
            model.seo_description = txbseo_description.Text;
            model.zhaiyao = txbzhaiyao.Text;
            model.orderby = int.Parse(txborderby.Text);
            model.click = int.Parse(txbclick.Text);
            if (rbtnstatus1.Checked)
                model.status = 1;
            else if (rbtnstatus2.Checked)
                model.status = 2;
            model.is_top = ckbis_top.Checked ? 1 : 0;
            model.is_red = ckbis_red.Checked ? 1 : 0;
            model.is_hot = ckbis_hot.Checked ? 1 : 0;
            model.is_slide = ckbis_slide.Checked ? 1 : 0;
            model.userid = base.UserID;
            model.username = base.UserName;
            model.add_time = DateTime.Now;
            model.update_time = DateTime.Now;
            model.category_id = int.Parse(ddlcategory.SelectedValue);
            model.call_index = txbcall_index.Text;
            model.title = txbtitle.Text;
            model.link_url = txblink_url.Text;
            model.img_url = Common.Utils.ObjectToStr(Request["img_url"]);
            model.seo_title = txbseo_title.Text;
            model.seo_keywords = txbseo_keywords.Text;

            model.content = Request["content"].ToString();

            int result = 0;
            string resultMsg = "";
            if (id > 0)
            {
                result = BLL.articleBLL.Update(model, ref resultMsg);
                if (result > 0)
                {
                    //Components.EventLogController.AddEventLog("修改文章", "修改文章-" + model.title, base.UserID);
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                }
            }
            else
            {
                result = BLL.articleBLL.Add(model, ref resultMsg);
                if (result > 0)
                {
                    //Components.EventLogController.AddEventLog("添加文章", "添加文章-" + model.title, base.UserID);
                    Response.Write("<script>parent.success('提交成功！');</script>");
                }
                else
                {
                    Response.Write("<script>parent.fail('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                }
            }

        }
    }
}