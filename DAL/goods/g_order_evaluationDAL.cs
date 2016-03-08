using BS.Components.Data.SQLProvider;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class g_order_evaluationDAL : CommonData<g_order_evaluationInfo>
    {
        /// <summary>
        /// O.*,M.displayname
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns>O.*,M.displayname</returns>
        public DataTable getdt(int Top, string strWhere, string filedOrder)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" O.*,M.displayname ");
                strSql.Append(" FROM g_order_evaluation O left join member M on M.uid=O.uid");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection, strSql.ToString(), CommandType.Text);
                return dt;
            }
            catch { }
            return null;
        }
    }
}
