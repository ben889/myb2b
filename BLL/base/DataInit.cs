using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class DataInit
    {
        public DataInit()
        {
            TabsBLL.updateSystem_updatetabs();
            RolesBLL.init();
            UsersBLL.InitUsers(null);

            TabsBLL.updateSystem_updatetabs();
            //初始化广告位
            AdPositionBLL.init();
            //商品分类初始化
            //ProductTypeBLL.init();
            memberBLL.init();
        }
    }
}
