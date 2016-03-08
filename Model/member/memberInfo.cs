using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //member
    [Property("member")]
    [Serializable]
    public class memberInfo
    {

        private long _uid;//会员表
        private string _uname;//用户名
        private string _password;//密码
        private int _vip;//等级
        private int _utype;//会员类型
        private bool _isdeleted;//是否已删除
        private DateTime _addtime;//注册时间
        private bool _islock;//是否锁定
        private string _displayname = "";//姓名
        private string _email = "";//邮箱
        private string _mobile = "";//手机
        private string _tel = "";//电话
        private decimal _balance;//可用金额
        private long _parentid;//parentid
        private string _identitycard = "";//身份证
        private string _address = "";//地址
        private string _nickname = "";//呢称
        private decimal _integral;//可用积分
        private string _openid = "";

        
        /// <summary>
        /// 会员表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public long uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int vip
        {
            get { return _vip; }
            set { _vip = value; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public int utype
        {
            get { return _utype; }
            set { _utype = value; }
        }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool islock
        {
            get { return _islock; }
            set { _islock = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string displayname
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// 可用金额
        /// </summary>
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        /// <summary>
        /// parentid
        /// </summary>
        public long parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string identitycard
        {
            get { return _identitycard; }
            set { _identitycard = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 呢称
        /// </summary>
        public string nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// 可用积分
        /// </summary>
        public decimal integral
        {
            get { return _integral; }
            set { _integral = value; }
        }
        public string openid
        {
            get { return _openid; }
            set { _openid = value; }
        }
    }
}