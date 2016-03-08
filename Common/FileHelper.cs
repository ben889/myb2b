using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Drawing;

namespace Common
{
    public class FileHelper
    {
        /// <summary>
        /// 图片单个上传
        /// </summary>
        /// <param name="file"></param>
        /// <param name="uploadFolder"></param>
        /// <param name="smallimgURL"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="Prefixed"></param>
        /// <param name="filename">返回的文件名</param>
        /// <returns></returns>
        public static bool UploadImgFile(System.Web.HttpPostedFile file, string uploadFolder, string smallimgURL
            , int width, int height
            , string Prefixed, ref string filename)
        {
            try
            {
                if (file == null || file.ContentLength == 0)
                {
                    return false;
                }

                if (uploadFolder.Trim().Length > 0 && !Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                if (smallimgURL.Trim().Length > 0 && !Directory.Exists(smallimgURL))
                {
                    Directory.CreateDirectory(smallimgURL);
                }

                string ContentType = file.ContentType.ToString();
                string FileName = file.FileName;

                string hz = "";
                if (FileName.IndexOf('.') != -1)
                    hz = FileName.Substring(FileName.LastIndexOf('.'), FileName.Length - FileName.LastIndexOf('.'));

                //if (FileName.IndexOf("\\") != -1)
                //    FileName = FileName.Replace("\"", "'").Substring(FileName.LastIndexOf("\\") + 1, FileName.Length - FileName.LastIndexOf("\\") - 1);
                FileName = Prefixed + System.Guid.NewGuid().ToString().Replace("-", "") + hz;

                int ContentLength = file.ContentLength;
                string GetType = file.GetType().ToString();
                string savePath = uploadFolder + FileName;
                file.SaveAs(savePath);
                filename = FileName;
                if (smallimgURL.Trim().Length > 0)
                    MakeThumbnail(savePath, smallimgURL + FileName, width, height);
                return true;
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 图片多个上传
        /// </summary>
        /// <param name="uploadFolder">上传的物理路径</param>
        /// <param name="Prefixed">文件名前辍</param>
        /// <param name="filenames">上传后的文件名</param>
        /// <returns></returns>
        public static bool UploadImgFiles(string uploadFolder, string Prefixed, ref List<string> filenames)
        {
            return UploadImgFiles(uploadFolder, "", 0, 0, Prefixed, ref filenames);
        }


        /// <summary>
        /// 图片多个上传
        /// </summary>
        /// <param name="uploadFolder">上传的物理路径</param>
        /// <param name="smallimgURL">缩略图路径(物理路径 如果为空则不压缩)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="Prefixed">文件名前辍</param>
        /// <param name="filenames">上传后的文件名</param>
        /// <returns></returns>
        public static bool UploadImgFiles(string uploadFolder, string smallimgURL, int width, int height
            , string Prefixed, ref List<string> filenames)
        {
            bool result = false;
            try
            {
                if (filenames == null)
                    filenames = new List<string>();

                HttpFileCollection files = HttpContext.Current.Request.Files;
                //string smallimgURL = uploadFolder;
                if (uploadFolder.Trim().Length > 0 && !Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                if (smallimgURL.Trim().Length > 0 && !Directory.Exists(smallimgURL))
                {
                    Directory.CreateDirectory(smallimgURL);
                }
                if (files.Count > 0)
                {
                    string path = uploadFolder;
                    //HttpPostedFile file = files[0];

                    for (int i = 0; i < files.Count; i++)
                    {
                        System.Web.HttpPostedFile file = files[i];

                        if (file == null || file.ContentLength == 0)
                        {
                            filenames.Add(file.FileName);
                            continue;
                        }
                        string ContentType = file.ContentType.ToString();
                        string FileName = file.FileName;

                        string hz = "";
                        if (FileName.IndexOf('.') != -1)
                            hz = FileName.Substring(FileName.LastIndexOf('.'), FileName.Length - FileName.LastIndexOf('.'));

                        //if (FileName.IndexOf("\\") != -1)
                        //    FileName = FileName.Replace("\"", "'").Substring(FileName.LastIndexOf("\\") + 1, FileName.Length - FileName.LastIndexOf("\\") - 1);
                        FileName = Prefixed + System.Guid.NewGuid().ToString().Replace("-", "") + hz;

                        int ContentLength = file.ContentLength;
                        string GetType = file.GetType().ToString();
                        string savePath = path + FileName;
                        file.SaveAs(savePath);
                        filenames.Add(FileName);
                        result = true;
                        if (smallimgURL.Trim().Length > 0)
                            MakeThumbnail(savePath, smallimgURL + FileName, width, height);
                        //bool ismake = Common.Library.MakeThumbnail(savePath, smallimgURL + filename, 500, 400);

                    }
                }

            }
            catch { }
            return result;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图(物理路径)</param>
        /// <param name="thumbnailPath">缩略图(物理路径)</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        public static bool MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {

            if (thumbnailPath.Trim().Length == 0)
            {
                return false;
            }
            if (originalImagePath.Trim().Length == 0)
            {
                return false;
            }

            bool result = true;

            Common.Library.WriteTxt("originalImagePath" + originalImagePath +
                "thumbnailPath" + thumbnailPath
                , HttpContext.Current.Server.MapPath("/log/"), "生成缩略图跟踪.txt");
            try
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
                int towidth = width;
                int toheight = height;

                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;
                if (ow < width || oh < height)
                {
                    File.Copy(originalImagePath, thumbnailPath);
                    originalImage.Dispose();
                    return true;
                }

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
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

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
                    result = false;
                    throw e;
                }
                finally
                {
                    originalImage.Dispose();
                    bitmap.Dispose();
                    g.Dispose();
                }
            }
            catch (Exception exc)
            {
                result = false;
                Common.Library.WriteTxt("生成出错！" + exc.Message, HttpContext.Current.Server.MapPath("/log/"), "生成缩略图跟踪.txt");
            }

            return result;
        }

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

            System.Drawing.Image image = System.Drawing.Image.FromFile(path + fileName);
            try
            {

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

            }
            catch
            {

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
        /// 文件单个上传
        /// </summary>
        /// <param name="file"></param>
        /// <param name="uploadFolder">上传的物理地址</param>
        /// <param name="Prefixed">文件名前辍</param>
        /// <param name="filename">返回的文件名</param>
        /// <returns></returns>
        public static bool UploadFile(System.Web.HttpPostedFile file, string uploadFolder, ref string filename, ref string resultMsg)
        {
            return UploadFile(file, uploadFolder, "", ref filename, ref resultMsg);
        }
        /// <summary>
        /// 文件单个上传
        /// </summary>
        /// <param name="file"></param>
        /// <param name="uploadFolder">上传的物理地址</param>
        /// <param name="Prefixed">文件名前辍</param>
        /// <param name="filename">返回的文件名</param>
        /// <returns></returns>
        public static bool UploadFile(System.Web.HttpPostedFile file, string uploadFolder, string Prefixed, ref string filename, ref string resultMsg)
        {
            try
            {
                if (file == null || file.ContentLength == 0)
                {
                    return false;
                }

                if (uploadFolder.Trim().Length > 0 && !Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }


                string ContentType = file.ContentType.ToString();
                string FileName = file.FileName;

                string hz = "";
                if (FileName.IndexOf('.') != -1)
                    hz = FileName.Substring(FileName.LastIndexOf('.'), FileName.Length - FileName.LastIndexOf('.'));

                if (filename.Trim().Length > 0)
                    FileName = filename + hz;

                //if (FileName.IndexOf("\\") != -1)
                //    FileName = FileName.Replace("\"", "'").Substring(FileName.LastIndexOf("\\") + 1, FileName.Length - FileName.LastIndexOf("\\") - 1);


                FileName = Prefixed + System.Guid.NewGuid().ToString().Replace("-", "") + hz;

                int ContentLength = file.ContentLength;
                string GetType = file.GetType().ToString();
                string savePath = uploadFolder + FileName;
                file.SaveAs(savePath);
                filename = FileName;
                return true;
            }
            catch (Exception e) { resultMsg = e.Message; }
            return false;
        }
    }
}
