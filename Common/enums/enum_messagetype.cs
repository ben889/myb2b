using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 短消息类型
    /// </summary>
    public enum enum_messagetype
    {
        /// <summary>
        /// 系统消息
        /// </summary>
        [Description("系统公告消息")]
        messagetype_sys = 0,
        ///// <summary>
        ///// 普通消息
        ///// </summary>
        //[Description("普通消息")]
        //messagetype_0 = 0,
        /// <summary>
        /// 维修申请回复
        /// </summary>
        //[Description("维修申请回复")]
        //messagetype_1 = 1,
        /// <summary>
        /// 投诉回复
        /// </summary>
        [Description("投诉回复")]
        messagetype_2 = 2,
        /// <summary>
        /// 返馈回复
        /// </summary>
        //[Description("返馈回复")]
        //feedback = 3,
    }
}
