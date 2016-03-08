using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 消费评价表
    /// </summary>
    [Property("g_order_evaluation")]
    [Serializable]
    public class g_order_evaluationInfo
    {

        private int _evalua_id;//消费评价表
        private string _orderno;//orderno
        private int _goodsid;//商品ID

        
        private int _evalua;//评价0很差1差2一般3满意4很满意
        private uint _score;//评分
        private string _evalua_content = "";//评价内容
        private DateTime _createtime;//createtime
        private long _uid;//评价人

        /// <summary>
        /// 消费评价表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int evalua_id
        {
            get { return _evalua_id; }
            set { _evalua_id = value; }
        }
        /// <summary>
        /// orderno
        /// </summary>
        public string orderno
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        public int goodsid
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// 评价0很差1差2一般3满意4很满意
        /// </summary>
        public int evalua
        {
            get { return _evalua; }
            set { _evalua = value; }
        }
        /// <summary>
        /// 评分
        /// </summary>
        public uint score
        {
            get { return _score; }
            set { _score = value; }
        }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string evalua_content
        {
            get { return _evalua_content; }
            set { _evalua_content = value; }
        }
        /// <summary>
        /// createtime
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 评价人
        /// </summary>
        public long uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

    }
}