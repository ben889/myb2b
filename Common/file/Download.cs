using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public class Download
    {
        /// <summary>
        /// 下载网上图片
        /// </summary>
        /// <param name="URL">远程地址</param>
        /// <param name="dic">下载的约对路径</param>
        /// <param name="fileName">文件名加后辍</param>
        /// <returns></returns>
        public static string downloadImg(string URL, string dic, string fileName)
        {

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            request.Timeout = 30000;
            System.Net.HttpWebResponse response = null;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                fileName = dic + fileName;
                img.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();
                response.Close();
                img.Dispose();
                return fileName;
            }
            catch (System.Exception)
            {
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
        }
    }
}
