using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeiPay;

namespace WebSite.mobile.weixinpay
{
    /**
     * 
     * 作用：支付完成以后通知页面，该页面实现数据库的更新操作，比如更新订单状态等等
     * 作者：
     * 编写日期：2014-12-25
     * 备注：请注意更新代码的填写位置
     * 
     * */
    public partial class notify : m_basepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wx_configInfo cinfo = BLL.wx_configBLL.getInfo();
            if (cinfo == null)
            {
                Response.Write("<script>alert('微信参数未设置');history.go(-1);</script>");
                return;
            }

            //创建ResponseHandler实例
            ResponseHandler resHandler = new ResponseHandler(Context);
            //resHandler.setKey(PayConfig.AppKey);
            resHandler.setKey(cinfo.AppKey);

            //判断签名
            try
            {
                string error = "";
                if (resHandler.isWXsign(out error))
                {
                    #region 协议参数=====================================
                    //--------------协议参数--------------------------------------------------------
                    //SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查
                    string return_code = resHandler.getParameter("return_code");
                    //返回信息，如非空，为错误原因签名失败参数格式校验错误
                    string return_msg = resHandler.getParameter("return_msg");
                    //微信分配的公众账号 ID
                    string appid = resHandler.getParameter("appid");

                    //以下字段在 return_code 为 SUCCESS 的时候有返回--------------------------------
                    //微信支付分配的商户号
                    string mch_id = resHandler.getParameter("mch_id");
                    //微信支付分配的终端设备号
                    string device_info = resHandler.getParameter("device_info");
                    //微信分配的公众账号 ID
                    string nonce_str = resHandler.getParameter("nonce_str");
                    //业务结果 SUCCESS/FAIL
                    string result_code = resHandler.getParameter("result_code");
                    //错误代码 
                    string err_code = resHandler.getParameter("err_code");
                    //结果信息描述
                    string err_code_des = resHandler.getParameter("err_code_des");

                    //以下字段在 return_code 和 result_code 都为 SUCCESS 的时候有返回---------------
                    //-------------业务参数---------------------------------------------------------
                    //用户在商户 appid 下的唯一标识
                    string openid = resHandler.getParameter("openid");
                    //用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
                    string is_subscribe = resHandler.getParameter("is_subscribe");
                    //JSAPI、NATIVE、MICROPAY、APP
                    string trade_type = resHandler.getParameter("trade_type");
                    //银行类型，采用字符串类型的银行标识
                    string bank_type = resHandler.getParameter("bank_type");
                    //订单总金额，单位为分
                    string total_fee = resHandler.getParameter("total_fee");
                    //货币类型，符合 ISO 4217 标准的三位字母代码，默认人民币：CNY
                    string fee_type = resHandler.getParameter("fee_type");
                    //微信支付订单号
                    string transaction_id = resHandler.getParameter("transaction_id");
                    //商户系统的订单号，与请求一致。
                    string out_trade_no = resHandler.getParameter("out_trade_no");
                    //商家数据包，原样返回
                    string attach = resHandler.getParameter("attach");//_uid + "|" + _model
                    //支 付 完 成 时 间 ， 格 式 为yyyyMMddhhmmss，如 2009 年12 月27日 9点 10分 10 秒表示为 20091227091010。时区为 GMT+8 beijing。该时间取自微信支付服务器
                    string time_end = resHandler.getParameter("time_end");

                    #endregion


                    //string[] arrattach = attach.Split('|');
                    //string uid = arrattach[0];
                    string model = attach;

                    //LogUtil.WriteLog(companyid, "OrderId=" + out_trade_no + " attach=" + attach + " return_code=" + return_code);
                    //支付成功
                    if (!out_trade_no.Equals("") && return_code.Equals("SUCCESS") && result_code.Equals("SUCCESS"))
                    {
                        try
                        {

                            /**
                             *  这里输入用户逻辑操作，比如更新订单的支付状态
                             * 
                             * **/
                            if (model.Equals("member_join_order"))
                            {
                                decimal total_fee_money = decimal.Parse(total_fee);
                                string resultMsg = "";
                                BLL.member_join_orderBLL.order_payresult(out_trade_no, 1, 1, transaction_id, total_fee_money, ref resultMsg);
                            }

                            //LogUtil.WriteLog("============ 单次支付结束 ===============out_trade_no=" + out_trade_no + "&transaction_id=" + transaction_id);
                            Response.Write("success");

                            //LogUtil.WriteLog("Notify 页面  支付成功，支付信息：商家订单号：" + out_trade_no + "、支付金额(分)：" + total_fee + "、自定义参数：" + attach);
                            return;
                        }
                        catch (Exception exc)
                        {
                            LogUtil.WriteLog("Notify 页面 异常信息：" + exc.Message + "  微信返回支付成功，支付信息：商家订单号：" + out_trade_no + "、支付金额(分)：" + total_fee + "、自定义参数：" + attach + " ");
                        }

                    }
                    else
                    {
                        if (model.Equals("member_join_order"))
                        {
                            string resultMsg = "";
                            decimal total_fee_money = decimal.Parse(total_fee);
                            int result = BLL.member_join_orderBLL.order_payresult(out_trade_no, 1, -2, transaction_id, total_fee_money, ref resultMsg);
                            if (result > 0)
                                LogUtil.WriteLog("微信支付失败更新数据库结果失败：resultMsg=" + resultMsg);
                        }
                        LogUtil.WriteLog("Notify 页面  支付失败，支付信息   total_fee= " + total_fee + "、err_code_des=" + err_code_des + "、result_code=" + result_code);
                    }
                }
                else
                {
                    LogUtil.WriteLog("Notify 页面  isWXsign= false ，错误信息：" + error);
                }


            }
            catch (Exception ee)
            {
                LogUtil.WriteLog("Notify 页面  发送异常错误：" + ee.Message);
            }

            Response.End();
        }
    }
}