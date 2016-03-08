using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 要支付的模块
    /// </summary>
    public enum enum_paymodel
    {
        /// <summary>
        /// 体验馆支付
        /// </summary>
        [Description("体验馆")]
        goods,
        /// <summary>
        /// 商城支付
        /// </summary>
        [Description("商城")]
        mall,
    }
}
