using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using BS.Components.Data.Entity;

namespace BLL
{
    public class PermissionBLL : CommonBLL<Model.PermissionInfo>
    {
        #region 权限定义常量
        ///// <summary>
        ///// 查看
        ///// </summary>
        //public const string pKey_VIEW = "VIEW";
        ///// <summary>
        ///// 添加
        ///// </summary>
        //public const string pKey_ADD = "ADD";
        ///// <summary>
        ///// 修改
        ///// </summary>
        //public const string pKey_UPDATE = "UPDATE";
        ///// <summary>
        ///// 删除
        ///// </summary>
        //public const string pKey_DELETE = "DELETE";
        ///// <summary>
        ///// 导入
        ///// </summary>
        //public const string pKey_Import = "Import";
        ///// <summary>
        ///// 导出
        ///// </summary>
        //public const string pKey_Export = "Export";
        ///// <summary>
        ///// 权限
        ///// </summary>
        //public const string pKey_Permission = "Permission";

        ///// <summary>
        ///// 标注
        ///// </summary>
        //public const string pKey_Mark = "Mark";
        ///// <summary>
        ///// 分配
        ///// </summary>
        //public const string pKey_fenpei = "fenpei";
        ///// <summary>
        ///// 验证
        ///// </summary>
        //public const string pKey_CHECK = "CHECK";
        ///// <summary>
        ///// 根据权限Key转换显示名(可自定义)
        ///// </summary>
        ///// <param name="PermissionKey"></param>
        ///// <returns></returns>
        //public static string GetNameBypKey(string PermissionKey)
        //{
        //    switch (PermissionKey)
        //    {
        //        case pKey_VIEW:
        //            return "查看";
        //        case pKey_ADD:
        //            return "添加";
        //        case pKey_UPDATE:
        //            return "修改";
        //        case pKey_DELETE:
        //            return "删除";
        //        case pKey_Permission:
        //            return "权限";
        //        case pKey_Mark:
        //            return "标注";
        //        case pKey_fenpei:
        //            return "分配";
        //        case pKey_Import:
        //            return "导入";
        //        case pKey_Export:
        //            return "导出";
        //        default:
        //            return "";
        //    }
        //}
        #endregion

        /// <summary>
        /// 编辑菜单 如存在则修改否则添加 tabid 必须大于0否则默认为添加
        /// </summary>
        /// <param name="info"></param>
        /// <param name="dic">TKey指PermissionKey,TValue指PermissionName</param>
        /// <returns></returns>
        public static int edittabs(TabsInfo info, Dictionary<string, string> dic)
        {
            //int tabid = BLL.TabsBLL.GetMaxId() + 1;
            //info.TabID = tabid;
            if (info.TabID <= 0)
                return 0;
            int result = BLL.TabsBLL.AddUpdateTabs(info);
            if (result > 0)
            {
                //操作权限定义表 如果数据库中存在则添加失败，如果数据库中存在当前不存在则删除
                List<PermissionInfo> plist = GetList(-1, "TabID=" + info.TabID, "");
                delPerissions(plist, dic, info.TabID);

                foreach (var item in dic)
                {
                    //Console.WriteLine(item.Key + item.Value);
                    int permissionid = GetMaxId() + 1;
                    string PermissionKey = item.Key;
                    string PermissionName = item.Value;
                    addPermission(permissionid, PermissionKey, PermissionName, info.TabID);
                }
                //end
            }
            return result;
        }

