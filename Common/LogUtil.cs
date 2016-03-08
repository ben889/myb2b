using System;
using System.IO;
using System.Text;
using System.Web;

namespace Common
{

    /**
    * 
    * 作用：用于调试微信支付的时候写txt日志
    * 作者：邹学典
    * 编写日期：2014-12-25
    * 备注：请设置目录的写入权限
    * 
    * */
    public class LogUtil
    {
        private static readonly object writeFile = new object();

        /// <summary>
        /// 在本地写入错误日志
        /// </summary>
        /// <param name="dir">文件夹目录(如：111/222/)</param> 
        /// <param name="Prefix">文件前辍</param> 
        /// <param name="debugstr">内容</param> 
        public static void WriteLog(string dir, string Prefix, string debugstr)
        {
            lock (writeFile)
            {
                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    string filename = Prefix + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    //服务器中日志目录
                    string folder = HttpContext.Current.Server.MapPath("/log/" + dir);
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    fs = new FileStream(folder + "/" + filename, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                    sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.WriteLine(debugstr + "\r\n");
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Dispose();
                        sw = null;
                    }
                    if (fs != null)
                    {
                        //     fs.Flush();
                        fs.Dispose();
                        fs = null;
                    }
                }
            }
        }

    }
}