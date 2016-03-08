using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.IO;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Common;
namespace Common.QRCode
{


    /// <summary>
    /// 二维码处理类
    /// </summary>
    public class QRCodeHandler
    {
        /// <summary>
        /// 二维码生成
        /// </summary>
        /// <param name="logoFilePath">logo物理路路径</param>
        /// <param name="qrString">二维码字符串 如 http://www.baidu.com</param>
        /// <param name="filename">二维码文件名</param>
        /// <param name="ForegroundColor">前景色十六进制颜色 如 #ffffff 如为空则为默认色</param>
        /// <param name="Dir">保存路径(相对路径)</param>
        /// <returns></returns>
        public bool CreateQRCode(string logoFilePath, string qrString, string filename, string ForegroundColor, string Dir)
        {
            try
            {
                QRCodeHandler qr = new QRCodeHandler();
                //string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @URL_userfiles+"QRCode/";    //文件目录  
                //string qrString = "http://www.hao123.com";                         //二维码字符串  
                //string logoFilePath = path + "myLogo.jpg";                                    //Logo路径50*50  
                //string filePath = path + "myCode.jpg";                                        //二维码文件名  
                bool hasLogo = false;
                if (logoFilePath.Trim().Length > 0)
                    hasLogo = true;
                if (Dir.Trim().Length > 0 && !Directory.Exists(HttpContext.Current.Server.MapPath(Dir)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(Dir));
                }
                if (File.Exists(HttpContext.Current.Server.MapPath(Dir) + filename))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(Dir) + filename);
                }
                return qr.CreateQRCode(qrString, "Byte", 5, 0, "H"
                    , HttpContext.Current.Server.MapPath(Dir) + filename
                    , hasLogo
                    , logoFilePath, ForegroundColor);   //生成  
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="QRString">二维码字符串</param>
        /// <param name="QRCodeEncodeMode">二维码编码(Byte、AlphaNumeric、Numeric)</param>
        /// <param name="QRCodeScale">二维码尺寸(Version为0时，1：26x26，每加1宽和高各加25</param>
        /// <param name="QRCodeVersion">二维码密集度0-40</param>
        /// <param name="QRCodeErrorCorrect">二维码纠错能力(L：7% M：15% Q：25% H：30%)</param>
        /// <param name="filePath">保存路径</param>
        /// <param name="hasLogo">是否有logo(logo尺寸50x50，QRCodeScale>=5，QRCodeErrorCorrect为H级)</param>
        /// <param name="logoFilePath">logo路径</param>
        /// <param name="ForegroundColor">前景色十六进制颜色 如 #ffffff 如为空则为默认色</param>
        /// <returns></returns>
        public bool CreateQRCode(string QRString, string QRCodeEncodeMode, short QRCodeScale, int QRCodeVersion
            , string QRCodeErrorCorrect, string filePath, bool hasLogo, string logoFilePath, string ForegroundColor)
        {
            bool result = true;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            switch (QRCodeEncodeMode)
            {
                case "Byte":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
                case "AlphaNumeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                    break;
                case "Numeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                    break;
                default:
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
            }

            qrCodeEncoder.QRCodeScale = QRCodeScale;
            qrCodeEncoder.QRCodeVersion = QRCodeVersion;

            switch (QRCodeErrorCorrect)
            {
                case "L":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    break;
                case "M":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    break;
                case "Q":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                    break;
                case "H":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
                default:
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
            }

            try
            {
                if (ForegroundColor.Trim().Length > 0)
                {
                    System.Drawing.Color color = ColorTranslator.FromHtml(ForegroundColor);
                    qrCodeEncoder.QRCodeForegroundColor = color;
                }
                Image image = qrCodeEncoder.Encode(QRString, System.Text.Encoding.UTF8);
                

                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();

                if (hasLogo && logoFilePath.Trim().Length > 0)
                {
                    Image copyImage = System.Drawing.Image.FromFile(logoFilePath);
                    Graphics g = Graphics.FromImage(image);
                    int x = image.Width / 2 - copyImage.Width / 2;
                    int y = image.Height / 2 - copyImage.Height / 2;
                    g.DrawImage(copyImage, new Rectangle(x, y, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                    g.Dispose();

                    image.Save(filePath);

                    addlogoborder(image, filePath);
                    copyImage.Dispose();
                }
                image.Dispose();

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        private void addlogoborder(Image image, string filePath)
        {
            if (filePath.Trim().Length <= 0)
                return;
            string logoborder = HttpContext.Current.Server.MapPath("/users/images/QRCode_LogoBorder.png");
            Image copyImage = System.Drawing.Image.FromFile(logoborder);
            Graphics g = Graphics.FromImage(image);
            int x = image.Width / 2 - copyImage.Width / 2;
            int y = image.Height / 2 - copyImage.Height / 2;
            g.DrawImage(copyImage, new Rectangle(x, y, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(filePath);
            //copyImage.Dispose();
        }
    }
}