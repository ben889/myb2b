using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using Model;
using BS.Components.Data.Entity;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace BLL
{
    public class TabsBLL : CommonBLL<Model.TabsInfo>
    {

        /// <summary>
        /// 系统升级 更新菜单
        /// </summary>
        /// <returns></returns>
        public static int updateSystem_updatetabs()
        {
            //PermissionController.DeleteAllPermission();
            new TabsDAL().Delete("");
            PermissionBLL.Delete("");
            PermissionBLL.addPermission(1, enum_userpermission.VIEW.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.VIEW), 0);
            TabsInfo info;
            int result = 0;

            #region 内容发布 1
            info = new TabsInfo(1, "内容发布", "Main.aspx?menuid=1", 0, "", true, "content", 1);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(11, "文章", "DesktopModules/article/article.aspx", 1, "", true, "article", 11);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(111, "文章", "DesktopModules/article/article.aspx", 11, "", true, "article", 111);
            PermissionBLL.edittabs(info, new Dictionary<string, string>() { 
                { enum_userpermission.ADD.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.ADD) }, 
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            info = new TabsInfo(112, "文章分类", "DesktopModules/article/article_category.aspx", 11, "", true, "article", 112);
            PermissionBLL.edittabs(info, new Dictionary<string, string>() { 
                { enum_userpermission.ADD.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.ADD) }, 
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });

            info = new TabsInfo(12, "广告", "DesktopModules/ad/ad.aspx", 1, "", true, "ad", 12);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(121, "广告位", "DesktopModules/ad/AdPosition.aspx", 12, "", true, "adposition", 121);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.ADD.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.ADD) }, 
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            info = new TabsInfo(122, "广告", "DesktopModules/ad/ad.aspx", 12, "", true, "ad", 122);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.ADD.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.ADD) }, 
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });

            #endregion

            #region 会员
            info = new TabsInfo(2, "会员", "Main.aspx?menuid=2", 0, "", true, "member", 2);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(21, "会员列表", "DesktopModules/member/member.aspx", 2, "", true, "article", 21);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            #endregion

            #region 商家
            info = new TabsInfo(3, "商家", "Main.aspx?menuid=2", 0, "", true, "member", 3);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(31, "商家列表", "DesktopModules/seller/seller.aspx", 3, "", true, "article", 31);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            #endregion

            #region 管理 4

            info = new TabsInfo(4, "管理", "Main.aspx?menuid=4", 0, "", true, "users", 4);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(41, "URL", "", 4, "", true, "companys", 41);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(411, "系统URL", "DesktopModules/resource/sysurl.aspx", 41, "", true, "url", 411);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            info = new TabsInfo(412, "自定义URL", "DesktopModules/resource/url.aspx", 41, "", true, "url", 412);
            PermissionBLL.edittabs(info, new Dictionary<string, string>() { 
                {enum_userpermission.ADD.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.ADD)}, 
                {enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE)}, 
                {enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE)}, 
            });
            info = new TabsInfo(42, "设置", "", 4, "", true, "config", 42);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(421, "参数设置", "DesktopModules/config/edit_config.aspx", 42, "", true, "url", 421);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            #endregion

            //===========================================

            #region 微信 5
            info = new TabsInfo(5, "微信", "Main.aspx?menuid=5", 0, "", true, "wx", 5);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(51, "微信", "", 5, "", true, "wx", 51);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
            });
            info = new TabsInfo(511, "素材", "DesktopModules/wx/wx_Material.aspx", 51, "", true, "wx_material", 511);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            info = new TabsInfo(512, "自动回复", "DesktopModules/wx/wx_ReplyMesage.aspx", 51, "", true, "wx_replymesage", 512);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            info = new TabsInfo(513, "自定义菜单", "DesktopModules/wx/wx_diymenu.aspx", 51, "", true, "wx_diymenu", 513);
            PermissionBLL.edittabs(info, new Dictionary<string, string>()
            {
                { enum_userpermission.UPDATE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.UPDATE) }, 
                { enum_userpermission.DELETE.ToString(), EnumHelper.GetEnumDescription(enum_userpermission.DELETE) }, 
            });
            #endregion

            return result;
        }


        #region 菜单
        #region 菜单XML
        /// <summary>
        /// 菜单XML
        /// </summary>
        /// <param name="UserID">当前登陆帐号</param>
        /// <param name="menuid">菜单ID 一般为父级ID 也可以是admin或host 如果是"0"则查全部</param>
        /// <param name="Level">级别 0为到所有级 1为到一级 2为到二级 ...</param>
        /// <returns></returns>
        public static string GetMenuXML(int UserID, string menuid, int Level)
        {
            i = 0;
            string result = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";

            if (menuid.Trim().Length == 0 || menuid.Trim() == "-1")
                return result;

            string UserType = "";
            Model.UserInfo userinfo = BLL.UsersBLL.GetModel(UserID);
            if (userinfo == null || userinfo.UserID != UserID)
                return "";
            UserType = userinfo.UserType;
            result += "<Tabs>";

            string addto1 = "";
            if ((UserType == Common.enumUserType.host.ToString() || UserType == Common.enumUserType.admin.ToString()) && (menuid.Trim().ToLower() == "admin"))
            {
                if (menuid.Trim().ToLower() == "admin")
                {
                    if (Level != 1)
                    {
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/companys/companys.aspx\" ID=\"companys\" Text=\"代理商\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Users/ViewUsers.aspx\" ID=\"users\" Text=\"帐号管理\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Roles/ViewRoles.aspx\" ID=\"viewroles\" Text=\"角色\"/>";
                    }
                }
                else
                {
                    addto1 += "<Tab ID=\"admin\" NavigateUrl=\"Main.aspx?menuid=admin\" Text=\"Admin\">";
                    if (Level != 1)
                    {
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/companys/companys.aspx\" ID=\"companys\" Text=\"代理商\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Users/ViewUsers.aspx\" ID=\"users\" Text=\"帐号管理\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Roles/ViewRoles.aspx\" ID=\"viewroles\" Text=\"角色\"/>";
                    }
                    addto1 += "</Tab>";
                }

            }
            if (UserType == Common.enumUserType.host.ToString() && (menuid.Trim().ToLower() == "host"))
            {
                if (menuid.Trim().ToLower() == "host")
                {
                    if (Level != 1)
                    {
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Tabs/TabsList.aspx\" ID=\"pagemenu\" Text=\"菜单\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/SQL/execSQL.aspx\" ID=\"execsql\" Text=\"执行脚本\" />";
                    }
                }
                else
                {
                    addto1 += "<Tab ID=\"host\" NavigateUrl=\"Main.aspx?menuid=host\" Text=\"host\">";
                    if (Level != 1)
                    {
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/Tabs/TabsList.aspx\" ID=\"pagemenu\" Text=\"菜单\" />";
                        addto1 += "<Tab NavigateUrl=\"DesktopModules/SQL/execSQL.aspx\" ID=\"execsql\" Text=\"执行脚本\" />";
                    }
                    addto1 += "</Tab>";
                }
            }

            int ParentId = -1;
            try { ParentId = int.Parse(menuid.Trim()); }
            catch { }

            string addto0 = "";
            //if (menuid.Trim().ToLower() == "0")
            //    addto0 = "<Tab NavigateUrl=\"javascript:void(0);\" ID=\"home\" Text=\"\" Img=\"images/home.png\"/>";
            result += menuXML(UserID, ParentId, Level, addto0, addto1);
            result += "</Tabs>";
            return result;
        }

        static int i = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ParentId"></param>
        /// <param name="Level">级别 0为到所有级 1为到一级 2为到二级 ...</param>
        /// <param name="addto0"></param>
        /// <param name="addto2"></param>
        /// <returns></returns>
        private static string menuXML(int UserID, int ParentId, int Level, string addto0, string addto1)
        {
            i++;
            if (Level > 0 && i > Level)
                return "";

            string result = "";
            List<TabsInfo> list = BLL.TabsBLL.GetList(-1, "ParentId=" + ParentId + " and DisPlay='True'", "");

            if (list != null && list.Count > 0)
            {
                result += "{0}";
                foreach (TabsInfo info in list)
                {
                    if (PermissionBLL.GetPermission(info.TabKey, UserID, "VIEW"))
                    {
                        string TabUrl = "javascript:void(0);";
                        if (info.TabUrl.Length > 0)
                        {
                            //if (i == 1)
                            //    TabUrl = "Main.aspx?menuid=" + info.TabID;
                            //else
                            TabUrl = info.TabUrl;
                        }
                        result += "<Tab ID=\"" + info.TabID + "\" NavigateUrl=\"" + TabUrl + "\" Text=\"" + info.TabName + "\">";
                        //result += "<Tab ID=\"" + info.TabID + "\" NavigateUrl=\"/admin/Main.aspx?menuid=" + info.TabID + "\" Text=\"" + info.TabName + "\">";
                        result += menuXML(UserID, info.TabID, Level, "", "");
                        result += "</Tab>";
                    }
                }
                result += "{1}";

            }
            else
            {
                if (i > 0)
                    result += "{0}{1}";
            }

            result = string.Format(result, addto0, addto1);

            i--;
            return result;
        }

        #endregion

        #region 菜单json
        public static string GetMenuJSON(int UserID)
        {
            string UserType = "";
            Model.UserInfo userinfo = BLL.UsersBLL.GetModel(UserID);
            if (userinfo == null || userinfo.UserID != UserID)
                return "";
            UserType = userinfo.UserType;
            List<TabsInfo> list = BLL.TabsBLL.GetList(-1, "ParentId=0 and DisPlay='True'", "");
            string result = "[";
            if (list != null && list.Count > 0)
            {
                foreach (TabsInfo info in list)
                {
                    if (PermissionBLL.GetPermission(info.TabKey, UserID, "VIEW"))
                    {
                        string TabUrl = "javascript:void(0);";
                        if (info.TabUrl.Length > 0)
                        {
                            //if (i == 1)
                            //    TabUrl = "Main.aspx?menuid=" + info.TabID;
                            //else
                            TabUrl = info.TabUrl;
                        }

                        result += "{\"url\":\"" + TabUrl + "\",\"id\":\"" + info.TabID + "\",\"name\":\"" + info.TabName + "\",\"submenu\":[]},";
                    }
                }
            }
            if (UserType == Common.enumUserType.host.ToString())
            {
                result += "{\"url\":\"javascript:void(0);\",\"id\":\"admin\",\"name\":\"admin\",\"submenu\":[]},";
                result += "{\"url\":\"javascript:void(0);\",\"id\":\"host\",\"name\":\"Host\",\"submenu\":[]},";
            }
            if (UserType == Common.enumUserType.admin.ToString())
            {
                result += "{\"url\":\"javascript:void(0);\",\"id\":\"admin\",\"name\":\"admin\",\"submenu\":[]},";
            }
            if (result.EndsWith(","))
                result = result.Remove(result.Length - 1);
            result += "]";
            return result;

        }
        /// <summary>
        /// 子菜单JSON
        /// </summary>
        /// <param name="UserID">当前登陆帐号</param>
        /// <param name="menuid">菜单ID 一般为父级ID 也可以是admin或host 如果是"0"则查全部</param>
        /// <param name="Level">级别 0为到所有级 1为到一级 2为到二级 ...</param>
        /// <returns></returns>
        public static string GetSubMenuJSON(int UserID, string menuid, int Level)
        {
            i = 0;
            if (menuid.Trim().Length == 0 || menuid.Trim() == "-1")
                return "[]";

            string UserType = "";
            Model.UserInfo userinfo = BLL.UsersBLL.GetModel(UserID);
            if (userinfo == null || userinfo.UserID != UserID)
                return "[]";
            UserType = userinfo.UserType;

            string result = "[";
            if ((UserType == Common.enumUserType.host.ToString() || UserType == Common.enumUserType.admin.ToString()) && (menuid.Trim().ToLower() == "admin"))
            {
                if (menuid.Trim().ToLower() == "admin")
                {
                    if (Level > 1)
                    {
                        result += "{\"url\":\"DesktopModules/district/district.aspx\",\"id\":\"district\",\"name\":\"城市设置\",\"submenu\":[]},";
                        //result += "{\"url\":\"DesktopModules/companys/companys.aspx\",\"id\":\"companys\",\"name\":\"代理商\",\"submenu\":[]},";
                        result += "{\"url\":\"DesktopModules/Users/ViewUsers.aspx\",\"id\":\"users\",\"name\":\"帐号管理\",\"submenu\":[]},";
                        result += "{\"url\":\"DesktopModules/Roles/ViewRoles.aspx\",\"id\":\"viewroles\",\"name\":\"角色\",\"submenu\":[]},";
                        result += "{\"url\":\"DesktopModules/eventlog/eventlog.aspx\",\"id\":\"eventlog\",\"name\":\"事件日志\",\"submenu\":[]},";
                    }
                }
                if (result.EndsWith(","))
                    result = result.Remove(result.Length - 1);
                result += "]";
                return result;
            }
            if (UserType == Common.enumUserType.host.ToString() && (menuid.Trim().ToLower() == "host"))
            {
                if (menuid.Trim().ToLower() == "host")
                {
                    if (Level > 1)
                    {
                        result += "{\"url\":\"DesktopModules/console/datainit.aspx\",\"id\":\"datainit\",\"name\":\"刷新基础数据\",\"submenu\":[]},";
                        result += "{\"url\":\"DesktopModules/Tabs/TabsList.aspx\",\"id\":\"pagemenu\",\"name\":\"菜单\",\"submenu\":[]},";
                        result += "{\"url\":\"DesktopModules//SQL/execSQL.aspx\",\"id\":\"execsql\",\"name\":\"执行脚本\",\"submenu\":[]},";
                    }
                }

                if (result.EndsWith(","))
                    result = result.Remove(result.Length - 1);
                result += "]";
                return result;
            }

            int ParentId = -1;
            int.TryParse(menuid.Trim(), out ParentId);
            if (ParentId > 0)
            {
                result += menuJSON(UserID, ParentId, Level);
            }
            if (result.EndsWith(","))
                result = result.Remove(result.Length - 1);
            result += "]";
            return result;
        }
        private static string menuJSON(int UserID, int ParentId, int Level)
        {
            i++;
            if (Level > 0 && i > Level)
                return "";

            string result = "";
            List<TabsInfo> list = BLL.TabsBLL.GetList(-1, "ParentId=" + ParentId + " and DisPlay='True'", ""); //TabsController.GetListInfoTabs(0, "ParentId=" + ParentId + " and DisPlay='True'");

            if (list != null && list.Count > 0)
            {
                foreach (TabsInfo info in list)
                {
                    if (PermissionBLL.GetPermission(info.TabKey, UserID, "VIEW"))
                    {
                        string TabUrl = "javascript:void(0);";
                        if (info.TabUrl.Length > 0)
                        {
                            //if (i == 1)
                            //    TabUrl = "Main.aspx?menuid=" + info.TabID;
                            //else
                            TabUrl = info.TabUrl;
                        }

                        result += "{\"url\":\"" + TabUrl + "\",\"id\":\"" + info.TabID + "\",\"name\":\"" + info.TabName + "\",\"submenu\":[";

                        result += menuJSON(UserID, info.TabID, Level);

                        result += "]},";
                    }
                }

            }
            if (result.Trim().Length > 0 && result.EndsWith(","))
                result = result.Remove(result.Length - 1);
            i--;
            return result;
        }
        #endregion
        #region
        public static int AddUpdateTabs(TabsInfo info)
        {
            if (info == null)
                return -1;
            int result = 0;
            if (info.TabID > 0)
            {
                result = Insert(info, ReturnTypes.EffectRow);
            }
            //else
            //{
            //    result = Update(info);
            //}
            return result;
        }

        public static List<int> GetTabIDsByTabKey(string keyvalue)
        {
            List<int> list = new DAL.TabsDAL().GetTabIDsByTabKey(keyvalue);
            return list;
        }

        public static DataTable GetDataTable()
        {
            return GetTable("select * from Tabs where DisPlay=1");
        }

        public static int GetMaxId()
        {
            return new DAL.TabsDAL().GetMaxId();
        }
        #endregion

        #region
        /// <summary>
        /// 绑定生成一个有树结构的下拉菜单
        /// </summary>
        /// <param name="dtNodeSets">菜单记录数据所在的表</param>
        /// <param name="strParentColumn">表中用于标记父记录的字段</param>
        /// <param name="strRootValue">第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录</param>
        /// <param name="strIndexColumn">索引字段，也就是放在DropDownList的Value里面的字段</param>
        /// <param name="strTextColumn">显示文本字段，也就是放在DropDownList的Text里面的字段</param>
        /// <param name="drpBind">需要绑定的DropDownList</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        /// <param name="arrRemoveTabID">要移除的ID组</param>
        public static void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, DropDownList drpBind, int i, int[] arrRemoveTabID)
        {
            //每向下一层，多一个缩入单位
            i++;

            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符

            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
            for (int j = 0; j < i; j++)
                strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了

            foreach (DataRowView drv in dvNodeSets)
            {
                ListItem li = new ListItem(strPading + "├ " + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
                int tabid = Convert.ToInt32(drv[strIndexColumn]);
                bool isadd = true;
                if (arrRemoveTabID != null)
                {
                    if (arrRemoveTabID.Contains(tabid))
                        isadd = false;
                }

                if (isadd)
                    drpBind.Items.Add(li);
                MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, drpBind, i, arrRemoveTabID);
            }


            //递归结束，要回到上一层，所以缩入量减少一个单位
            i--;
        }

        ArrayList list = new ArrayList();

        /// <summary>
        /// 树结构
        /// </summary>
        /// <param name="dtNodeSets">菜单记录数据所在的表</param>
        /// <param name="strParentColumn">表中用于标记父记录的字段</param>
        /// <param name="strRootValue">第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录</param>
        /// <param name="strIndexColumn">索引字段，也就是放在DropDownList的Value里面的字段</param>
        /// <param name="strTextColumn">显示文本字段，也就是放在DropDownList的Text里面的字段</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        public ArrayList MakeTree2(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, int i)
        {

            //每向下一层，多一个缩入单位
            i++;

            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符



            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格
            for (int j = 0; j < i; j++)
                strPading += "　　";//如果要增加缩入的长度，改成两个全角的空格就可以了

            foreach (DataRowView drv in dvNodeSets)
            {
                TabsInfo info = new TabsInfo();
                info.TabID = Convert.ToInt32(drv["TabID"].ToString());

                info.TabUrl = drv["TabUrl"].ToString();
                info.ParentId = Convert.ToInt32(drv["ParentID"].ToString());
                //if (info.ParentId == 0)
                //{
                //    info.TabName = strPading + " <a href='javascript:void(0);' onclick='showhidetype(" + info.TabID + ")'>├</a> " + drv[strTextColumn].ToString();
                //}
                //else
                info.TabName = strPading + " ├ " + drv[strTextColumn].ToString();
                info.Level = Convert.ToInt32(drv["Level"].ToString());
                info.OrderByNo = drv["OrderByNo"] != DBNull.Value ? Convert.ToInt32(drv["OrderByNo"].ToString()) : 0;
                info.DisPlay = drv["DisPlay"] != DBNull.Value ? Convert.ToBoolean(drv["DisPlay"].ToString()) : false;
                info.TabKey = drv["TabKey"].ToString();
                list.Add(info);
                MakeTree2(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, i);
            }


            //递归结束，要回到上一层，所以缩入量减少一个单位
            i--;
            return list;
        }
        #endregion
        #endregion


    }
}
