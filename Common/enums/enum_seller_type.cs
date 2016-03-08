using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 商家类型
    /// </summary>
    public enum enum_seller_type
    {
        /// <summary>
        /// 区域商家
        /// </summary>
        [Description("区域商家")]
        seller_type_area = 0,
        /// <summary>
        /// 公共商家
        /// </summary>
        [Description("公共商家")]
        seller_type_public = 1,
    }
}
