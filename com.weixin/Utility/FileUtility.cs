using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Shell32;
using System.Text.RegularExpressions;

namespace com.weixin.Utility
{
    public class FileUtility
    {
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>string</returns>
        public static string Read(string path)
        {
            string result = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(fs, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// MP3 Mp4 视频文件播放时间长度
        /// </summary>
        /// <param name="SongPath"></param>
        /// <returns></returns>
        public static int GetTime(string SongPath)
        {
            int value = 0;
            try
            {
                string dirName = Path.GetDirectoryName(SongPath);
                string SongName = Path.GetFileName(SongPath);//获得歌曲名称
                FileInfo fInfo = new FileInfo(SongPath);
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(dirName);
                FolderItem item = dir.ParseName(SongName);
                string SongTime = Regex.Match(dir.GetDetailsOf(item, -1), "\\d{2}:\\d{2}:\\d{2}").Value;
                if (!string.IsNullOrEmpty(SongTime))
                {
                    string[] str = SongTime.Split(':');
                    if (str[0] != "00")
                    {
                        value += int.Parse(str[2]) * 60 * 60;
                    }
                    if (str[1] != "00")
                    {
                        value += int.Parse(str[1]) * 60;
                    }
                    if (str[2] != "00")
                    {
                        value += int.Parse(str[2]);
                    }
                }

                //Dictionary<string, string> Properties = new Dictionary<string, string>();
                //int i = 0;
                //while (true)
                //{
                //    //获取属性名称 
                //    string key = dir.GetDetailsOf(null, i);
                //    if (string.IsNullOrEmpty(key))
                //    {
                //        //当无属性可取时，推出循环 
                //        break;
                //    }
                //    //获取属性值 
                //    string value1 = dir.GetDetailsOf(item, i);
                //    //保存属性 
                //    Properties.Add(key, value1);
                //    i++;
                //} 


                //string str1 = string.Empty;
                //foreach (string key in Properties.Keys)
                //{
                //    str1 += key + ":" + Properties[key].ToString() + "\r\n";
                //}  
                //FileUtility.WriteLog("MP3 Mp4：" + DateTime.Now.ToString() + "| " + SongPath.ToString() + "|" + dir.GetDetailsOf(item, -1).ToString() + " | " + str1.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                FileUtility.WriteLog("获取MP3 Mp4 视频文件播放时间长度错误：" + DateTime.Now.ToString() + " " + ex.ToString() + "\r\n");
                value = 0;
                throw ex;
            }

            return value;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="strMemo">内容</param>
        public static void WriteLog(string strMemo)
        {
            string filename = System.Web.HttpContext.Current.Server.MapPath("/log/wx_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("/log")))
                System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/log"));
            System.IO.StreamWriter sr = null;
            try
            {
                if (!System.IO.File.Exists(filename))
                {
                    sr = System.IO.File.CreateText(filename);
                }
                else
                {
                    sr = System.IO.File.AppendText(filename);
                }
                sr.WriteLine(strMemo);
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }
    }
}
