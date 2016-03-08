using BLL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;
using WebSite.mobile.member;
using WeiPay;

namespace WebSite.mobile.weixinpay
{
    public partial class send : m_basepage
    {
        private string UserOpenId = ""; //微信用户openid；
        //protected int orderid;
        //protected g_orderInfo orderinfo;
        string State_Str = "";//订单号等参数

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //orderid = Common.Utils.ObjectToint(Request["orderid"]);
                //if (Request.QueryString["state"] != null)
                //    orderid =  Common.Utils.ObjectToint(Request.QueryString["state"]);


                if (Request.QueryString["orderno"] != null
                    && Request.QueryString["model"] != null
                    && Request.QueryString["price"] != null)
                {
                    //订单编号、应收金额、优惠劵id
                    State_Str = Request.QueryString["orderno"] + "*" + Request.QueryString["price"]
                                + "*" + Request.QueryString["model"];
                }
                //
                if (Request.QueryString["state"] != null)
                    State_Str = Request.QueryString["state"];

                //获取当前用户的OpenId，如果可以通过系统获取用户Openid就不用调用该函数
                this.GetUserOpenId();
            }
        }

        /// <summary>
        /// 获取当前用户的微信 OpenId，如果知道用户的OpenId请不要使用该函数
        /// </summary>
        private void GetUserOpenId()
        {
            wx_configInfo cinfo = wx_configBLL.getInfo();
            if (cinfo == null)
            {
                Response.Write("<script>alert('微信参数未设置');history.go(-1);</script>");
                return;
            }
            if (cinfo.AppId == null || cinfo.AppId.Trim().Length == 0)
            {
                Response.Write("<script>alert('微信参数AppId未设置');history.go(-1);</script>");
                return;
            }
            if (cinfo.MchId == null || cinfo.MchId.Trim().Length == 0)
            {
                Response.Write("<script>alert('微信参数MchId未设置');history.go(-1);</script>");
                return;
            }
            if (cinfo.AppKey == null || cinfo.AppKey.Trim().Length == 0)
            {
                Response.Write("<script>alert('微信参数AppKey未设置');history.go(-1);</script>");
                return;
            }
            if (cinfo.AppSecret == null || cinfo.AppSecret.Trim().Length == 0)
            {
                Response.Write("<script>alert('微信参数AppSecret未设置');history.go(-1);</script>");
                return;
            }

            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                //string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect"
                //    , PayConfig.AppId, PayConfig.SendUrl, State_Str);
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect"
                    , cinfo.AppId, Common.Constant.Get_Host() + PayConfig.SendUrl, State_Str);
                Response.Redirect(code_url);
            }
            else
            {
                //LogUtil.WriteLog(" ============ 开始 获取微信用户相关信息 =====================");

                #region 获取支付用户 OpenID================
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", cinfo.AppId, cinfo.AppSecret, code);
                string returnStr = HttpUtil.Send("", url);
                //LogUtil.WriteLog("Send 页面  returnStr 第一个：" + returnStr);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", cinfo.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                //LogUtil.WriteLog("Send 页面  access_token：" + obj.access_token);
                //LogUtil.WriteLog("Send 页面  openid=" + obj.openid);

                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                //LogUtil.WriteLog(companyid, "Send 页面  returnStr：" + returnStr);
                //LogUtil.WriteLog(companyid, "Send 页面  openid：" + obj.openid);
                this.UserOpenId = obj.openid;

                //LogUtil.WriteLog(" ============ 结束 获取微信用户相关信息 =====================");
                SendPay();
                #endregion
            }
        }

        void SendPay()
        {

            //if (orderid <= 0)
            //{
            //    Response.Write("<script>alert('参数orderid=" + orderid + "错误');history.go(-1);</script>");
            //    return;
            //}
            //orderinfo = BLL.g_orderBLL.GetModel(orderid);
            //if (orderinfo == null || orderinfo.orderid != orderid)
            //{
            //    Response.Write("<script>alert('参数orderid错误');history.go(-1);</script>");
            //    return;
            //}
            //if (orderinfo.orderstatus != 0)
            //{
            //    Response.Write("<script>alert('当前订单已处理，不能重复支付');history.go(-1);</script>");
            //    return;
            //}


            string[] sta = State_Str.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            //LogUtil.WriteLog("Send 页面  State_Str：" + State_Str + ",coupon_id:" + sta[2]);
            if (sta.Length > 1)
            {
                //string _uid = sta[2];
                string _model = sta[2];//所属订单模块
                //if (_uid == null || !_uid.Equals(base.uid))
                //{
                //    Response.Write("<script>alert('参数uid错误');history.go(-1);</script>");
                //    return;
                //}
                if (_model == null || _model.Trim().Length == 0)
                {
                    Response.Write("<script>alert('参数model错误');history.go(-1);</script>");
                    return;
                }
                string Body = "手机充值支付";
                if (_model.Trim().ToLower().Equals("recharge_order"))
                {
                    Body = "手机充值支付";
                }
                //设置支付数据
                PayModel model = new PayModel();
                model.OrderSN = sta[0];
                model.TotalFee = Convert.ToInt32(Convert.ToDecimal(sta[1]) * 100);
                model.Body = Body;
                model.Attach = _model; //uid|model 不能有中文
                model.OpenId = this.UserOpenId;

                //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
                this.Response.Redirect(model.ToString());
            }
        }
    }
}