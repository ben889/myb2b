using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //Companys
    [Property("Companys")]
    [Serializable]
    public class CompanysInfo
    {

        private int _companyid;//代理商表
        private string _username = "";//登陆帐号
        private string _password = "";//登录密码
        private string _companyname = "";//名称
        private string _contact = "";//联系人
        private string _phone = "";//电话
        private string _mobile = "";//手机
        private string _fax = "";//传真
        private string _address = "";//地址
        private DateTime _createtime;//创建时间
        private string _email = "";//Email
        private string _website = "";//网址
        private decimal _totalamount;//总金额
        private int _status;//状态0正常-1关闭
        private string _domain = "";//域名 www.aaa.com
        private string _qrcode = "";//二维码
        private string _wxqrcode = "";//微信二维码
        private string _lng = "";//经度
        private string _lat = "";//纬度
        private int _distid;//区域ID
        
        /// <summary>
        /// 代理商表
        /// </summary>
        [Property(ColumnTypes.Identity)]
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// 登陆帐号
        /// </summary>
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal totalamount
        {
            get { return _totalamount; }
            set { _totalamount = value; }
        }
        /// <summary>
        /// 状态0正常-1关闭
        /// </summary>
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 域名 www.aaa.com
        /// </summary>
        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        /// <summary>
        /// 二维码
        /// </summary>
        public string qrcode
        {
            get { return _qrcode; }
            set { _qrcode = value; }
        }
        /// <summary>
        /// 微信二维码
        /// </summary>
        public string wxqrcode
        {
            get { return _wxqrcode; }
            set { _wxqrcode = value; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int distid
        {
            get { return _distid; }
            set { _distid = value; }
        }
    }
}