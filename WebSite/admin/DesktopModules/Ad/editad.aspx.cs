using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.IO;

namespace WebSite.admin.DesktopModules.Ad
{
    public partial class editad : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "ad";
                adid = Request["adid"] != null ? Convert.ToInt32(Request["adid"]) : 0;
                call_index = Common.Utils.ObjectToStr(Request["call_index"]);
                bind();
            }
        }
        protected string title = "编辑";
        protected int adid = 0;
        protected int parentid;
        protected string img = "";
        protected int adpositionid;
        protected string call_index
        {
            get
            {
                return ViewState["call_index"] != null ? ViewState["call_index"].ToString() : "";
            }
            set { ViewState["call_index"] = value; }
        }
        private void bind()
        {
            if (adid > 0)
            {
                hfadid.Value = adid.ToString();
                AdInfo info = BLL.AdBLL.GetModel(adid);
                txbadname.Text = info.adname;
                adpositionid = info.adpositionid;
                if (info.adimg != null && info.adimg.Trim().Length > 0)
                    img = BLL.AdBLL.showad(info.adimg, info.suffix, info.adblank, info.adlink, -1, 50);
                if (img.Trim().Length > 0)
                    img = img + "<br/>";
                //img = "<img src=\"" + Common.Constant.URL_ad + info.adimg + "\" height=\"50\"/><br/>";
                txbadlink.Text = info.adlink;
                if (info.adblank == 0)
                    rbtnadblank0.Checked = true;
                else if (info.adblank == 1)
                    rbtnadblank1.Checked = true;
                try { ddlstatus.SelectedValue = info.status.ToString(); }
                catch { }
                txbclick.Text = info.click.ToString();

            }
            ddlAdPositionbind();
        }
        protected void ddlAdPositionbind()
        {
            ddlAdPosition.Items.Clear();
            ddlAdPosition.Items.Add(new ListItem("选择广告位", "0"));
            List<AdPositionInfo> list = BLL.AdPositionBLL.GetList(-1, "", "");

            if (list == null || list.Count == 0)
                return;
            //ddlAdPosition.DataTextField = "name";
            //ddlAdPosition.DataValueField = "id";
            //ddlAdPosition.DataSource = list;
            //ddlAdPosition.DataBind();


            foreach (AdPositionInfo info in list)
            {
                ddlAdPosition.Items.Add(new ListItem(info.name + " (" + info.width + "px * " + info.height + "px)", info.id.ToString()));
            }

            if (call_index.Trim().Length > 0)
            {
                List<AdPositionInfo> adpositioninfolist = BLL.AdPositionBLL.GetList(1, "call_index='" + call_index.Trim() + "'", "");
                if (adpositioninfolist != null && adpositioninfolist.Count > 0)
                {
                    AdPositionInfo adpositioninfo = list[0];
                    if (adpositioninfo != null && adpositioninfo.id > 0)
                    {
                        ddlAdPosition.SelectedValue = adpositioninfo.id.ToString();
                        title = adpositioninfo.name;
                    }
                }
            }
            if (adpositionid > 0)
            {
                AdPositionInfo adpositioninfo = BLL.AdPositionBLL.GetModel(adpositionid);
                if (adpositioninfo != null && adpositioninfo.id > 0)
                {
                    ddlAdPosition.SelectedValue = adpositioninfo.id.ToString();
                    title = adpositioninfo.name;
                }
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
            //            Response.Write("<script>parent.fail('图片大小不能超过500K！');</script>");
            //            return;
            //        }
            //    }
            //}
            


            int adid = hfadid.Value != null ? int.Parse(hfadid.Value) : 0;
            string adname = txbadname.Text.Trim();
            if (adname.Trim().Length == 0)
            {
                Response.Write("<script>parent.fail('名称不能为空！');</script>");
                return;
            }
            int _adpositionid = int.Parse(ddlAdPosition.SelectedValue);
            //if (_adpositionid <= 0)
            //{
            //    Response.Write("<script>parent.fail('请选择广告位！');</script>");
            //    return;
            //}

            string oldimg = "";

            Model.AdInfo model = new Model.AdInfo();
            if (adid > 0)
            {
                model = BLL.AdBLL.GetModel(adid);
                if (model == null || model.adid != adid)
                {
                    Response.Write("<script>parent.fail('参数ID错误！');</script>");
                    return;
                }
                oldimg = model.adimg;
            }
            model.adid = adid;
            model.adname = adname;
            if (rbtnadblank0.Checked)
                model.adblank = 0;
            else if (rbtnadblank1.Checked)
                model.adblank = 1;
            model.adlink = txbadlink.Text.Trim();
            model.click = int.Parse(txbclick.Text.Trim());
            model.status = int.Parse(ddlstatus.SelectedValue);
            model.adpositionid = _adpositionid;

            //================上传
            if (!Directory.Exists(Server.MapPath(Common.Constant.URL_ad())))
            {
                Directory.CreateDirectory(Server.MapPath(Common.Constant.URL_ad()));
            }

            bool upolad=false;
            if (this.file_adimg.PostedFile.FileName != null && this.file_adimg.PostedFile.FileName.Trim().Length > 0)
            {

                if (file_adimg.FileContent.Length > 500 * 1024)
                {
                    Response.Write("<script>alert('图片大小不能超过500K');</script>");
                    return;
                }

                string FileName = Path.GetFileName(this.file_adimg.PostedFile.FileName);//文件后辍
                string suffix = "";
                if (FileName.IndexOf('.') != -1)
                    suffix = FileName.Substring(FileName.LastIndexOf('.'), FileName.Length - FileName.LastIndexOf('.'));



                if (!suffix.Trim().ToLower().EndsWith("jpg")
                    && !suffix.Trim().ToLower().EndsWith("jpeg")
                    && !suffix.Trim().ToLower().EndsWith("gif")
                    && !suffix.Trim().ToLower().EndsWith("png"))
                {
                    Response.Write("<script>alert('请上传jpg gif png logo图片');</script>");
                    return;
                }

                string img = "ad_" + System.Guid.NewGuid().ToString("N") + suffix;
                file_adimg.SaveAs(Server.MapPath(Common.Constant.URL_ad() + img));
                model.adimg = Common.Constant.URL_ad() + img;
                model.suffix = suffix;
                upolad=true;
            }
            //=============================

            int result = 0;
            string resultMsg = "";
            if (adid > 0)
            { result = BLL.AdBLL.Update(model);
            if (result > 0)
            {
                if (upolad && oldimg.Trim().Length > 0)
                    File.Delete(Server.MapPath(oldimg));
            }
            }
            else
            {
                result = BLL.AdBLL.Add(model);
            }
            if (result > 0)
            {
                //Response.Redirect("Ad.aspx");
                Response.Write("<script>parent.success('保存成功','ad_call_index.aspx?call_index=" + call_index + "');</script>");
            }
            else
            {
                Response.Write("<script>parent.fail('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MScript", "alert('提交失败！" + resultMsg.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');", true);
            }
        }

    }
}