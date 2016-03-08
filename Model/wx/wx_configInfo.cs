using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //wx_config
    [Property("wx_config")]
    [Serializable]
    public class wx_configInfo
    {

        private int _wxconfigid;//微信参数配置
        private string _mchid = "";//MchId
        private string _appid = "";//AppId
        private string _appsecret = "";//AppSecret
        private string _appkey = "";//AppKey
        private string _token = "aishuile";//Token

        /// <summary>
        /// 微信参数配置
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int wxConfigId
        {
            get { return _wxconfigid; }
            set { _wxconfigid = value; }
        }
        /// <summary>
        /// MchId
        /// </summary>
        public string MchId
        {
            get { return _mchid; }
            set { _mchid = value; }
        }
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId
        {
            get { return _appid; }
            set { _appid = value; }
        }
        /// <summary>
        /// AppSecret
        /// </summary>
        public string AppSecret
        {
            get { return _appsecret; }
            set { _appsecret = value; }
        }
        /// <summary>
        /// AppKey
        /// </summary>
        public string AppKey
        {
            get { return _appkey; }
            set { _appkey = value; }
        }
        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

    }
}