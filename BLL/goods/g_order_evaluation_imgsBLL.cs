using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    public class g_order_evaluation_imgsBLL : CommonBLL<g_order_evaluation_imgsInfo>
    {
        public static int delete(int evaluaimg_id, ref string resultMsg)
        {
            try
            {
                if (evaluaimg_id <= 0)
                {
                    resultMsg = "evaluaimg_id 错误";
                    return 0;
                }
                g_order_evaluation_imgsInfo info = GetModel(evaluaimg_id);
                if (info == null || info.evaluaimg_id != evaluaimg_id)
                {
                    resultMsg = "不存在对应的评价图片信息";
                    return 0;
                }
                int result = Delete(evaluaimg_id, "evalua_id");
                if (result > 0)
                {
                    File.Delete(HttpContext.Current.Server.MapPath(info.img));
                }
                return result;
            }
            catch { }
            return 0;
        }
    }
}
