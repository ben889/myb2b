using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 订单状态 0为未付 -1作废 -2支付失败 1已付
    /// </summary>
    public enum enum_orderstatus
    {
        /// <summary>
        /// 支付失败
        /// </summary>
        [Description("支付失败")]
        payfail = -2,
        /// <summary>
        /// 作废
        /// </summary>
        [Description("作废")]
        redlined = -1,
        /// <summary>
        /// 未付
        /// </summary>
        [Description("未付")]
        unpaid = 0,
        /// <summary>
        /// 已付
        /// </summary>
        [Description("已付")]
        payed = 1,
    }
}
