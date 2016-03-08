using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BS.Components.Data.Entity;
using System.Data;
using Model;

namespace BLL
{
    public class AdPositionBLL : CommonBLL<Model.AdPositionInfo>
    {
        public static void init()
        {
            //初始化广告位
            AdPositionInfo adinfo = new AdPositionInfo() { name = "首页幻灯片", width = 480, height = 160, filetype = "", call_index = "index_hdp" };
            AdPositionBLL.Add(adinfo);
            adinfo = new AdPositionInfo() { name = "首页内容栏1张", width = 180, height = 180, filetype = "", call_index = "index_ad1" };
            AdPositionBLL.Add(adinfo);
            adinfo = new AdPositionInfo() { name = "首页内容栏2张", width = 180, height = 90, filetype = "", call_index = "index_ad2" };
            AdPositionBLL.Add(adinfo);
            //==========================商城
            //adinfo = new AdPositionInfo() { name = "商城首页幻灯片", width = 480, height = 160, filetype = "", call_index = "mall_hdp" };
            //AdPositionBLL.Add(adinfo);
            //==========================
        }
        public static int Add(Model.AdPositionInfo info)
        {
            if (info.call_index.Trim().Length > 0)
            {
                List<AdPositionInfo> list = GetList(1, "call_index='" + info.call_index + "'", "");
                if (list != null && list.Count > 0)
                {
                    return 0;
                }
            }
            return Insert(info, ReturnTypes.Identity);
        }
        //public static int Add(Model.AdPositionInfo info)
        //{
        //    return Insert(info, ReturnTypes.Identity);
        //}

        public static DataTable GetDataTable()
        {
            return GetTable("select * from AdPosition");
        }
    }
}
