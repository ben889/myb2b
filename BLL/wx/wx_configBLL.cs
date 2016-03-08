using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class wx_configBLL : CommonBLL<wx_configInfo>
    {
        public static int edit(wx_configInfo info,ref string resultMsg)
        {
            try
            {
                Delete("");
                return Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return 0;
        }

        public static wx_configInfo getInfo()
        {
            List<wx_configInfo> list = GetList(1, "", "");
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
    }
}
