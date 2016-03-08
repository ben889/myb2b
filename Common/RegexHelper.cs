using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 正则表达式
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool IsTel(string tel)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(tel, @"^(\d{3,4}-)?\d{6,8}$");

        }
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsMobile(string mobile)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^(13[0-9]|15[0-9]|18[0-9])\d{8}$");

        }
        /// <summary>
        /// 验证身份证号
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public static bool IsIDcard(string idcard)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(idcard, @"(^\d{18}$)|(^\d{15}$)");

        }

        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="str_number"></param>
        /// <returns></returns>
        public static bool IsNumber(string str_number)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");

        }

        /// <summary>
        /// 验证邮编
        /// </summary>
        /// <param name="str_postalcode"></param>
        /// <returns></returns>
        public static bool IsPostalcode(string str_postalcode)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");

        }

        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="str_Email"></param>
        /// <returns></returns>
        public static bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
        }

        /// <summary>
        /// 验证字母
        /// </summary>
        /// <param name="str_letters"></param>
        /// <returns></returns>
        public static bool IsLetters(string str_letters)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_letters, @"^[A-Za-z]+$");
        }


        /// <summary>
        /// 验证字母或者数字
        /// </summary>
        /// <param name="str_letters"></param>
        /// <returns></returns>
        public static bool IsLettersOrNumber(string str_letters)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_letters, @"^[A-Za-z0-9]+$");
        }
    }
}
