using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Web;

namespace Common.ValidatedCode
{
    public class checkcode
    {
        //生成字符串：

        //CreateRandomNum(int NumCount)方法随机生成一个长度为NumCount的验证字符串。为了避免生成重复的随机数，这里通过变量记录随机数的结果，如果出现与上次随机数相同的数时，则调用函数本身，以保证生成不同的随机数：

        public string CreateRandomNum(int NumCount)
        {
            //string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            //int index = 35;

            string allChar0 = "0,1,2,3,4,5,6,7,8,9";
            string allChar1 = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string allChar2 = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

            string allChar = "0,1,2,3,4,5,6,7,8,9";
            int index = 10;
            Random source_rand = new Random();
            int source_index = source_rand.Next(3);
            if (source_index == 0)
            {
                allChar = allChar0;
                index = 10;
            }
            else if (source_index == 1)
            {
                allChar = allChar1;
                index = 26;
            }
            else if (source_index == 2)
            {
                allChar = allChar2;
                index = 26;
            }

            string[] allCharArray = allChar.Split(',');//差分成数组
            string randomNum = "";
            int temp = -1;//记录上次随机数值的数值，尽量避免产生几个相同的随机数
            Random rand = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(index);
                if (temp == t)
                {
                    return CreateRandomNum(NumCount);
                }
                temp = t;
                randomNum += allCharArray[t];
            }
            return randomNum;
        }

        //CreateImage(string validateNum)方法基于随机产生的字符串validateNum进一步生成图形码，为了进一步保证安全性，这里为图形码加了一些干扰色，如随机背景花纹、文字处理等。

        //生成图片
        public void CreateImage(string validateNum, HttpContext context)
        {
            if (validateNum == null || validateNum.Trim() == String.Empty)
                return;
            //生成bitmap图像
            Bitmap image = new Bitmap(validateNum.Length * 12 + 10, 24);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                g.Clear(Color.White);
                //画图片背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 2, 2);
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //将图像保存到指定的流
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
                //保存验证码
                //Session["validatecode"] = validateNum;
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}
