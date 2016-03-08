using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 随机码
    /// </summary>
    public class Randomcode
    {
        public static string CreateRandomNum(int NumCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
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
                int t = rand.Next(10);
                if (temp == t)
                {
                    return CreateRandomNum(NumCount);
                }
                temp = t;
                randomNum += allCharArray[t];
            }
            return randomNum;
        }
        public static string CreateRandomNum(int NumCount, int seed)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');//差分成数组
            string randomNum = "";
            int temp = -1;//记录上次随机数值的数值，尽量避免产生几个相同的随机数
            Random rand = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * seed);
                }
                int t = rand.Next(10);
                temp = t;
                randomNum += allCharArray[t];
            }
            return randomNum;
        }
    }
}
