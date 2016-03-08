using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //member_CashRecord
    [Property("member_CashRecord")]
    [Serializable]
    public class member_CashRecordInfo
    {

        private long _id;//Id
        private long _uid;//会员ID
        private int _way;//赠送方式 1增加2减少
        private decimal _amount;//金额
        private string _reamrk = "";//备注
        private string _companyid="";//CompanyId
        private DateTime _createtime;//CreateTime
        private decimal _balance;//可用余额
        private string _orderid = "";//所属订单
        private int _source_level;//来源第几级
       

        /// <summary>
        /// Id
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        public long uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// 赠送方式 1增加2减少
        /// </summary>
        public int way
        {
            get { return _way; }
            set { _way = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Reamrk
        {
            get { return _reamrk; }
            set { _reamrk = value; }
        }
        /// <summary>
        /// CompanyId
        /// </summary>
        public string CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
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
        /// 可用余额
        /// </summary>
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        /// <summary>
        /// 所属订单
        /// </summary>
        public string orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// 来源第几级
        /// </summary>
        public int source_level
        {
            get { return _source_level; }
            set { _source_level = value; }
        }
    }
}