using BS.Components.Data.Entity;
using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class g_orderBLL : CommonBLL<g_orderInfo>
    {
        object locker = new object();

        public int add(g_orderInfo info, ref string resultMsg)
        {
            lock (locker)
            {
                //if (info.siteid.Trim().Length == 0)
                //{
                //    resultMsg = "siteid错误！";
                //    return 0;
                //}
                //if (info.sellerid == null || info.sellerid <= 0)
                //{
                //    resultMsg = "无效的商家ID";
                //    return 0;
                //}
                //Model.goodsInfo gi = BLL.goodsBLL.GetModel(info.goodsid, "GoodsId", "");
                //if (info.totalprice != (gi.Price * info.goods_count)) 
                //{
                //    resultMsg = "请核实付款金额";
                //    return 0;
                //}

                if (info.goodsid <= 0)
                {
                    resultMsg = "未选择任何商品";
                    return 0;
                }
                if (info.goods_count <= 0)
                {
                    resultMsg = "商品数量不能小于1";
                    return 0;
                }

                //======================验证帐号
                if (info.uid <= 0)
                {
                    resultMsg = "请登录后提交";
                    return 0;
                }

                memberInfo memberinfo = memberBLL.getModel(info.uid);
                if (memberinfo == null || memberinfo.uid != info.uid)
                {
                    resultMsg = "无效的帐号信息";
                    return 0;
                }
                //==========================


                goodsInfo goodsinfo = BLL.goodsBLL.GetModel(info.goodsid);
                if (goodsinfo == null || goodsinfo.GoodsId != info.goodsid)
                {
                    resultMsg = "无效的商品信息";
                    return 0;
                }
                info.sellerid = goodsinfo.sellerid;

                if (info.ordertype != goodsinfo.GoodsType)
                {
                    resultMsg = "订单类型和商品类型不匹配";
                    return 0;
                }
                //info.ordertype = goodsinfo.GoodsType;
                int old_user_count = getcount(info.uid, info.goodsid);

                if (goodsinfo.Purchase > 0)
                {
                    if (goodsinfo.Purchase < (info.goods_count + old_user_count))
                    {
                        if ((goodsinfo.Purchase - old_user_count) == 0)
                            resultMsg = "每人只能限购" + goodsinfo.Purchase + "份，你已经购买" + old_user_count + "份！";
                        else
                            resultMsg = "每人只能限购" + goodsinfo.Purchase + "份，你已经购买" + old_user_count + "份！只能再购买" + (goodsinfo.Purchase - old_user_count) + "份！";
                        return 0;
                    }


                    //if (old_count >= info.goods_count)
                    //{
                    //    resultMsg = "每人只能限购" + goodsinfo.Purchase + "份，你已经购买" + old_count + "份！";
                    //    return 0;
                    //}
                }
                int old_count = getcount("goodsid=" + info.goodsid);
                if (goodsinfo.TotalCount > 0)
                {
                    if (goodsinfo.TotalCount < (info.goods_count + old_count))
                    {
                        resultMsg = "您下手慢啦，只剩下" + (goodsinfo.TotalCount - old_count) + "份！";
                        return 0;
                    }
                }

                DateTime now = DateTime.Now;
                if (goodsinfo.StartDate > now)
                {
                    resultMsg = "未到抢购时间";
                    return 0;
                }

                info.createtime = now;
                //if (goodsinfo.GoodsType != (int)enum_goodstype.goodstype_1)
                //{
                //    resultMsg = "当前商品不是抵用券，不能下此订单";
                //    return 0;
                //}
                //return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
                info.orderno = DateTime.Now.ToString("yyyyMMddHHmmss") + Randomcode.CreateRandomNum(4);
                if (info.goods_count <= 0)
                {
                    resultMsg = "商品数量必须大于1";
                    return 0;
                }
                decimal totalprice = goodsinfo.Price * info.goods_count;
                if (totalprice != info.totalprice)
                {
                    resultMsg = "订单总金额错误！";
                    return 0;
                }
                List<goodsExchInfo> goodsexch_list = new List<goodsExchInfo>();
                //if (info.ordertype == (int)enum_goodstype.goodstype_1)
                //{
                for (int i = 0; i < info.goods_count; i++)
                {
                    goodsExchInfo goodsExchinfo = new goodsExchInfo();
                    goodsExchinfo.sellerid = info.sellerid;
                    goodsExchinfo.createTime = now;
                    goodsExchinfo.goodsid = info.goodsid;
                    goodsExchinfo.status = 0;
                    goodsExchinfo.Sequence = DateTime.Now.ToString("HHmmss") + Randomcode.CreateRandomNum(6, i);
                    goodsexch_list.Add(goodsExchinfo);
                }
                //}

                return new g_orderDAL().add(info, goodsexch_list, ref resultMsg);
            }
        }

        /// <summary>
        /// 查用户已购的数量
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public static int getcount(long uid, int goodsid)
        {
            return new g_orderDAL().getcount(uid, goodsid);
        }
        public static int getcount(string where)
        {
            return new g_orderDAL().getcount(where);
        }

        /// <summary>
        /// 0为未付 -1作废 -2支付失败 1已付 
        /// </summary>
        /// <param name="objorderstatus">0为未付 -1作废 -2支付失败 1已付 </param>
        /// <returns></returns>
        public static string getorderstatus_str(object objorderstatus)
        {
            if (objorderstatus == null || objorderstatus == DBNull.Value || objorderstatus.ToString().Trim().Length == 0)
                return "";
            if (objorderstatus.ToString().Trim().Equals("0"))
                return "未付";
            else if (objorderstatus.ToString().Trim().Equals("1"))
                return "<span style=\"color:green;\">已付</span>";
            else if (objorderstatus.ToString().Trim().Equals("-1"))
                return "<span style=\"color:red;\">作废</span>";
            else if (objorderstatus.ToString().Trim().Equals("-2"))
                return "<span style=\"color:#f60;\">支付失败</span>";
            return "";
        }
        #region 支付结果
        public static int pay_result(string orderno, int payment, int status, string transaction_id, decimal pay_money, ref string resultMsg)
        {
            try
            {
                if (orderno == null || orderno.Trim().Length == 0)
                {
                    resultMsg = "订单编号错误orderno=" + orderno;
                    return -1;
                }

                g_orderInfo info = GetModel(orderno, "orderno", "*");
                if (info == null || !info.orderno.Equals(orderno))
                {
                    resultMsg = "不存在对应的订单";
                    return -1;
                }
                if (info.status == (int)Common.enum_orderstatus.payed)
                {
                    resultMsg = "当前订单" + orderno + "已支付，不能重复处理";
                    return -1;
                }

                string excep_remark = "";
                bool isExcep = false;
                //if (status == 1)
                //    excep_remark = "体验馆商品支付成功";
                if (info.pay_price != pay_money)
                {
                    isExcep = true;
                    excep_remark = "支付成功后返回的订单金额(" + pay_money + ")和数据库订单实际支付金额(" + info.pay_price + ")不相同";
                }

                int result = Update("g_order", "payment=" + payment + ",status=" + status + ",transaction_id='" + transaction_id + "',isExcep='" + isExcep + "',excep_remark='" + excep_remark + "'"
                                  , "orderno='" + orderno + "'");
                if (result > 0 && status == 1)
                { //如果支付成功，减掉库存
                    //payed_update_inventory(info.orderid);
                }
                return result;
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return -1;
        }
        #endregion


    }
}
