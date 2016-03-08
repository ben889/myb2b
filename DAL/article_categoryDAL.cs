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
    public class article_categoryDAL
    {


        public int Add(article_categoryInfo model, ref string resultMsg)
        {

          
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into article_category(");
                strSql.Append("img,content,seo_title,seo_keywords,seo_description,channel_id,title,call_index,parentid,orderby,link_url,companyid");
                strSql.Append(") values (");
                strSql.Append("@img,@content,@seo_title,@seo_keywords,@seo_description,@channel_id,@title,@call_index,@parentid,@orderby,@link_url,@companyid");
                strSql.Append(") ");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					            new SqlParameter("@img", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@content", SqlDbType.Text) ,            
	            	            new SqlParameter("@seo_title", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@seo_description", SqlDbType.NVarChar,255) ,            
	            	            new SqlParameter("@channel_id", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
	            	            new SqlParameter("@call_index", SqlDbType.NVarChar,50) ,            
	            	            new SqlParameter("@parentid", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@orderby", SqlDbType.Int,4) ,            
	            	            new SqlParameter("@link_url", SqlDbType.NVarChar,255) ,            
	                            new SqlParameter("@companyid", SqlDbType.Int,4) ,
	            };

                parameters[0].Value = model.img;
                parameters[1].Value = model.content;
                parameters[2].Value = model.seo_title;
                parameters[3].Value = model.seo_keywords;
                parameters[4].Value = model.seo_description;
                parameters[5].Value = model.channel_id;
                parameters[6].Value = model.title;
                parameters[7].Value = model.call_index;
                parameters[8].Value = model.parentid;
                parameters[9].Value = model.orderby;
                parameters[10].Value = model.link_url;
                parameters[11].Value = model.companyid;
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


        public int Update(article_categoryInfo model, ref string resultMsg)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update article_category set ");

                strSql.Append(" img = @img , ");
                strSql.Append(" content = @content , ");
                strSql.Append(" seo_title = @seo_title , ");
                strSql.Append(" seo_keywords = @seo_keywords , ");
                strSql.Append(" seo_description = @seo_description , ");
                strSql.Append(" channel_id = @channel_id , ");
                strSql.Append(" title = @title , ");
                strSql.Append(" call_index = @call_index , ");
                strSql.Append(" parentid = @parentid , ");
                strSql.Append(" orderby = @orderby , ");
                strSql.Append(" link_url = @link_url,  ");
                    strSql.Append(" companyid = @companyid  ");
                strSql.Append(" where id=@id ");

                SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@img", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@content", SqlDbType.Text) ,	            
	            	            new SqlParameter("@seo_title", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@seo_description", SqlDbType.NVarChar,255) ,	            
	            	            new SqlParameter("@channel_id", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@title", SqlDbType.NVarChar,100) ,	            
	            	            new SqlParameter("@call_index", SqlDbType.NVarChar,50) ,	            
	            	            new SqlParameter("@parentid", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@orderby", SqlDbType.Int,4) ,	            
	            	            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                                new SqlParameter("@companyid", SqlDbType.Int,4) ,	
	            };

                parameters[0].Value = model.id;
                parameters[1].Value = model.img;
                parameters[2].Value = model.content;
                parameters[3].Value = model.seo_title;
                parameters[4].Value = model.seo_keywords;
                parameters[5].Value = model.seo_description;
                parameters[6].Value = model.channel_id;
                parameters[7].Value = model.title;
                parameters[8].Value = model.call_index;
                parameters[9].Value = model.parentid;
                parameters[10].Value = model.orderby;
                parameters[11].Value = model.link_url;
                parameters[12].Value = model.companyid;
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
            strSql.Append("delete from article_category ");
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
            strSql.Append("delete from article_category ");
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

        public List<article_categoryInfo> GetList(int Top, string strWhere, string filedOrder)
        {
            List<article_categoryInfo> list = new List<article_categoryInfo>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" * ");
                strSql.Append(" FROM article_category ");
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
                        article_categoryInfo info = GetInfoByDr(dr);
                        list.Add(info);
                    }
                }
                return list;
            }
            catch { }
            return null;
        }

        public article_categoryInfo GetModel(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * ");
                strSql.Append("  from article_category ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                article_categoryInfo info = new article_categoryInfo();
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

        private article_categoryInfo GetInfoByDr(SqlDataReader dr)
        {
            article_categoryInfo info = new article_categoryInfo();
            info.id = int.Parse(dr["id"] != DBNull.Value ? dr["id"].ToString() : "0");
            info.img = dr["img"] != DBNull.Value ? dr["img"].ToString() : "";
            info.content = dr["content"] != DBNull.Value ? dr["content"].ToString() : "";
            info.seo_title = dr["seo_title"] != DBNull.Value ? dr["seo_title"].ToString() : "";
            info.seo_keywords = dr["seo_keywords"] != DBNull.Value ? dr["seo_keywords"].ToString() : "";
            info.seo_description = dr["seo_description"] != DBNull.Value ? dr["seo_description"].ToString() : "";
            info.channel_id = int.Parse(dr["channel_id"] != DBNull.Value ? dr["channel_id"].ToString() : "0");
            info.title = dr["title"] != DBNull.Value ? dr["title"].ToString() : "";
            info.call_index = dr["call_index"] != DBNull.Value ? dr["call_index"].ToString() : "";
            info.parentid = int.Parse(dr["parentid"] != DBNull.Value ? dr["parentid"].ToString() : "");
            info.orderby = int.Parse(dr["orderby"] != DBNull.Value ? dr["orderby"].ToString() : "0");
            info.link_url = dr["link_url"] != DBNull.Value ? dr["link_url"].ToString() : "";
            info.companyid = int.Parse(dr["companyid"] != DBNull.Value ? dr["companyid"].ToString() : "0");
            return info;

        }

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
                strSql.Append(" O.*,C.CompanyName ");
                strSql.Append(" FROM article_category O ");
                strSql.Append(" left join Companys C ON C.CompanyID=O.CompanyID ");
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

        public List<int> GetSubListID(int id)
        {
            List<int> list = new List<int>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id FROM article_category where parentid=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                using (SqlDataReader dr = SqlDbHelper.ExecuteReader(Config.SqlConnection,strSql.ToString(), CommandType.Text, parameters))
                {
                    while (dr.Read())
                    {
                        int _id = int.Parse(dr["id"] != DBNull.Value ? dr["id"].ToString() : "");
                        list.Add(_id);
                    }
                }
                return list;
            }
            catch { }
            return null;
        }
    }
}
