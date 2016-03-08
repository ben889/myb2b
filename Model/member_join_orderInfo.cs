using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 会员入会支付订单
    /// </summary>
    [Property("member_join_order")]
    [Serializable]
    public class member_join_orderInfo
    {

        private string _orderid;//OrderId
        private string _mobile = "";//Mobile
        private decimal _amount;//Amount
        private decimal _pay_amount;//支付金额
        private decimal _use_integral;//使用余额
        private DateTime _createtime;//CreateTime
        private DateTime _pay_time;//支付时间
        private long _recharge_uid;//充值人(如为空则游客充值)
        private int _orderstatus;//订单状态 0为未付 -1作废 1已付 -2支付失败
        private int _payment;//支付方式 1微信支付2为支付宝
        private bool _isexce;//isExce
        private string _exce_remark = "";//Exce_remark
        private string _transaction_id = "";//交易ID 关联第三方交易号
        private string _remark = "";//备注
        private string _companyid = "";//companyid
        private int _type;//充值类型 1为充流量，2为充话费
        private decimal _recharge_amount;//Recharge_amount
        private string _recharge_result = "";//充值结果
        private string _recharge_result_remark = "";//Recharge_result_Remark

        /// <summary>
        /// OrderId
        /// </summary>
        [Property(ColumnTypes.Identity)]
        public string OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// Mobile
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal pay_amount
        {
            get { return _pay_amount; }
            set { _pay_amount = value; }
        }
        /// <summary>
        /// 使用余额
        /// </summary>
        public decimal use_integral
        {
            get { return _use_integral; }
            set { _use_integral = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime pay_time
        {
            get { return _pay_time; }
            set { _pay_time = value; }
        }
        /// <summary>
        /// 充值人(如为空则游客充值)
        /// </summary>
        public long recharge_uid
        {
            get { return _recharge_uid; }
            set { _recharge_uid = value; }
        }
        /// <summary>
        /// 订单状态 0为未付 -1作废 1已付 -2支付失败
        /// </summary>
        public int orderstatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }
        /// <summary>
        /// 支付方式 1微信支付2为支付宝
        /// </summary>
        public int payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
        /// <summary>
        /// isExce
        /// </summary>
        public bool isExce
        {
            get { return _isexce; }
            set { _isexce = value; }
        }
        /// <summary>
        /// Exce_remark
        /// </summary>
        public string Exce_remark
        {
            get { return _exce_remark; }
            set { _exce_remark = value; }
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
        /// 备注
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// companyid
        /// </summary>
        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// 充值类型
        /// </summary>
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Recharge_amount
        /// </summary>
        public decimal Recharge_amount
        {
            get { return _recharge_amount; }
            set { _recharge_amount = value; }
        }
        /// <summary>
        /// 充值结果
        /// </summary>
        public string Recharge_result
        {
            get { return _recharge_result; }
            set { _recharge_result = value; }
        }
        /// <summary>
        /// Recharge_result_Remark
        /// </summary>
        public string Recharge_result_Remark
        {
            get { return _recharge_result_remark; }
            set { _recharge_result_remark = value; }
        }

    }
}