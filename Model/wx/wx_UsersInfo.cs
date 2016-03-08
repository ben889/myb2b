using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //wx_Users
    [Property("wx_Users")]
    [Serializable]
    public class wx_UsersInfo
    {

        private int _wx_userid;//微信用户表(粉丝表)
        private string _openid = "";//OpenId
        private string _nickname = "";//昵称
        private string _head = "";//用户头像
        private string _qrcode = "";//二维码
        private int _sex;//姓别
        private int _state;//是否可用，1可用，0不可用
        private string _lng;//经度
        private string _lat;//纬度
        private DateTime _lasttime;//最后登录时间
        private DateTime _createtime;//创建时间
        private int _sourcetype;//用户来源：1平台自然发展，2分销商发展
        private string _sourceid = "";//用户来源ID：SourceType=1时为0，SourceType=2时为分销商iD
        private string _companyid = "";



        /// <summary>
        /// 微信用户表(粉丝表)
        /// </summary> 
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int wx_userid
        {
            get { return _wx_userid; }
            set { _wx_userid = value; }
        }
        /// <summary>
        /// OpenId
        /// </summary> 
        public string OpenId
        {
            get { return _openid; }
            set { _openid = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary> 
        public string NickName
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// 用户头像
        /// </summary> 
        public string Head
        {
            get { return _head; }
            set { _head = value; }
        }
        /// <summary>
        /// 二维码
        /// </summary> 
        public string QRCode
        {
            get { return _qrcode; }
            set { _qrcode = value; }
        }
        /// <summary>
        /// 姓别
        /// </summary> 
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// 是否可用，1可用，0不可用
        /// </summary> 
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 经度
        /// </summary> 
        public string Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary> 
        public string Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary> 
        public DateTime LastTime
        {
            get { return _lasttime; }
            set { _lasttime = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary> 
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 用户来源：1平台自然发展，2分销商发展
        /// </summary> 
        public int SourceType
        {
            get { return _sourcetype; }
            set { _sourcetype = value; }
        }
        /// <summary>
        /// 用户来源ID
        /// </summary> 
        public string SourceID
        {
            get { return _sourceid; }
            set { _sourceid = value; }
        }
        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
    }
}