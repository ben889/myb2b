using BS.Components.Data.Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class UsersBLL : CommonBLL<Model.UserInfo>
    {
        /// <summary>
        /// 用户登录 -4已被删除 -2被锁定 -100异常 -1帐号/密码错误
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public static int Login(string UserName, string PassWord, ref string resultMsg)
        {
            Model.UserInfo info = new DAL.UsersDAL().Login(UserName, PassWord);
            if (info != null && info.UserID > 0)
            {
                if (info.IsDeleted)
                {
                    resultMsg = "帐号已被删除";
                    return -4;
                }
                if (info.IsLock)
                {
                    resultMsg = "帐号已被锁定";
                    return -2;
                }
                try
                {
                    System.Web.HttpContext.Current.Session["Users"] = info;
                    return info.UserID;
                }
                catch (Exception exc) { resultMsg = exc.Message; }
                return -100;
            }
            resultMsg = "帐号/密码错误";
            return -1;
        }

        //public static UserInfo GetUser(string UserName, string PassWord)
        //{
        //    //Model.UserInfo info = new DAL.UsersDAL().Login(UserName, PassWord);
        //    List<UserInfo> list = GetList(1, "UserName='" + UserName + "' and PassWord='" + PassWord + "'", "");
        //    return info;
        //}

        public static int Add(Model.UserInfo info, ref string resultMsg)
        {
            if (info.UserName.Trim().Length < 3)
            {
                resultMsg = "帐号必须三位以上";
                return 0;
            }
            return Insert(info, ReturnTypes.Identity);
        }

        #region 用户状态
        /// <summary>
        /// 登陆会员信息
        /// </summary>
        public static Model.UserInfo UserEntity
        {

            get
            {
                try
                {
                    object obj = HttpContext.Current.Session["Users"];
                    if (obj == null)
                    {
                        return null;
                    }
                    return obj as Model.UserInfo;
                }
                catch { return null; }

            }

        }
        public static void Exit()
        {
            HttpContext.Current.Session.RemoveAll();
            //HttpContext.Current.Session.Remove("Users");
            //HttpContext.Current.Session["Users"] = null;
            //HttpContext.Current.Response.Redirect("/waifuSystem/login.htm");
        }
        #endregion

        #region 系统初始化users

        public static void InitUsers(List<int> roleids)
        {
            string resultMessage = "";
            AddUser("host", "h1234!@#$", "超级管理员", "", "", "", Common.enumUserType.host.ToString(), null, ref resultMessage);
            AddUser("admin", "h1234!@#$", "系统管理员", "", "", "", Common.enumUserType.admin.ToString(), null, ref resultMessage);
            //int companyuserid = AddUser("sysadmin", "111111", "代理商管理员", "", "", "", Common.enumUserType.company.ToString(), roleids, ref resultMessage);
            //if (userlist != null)
            //{
            //    foreach (UserInfo info in userlist)
            //    {
            //        if (info.UserType == Common.enumUserType.host.ToString() || info.UserType == Common.enumUserType.admin.ToString())
            //            continue;
            //        AddUser(info.UserName, info.PassWord, info.DisplayName, info.FirstName, info.LastName, info.Email, info.UserType, ref resultMessage);
            //    }
            //}
        }


        public static int AddUser(string UserName, string PassWord, string DisplayName
            , string FirstName, string LastName, string Email, string UserType, List<int> roleids, ref string resultMessage)
        {
            try
            {
                //if (!UserType.Equals(Common.enumUserType.host.ToString()) && !UserType.Equals(Common.enumUserType.admin.ToString()))
                //{
                //    if (CompanyId.Trim().Length == 0)
                //        return 0;
                //}
                Model.UserInfo userinfo = GetModel(UserName.Trim(), "UserName", "*");// UsersController.GetUserByUserName(UserName.Trim());
                if (userinfo != null && userinfo.UserID > 0)
                    return -2;
                Model.UserInfo info = new Model.UserInfo();
                info.UserName = UserName;
                info.DisplayName = DisplayName;
                info.PassWord = Common.Utility.MD5Encrypt(PassWord);
                info.FirstName = FirstName;
                info.LastName = LastName;
                info.Email = Email;
                info.IsLock = false;
                info.UserType = UserType;
                info.CreatedOnDate = DateTime.Now;
                info.LastLoginDate = DateTime.Now;
                int result = Insert(info, ReturnTypes.Identity);// Components.UsersController.AddUser(info);
                if (result > 0)
                {
                    if (UserType == Common.enumUserType.company.ToString())
                    {
                        //Components.UsersController.DeleteUserRolesByUserID(result);
                        UserRolesBLL.Delete(result, "userid");
                        if (roleids != null)
                        {

                            foreach (int roleid in roleids)
                            {
                                //Components.UsersController.AddUserRole(result, roleid, 0);
                                UserRolesInfo urinfo = new UserRolesInfo();
                                urinfo.UserID = result;
                                urinfo.RoleID = roleid;
                                urinfo.CreatedByUserID = 0;
                                urinfo.CreatedOnDate = DateTime.Now;
                                UserRolesBLL.Add(urinfo);
                            }
                        }
                    }
                    resultMessage = "成功";
                }
                else
                    resultMessage = "失败";
                return result;
            }
            catch (Exception exc) { resultMessage = exc.Message; }
            return 0;
        }

        #endregion

        //===============================================================

        //===============================================================
        /// <summary>
        /// 根据帐号id查企业id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int GetCompanyID(int userid)
        {
            if (userid <= 0)
                return 0;
            string companyid = new DAL.UsersDAL().GetCompanyId(userid);
            int cid = 0;
            int.TryParse(companyid, out cid);
            return cid;
        }
    }
}
