using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BS.Components.Data.SQLProvider;

namespace DAL
{
    public class AdDAL : CommonData<Model.AdInfo>
    {
        public DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" O.*,A.[width],A.[height],A.name as positionname ");
                strSql.Append(" FROM Ad O LEFT JOIN AdPosition A ON A.id=O.adpositionid");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection, strSql.ToString());
                return dt;
            }
            catch { }
            return null;
        }
    }
}
