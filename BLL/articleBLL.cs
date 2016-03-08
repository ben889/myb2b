using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Web;
using Common;
using BS.Components.Data.Entity;

namespace BLL
{
    public class articleBLL : CommonBLL<articleInfo>
    {
        private static DAL.articleDAL dal = new DAL.articleDAL();
        public articleBLL()
        { }

        public static int Add(articleInfo info, ref string resultMsg)
        {
            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //for (int i = 0; i < files.Count; i++)
            //{
            //    if (files[i].ContentLength > 10234 * 300)
            //    {
            //        resultMsg = "上传图片不能大于300k";
            //        return -1;
            //    }
            //}
            //string url = HttpContext.Current.Server.MapPath(Common.Constant.URL_article(companyid));
            //string filename = "";
            //bool upload = false;
            //for (int i = 0; i < files.Count; i++)
            //{
            //    System.Web.HttpPostedFile file = files[i];
            //    upload = FileHelper.UploadImgFile(file, url + "b/", url + "s/", 351, 213, "", ref filename);
            //    break;
            //}
            //info.img_url = filename;
            //return dal.Add(info, ref resultMsg);
            if (info.title.Trim().Length == 0)
            {
                resultMsg = "标题不能为空";
                return -1;
            }
            return Insert(info, ReturnTypes.Identity);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(articleInfo model, ref string resultMsg)
        {
            if (model == null || model.id <= 0)
            {
                resultMsg = "参数错误";
                return -1;
            }
            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //for (int i = 0; i < files.Count; i++)
            //{
            //    if (files[i].ContentLength > 10234 * 300)
            //    {
            //        resultMsg = "上传图片不能大于300k";
            //        return -1;
            //    }
            //}
            //string url = HttpContext.Current.Server.MapPath(Common.Constant.URL_article(companyid));
            //string filename = "";
            //bool upload = false;
            //if (files != null && files.Count > 0)
            //{
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        System.Web.HttpPostedFile file = files[i];
            //        upload = FileHelper.UploadImgFile(file, url + "b/", url + "s/", 351, 213, "", ref filename);
            //        break;
            //    }
            //}
            articleInfo info = GetModel(model.id);
            if (info == null || info.id <= 0)
            {
                resultMsg = "参数错误";
            }
            string oldimg = info.img_url;
            //model.img_url = filename;
            int result = Update(model);
            if (result > 0)
            {
                if (!model.img_url.Equals(oldimg))
                {
                    Common.FileHelper.DeleteFile(oldimg);
                }
            }
            return result;
        }

        
        public static DataTable GetDt(int Top, string strWhere, string filedOrder)
        {
            return dal.GetDt(Top, strWhere, filedOrder);
        }

        public static DataTable GetPagearticle(string WhereClause, string OrderBy, int PageIndex, int PageSize, ref int TotalRows)
        {
            return dal.GetPagearticle(WhereClause, OrderBy, PageIndex, PageSize, ref TotalRows);
        }
    }
}
