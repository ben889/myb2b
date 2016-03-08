using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //Companys_PayConfig
    [Property("Companys_PayConfig")]
    [Serializable]
    public class Companys_PayConfigInfo
    {

        private string _companyid;//CompanyId
        private string _mchid = "";//微信支付商户号
        private string _appid = "";//应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        private string _appsecret = "";//应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        private string _appkey = "";//API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
        private string _token = "7rg2015";//开发者填写的token



        /// <summary>
        /// CompanyId
        /// </summary>	
        [Property(ColumnTypes.Identity)]
        public string CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// 微信支付商户号
        /// </summary>	

        public string MchId
        {
            get { return _mchid; }
            set { _mchid = value; }
        }
        /// <summary>
        /// 应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>	

        public string AppId
        {
            get { return _appid; }
            set { _appid = value; }
        }
        /// <summary>
        /// 应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>	

        public string AppSecret
        {
            get { return _appsecret; }
            set { _appsecret = value; }
        }
        /// <summary>
        /// API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
        /// </summary>	

        public string AppKey
        {
            get { return _appkey; }
            set { _appkey = value; }
        }
        [Property(ColumnTypes.Read)]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

    }
}