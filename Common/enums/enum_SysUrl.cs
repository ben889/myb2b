using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 系统URL
    /// </summary>
    public enum enum_SysUrl
    {
        /// <summary>
        /// 微站首页
        /// </summary>
        [Description("微站首页")]
        m_index,
        /// <summary>
        /// 租赁中心
        /// </summary>
        [Description("租赁中心")]
        goods,
        /// <summary>
        /// 会员中心
        /// </summary>
        [Description("会员中心")]
        member,
        /// <summary>
        /// 分销商中心
        /// </summary>
        [Description("分销商中心")]
        sell_seller,
        /// <summary>
        /// 服务商中心
        /// </summary>
        [Description("服务商中心")]
        service_seller,
        /// <summary>
        /// 微相册
        /// </summary>
        [Description("微相册")]
        album,
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        product,
        
        map,
        /// <summary>
        /// 大转盘
        /// </summary>
        [Description("大转盘")]
        dzp,
        /// <summary>
        /// 一键拨号
        /// </summary>
        [Description("一键拨号")]
        tel,
        
    }
}
