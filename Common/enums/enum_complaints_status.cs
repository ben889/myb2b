using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    public enum enum_complaints_status
    {
        /// <summary>
        /// 作废
        /// </summary>
        [Description("作废")]
        suatus_2 = -2,
        /// <summary>
        /// 不能处理
        /// </summary>
        [Description("不能处理")]
        suatus_1 = -1,
        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        suatus0 = 0,
        /// <summary>
        /// 处理中
        /// </summary>
        [Description("处理中")]
        suatus1 = 1,
        /// <summary>
        ///  待处理
        /// </summary>
        [Description("待处理")]
        suatus2 = 2,
    }
}
