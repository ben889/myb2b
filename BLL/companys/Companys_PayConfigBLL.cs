using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Companys_PayConfigBLL : CommonBLL<Companys_PayConfigInfo>
    {
        public static int edit(Companys_PayConfigInfo info, ref string resultmsg)
        {
            if (info == null)
            {
                resultmsg = "参数错误";
                return -1;
            }
            if (info.CompanyId == null || info.CompanyId.Trim().Length == 0)
            {
                resultmsg = "参数CompanyId错误";
                return -1;
            }
            Companys_PayConfigInfo model = GetModel(info.CompanyId);
            if (model != null && model.CompanyId.Equals(info.CompanyId))
            {
                return Update(info);
            }
            //Delete(info.CompanyId, "CompanyId");
            return Insert(info, BS.Components.Data.Entity.ReturnTypes.EffectRow);
        }
    }
}
