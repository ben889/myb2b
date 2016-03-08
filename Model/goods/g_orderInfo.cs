using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    [Property("g_order")]
    [Serializable]
    public class g_orderInfo
    {

        private int _orderid;//团购商品订单表
        private string _orderno;//订单号
        private long _uid;//帐号ID
        private int _goods_count;//商品数量
        private DateTime _createtime;//创建时间
        private int _goodsid;//商品ID
        private decimal _totalprice;//订单金额
        private decimal _pay_price;//实际支付金额
        private decimal _use_integral;//使用积分
        private int _sellerid;//商家ID
        private int _companyid;//代理商ID
        private bool _has_evalua;//是否已评价
        private int _status;//订单状态 0为未付 -1作废 -2支付失败 1已付
        private int _ordertype;//订单类型，1为体验卷，2为付费商品
        private bool _isExcep;//是否是异常
        private string _excep_remark = "";//异常备注
        private string _transaction_id = "";//交易ID 关联第三方交易号
        private int _payment;//支付方式 0为现金支付 1为微信付，2为支付宝支付

        /// <summary>
        /// 团购商品订单表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderno
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        /// <summary>
        /// 帐号ID
        /// </summary>
        public long uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int goods_count
        {
            get { return _goods_count; }
            set { _goods_count = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goodsid
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal totalprice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }
        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal pay_price
        {
            get { return _pay_price; }
            set { _pay_price = value; }
        }
        /// <summary>
        /// 使用积分
        /// </summary>
        public decimal use_integral
        {
            get { return _use_integral; }
            set { _use_integral = value; }
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public int sellerid
        {
            get { return _sellerid; }
            set { _sellerid = value; }
        }
        /// <summary>
        /// 代理商ID
        /// </summary>
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// 是否已评价
        /// </summary>
        public bool has_evalua
        {
            get { return _has_evalua; }
            set { _has_evalua = value; }
        }
        /// <summary>
        /// 订单状态 0为未付 -1作废 -2支付失败 1已付
        /// </summary>
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 订单类型，1为体验卷，2为付费商品
        /// </summary>
        public int ordertype
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }
        /// <summary>
        /// 是否是异常
        /// </summary>
        public bool isExcep
        {
            get { return _isExcep; }
            set { _isExcep = value; }
        }
        /// <summary>
        /// 异常备注
        /// </summary>
        public string excep_remark
        {
            get { return _excep_remark; }
            set { _excep_remark = value; }
        }
        /// <summary>
        /// 交易ID 关联第三方交易号
        /// </summary>
        public string transaction_id
        {
            get { return _transaction_id; }
            set { _transaction_id = value; }
        }
        /// <summary>
        /// 支付方式 0为现金支付 1为微支付 
        /// </summary>	
        public int payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
    }
}