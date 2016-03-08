using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BLL;

namespace WebSite.admin.DesktopModules.wx
{
    public partial class wx_diymenu : basePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "wx_diymenu";
                string ac = Common.Utils.ObjectToStr(Request.Form["ac"]);
                if (ac.Trim().Length > 0)
                {
                    if (ac.Equals("save"))
                    {
                        int id = Common.Utils.ObjectToint(Request.Form["id"]);
                        string name = Common.Utils.ObjectToStr(Request.Form["name"]);
                        int parentid = Common.Utils.ObjectToint(Request.Form["parentid"]);
                        save(id, name, parentid);
                    }
                }
                else
                {
                    listbind();
                }
            }
        }
        private void listbind()
        {
            string where = "1=1";
            //if (companyid.Trim().Length > 0)
            //{
            //    where += " and O.companyid='" + companyid + "'";
            //}
            DataTable dt = BLL.publicBLL.GetDt("wx_diymenu", -1, where, "Sort asc");
            DataTable newdt = new BLL.publicBLL().MakeTree_Dt(dt, "parentid", "0", "MenuId", "Name", -1);
            Repeater1.DataSource = newdt;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string resultMsg = "";
                int b = BLL.wx_diymenuBLL.delete(id, ref resultMsg);
                if (b > 0)
                { Response.Write("<script>parent.success('');</script>"); }
                else
                {
                    Response.Write("<script>parent.fail('删除失败！" + resultMsg + "');</script>");
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.ToString(), "alert('删除失败！" + resultMsg + "');", true);
                }
            }
        }


        protected void save(int id, string name, int parentid)
        {
            try
            {
                if (name.Trim().Length == 0)
                {
                    Response.Write("<script>parent.fail('请填写名称！');</script>");
                    return;
                }
                wx_diymenuInfo model = new wx_diymenuInfo();
                if (id > 0)
                {
                    model = BLL.wx_diymenuBLL.GetModel(id);
                    if (model == null || model.MenuId != id)
                    {
                        Response.Write("<script>parent.fail('参数id错误！');</script>");
                        return;
                    }
                }


                model.Name = name.Trim();
                model.ParentId = parentid;
                int saveresult = 0;
                string resultmsg = "";
                if (id > 0)
                {
                    saveresult = BLL.wx_diymenuBLL.Update(model);
                }
                else
                {
                    model.State = 1;
                    model.RefType = -1;
                    model.RefID = 0;
                    model.companyid = "";
                    model.CreateTime = DateTime.Now;
                    saveresult = BLL.wx_diymenuBLL.add(model, ref resultmsg);

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


        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnrelease_Click(object sender, EventArgs e)
        {
            try
            {
                wx_configInfo cinfo = wx_configBLL.getInfo();
                if (cinfo == null)
                {
                    Response.Write("<script>parent.fail('参数未配置');</script>");
                    return;
                }

                string AccessToken = com.weixin.Utility.Context.GetAccessToken(cinfo.AppId, cinfo.AppSecret);
                string strHtml = BLL.wx_diymenuBLL.getjson();
                //Common.LogUtil.WriteLog("", "微信菜单生成xml_", strHtml);
                string result = com.weixin.Menu.MenuManager.CreateMenu(strHtml.ToString(), AccessToken);
                //System.Xml.Linq.XDocument doc = com.weixin.Utility.XmlUtility.ParseJson(result, "root");
                //System.Xml.Linq.XElement root = doc.Root;

                JObject resultjo = (JObject)JsonConvert.DeserializeObject(result);



                if (resultjo != null)
                {
                    string errcode = resultjo["errcode"] != null ? resultjo["errcode"].ToString() : "";
                    string errmsg = resultjo["errmsg"] != null ? resultjo["errmsg"].ToString() : "";
                    //string errcode = root.Element("errcode").Value;
                    //string errmsg = root.Element("errmsg").Value;
                    if (errcode.ToString() == "0")
                    {
                        Response.Write("<script>parent.success('发布成功');</script>");
                        return;
                    }
                    else
                    {
                        Response.Write("<script>parent.fail('发布失败，" + errmsg + "');</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>parent.fail('发布失败');</script>");
                    return;
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>parent.fail('" + exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "") + "');</script>");
            }
        }
    }
}