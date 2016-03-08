using System;
using System.IO;
using System.Text;
using System.Web;

namespace Common
{

    /**
    * 
    * ���ã����ڵ���΢��֧����ʱ��дtxt��־
    * ���ߣ���ѧ��
    * ��д���ڣ�2014-12-25
    * ��ע��������Ŀ¼��д��Ȩ��
    * 
    * */
    public class LogUtil
    {
        private static readonly object writeFile = new object();

        /// <summary>
        /// �ڱ���д�������־
        /// </summary>
        /// <param name="dir">�ļ���Ŀ¼(�磺111/222/)</param> 
        /// <param name="Prefix">�ļ�ǰ�</param> 
        /// <param name="debugstr">����</param> 
        public static void WriteLog(string dir, string Prefix, string debugstr)
        {
            lock (writeFile)
            {
                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    string filename = Prefix + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    //����������־Ŀ¼
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