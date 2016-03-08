using BS.Components.Data.SQLProvider;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class goodsDAL : CommonData<goodsInfo>
    {
        public DataTable GetPager(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows, string lng, string lat)
        {
            try
            {
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@WhereClause",SqlDbType.VarChar,2000),
                    new SqlParameter("@OrderBy",SqlDbType.VarChar,2000),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@lng",SqlDbType.VarChar,32),
                    new SqlParameter("@lat",SqlDbType.VarChar,32),
                    new SqlParameter("@TotalRows",SqlDbType.Int),
                };
                paras[0].Value = WhereClause;
                paras[1].Value = OrderBy;
                paras[2].Value = PageIndex;
                paras[3].Value = PageSize;
                paras[4].Value = lng;
                paras[5].Value = lat;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection, "goods_GetPagegoods", CommandType.StoredProcedure, paras);
                TotalRows = Convert.ToInt32(paras[6].Value != DBNull.Value ? paras[6].Value : 0);
                return dt;
            }
            catch { }
            return null;
        }
    }
}
