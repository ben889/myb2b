using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //Users
    [Property("Users")]
    [Serializable]
    public class UserInfo
    {

        private int _userid;//UserID
        private string _username;//帐号
        private string _password = "";//密码
        private string _firstname = "";//姓
        private string _lastname = "";//名
        private string _email = "";//Email
        private string _displayname = "";//显示名称
        private string _lastipaddress = "";//上次登陆IP地址
        private bool _isdeleted;//是否已删除
        private int _createdbyuserid;//创建人
        private DateTime _createdondate;//创建时间
        private bool _islock;//是否被锁定
        private DateTime _lastlogindate;//上次登陆日期
        private string _comment = "";//备注
        private string _usertype = "";//UserType

        /// <summary>
        /// UserID
        /// </summary> 
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 帐号
        /// </summary> 
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 密码
        /// </summary> 
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// 姓
        /// </summary> 
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        /// <summary>
        /// 名
        /// </summary> 
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        /// <summary>
        /// Email
        /// </summary> 
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 显示名称
        /// </summary> 
        public string DisplayName
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        /// <summary>
        /// 上次登陆IP地址
        /// </summary> 
        public string LastIPAddress
        {
            get { return _lastipaddress; }
            set { _lastipaddress = value; }
        }
        /// <summary>
        /// 是否已删除
        /// </summary> 
        public bool IsDeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        /// <summary>
        /// 创建人
        /// </summary> 
        public int CreatedByUserID
        {
            get { return _createdbyuserid; }
            set { _createdbyuserid = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary> 
        public DateTime CreatedOnDate
        {
            get { return _createdondate; }
            set { _createdondate = value; }
        }
        /// <summary>
        /// 是否被锁定
        /// </summary> 
        public bool IsLock
        {
            get { return _islock; }
            set { _islock = value; }
        }
        /// <summary>
        /// 上次登陆日期
        /// </summary> 
        public DateTime LastLoginDate
        {
            get { return _lastlogindate; }
            set { _lastlogindate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary> 
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        /// <summary>
        /// UserType
        /// </summary> 
        public string UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

    }
}