using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 兑换表()
    /// </summary>
    [Property("goodsExch")]
    [Serializable]
    public class goodsExchInfo
    {

        private int _exchid;//兑换表
        private DateTime _createtime;//createTime
        private string _sequence = "";//序列号
        private int _orderid;//订单ID
        private int _goodsid;//商品ID
        private string _exchname = "";//兑换人姓名
        private string _exchtel = "";//联系电话
        private string _exchaddress = "";//收货地址
        private string _exchzipcode = "";//邮编
        private int _status;//总换状态0未使用1为已使用-1作废
        private int? _sellerid;//商家ID
        private string _ExchTime="";//兑换时间
        
        

        /// <summary>
        /// 兑换表
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int ExchId
        {
            get { return _exchid; }
            set { _exchid = value; }
        }
        /// <summary>
        /// createTime
        /// </summary>	
        public DateTime createTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 序列号
        /// </summary>	
        public string Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>	
        public int orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
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
        /// 兑换人姓名
        /// </summary>	
        public string ExchName
        {
            get { return _exchname; }
            set { _exchname = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>	
        public string ExchTel
        {
            get { return _exchtel; }
            set { _exchtel = value; }
        }
        /// <summary>
        /// 收货地址
        /// </summary>	
        public string ExchAddress
        {
            get { return _exchaddress; }
            set { _exchaddress = value; }
        }
        /// <summary>
        /// 邮编
        /// </summary>	
        public string ExchZipCode
        {
            get { return _exchzipcode; }
            set { _exchzipcode = value; }
        }
        /// <summary>
        /// 总换状态0未使用1为已使用-1作废
        /// </summary>	
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int? sellerid
        {
            get { return _sellerid; }
            set { _sellerid = value; }
        }
        /// <summary>
        /// 兑换时间
        /// </summary>
        public string ExchTime
        {
            get { return _ExchTime; }
            set { _ExchTime = value; }
        }
    }
}