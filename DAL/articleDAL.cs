using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;

using System.Data;
using BS.Components.Data.SQLProvider;

namespace DAL
{
    
    public class articleDAL
    {
        public int Add(articleInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into article(");
                strSql.Append("seo_description,zhaiyao,content,orderby,click,status,is_top,is_red,is_hot,channel_id,is_slide,userid,username,add_time,update_time,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,companyid");
                strSql.Append(") values (");
                strSql.Append("@seo_description,@zhaiyao,@content,@orderby,@click,@status,@is_top,@is_red,@is_hot,@channel_id,@is_slide,@userid,@username,@add_time,@update_time,@category_id,@call_index,@title,@link_url,@img_url,@seo_title,@seo_keywords,@companyid");
                strSql.Append(") ");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@content", SqlDbType.Text) ,            
	            	            new SqlParameter("@orderby", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@click", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@status", SqlDbType.TinyInt,1) ,                     
	            	            new SqlParameter("@is_top", SqlDbType.TinyInt,1) ,            
	            	            new SqlParameter("@is_red", SqlDbType.TinyInt,1) ,            
	            	            new SqlParameter("@is_hot", SqlDbType.TinyInt,1) ,            
	            	            new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@is_slide", SqlDbType.TinyInt,1) ,            
	            	            new SqlParameter("@userid", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@username", SqlDbType.NVarChar,100) ,            
	            	            new SqlParameter("@add_time", SqlDbType.DateTime) ,            
	            	            new SqlParameter("@update_time", SqlDbType.DateTime) ,            
	            	            new SqlParameter("@category_id", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@call_index", SqlDbType.NVarChar,50) ,            
	            	            new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
	            	            new SqlParameter("@link_url", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@img_url", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@seo_title", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                                new SqlParameter("@companyid", SqlDbType.Int,4) , 
	              
	            };

                parameters[0].Value = model.seo_description;
                parameters[1].Value = model.zhaiyao;
                parameters[2].Value = model.content;
                parameters[3].Value = model.orderby;
                parameters[4].Value = model.click;
                parameters[5].Value = model.status;
                parameters[6].Value = model.is_top;
                parameters[7].Value = model.is_red;
                parameters[8].Value = model.is_hot;
                parameters[9].Value = model.channel_id;
                parameters[10].Value = model.is_slide;
                parameters[11].Value = model.userid;
                parameters[12].Value = model.username;
                parameters[13].Value = model.add_time;
                parameters[14].Value = model.update_time;
                parameters[15].Value = model.category_id;
                parameters[16].Value = model.call_index;
                parameters[17].Value = model.title;
                parameters[18].Value = model.link_url;
                parameters[19].Value = model.img_url;
                parameters[20].Value = model.seo_title;
                parameters[21].Value = model.seo_keywords;
                parameters[22].Value = model.companyid;
                object obj = SqlDbHelper.ExecuteScalar(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
                if (obj == null)
                {
                    return 0;
                }
                else
                {

                    return Convert.ToInt32(obj);

                }

            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;
        }


        public int Update(articleInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update article set ");

                strSql.Append(" seo_description = @seo_description , ");
                strSql.Append(" zhaiyao = @zhaiyao , ");
                strSql.Append(" content = @content , ");
                strSql.Append(" orderby = @orderby , ");
                strSql.Append(" click = @click , ");
                strSql.Append(" status = @status , ");
                strSql.Append(" is_top = @is_top , ");
                strSql.Append(" is_red = @is_red , ");
                strSql.Append(" is_hot = @is_hot , ");
                strSql.Append(" is_slide = @is_slide , ");
                strSql.Append(" update_time = @update_time , ");
                strSql.Append(" category_id = @category_id , ");
                strSql.Append(" call_index = @call_index , ");
                strSql.Append(" title = @title , ");
                strSql.Append(" link_url = @link_url , ");
                strSql.Append((model.img_url != null && model.img_url.Trim().Length > 0 ? "[img_url]='" + model.img_url + "'," : ""));
                strSql.Append(" seo_title = @seo_title , ");
                strSql.Append(" seo_keywords = @seo_keywords,  ");
                strSql.Append(" companyid = @companyid  ");
                strSql.Append(" where id=@id ");

                SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@seo_description", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@content", SqlDbType.Text) ,	            
	            	            new SqlParameter("@orderby", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@click", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@status", SqlDbType.TinyInt,1) ,           
	            	            new SqlParameter("@is_top", SqlDbType.TinyInt,1) ,	            
	            	            new SqlParameter("@is_red", SqlDbType.TinyInt,1) ,	            
	            	            new SqlParameter("@is_hot", SqlDbType.TinyInt,1) ,	             
	            	            new SqlParameter("@is_slide", SqlDbType.TinyInt,1) ,	         
	            	            new SqlParameter("@update_time", SqlDbType.DateTime) ,	            
	            	            new SqlParameter("@category_id", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@call_index", SqlDbType.NVarChar,50) ,	            
	            	            new SqlParameter("@title", SqlDbType.NVarChar,100) ,	            
	            	            new SqlParameter("@link_url", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@seo_title", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
	                            new SqlParameter("@companyid", SqlDbType.Int,4) ,
	              
	            };

                parameters[0].Value = model.id;
                parameters[1].Value = model.seo_description;
                parameters[2].Value = model.zhaiyao;
                parameters[3].Value = model.content;
                parameters[4].Value = model.orderby;
                parameters[5].Value = model.click;
                parameters[6].Value = model.status;
                parameters[7].Value = model.is_top;
                parameters[8].Value = model.is_red;
                parameters[9].Value = model.is_hot;
                parameters[10].Value = model.is_slide;
                parameters[11].Value = DateTime.Now;
                parameters[12].Value = model.category_id;
                parameters[13].Value = model.call_index;
                parameters[14].Value = model.title;
                parameters[15].Value = model.link_url;
                parameters[16].Value = model.seo_title;
                parameters[17].Value = model.seo_keywords;
                parameters[18].Value = model.companyid;
                int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);

                return rows;
            }
            catch (Exception exc)
            { resultMsg = exc.Message; }
            return 0;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from article ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from article ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            int rows = SqlDbHelper.ExecuteNonQuery(Config.SqlConnection,strSql.ToString(), CommandType.Text);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<articleInfo> GetList(int Top, string strWhere, string filedOrder)
        {
            List<articleInfo> list = new List<articleInfo>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" * ");
                strSql.Append(" FROM article ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text))
                {
                    while (dr.Read())
                    {
                        articleInfo info = GetInfoByDr(dr);
                        list.Add(info);
                    }
                }
                return list;
            }
            catch { }
            return null;
        }

        public articleInfo GetModel(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *  ");
                strSql.Append("  from article ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
                parameters[0].Value = id;

                articleInfo info = new articleInfo();
                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters))
                {
                    if (dr.Read())
                    {
                        info = GetInfoByDr(dr);
                    }
                }
                return info;
            }
            catch { }
            return null;
        }

