using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.weixin.Utility;


namespace com.weixin.Menu
{
    /// <summary>
    /// 创建菜单类
    /// </summary>
    public class MenuManager
    {
        /// <summary>
        /// 菜单文件路径
        /// </summary>
        private static readonly string Menu_Data_Path = System.Web.HttpContext.Current.Server.MapPath("/Data/menu.txt");
        /// <summary>
        /// 获取菜单
        /// </summary>
        public static string GetMenu(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", AccessToken);
            return HttpUtility.GetData(url);
        }
        /// <summary>
        /// 创建菜单
        /// </summary>
        public static string CreateMenu(string menu, string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessToken);
            //string smenu = FileUtility.Read(Menu_Data_Path);
            return HttpUtility.SendHttpRequest(url, menu);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        public static string DeleteMenu(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", AccessToken);
            return HttpUtility.GetData(url);
        }
        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public static string LoadMenu()
        {
            return FileUtility.Read(Menu_Data_Path);
        }
    }
}
