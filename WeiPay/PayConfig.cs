﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiPay
{
    /**
     * 
     * 作用：微信支付公用参数，微信支付版本V3.3.7
     * 作者：邹学典
     * 编写日期：2014-12-25
     * 备注：请正确填写相关参数
     * 
     * */
    public   class PayConfig
    {
        /// <summary>
        /// 人民币
        /// </summary>
        public static string Tenpay = "1"; 
   
        /// <summary>
        /// mchid ， 微信支付商户号
        /// </summary>
        //public static string MchId = ""; //1244329802

        /// <summary>
        /// appid，应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        //public static string AppId = "";//wxfd89e38cbbb15c6d

        /// <summary>
        /// appsecret ，应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        //public static string AppSecret = ""; //b86fb09854ac029e196674800c3c6e4b
      
        /// <summary>
        /// paysignkey，API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
        /// </summary>
        //public static string AppKey = "";//kangyuankangyuan1111111111111111


        //static string host = "http://m.carnoy.cc";

        /// <summary>
        /// 支付起点页面地址，也就是send.aspx页面完整地址
        /// 用于获取用户OpenId，支付的时候必须有用户OpenId，如果已知可以不用设置
        /// </summary>
        public static string SendUrl = "/mobile/weixinpay/send.aspx";



        

        /// <summary>
        /// 支付页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 注意目录的层次，比如我的：http://zousky.com/WXPay/
        /// </summary>
        //public static string PayUrl = host + "/mobile/weixinpay/weipay.aspx";
        
        /// <summary>
        ///  支付通知页面，请注意测试阶段设置授权目录，在微信公众平台中“微信支付”---“开发配置”--修改测试目录   
        /// 支付完成后的回调处理页面,替换成notify_url.asp所在路径
        /// </summary>
        public static string NotifyUrl = "/mobile/weixinpay/notify.aspx"; 


    }
}
