using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    /// <summary>
    /// 红包订单
    /// </summary>
    public class member_join_orderBLL : CommonBLL<member_join_orderInfo>
    {
        protected static string LOG_TAG = "红包支付_";
        private static object asyncLock = new object();

        public static int createorder(string companyid, string mobile, decimal Amount, int payment, long recharge_uid, string remark
            , ref string orderid, ref string resultMsg)
        {
            lock (asyncLock)
            {
                if (companyid.Trim().Length <= 0)
                {
                    resultMsg = "companyid 错误";
                    return 0;
                }

                if (mobile.Trim().Length <= 0)
                {
                    resultMsg = "手机号不能为空";
                    return 0;
                }
                if (!Common.RegexHelper.IsMobile(mobile))
                {
                    resultMsg = "手机号不正确";
                    return 0;
                }
                member_join_orderInfo orderinfo = new member_join_orderInfo();
                orderid = orderinfo.OrderId = DateTime.Now.ToString("yyyyMMddHHmmss") + Randomcode.CreateRandomNum(6);
                orderinfo.companyid = companyid;
                orderinfo.orderstatus = 0;
                orderinfo.CreateTime = DateTime.Now;
                orderinfo.Amount = Amount;
                orderinfo.Mobile = mobile;
                orderinfo.payment = payment;
                orderinfo.recharge_uid = recharge_uid;
                orderinfo.remark = remark;
                //orderinfo.type = type;
                //orderinfo.Recharge_amount = Recharge_amount;
                return Insert(orderinfo, BS.Components.Data.Entity.ReturnTypes.EffectRow);
            }
        }

        public static int delete(int orderid, ref string resultMsg)
        {
            if (orderid <= 0)
            {
                resultMsg = "订单id错误";
                return 0;
            }
            member_join_orderInfo info = GetModel(orderid);
            if (info == null || !info.OrderId.Equals(orderid))
            {
                resultMsg = "无对应的订单信息";
                return 0;
            }
            if (info.orderstatus == 1)
            {
                resultMsg = "订单已支付，不能删除";
                return 0;
            }
            int result = Delete(orderid, "OrderId");
            return result;
        }

        /// <summary>
        /// 订单状态 0为未付 -1作废 1已付 -2支付失败
        /// </summary>
        /// <param name="objstatus"></param>
        /// <returns></returns>
        public static string get_statusstr(object objstatus)
        {
            if (objstatus == null || objstatus == DBNull.Value)
                return "";
            string s = objstatus.ToString();
            switch (s)
            {
                case "-2":
                    return "<span style=\"color:red;\">支付失败</span>";
                case "-1":
                    return "<span style=\"color:red;\">作废</span>";
                case "0":
                    return "<span style=\"color:#f60;\">未付</span>";
                case "1":
                    return "<span style=\"color:green;\">已付</span>";
            }
            return "";
        }

        public static string get_typestr(object objtype)
        {
            if (objtype == null || objtype == DBNull.Value || objtype.ToString().Trim().Length == 0)
                return "";
            if (objtype.ToString().Trim().Equals("1"))
                return "充流量";
            else if (objtype.ToString().Trim().Equals("2"))
                return "充话费";
            return "";
        }
        #region 支付
        /// <summary>
        /// 支付结果
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="payment">支付方式1微信支付2支付宝</param>
        /// <param name="status">0为未付 -1作废 1已付 -2支付失败</param>
        /// <param name="transaction_id"></param>
        /// <param name="pay_money"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int order_payresult(string orderid, int payment, int status, string transaction_id, decimal pay_money, ref string resultMsg)
        {
            lock (asyncLock)
            {
                try
                {
                    if (orderid == null || orderid.Trim().Length == 0)
                    {
                        resultMsg = "订单编号错误orderid=" + orderid;
                        return -1;
                    }

                    member_join_orderInfo info = GetModel(orderid);
                    if (info == null || !info.OrderId.Equals(orderid))
                    {
                        resultMsg = "不存在对应的订单";
                        return -1;
                    }

                    if (info.orderstatus != 0 && info.orderstatus != -2)
                    {
                        resultMsg = "当前订单" + orderid + "已处理，不能重复处理";
                        return -1;
                    }
                    lock (asyncLock)
                    {
                        bool isExce = false;
                        string Exce_remark = "";
                        if (status == 1)
                            Exce_remark = "充值成功";
                        if (info.Amount != pay_money)
                        {
                            isExce = true;
                            Exce_remark = "订单金额(" + pay_money + ")和数据库订单金额(" + info.Amount + ")不相同";
                        }
                        int vip = (int)BLL.member.enum_member_vip.普通会员;
                        if (status == (int)Common.enum_orderstatus.payed)
                            vip = (int)BLL.member.enum_member_vip.付费会员;
                        int result = new member_join_orderDAL().order_payresult(info.OrderId, payment, status, info.Amount, transaction_id, isExce, Exce_remark, vip, ref resultMsg);
                        //Common.LogUtil.WriteLog("", LOG_TAG, "OrderId=" + info.OrderId + " status=" + status + " result=" + result + " resultMsg=" + resultMsg);
                        if (result > 0 && status == 1)
                        {
                            if (info.Amount != pay_money)
                            {
                                resultMsg = "支付成功后返回的订单金额(" + pay_money + ")和数据库订单金额(" + info.Amount + ")不相同";
                                return result;
                            }
                            string msg = "";

                            string remark = "会员订单(" + orderid + ")红包支付返回提成";
                            try
                            {
                                memberInfo memberinfo = memberBLL.GetModel(info.recharge_uid);
                                if (memberinfo != null && memberinfo.uid == info.recharge_uid)
                                {
                                    remark = "会员(" + memberinfo.uname + " " + memberinfo.displayname + ")订单(" + orderid + ")红包支付返回提成";
                                }
                            }
                            catch { }

                            int sell_cash_result = memberBLL.give_cash_to_parent(info.recharge_uid, info.Amount, remark, ref msg);

                        }
                        return result;
                    }
                }
                catch (Exception exc)
                {
                    resultMsg = exc.Message;
                    Common.LogUtil.WriteLog("", LOG_TAG, exc.Message);
                }
                return -1;
            }

        }

        public static string getpayment(object objpayment)
        {
            if (objpayment == null || objpayment == DBNull.Value || objpayment.ToString().Trim().Length == 0)
                return "";
            if (objpayment.ToString().Trim().Equals("1"))
                return "微支付";
            else if (objpayment.ToString().Trim().Equals("2"))
                return "支付宝";
            return "";
        }
        #endregion
    }
}
