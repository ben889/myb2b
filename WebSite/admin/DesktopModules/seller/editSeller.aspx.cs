using BLL;
using Common;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace WebSite.admin.DesktopModules.seller
{
    public partial class editSeller : basePage
    {
        protected string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.TabKey = "Seller";
                id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                HiddenFieldID.Value = id.ToString();
                if (id > 0)
                {
                    title = "修改商家信息";
                }
                else
                {
                    title = "添加商家信息";
                }
                bingSellerType(); // 下拉列表
                bind();
                bind_dist();
            }
        }

        protected int id;
        protected string name;
        protected string uname;
        protected string password;
        //protected string ctype;
        protected string address;
        protected string tel;
        protected string fax;
        protected string qq;
        protected string wx;
        protected string wxqrcode;
        //protected string business;
        protected int curruserid;
        protected int category_id;
        protected string description;
        protected bool islock;
        protected int orderby;
        protected bool recommend;



        protected int ProvinceId;
        protected int CityId;
        protected int AreaId;
        protected int DistrictId;
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void bind()
        {
            id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
            //int updatecompanyid = 0;
            if (id > 0)
            {
                Model.SellerInfo info = BLL.SellerBLL.GetModel(id);
                if (info == null) return;
                textislock.Checked = info.islock;
                textrecommend.Checked = info.recommend;
                textorderby.Text = info.orderby.ToString();
                txbuname.Text = info.uname.Trim().ToString();
                txbname.Text = info.name.Trim().ToString();
                //txbctype.Text = info.ctype.Trim().ToString();
                //txbbusiness.Text = info.business.Trim().ToString();
                txbtel.Text = info.tel.Trim().ToString();
                txbfax.Text = info.fax.Trim().ToString();
                txbqq.Text = info.qq.Trim().ToString();
                txbwx.Text = info.wx.Trim().ToString();
                txbDescription.Text = info.description.Trim().ToString();
                ddlSellerType.SelectedValue = info.category_id.ToString(); // 商家类型

                wxqrcode = "<img src=\"\" >";
                txbAddress.Text = info.address.Trim().ToString();
                //updatecompanyid = info.companyid;
                DistrictInfo dinfo = BLL.DistrictBLL.GetModel(info.distid);
                if (dinfo != null)
                {
                    ProvinceId = dinfo.ProvinceId;
                    CityId = dinfo.CityId;
                    AreaId = dinfo.AreaId;
                    DistrictId = dinfo.DistrictId;
                }

                txblng.Text = info.lng;
                txblat.Text = info.lat;

            }
            //CompanyControls = BLL.CompanysBLL.CreateCompanyHTMLControls(this.UserID, updatecompanyid);

        }

        /// <summary>
        /// 数据保存
        /// </summary>
        protected void save()
        {
            id = Convert.ToInt32(HiddenFieldID.Value);
            string resultMsg = "";
            int result = 0;

            //锁
            islock = textislock.Checked;
            //排序
            orderby = Convert.ToInt32(textorderby.Text);
            //推荐
            recommend = textrecommend.Checked;

            uname = txbuname.Text.Trim().ToString();
            password = txbpassword.Text.Trim().ToString();
            name = txbname.Text.Trim().ToString();
            //ctype = txbctype.Text.Trim().ToString();
            address = txbAddress.Text.Trim().ToString();
            tel = txbtel.Text.Trim().ToString();
            fax = txbfax.Text.Trim().ToString();
            qq = txbqq.Text.Trim().ToString();
            wx = txbwx.Text.Trim().ToString();
            description = txbDescription.Text.Trim().ToString();
            category_id = Int32.Parse(ddlSellerType.SelectedValue);
            wxqrcode = "";
            //business = txbbusiness.Text.Trim().ToString();
            curruserid = base.UserID;

            int distid = 0;
            int select1 = Common.Utils.ObjectToint(Request["Select1"]);
            if (select1 > 0)
                distid = select1;
            int select2 = Common.Utils.ObjectToint(Request["Select2"]);
            if (select2 > 0)
                distid = select2;
            int select3 = Common.Utils.ObjectToint(Request["Select3"]);
            if (select3 > 0)
                distid = select3;
            int select4 = Common.Utils.ObjectToint(Request["Select4"]);
            if (select4 > 0)
                distid = select4;
            string lng = txblng.Text.Trim();
            string lat = txblat.Text.Trim();

            if (id <= 0)
            {
                result = BLL.SellerBLL.AddTran(uname, password, name, address, description, "", 0,
                    tel, fax, qq, wx, wxqrcode, "", curruserid, category_id, islock, recommend, orderby, distid,lng,lat, ref resultMsg);
            }
            else
            {
                result = BLL.SellerBLL.Update(id, name, address, description, "", tel, fax, qq, wx, wxqrcode, "", curruserid, category_id, islock, recommend, orderby, distid, lng, lat, ref resultMsg);
            }
            if (result <= 0)
            {
                Response.Write("<script>alert(\"保存失败!" + resultMsg + "\");</script>");
                return;
            }
            else
            {
                Response.Write("<script>alert(\"保存成功\");window.parent.location.href=\"Seller.aspx\";</script>");
                return;
            }


        }
        /// <summary>
        /// 合并排序顺序值（排序用）
        /// </summary>
        /// <returns></returns>
        public int merge_orderby(int orderby)
        {
            DateTime datetime = DateTime.Now;
            string Year = datetime.Year.ToString();            // 2008获取年份 
            string DayOfYear = datetime.DayOfYear.ToString();    // 248获取第几天
            string Hour = datetime.Hour.ToString();             // 20获取小时
            string Minute = datetime.Minute.ToString();        // 31获取分钟
            string Second = datetime.Second.ToString();        // 45获取秒数
            long result = Convert.ToInt64(orderby + Year + DayOfYear + Hour + Minute + Second);
            return 0;
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        /// <summary>
        /// 强行修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnresetpass_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(HiddenFieldID.Value);
            resetpassword(id);
        }

        private void resetpassword(int sellerid)
        {
            if (id > 0)
            {
                if (base.UserType != Common.enumUserType.host.ToString()
                    && base.UserType != Common.enumUserType.admin.ToString()
                    && base.UserType != Common.enumUserType.company.ToString())
                {
                    Response.Write("<script>alert('当前帐号无修改密码权限！');</script>");
                    return;
                }
                string password = "111111";
                password = Common.Utility.MD5Encrypt(password);
                int result = BLL.publicBLL.UpdateTableValue("seller", "password='" + password + "'", "sellerid=" + sellerid);
                if (result > 0)
                    Response.Write("<script>alert('密码重置成功！');</script>");
                else
                    Response.Write("<script>alert('密码重置失败！');</script>");
            }
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        protected void bingSellerType()
        {
            ddlSellerType.Items.Add(new ListItem("选择分类", "0"));
            DataTable dt = BLL.Seller_categoryBLL.GetDt(-1, "");
            ArrayList arrlist = new ArrayList();
            publicBLL.MakeTree(dt, "parentid", "0", "id", "name", ddlSellerType, -1);
        }



        #region 区域json
        protected string dist_json;
        protected void bind_dist()
        {
            StringBuilder json_text = new System.Text.StringBuilder();
            json_text.Append("{");
            json_text.Append("\"省份\": {val: \"\", items: {\"城市\": {val: \"\", items: {\"区县\": {val: \"\", items: {\"乡镇\": \"\"}}}}}}");

            List<DistrictInfo> list = BLL.DistrictBLL.GetList(-1, "parentid=0", "sort asc");
            if (list != null && list.Count > 0)
            {
                foreach (DistrictInfo info in list)
                {
                    json_text.Append(",\"" + info.Name + "\": {val: \"" + info.DistId + "\", items: {");
                    json_text.Append(get_josn_dist(info.DistId, info.Level));
                    json_text.Append("}}");
                }
            }
            json_text.Append("}");
            dist_json = json_text.ToString();
        }
        protected string get_josn_dist(int parentid, int parentLevel)
        {

            StringBuilder builder = new System.Text.StringBuilder();
            if (parentLevel == 3)
            { builder.Append("\"...\": \"\","); }
            else
            {
                builder.Append("\"...\": {val: \"\", items: {}},");
            }
            List<DistrictInfo> list = BLL.DistrictBLL.GetList(-1, "parentid=" + parentid, "sort asc");
            if (list != null && list.Count > 0)
            {
                foreach (DistrictInfo info in list)
                {
                    if (parentLevel == 3)
                    {
                        builder.Append("\"" + info.Name + "\": \"" + info.DistId + "\",");
                    }
                    else
                    {
                        builder.Append("\"" + info.Name + "\": {val: \"" + info.DistId + "\", items: {");
                        builder.Append(get_josn_dist(info.DistId, info.Level));
                        builder.Append("}},");
                    }
                }
            }
            if (builder.ToString().EndsWith(","))
                builder.Remove(builder.ToString().Length - 1, 1);
            return builder.ToString();
        }
        #endregion
    }
}