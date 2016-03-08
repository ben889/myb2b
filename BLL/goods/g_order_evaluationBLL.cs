using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    /// <summary>
    /// 订单评价
    /// </summary>
    public class g_order_evaluationBLL : CommonBLL<g_order_evaluationInfo>
    {
        /// <summary>
        /// 给订单评价
        /// </summary>
        /// <param name="info"></param>
        /// <param name="imglist"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int add(g_order_evaluationInfo info, List<g_order_evaluation_imgsInfo> imglist, ref string resultMsg)
        {
            try
            {
                if (info.orderno == null || info.orderno.Trim().Length == 0)
                {
                    resultMsg = "orderno错误";
                    return 0;
                }
                if (info.goodsid <= 0)
                {
                    resultMsg = "goodsid错误";
                    return 0;
                }
                if (info.uid <= 0)
                {
                    resultMsg = "uid错误";
                    return 0;
                }
                g_orderInfo g_orderinfo = BLL.g_orderBLL.GetModel(info.orderno, "orderno", "*");
                if (g_orderinfo == null || !g_orderinfo.orderno.Equals(info.orderno))
                {
                    resultMsg = "不存在对应的订单信息";
                    return 0;
                }
                if (g_orderinfo.ordertype == 2)
                {
                    if (g_orderinfo.status != (int)Common.enum_orderstatus.payed)
                    {
                        resultMsg = "订单（" + info.orderno + "）未支付，不能评价";
                        return 0;
                    }
                }
                if (info.uid != g_orderinfo.uid)
                {
                    resultMsg = "你没有对订单（" + info.orderno + "）评价权限";
                    return 0;
                }
                if (info.score < 1 || info.score > 5)
                {
                    resultMsg = "score参数错误，请选择1-5分的评分";
                    return 0;
                }
                if (info.evalua < 0 || info.evalua > 4)
                {
                    resultMsg = "evalua参数错误，请选择0-4分的评价";
                    return 0;
                }
                if (info.evalua_id > 0)
                {
                    string msg = "";
                    delete(info.evalua_id, ref msg);
                }
                bool isexists = IsExist("uid=" + info.uid + " and orderno='" + info.orderno + "'");
                if (isexists)
                {
                    resultMsg = "您已评价过，不能重复评价";
                    return 0;
                }
                int result = Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
                if (result > 0)
                {

                    if (imglist != null && imglist.Count > 0)
                    {
                        try
                        {
                            foreach (g_order_evaluation_imgsInfo imginfo in imglist)
                            {

                                if (imginfo.img == null || imginfo.img.Trim().Equals(""))
                                    continue;
                                imginfo.evalua_id = result;
                                g_order_evaluation_imgsBLL.Insert(imginfo, BS.Components.Data.Entity.ReturnTypes.Identity);
                            }
                        }
                        catch { }
                    }
                    //g_orderinfo.has_evalua
                    int s = BLL.g_orderBLL.Update("g_order", "has_evalua=1", "orderno='" + info.orderno + "'");
                }
                return result;
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return 0;
        }
        /// <summary>
        /// 删除订单评价
        /// </summary>
        /// <param name="evalua_id"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int delete(int evalua_id, ref string resultMsg)
        {
            int result = 0;
            if (evalua_id <= 0)
            {
                resultMsg = "evalua_id 错误";
                return 0;
            }
            result = Delete(evalua_id, "evalua_id");
            if (result <= 0)
                return 0;
            List<g_order_evaluation_imgsInfo> imglist = g_order_evaluation_imgsBLL.GetList(-1, "evalua_id=" + evalua_id, "evaluaimg_id,img");
            if (imglist != null || imglist.Count > 0)
            {
                foreach (g_order_evaluation_imgsInfo info in imglist)
                {
                    if (info == null || info.evaluaimg_id <= 0)
                    {
                        //resultMsg = "不存在对应的评价图片信息";
                        continue;
                    }
                    int s_result = g_order_evaluation_imgsBLL.Delete(info.evaluaimg_id, "evaluaimg_id");
                    if (s_result > 0)
                    {
                        File.Delete(HttpContext.Current.Server.MapPath(info.img));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// O.*,M.displayname
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns>O.*,M.displayname</returns>
        public static DataTable getdt(int Top, string strWhere, string filedOrder)
        {
            return new g_order_evaluationDAL().getdt(Top, strWhere, filedOrder);
        }

    }
}