        private articleInfo GetInfoByDr(SqlDataReader dr)
        {
            articleInfo info = new articleInfo();
            info.id = int.Parse(dr["id"] != DBNull.Value ? dr["id"].ToString() : "");
            info.seo_description = dr["seo_description"] != DBNull.Value ? dr["seo_description"].ToString() : "";
            info.zhaiyao = dr["zhaiyao"] != DBNull.Value ? dr["zhaiyao"].ToString() : "";
            info.content = dr["content"] != DBNull.Value ? dr["content"].ToString() : "";
            info.orderby = int.Parse(dr["orderby"] != DBNull.Value ? dr["orderby"].ToString() : "");
            info.click = int.Parse(dr["click"] != DBNull.Value ? dr["click"].ToString() : "");
            info.status = int.Parse(dr["status"] != DBNull.Value ? dr["status"].ToString() : "0");
            info.is_top = int.Parse(dr["is_top"] != DBNull.Value ? dr["is_top"].ToString() : "0");
            info.is_red = int.Parse(dr["is_red"] != DBNull.Value ? dr["is_red"].ToString() : "0");
            info.is_hot = int.Parse(dr["is_hot"] != DBNull.Value ? dr["is_hot"].ToString() : "0");
            info.channel_id = int.Parse(dr["channel_id"] != DBNull.Value ? dr["channel_id"].ToString() : "");
            info.is_slide = int.Parse(dr["is_slide"] != DBNull.Value ? dr["is_slide"].ToString() : "");
            info.userid = int.Parse(dr["userid"] != DBNull.Value ? dr["userid"].ToString() : "");
            info.username = dr["username"] != DBNull.Value ? dr["username"].ToString() : "";
            info.add_time = DateTime.Parse(dr["add_time"] != DBNull.Value ? dr["add_time"].ToString() : "");
            info.update_time = DateTime.Parse(dr["update_time"] != DBNull.Value ? dr["update_time"].ToString() : "");
            info.category_id = int.Parse(dr["category_id"] != DBNull.Value ? dr["category_id"].ToString() : "");
            info.call_index = dr["call_index"] != DBNull.Value ? dr["call_index"].ToString() : "";
            info.title = dr["title"] != DBNull.Value ? dr["title"].ToString() : "";
            info.link_url = dr["link_url"] != DBNull.Value ? dr["link_url"].ToString() : "";
            info.img_url = dr["img_url"] != DBNull.Value ? dr["img_url"].ToString() : "";
            info.seo_title = dr["seo_title"] != DBNull.Value ? dr["seo_title"].ToString() : "";
            info.seo_keywords = dr["seo_keywords"] != DBNull.Value ? dr["seo_keywords"].ToString() : "";
            info.companyid = int.Parse(dr["companyid"] != DBNull.Value ? dr["companyid"].ToString() : "0");
            return info;

        }

        public DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            List<articleInfo> list = new List<articleInfo>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" O.*,T.title as category_title ");
                strSql.Append(" FROM article O LEFT JOIN article_category T T.id=O.category_id");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                if (filedOrder.Trim() != "")
                {
                    strSql.Append(" order by " + filedOrder);
                }
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection,strSql.ToString(), CommandType.Text);
                return dt;
            }
            catch { }
            return null;
        }
        public DataTable GetPagearticle(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            try
            {
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@WhereClause",SqlDbType.VarChar,2000),
                    new SqlParameter("@OrderBy",SqlDbType.VarChar,2000),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@TotalRows",SqlDbType.Int),
                };
                paras[0].Value = WhereClause;
                paras[1].Value = OrderBy;
                paras[2].Value = PageIndex;
                paras[3].Value = PageSize;
                paras[4].Direction = ParameterDirection.Output;
                DataTable dt = SqlDbHelper.ExecuteDataTable(Config.SqlConnection,"article_GetPagearticle", CommandType.StoredProcedure, paras);
                TotalRows = Convert.ToInt32(paras[4].Value != DBNull.Value ? paras[4].Value : 0);
                return dt;
            }
            catch { }
            return null;
        }
    }
}
