using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    public enum enumUserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        host = 0,
        /// <summary>
        /// 系统管理员
        /// </summary>
        [Description("系统管理员")]
        admin = 1,
        /// <summary>
        /// 代理商管理员
        /// </summary>
        [Description("代理商管理员")]
        company = 2,
        /// <summary>
        /// 普通管理员
        /// </summary>
        [Description("普通管理员")]
        person = 3,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("站点管理员")]
        site = 4,
    }
}
