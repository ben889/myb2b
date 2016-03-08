using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.auth
{
    public class auth
    {
        public static string DES_Key = "zhsq8888";


        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="signinfo">签名内容</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        public bool check_user_requset(string signinfo, string sign)
        {
            string md5signinfo = MD5(signinfo);
            return sign.Equals(md5signinfo);
        }

        public string createToken(string uid)
        {
            return Des.DESEnCode(uid + "_" + getTimestamp(), DES_Key);
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        public static string getTimestamp()
        {
            //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds).ToString();
            return DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
        }

        public static String MD5(String str)
        {
            byte[] result = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder output = new StringBuilder(16);
            for (int i = 0; i < result.Length; i++)
            {
                // convert from hexa-decimal to character  
                output.Append((result[i]).ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
            }
            return output.ToString();
        } 


        //java MD5算法
        //    public final static String md5(String s) {  
        //char hexDigits[] = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',  
        //        'a', 'b', 'c', 'd', 'e', 'f' };  
        //try {  
        //    byte[] strTemp = s.getBytes();  
        //    MessageDigest mdTemp = MessageDigest.getInstance("MD5");  
        //    mdTemp.update(strTemp);  
        //    byte[] md = mdTemp.digest();  
        //    int j = md.length;  
        //    char str[] = new char[j * 2];  
        //    int k = 0;  
        //    for (int i = 0; i < j; i++) {  
        //        byte byte0 = md[i];  
        //        str[k++] = hexDigits[byte0 >>> 4 & 0xf];  
        //        str[k++] = hexDigits[byte0 & 0xf];  
        //    }  
        //    return new String(str);  
        //} catch (Exception e) {  
        //    e.printStackTrace();  
        //    return null;  
        //}  
        //} 
    }
}
