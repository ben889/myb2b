using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class wx_UsersBLL : CommonBLL<wx_UsersInfo>
    {
        public static int edit(wx_UsersInfo info, ref string resultMsg)
        {
            //if (info.OpenId.Trim().Length > 0)
            //{
            //    return update(info);
            //}
            wx_UsersInfo wx_usersInfo = GetModel(info.OpenId.Trim(), "OpenId", "*");
            if (wx_usersInfo != null && wx_usersInfo.OpenId.Equals(info.OpenId.Trim()))
            {
                if (wx_usersInfo.SourceID.Trim().Length == 0)
                {
                    wx_usersInfo.SourceType = 2;
                    wx_usersInfo.SourceID = info.SourceID;
                    return update(wx_usersInfo);
                }
                return 0;
            }
            return add(info, ref resultMsg);
        }
        public static int add(wx_UsersInfo info, ref string resultMsg)
        {
            try
            {
                if (info.OpenId.Trim().Length == 0)
                {
                    resultMsg = "OpenId不能为空";
                    return 0;
                }
                //if (info.companyid.Trim().Length == 0)
                //{
                //    resultMsg = "companyid不能为空";
                //    return 0;
                //}


                bool b = IsExist("openid='" + info.OpenId + "'");
                if (b)
                {
                    resultMsg = "已存在";
                    return -1;
                }
                int result = Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
                if (result > 0)
                {
                    string memmsg = "";
                    long parentid = 0;
                    long.TryParse(info.SourceID, out parentid);
                    long member_result = memberBLL.reg("", "", info.NickName, info.OpenId, parentid, ref memmsg);
                    //Common.LogUtil.WriteLog("/创建member帐号日志/", "创建member帐号结果", "member_result=" + member_result + " " + memmsg);
                    if (member_result <= 0)
                    {
                        Common.LogUtil.WriteLog("/创建member帐号日志/", "创建member帐号失败", memmsg);
                    }
                }

                return result;
            }
            catch (Exception exc) { resultMsg = exc.Message; }
            return 0;
        }

        public static int update(wx_UsersInfo info)
        {
            int result = 0;
            try
            {
                result = Update(info);
                if (result > 0)
                {
                    string memmsg = "";
                    long parentid = 0;
                    long.TryParse(info.SourceID, out parentid);
                    long member_result = memberBLL.reg("", "", info.NickName, info.OpenId, parentid, ref memmsg);
                    //Common.LogUtil.WriteLog("/创建member帐号日志/", "创建member帐号结果", "member_result=" + member_result + " " + memmsg);
                    if (member_result <= 0)
                    {
                        Common.LogUtil.WriteLog("/创建member帐号日志/", "创建member帐号失败", memmsg);
                    }
                }
                return result;
            }
            catch { }
            return result;
        }
    }
}
