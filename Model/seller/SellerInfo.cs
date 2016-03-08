using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //Seller
    [Property("Seller")]
    [Serializable]
    public class SellerInfo
    {

        private int _sellerid;//sellerid
        private string _uname;//uname
        private string _name = "";//name
        private string _address = "";//address
        private string _ctype = "";//公司类型
        private int _companyid;//所属物业
        private string _tel = "";//电话
        private string _fax = "";//传真
        private string _qq = "";//QQ
        private string _wx = "";//微信公众号
        private string _wxqrcode = "";//微信二维码
        private string _business = "";//主要经营范围
        private int _category_id;//分类ID
        private string _description = "";//description
        private string _sellerimg = "";//sellerimg
        private string _password = "";//password
        private int _orderby;
        private bool _recommend;//推荐
        private bool _islock;//是否锁定
        //private string _siteid = "";//代理商点ID
        private int _distid;//区域
        private string _lng = "";//经度
        private string _lat = "";//纬度
        private int _seller_type;//商家类型 0为区域商家 1为公共商家
        


        /// <summary>
        /// sellerid
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int sellerid
        {
            get { return _sellerid; }
            set { _sellerid = value; }
        }
        /// <summary>
        /// uname
        /// </summary>	

        public string uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        /// <summary>
        /// name
        /// </summary>	

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// address
        /// </summary>	

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 公司类型
        /// </summary>	

        public string ctype
        {
            get { return _ctype; }
            set { _ctype = value; }
        }
        /// <summary>
        /// 所属物业
        /// </summary>	

        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
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
        /// 传真
        /// </summary>	

        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// QQ
        /// </summary>	

        public string qq
        {
            get { return _qq; }
            set { _qq = value; }
        }
        /// <summary>
        /// 微信公众号
        /// </summary>	

        public string wx
        {
            get { return _wx; }
            set { _wx = value; }
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
        /// 主要经营范围
        /// </summary>	

        public string business
        {
            get { return _business; }
            set { _business = value; }
        }
        /// <summary>
        /// 分类ID
        /// </summary>	

        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }
        /// <summary>
        /// description
        /// </summary>	

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// sellerimg
        /// </summary>	

        public string sellerimg
        {
            get { return _sellerimg; }
            set { _sellerimg = value; }
        }
        /// <summary>
        /// password
        /// </summary>	

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        public bool recommend
        {
            get { return _recommend; }
            set { _recommend = value; }
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
        /// 代理商点ID
        /// </summary>
        //public string siteid
        //{
        //    get { return _siteid; }
        //    set { _siteid = value; }
        //}
        /// <summary>
        /// 区域
        /// </summary>
        public int distid
        {
            get { return _distid; }
            set { _distid = value; }
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
        /// 商家类型 0为区域商家 1为公共商家
        /// </summary>
        public int seller_type
        {
            get { return _seller_type; }
            set { _seller_type = value; }
        }
    }
}