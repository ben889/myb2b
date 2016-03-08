using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class wx_ReplyMesageBLL : CommonBLL<wx_ReplyMesageInfo>
    {


        public static int add(wx_ReplyMesageInfo model, ref string resultMsg)
        {
            try
            {
                bool b = check(model, ref resultMsg);
                if (!b)
                {
                    return 0;
                }
                int result = 0;
                model.CreateTime = DateTime.Now;
                result = BLL.wx_ReplyMesageBLL.Insert(model, BS.Components.Data.Entity.ReturnTypes.Identity);
                return result;
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
            }
            return 0;
        }
        public static int update(wx_ReplyMesageInfo model, ref string resultMsg)
        {
            try
            {
                bool b = check(model, ref resultMsg);
                if (!b)
                {
                    return 0;
                }
                if (model.ReplyID <= 0)
                {
                    resultMsg = "ReplyID错误";
                    return 0;
                }
                wx_ReplyMesageInfo info = GetModel(model.ReplyID);
                if (info == null || info.ReplyID != model.ReplyID)
                {
                    resultMsg = "无对应的数据";
                    return 0;
                }
                if (info.companyid != model.companyid)
                {
                    resultMsg = "companyid不正确";
                    return 0;
                }
                int result = 0;
                model.CreateTime = DateTime.Now;
                result = BLL.wx_ReplyMesageBLL.Update(model);
                return result;
            }
            catch (Exception exc)
            {
                resultMsg = exc.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
            }
            return 0;
        }
        private static bool check(wx_ReplyMesageInfo model, ref string resultMsg)
        {
            if (model.State != 0 && model.State != 1)
            {
                resultMsg = "状态错误";
                return false;
            }
            //if (model.companyid.Trim().Length == 0)
            //{
            //    resultMsg = "分站ID错误";
            //    return false;
            //}
            //===============
            if (model.RefType == 1)
            {
                if (model.Body.Trim().Length == 0)
                {
                    resultMsg = "请填写回复文本";
                    return false;
                }
            }
            else if (model.RefType == 2)
            {
                if (model.RefID <= 0)
                {
                    resultMsg = "请选择图片素材";
                    return false;
                }
            }
            else if (model.RefType == 3)
            {
                if (model.RefID <= 0)
                {
                    resultMsg = "请选择图文素材";
                    return false;
                }
            }
            else
            {
                resultMsg = "回复类型错误";
                return false;
            }
            //=================
            return true;
        }

        public static int delete(int replyid)
        {
            int result = Delete(replyid, "ReplyID");
            if (result > 0)
            {
                BLL.wx_ReplyKeyBLL.Delete("replyid=" + replyid);
            }
            return result;
        }

        /// <summary>
        /// 是否可用：0否，1是
        /// </summary>
        /// <param name="objState">是否可用：0否，1是</param>
        /// <returns></returns>
        public static string getState_str(object objState)
        {
            if (objState == null || objState == DBNull.Value || objState.ToString().Trim().Length == 0)
                return "";
            if (objState.ToString().Trim().Equals("0"))
                return "<span style=\"color:red;\">不可用</span>";
            else if (objState.ToString().Trim().Equals("1"))
                return "<span style=\"color:green;\">可用</span>";
            return "";
        }
    }
}
