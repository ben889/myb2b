using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Common
{
    public enum enum_userpermission
    {
        [Description("查看")]
        VIEW,
        [Description("添加")]
        ADD,
        [Description("修改")]
        UPDATE,
        [Description("删除")]
        DELETE,
    }
}
