using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    public enum enum_goodstype
    {
        /// <summary>
        /// 体验券
        /// </summary>
        [Description("体验券")]
        goodstype_1 = 1,
        /// <summary>
        /// 付费商品
        /// </summary>
        [Description("付费商品")]
        goodstype_2 = 2,
    }
}
