using BS.Components.Data.Entity;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class goodsExchBLL : CommonBLL<goodsExchInfo>
    {
        /// <summary>
        /// 用户兑换
        /// </summary>
        /// <param name="ExchId"></param>
        /// <param name="sellerid">当前商家</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int exch(int ExchId, int sellerid, ref string resultMsg)
        {
            try
            {
                if (ExchId <= 0)
                {
                    resultMsg = "兑换ID错误";
                    return 0;
                }
                if (sellerid <= 0)
                {
                    resultMsg = "商家ID错误";
                    return 0;
                }

                DateTime now = DateTime.Now;
                goodsExchInfo info = GetModel(ExchId);
                if (info == null || info.ExchId != ExchId)
                {
                    resultMsg = "不存在对应的兑换信息";
                    return 0;
                }
                g_orderInfo g_orderinfo = BLL.g_orderBLL.GetModel(info.orderid);
                if (g_orderinfo == null || g_orderinfo.orderid != info.orderid)
                {
                    resultMsg = "不存在对应的订单信息";
                    return 0;
                }
                goodsInfo goodsinfo = BLL.goodsBLL.GetModel(info.goodsid);
                if (goodsinfo == null || goodsinfo.GoodsId != info.goodsid)
                {
                    resultMsg = "不存在对应的商品信息";
                    return 0;
                }
                if (goodsinfo.sellerid != sellerid)
                {
                    resultMsg = "此兑换单不属于当前商家";
                    return 0;
                }
                if (now > goodsinfo.EndDate)
                {
                    resultMsg = "此活动已到期";
                    return 0;
                }

                //info.status = 1;
                //info.ExchName = "";
                //info.ExchTel = "";
                //info.ExchZipCode = "";
                //info.ExchAddress = "";
                //return Update(info);
                int result = new goodsExchDAL().exch(ExchId, info.goodsid, ref resultMsg);
               
                return result;
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns>O.*,D.orderno,D.goods_count,G.GoodsName,G.Img,G.Description</returns>
        public static DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            return new DAL.goodsExchDAL().GetDt(Top, strWhere, filedOrder);
        }
        public static int getcount(string where)
        {
            return new DAL.goodsExchDAL().getcount(where);
        }

        public static string getstatus_str(object objstatus)
        {
            if (objstatus == null)
                return "";
            if (objstatus.ToString().Trim().Equals("1"))
            {
                return "<span style=\"color:green;\">已使用</span>";
            }
            else if (objstatus.ToString().Trim().Equals("0"))
            {
                return "<span style=\"color:#f60;\">未使用</span>";
            }
            else if (objstatus.ToString().Trim().Equals("-1"))
            {
                return "<span style=\"color:red;\">作废</span>";
            }
            return "";
        }

        public static int add(goodsExchInfo info)
        {
            return Insert(info, ReturnTypes.Identity);
        }
    }
}
