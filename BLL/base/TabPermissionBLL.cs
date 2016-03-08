using BS.Components.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TabPermissionBLL : CommonBLL<Model.TabPermissionInfo>
    {
        public static int Add(Model.TabPermissionInfo info)
        {
            return Insert(info, ReturnTypes.Identity);
        }
        /// <summary>
        /// 存在修改，不存在则添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int Save(Model.TabPermissionInfo info)
        {
            int result = 0;
            if (info.TabPermissionID > 0)
                result = Update(info);
            else
                result = Insert(info, ReturnTypes.Identity);
            return result;
        }

        public static DataTable GetAllTabPermission()
        {
            return GetTable("select * from TabPermission");
        }
    }
}
