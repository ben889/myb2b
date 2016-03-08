using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 自动回复关键字表
    /// </summary>
    [Property("wx_ReplyKey")]
    [Serializable]
    public class wx_ReplyKeyInfo
    {

        private int _wx_replykeyid;//自动回复关键字表
        private int _replyid;//自动回复规则ID
        private string _name;//规则名称
        private int _wx_replykeytype;//匹配方式：1全匹配，2模糊匹配
        private int _state;//是否可用：0否，1是
        private DateTime _createtime;//创建时间
        private string _companyid="";

        /// <summary>
        /// 自动回复关键字表
        /// </summary> 
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int wx_ReplyKeyID
        {
            get { return _wx_replykeyid; }
            set { _wx_replykeyid = value; }
        }
        /// <summary>
        /// 自动回复规则ID
        /// </summary> 
        public int ReplyID
        {
            get { return _replyid; }
            set { _replyid = value; }
        }
        /// <summary>
        /// 规则名称
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 匹配方式：1全匹配，2模糊匹配
        /// </summary> 
        public int wx_ReplyKeyType
        {
            get { return _wx_replykeytype; }
            set { _wx_replykeytype = value; }
        }
        /// <summary>
        /// 是否可用：0否，1是
        /// </summary> 
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary> 
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
    }
}