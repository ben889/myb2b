using BS.Components.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Config
    {
        /// <summary>
        /// 本系统名称
        /// </summary>
        public static string SYSTEM_NAME
        {
            get
            {
                return "成员系统";
            }
        }

        /// <summary>
        /// 数据库连接符
        /// </summary>
        public static readonly string SqlConnection = ConnConfig.getConn;// AppConfig.GetConnection("conn");

        /// <summary>
        /// 设置系统使用的Cache模块，可扩展到Memcach
        /// </summary>
        public static readonly string CacheAssembly = AppConfig.GetString("CacheAssembly");
    }
}
