using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Common
{
    public static class EnumHelper
    {
        /// <summary> 
        /// 获得枚举类型数据项（不包括空项）
        /// </summary> 
        /// <param name="enumType">枚举类型</param> 
        /// <returns></returns> 
        public static IList<object> GetItems(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException();

            IList<object> list = new List<object>();

            // 获取Description特性 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获取枚举字段
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                    continue;

                // 获取枚举值
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);

                // 不包括空项
                if (value > 0)
                {
                    string text = string.Empty;
                    object[] array = field.GetCustomAttributes(typeDescription, false);

                    if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                    else text = field.Name; //没有描述，直接取值

                    //添加到列表
                    list.Add(new { Value = value, Text = text });
                }
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getItems(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException();

            //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> dc = new Dictionary<string, string>();
            // 获取Description特性 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获取枚举字段
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                    continue;

                // 获取枚举值
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);

                // 不包括空项
                //if (value > 0)
                //{
                //    string text = string.Empty;
                //    object[] array = field.GetCustomAttributes(typeDescription, false);
                //    if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                //    else text = field.Name; //没有描述，直接取值
                //    dc.Add(value.ToString(), text);
                //}

                string text = string.Empty;
                object[] array = field.GetCustomAttributes(typeDescription, false);
                if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                else text = field.Name; //没有描述，直接取值
                dc.Add(value.ToString(), text);
            }
            return dc;
        }


        public static Dictionary<string, string> getItemstr(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException();

            //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> dc = new Dictionary<string, string>();
            // 获取Description特性 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获取枚举字段
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                    continue;

                // 获取枚举值
                string value = enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null).ToString();

                // 不包括空项
                //if (value > 0)
                //{
                //    string text = string.Empty;
                //    object[] array = field.GetCustomAttributes(typeDescription, false);
                //    if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                //    else text = field.Name; //没有描述，直接取值
                //    dc.Add(value.ToString(), text);
                //}

                string text = string.Empty;
                object[] array = field.GetCustomAttributes(typeDescription, false);
                if (array.Length > 0) text = ((DescriptionAttribute)array[0]).Description;
                else text = field.Name; //没有描述，直接取值
                dc.Add(value.ToString(), text);
            }
            return dc;
        }

        ///<summary>  
        /// 根据枚举类型获取描述  
        ///</summary>  
        ///<param name="enumSubitem">类型</param>  
        ///<returns>描述</returns>  
        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value  
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        ///<summary>  
        /// 根据枚举类型获取描述  
        ///</summary>  
        ///<param name="enumSubitem">类型</param>  
        ///<param name="val"></param>  
        ///<returns>描述</returns>  
        public static string GetEnumDescription(this Type enumType, int val)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException();
            Dictionary<string, string> dc = new Dictionary<string, string>();
            // 获取Description特性 
            Type typeDescription = typeof(DescriptionAttribute);
            // 获取枚举字段
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                    continue;

                // 获取枚举值
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                if (value == val)
                {
                    object[] array = field.GetCustomAttributes(typeDescription, false);
                    return ((DescriptionAttribute)array[0]).Description;
                }
            }
            return "";
        }
    }
}