        /// <summary>
        /// 删除当前不存在的定义(如果数据库中存在当前不存在则删除)
        /// </summary>
        /// <param name="plist"></param>
        /// <param name="dic"></param>
        /// <param name="TabID"></param>
        public static void delPerissions(List<PermissionInfo> plist, Dictionary<string, string> dic, int TabID)
        {

            if (plist != null && plist.Count > 0)
            {
                foreach (PermissionInfo info in plist)
                {
                    bool isexists = false;
                    foreach (var item in dic)
                    {
                        //Console.WriteLine(item.Key + item.Value);
                        string PermissionKey = item.Key;
                        string PermissionName = item.Value;

                        if (info.PermissionKey.Trim().ToLower() == PermissionKey.Trim().ToLower()
                            && info.TabID == TabID)//存在
                        {
                            isexists = true;
                            break;
                        }
                    }

                    if (!isexists)//如果数据库中存在当前不存在则删除
                    {
                        //int delresult = PermissionController.DeletePermission("PermissionID=" + info.PermissionID);
                        //if (delresult > 0)
                        //{
                        //    PermissionController.DeleteTabPermissionByWhere("TabID=" + info.TabID + " and PermissionID=" + info.PermissionID);
                        //}
                        DeletePermissionByPermissionID(info.PermissionID);
                    }
                }

            }
        }


        /// <summary>
        /// 添加权限定义  -2已存在对应的定义
        /// </summary>
        /// <param name="PermissionID"></param>
        /// <param name="PermissionKey">权限KEY 如：VIEW，UPDATE，ADD，DELETE</param>
        /// <param name="PermissionName"></param>
        /// <param name="TabID"></param>
        /// <returns></returns>
        public static int addPermission(int PermissionID, string PermissionKey, string PermissionName, int TabID)
        {

            PermissionInfo info;
            int result = 0;
            info = new PermissionInfo(PermissionID, "SYSTEM_TAB", PermissionKey, PermissionName, TabID);
            result = PermissionBLL.Insert(info, ReturnTypes.EffectRow);
            return result;
        }

        /// <summary>
        /// 删除权限定义并同时删除已被引用的数据(TabPermission表)
        /// </summary>
        /// <param name="PermissionID"></param>
        /// <returns></returns>
        public static int DeletePermissionByPermissionID(int PermissionID)
        {
            PermissionInfo pinfo = GetModel(PermissionID);
            if (pinfo != null && pinfo.PermissionID <= 0)
                return -1;
            int result = Delete("PermissionID=" + PermissionID);
            if (result > 0)
            {
                Delete("TabID=" + pinfo.TabID + " and PermissionID=" + PermissionID);
            }
            return result;
        }

        /// <summary>
        /// 查询是否有权限
        /// </summary>
        /// <param name="TabKey">页面Key</param>
        /// <param name="RoleID">角色ID</param>
        /// <param name="PermissionKey">权限Key(全部为大写 如添加为ADD,修改为UPDATE,删除为DELETE,查看为VIEW)</param>
        /// <returns></returns>
        public static bool GetPermission(string TabKey, int UserID, string PermissionKey)
        {
            bool isVIEW = false;
            try
            {

                Model.UserInfo userInfo = BLL.UsersBLL.GetModel(UserID);
                if (userInfo == null || userInfo.UserID <= 0)
                {
                    return false;
                }
                if (userInfo.UserType == Common.enumUserType.host.ToString() || userInfo.UserType == Common.enumUserType.admin.ToString())
                    return true;

                List<int> TabIDs = BLL.TabsBLL.GetTabIDsByTabKey(TabKey);

                foreach (int TabID in TabIDs)
                {
                    if (TabID > 0)
                    {
                        List<Model.RoleInfo> rolelist = BLL.RolesBLL.GetList(-1, "RoleID in (select Roleid from UserRoles where userid=" + UserID + ")", "");
                        bool isPermission = false;
                        foreach (Model.RoleInfo roleinfo in rolelist)
                        {
                            isVIEW = new PermissionDAL().GetPermission(TabID, roleinfo.RoleID, PermissionKey);
                            if (isVIEW)
                                isPermission = true;
                        }
                        if (isPermission)
                            break;
                    }
                }
            }
            catch { }
            return isVIEW;

        }

        public static int GetMaxId()
        {
            return new DAL.PermissionDAL().GetMaxId();
        }

    }
}
