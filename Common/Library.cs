using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace Common
{
    public class Library
    {
        #region 截取字符串
        public static string leftlength(object str, int number)
        {
            if (str != null && number > 0 && str.ToString().Length > number)
                return str.ToString().Substring(0, number) + "..";
            else
                return str != null ? str.ToString() : "";
        }
        public static string leftSubstring(object str, int number)
        {
            if (str != null && number > 0 && str.ToString().Length > number)
                return "<span title=\"" + RemoveHTML(str.ToString()) + "\">" + str.ToString().Substring(0, number - 1) + "..</span>";
            else
                return str != null ? str.ToString() : "";
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="number"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string leftString(object str, int number, string color)
        {
            string thiscolor = "";
            if (color.Length > 0)
                thiscolor = "style='color:" + color + "'";
            if (number > 0 && str.ToString().Length > number)
                return "<span title='" + str.ToString() + "' " + thiscolor + ">" + str.ToString().Substring(0, number) + "..</span>";
            else
                return "<span title='" + str.ToString() + "' " + thiscolor + ">" + str.ToString() + "</span>";
        }
        public static string rightlength(object str, int number)
        {
            if (str != null && number > 0 && str.ToString().Length > number)
            {
                int left = str.ToString().Trim().Length - number;
                return "<span title='" + str.ToString() + "'>" + ".." + str.ToString().Substring(left, str.ToString().Trim().Length - left) + "</span>"; ;
            }
            else
                return str != null ? str.ToString() : "";
        }
        #endregion

        /// <summary>
        /// int泛型转换成用 , 隔开的string
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListChangeToString(List<int> list)
        {
            if (list == null || list.Count == 0)
                return "";

            string result = "";
            foreach (int i in list)
            {
                result += i + ",";
            }
            if (result.Length > 1)
                result = result.Remove(result.Length - 1);
            return result;
        }


        #region txt
        /// <summary>
        /// 写入txt日志
        /// </summary>
        /// <param name="content">写入内容</param>
        /// <param name="txturl">物理路径</param>
        /// <param name="file">文件名</param>
        public static void WriteTxt(string content, string txturl, string file)
        {
            try
            {
                if (!Directory.Exists(txturl))
                {
                    Directory.CreateDirectory(txturl);
                }
                StreamWriter sw = new StreamWriter(txturl + file, true, Encoding.UTF8);//c:\windows\system32\inetsrv\  日志路径
                //Stream instream = Request.InputStream;

                //BufferedStream buf = new BufferedStream(instream);
                //byte[] buffer = new byte[1024];

                sw.WriteLine(content);
                //sw.WriteLine("---------------------------------------------------------------------------------------------");
                sw.Flush();
                sw.Close();
                GC.Collect();
            }
            catch { }
        }
        /// <summary>
        /// 读取txt文件的内容
        /// </summary>
        /// <param name="txtfile">文件物理路径</param>
        /// <returns></returns>
        public static string ReadTxt(string txtfile)
        {
            string strout;
            strout = "";
            if (!File.Exists(txtfile))
            {
                return null;
            }
            else
            {
                StreamReader sr = new StreamReader(txtfile, System.Text.Encoding.Default);
                String input = sr.ReadToEnd();
                sr.Close();
                strout = input;
            }
            return strout;
        }

        #endregion

        #region   移除HTML标签
        /// <summary>
        /// 移除HTML标签
        /// </summary>
        /// <param name="HTMLStr"></param>
        /// <returns></returns>

        public static string RemoveHTML(string HTMLStr)
        {
            //string str = System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
            string str = Regex.Replace(HTMLStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            return str;
        }
        public static string NoHTML(string Htmlstring)  //替换HTML标记   
        { //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;

        }

        #endregion

        #region 图片
        /// <summary>
        /// 取出文本中的图片地址
        /// </summary>
        /// <param name="HTMLStr"></param>
        /// <returns></returns>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;

            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>", RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }



        //public static void goErr(string tm)
        //{
        //    if (!Common.Utility.ProcessSqlStr(tm))
        //        //this.Response.Redirect("/error.html");
        //        System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('您输入了非法字符，请重新输入！');history.back();</script>");

        //}

        /// <summary>
        /// 图片宽度
        /// </summary>
        /// <param name="strPath">物理路径</param>
        /// <returns></returns>
        public static int ImgWidth(string strPath)
        {
            System.Drawing.Image imageFile = System.Drawing.Image.FromFile(strPath);
            return imageFile.Width;
        }
        /// <summary>
        /// 图片高度
        /// </summary>
        /// <param name="strPath">物理路径</param>
        /// <returns></returns>
        public static int ImgHeight(string strPath)
        {
            System.Drawing.Image imageFile = System.Drawing.Image.FromFile(strPath);
            return imageFile.Height;
        }
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="strPath">物理路径</param>
        /// <returns></returns>
        public static long FileLength(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            return fi.Length;
        }
        /// <summary>
        /// 文件格式
        /// </summary>
        /// <param name="strPath">物理路径</param>
        /// <returns></returns>
        public static string ContentType(string strPath)
        {
            System.Drawing.Image imageFile = System.Drawing.Image.FromFile(strPath);
            return imageFile.RawFormat.ToString();
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径(物理路径)</param>
        /// <param name="thumbnailPath">缩略图路径(物理路径)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;


            //--------------------------新加
            string mode = "";

            if (ow > oh)
            {
                mode = "W";
            }
            else
            {
                mode = "H";
            }
            //-------------------------

            switch (mode)
            {
                case "HW"://指定高宽缩放(可能变形)                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减(不变形)                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        #endregion

        #region 文件
        /// <summary>
        /// 水印
        /// </summary>
        /// <param name="path">临时路径</param>
        /// <param name="fileName">要加水印的图片</param>
        /// <param name="type">类型1为文字水印,2为图片水印,其它为无水印</param>
        /// <param name="savepath">上传目标路径</param>
        public static void Watermark(string path, string fileName, short type, string savepath)
        {
            //string extension = Path.GetExtension(path + fileName); //获得文件的扩展名
            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(savepath)))
            //{
            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(savepath));
            //}
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(path + fileName);
                if (type == 1)
                {
                    //加文字水印
                    Graphics g = Graphics.FromImage(image);
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                    Font f = new Font("Verdana", 32);
                    Brush b = new SolidBrush(Color.White);
                    string addText = "winnie";
                    g.DrawString(addText, f, b, 10, 10);
                    g.Dispose();
                }
                if (type == 2)
                {
                    //加图片水印
                    System.Drawing.Image copyImage = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/images/Watermark.png"));
                    Graphics g = Graphics.FromImage(image);
                    g.DrawImage(copyImage, new Rectangle(image.Width - copyImage.Width - 10, image.Height - copyImage.Height - 10, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                    g.Dispose();
                }



                //保存加水印过后的图片,
                string newPath = savepath + fileName;// HttpContext.Current.Server.MapPath(savepath + fileName);
                image.Save(newPath);
                image.Dispose();

                //删除原始图片
                if (File.Exists(path + fileName))
                {
                    File.Delete(path + fileName);
                }
            }
            catch { }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileUrl">物理路径</param>
        public static void DeleteFile(string fileUrl)
        {
            if (File.Exists(fileUrl))
            {
                File.Delete(fileUrl);
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="downloadfile">文件物理路径</param>
        public static void download(string downloadfile)
        {
            FileInfo DownloadFile = new FileInfo(downloadfile);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(DownloadFile.Name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
            HttpContext.Current.Response.WriteFile(DownloadFile.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }

        ///<summary>  
        /// 加载XML文件        
        /// </summary>        
        /// <param name="xmlPath">XML文件所在地址</param>        
        /// <param name="nodalName">要读取节点的父节点名称</param>        
        /// <returns></returns>        
        public static XmlNode XmlRead(string xmlPath, string nodalName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlPath);
            XmlNode node = xmldoc.SelectSingleNode("//" + nodalName);
            return node;
        }

        #endregion


        #region 用递归方法删除文件夹目录及文件
        /// <summary>   
        /// 用递归方法删除文件夹目录及文件   
        /// </summary>   
        /// <param name="dir">带文件夹名的路径</param>    
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之    
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件                           
                    else
                        DeleteFolder(d); //递归删除子文件夹    
                }
                Directory.Delete(dir, true); //删除已空文件夹                    
            }
        }
        #endregion

        #region 日期转换

        /// <summary>
        /// 将分钟转换为时分的格式
        /// </summary>
        /// <param name="minutes">分钟</param>
        /// <returns></returns>
        public static string GetFormatTime(long minutes)
        {
            int day = (int)Math.Floor(Convert.ToDouble(minutes / 1440));
            if (day > 0)
                minutes = minutes - (day * 1440);

            long hour = (long)Math.Floor(Convert.ToDecimal(minutes / 60));
            if (hour > 0)
                minutes = minutes - (hour * 60);
            long minute = minutes;
            string time = "";
            //if (day > 0) time += day + "天";
            //if (hour > 0) time += hour + "小时";
            //if (minute > 0) time += minute + "分钟";
            if (day > 0) time += day + "天";
            if (hour > 0) time += hour + "小时";
            time += minute + "分钟";
            return time;
        }

        /// <summary>
        /// 将秒数转换为时分秒的格式
        /// </summary>
        /// <param name="data">秒数</param>
        /// <returns></returns>
        public static string GetFormatTime(string data)
        {
            long seconds;
            if (Int64.TryParse(data, out seconds))
            {
                //0的话,页面刷新,-100表示拍卖结束
                if (seconds <= 0) return data;
                long minutes = (int)Math.Floor(Convert.ToDouble(seconds / 60));
                seconds = seconds - minutes * 60;
                return GetFormatTime(minutes) + (seconds > 0 ? seconds + "秒" : "");
            }
            return data;
        }
        /// <summary>
        /// 时间刻度转换到小时
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string TimeSpanToHour(TimeSpan ts)
        {
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;
            if (days > 0)
                hours += days * 24;
            string result = (decimal)hours + Math.Round(((decimal)minutes / 60), 2) + "小时";
            return result;
        }
        /// <summary>
        /// 时间刻度转换成字符串
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string TimeSpanToString(TimeSpan ts)
        {
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;
            string result = "";
            if (days > 0)
                result += days + " ";
            result += "" + hours + ":";
            result += "" + minutes + ":";
            result += "" + seconds + "";
            return result;
        }
        /// <summary>
        /// 时间刻度转换成分钟
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static long TimeSpanToMinutes(TimeSpan ts)
        {
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;
            long result = 0;
            if (days > 0)
                result = result + (long)(days * 24 * 60);
            if (hours > 0)
                result = result + (long)(hours * 60);
            result = result + (long)minutes;
            return result;
        }
        #endregion

        #region 时间(星期)周
        /// <summary>
        /// 获取前N周的时间段
        /// </summary>
        /// <returns></returns>
        public static string[][] GetLastWeeks()
        {


            int arrleght = 5;
            string[][] arr = new string[arrleght][];
            DateTime now = DateTime.Now;

            int d = 0;
            for (int i = 0; i < arrleght; i++)
            {
                string[] inti = new string[2];

                int weeknow = Convert.ToInt32(now.DayOfWeek);
                weeknow = weeknow + d;
                DateTime thisweekStart = now.AddDays(-weeknow);
                DateTime thisweekEnd = thisweekStart.AddDays(6);
                //int daydiff = (-1) * weeknow + 1;
                //dtStart = Convert.ToDateTime(dt.AddDays(daydiff).ToShortDateString());
                //dtEnd = DateTime.Now;
                d = d + 7;

                inti[0] = thisweekStart.ToString("yyyy-MM-dd");
                inti[1] = thisweekEnd.ToString("yyyy-MM-dd");
                arr[i] = inti;
            }

            return arr;
        }
        #endregion


        #region 拼音字母转换
        #region 编码定义

        private static int[] pyvalue = new int[] 
        { 
        -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, 
        -20026, 
        -20002, -19990, -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, 
        -19741, -19739, -19728, 
        -19725, -19715, -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, 
        -19275, -19270, -19263, 
        -19261, -19249, -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, 
        -19006, -19003, -18996, 
        -18977, -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, 
        -18697, -18696, -18526, 
        -18518, -18501, -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, 
        -18201, -18184, -18183, 
        -18181, -18012, -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, 
        -17752, -17733, -17730, 
        -17721, -17703, -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, 
        -17427, -17417, -17202, 
        -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, 
        -16470, -16465, -16459, 
        -16452, -16448, -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, 
        -16216, -16212, -16205, 
        -16202, -16187, -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, 
        -15903, -15889, -15878, 
        -15707, -15701, -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, 
        -15435, -15419, -15416, 
        -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, 
        -15150, -15149, -15144, 
        -15143, -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, 
        -14930, -14929, -14928, 
        -14926, -14922, -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, 
        -14674, -14670, -14668, 
        -14663, -14654, -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, 
        -14345, -14170, -14159, 
        -14151, -14149, -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, 
        -14094, -14092, -14090, 
        -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, 
        -13847, -13831, -13658, 
        -13611, -13601, -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, 
        -13343, -13340, -13329, 
        -13326, -13318, -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, 
        -12888, -12875, -12871, 
        -12860, -12858, -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, 
        -12556, -12359, -12346, 
        -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, 
        -11798, -11781, -11604, 
        -11589, -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, 
        -11041, -11038, -11024, 
        -11020, -11019, -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, 
        -10533, -10519, -10331, 
        -10329, -10328, -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, 
        -10254 
        };

        private static string[] pystr = new string[] 
        { 
        "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", 
        "biao", 
        "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan" 
        , "chang", "chao", "che", "chen", 
        "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong" 
        , "cou", "cu", "cuan", "cui", 
        "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", "die", "ding", 
        "diu", "dong", "dou", "du", "duan", 
        "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", "fei", "fen", "feng", "fo", "fou", "fu", "ga" 
        , "gai", "gan", "gang", "gao", 
        "ge", "gei", "gen", "geng", "gong", "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo", 
        "ha", "hai", "han", "hang", 
        "hao", "he", "hei", "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", 
        "huo", "ji", "jia", "jian", 
        "jiang", "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan", 
        "kang", "kao", "ke", "ken", 
        "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan", 
        "lang", "lao", "le", "lei", 
        "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", "lv", 
        "luan", "lue", "lun", "luo", 
        "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", "miao", "mie", "min", 
        "ming", "miu", "mo", "mou", "mu", 
        "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", "neng", "ni", "nian", "niang", "niao", "nie", 
        "nin", "ning", "niu", "nong", 
        "nu", "nv", "nuan", "nue", "nuo", "o", "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", 
        "pi", "pian", "piao", "pie", 
        "pin", "ping", "po", "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", 
        "qu", "quan", "que", "qun", 
        "ran", "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa", 
        "sai", "san", "sang", 
        "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi", 
        "shou", "shu", "shua", 
        "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", 
        "suo", "ta", "tai", 
        "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", 
        "tui", "tun", "tuo", 
        "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao", 
        "xie", "xin", "xing", 
        "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", "ying", "yo", 
        "yong", "you", 
        "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", "zeng", "zha", "zhai" 
        , "zhan", "zhang", 
        "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", "zhuang", 
        "zhui", "zhun", "zhuo", 
        };
        #endregion

        #region 拼音处理

        /// <summary> 
        /// 将一串中文转化为拼音
        /// 如果给定的字符为非中文汉字将不执行转化，直接返回原字符；
        /// </summary> 
        /// <param name="chsstr">指定汉字</param> 
        /// <returns>拼音码</returns> 
        public static string ChsString2Spell(string chsstr)
        {
            string strRet = string.Empty;

            char[] ArrChar = chsstr.ToCharArray();

            foreach (char c in ArrChar)
            {
                strRet += SingleChs2Spell(c.ToString());
            }

            return strRet;
        }
        /// <summary> 
        /// 将一串中文转化为拼音
        /// </summary> 
        /// <param name="chsstr">指定汉字</param> 
        /// <returns>拼音首字母</returns> 
        public static string GetHeadOfChs(string chsstr)
        {
            string strRet = string.Empty;

            char[] ArrChar = chsstr.ToCharArray();

            foreach (char c in ArrChar)
            {
                strRet += GetHeadOfSingleChs(c.ToString());
            }

            return strRet;
        }

        /// <summary> 
        /// 单个汉字转化为拼音
        /// </summary> 
        /// <param name="SingleChs">单个汉字</param> 
        /// <returns>拼音</returns> 
        public static string SingleChs2Spell(string SingleChs)
        {
            byte[] array;
            int iAsc;
            string strRtn = string.Empty;

            array = Encoding.Default.GetBytes(SingleChs);

            try
            {
                iAsc = (short)(array[0]) * 256 + (short)(array[1]) - 65536;
            }
            catch
            {
                iAsc = 1;
            }

            if (iAsc > 0 && iAsc < 160)
                return SingleChs;

            for (int i = (pyvalue.Length - 1); i >= 0; i--)
            {
                if (pyvalue[i] <= iAsc)
                {
                    strRtn = pystr[i];
                    break;
                }
            }

            //将首字母转为大写
            if (strRtn.Length > 1)
            {
                strRtn = strRtn.Substring(0, 1).ToUpper() + strRtn.Substring(1);
            }

            return strRtn;
        }

        /// <summary> 
        /// 得到单个汉字拼音的首字母
        /// </summary> 
        /// <returns> </returns> 
        public static string GetHeadOfSingleChs(string SingleChs)
        {
            string result = SingleChs2Spell(SingleChs);
            return result.Length > 1 ? result.Substring(0, 1) : "";
        }
        #endregion

        #endregion
    }
}
