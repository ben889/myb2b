using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BLL.member
{
    public enum enum_member_vip
    {
        /// <summary>
        /// 普通会员
        /// </summary>
        [Description("普通会员")]
        普通会员 = 0,
        /// <summary>
        /// 付费会员
        /// </summary>
        [Description("付费会员")]
        付费会员 = 1,
    }
}
