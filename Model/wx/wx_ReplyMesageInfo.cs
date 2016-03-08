using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 自动回复规则表
    /// </summary>
    [Property("wx_ReplyMesage")]
    [Serializable]
    public class wx_ReplyMesageInfo
    {

        private int _replyid;//自动回复规则表
        private string _name = "";//规则名称
        private int _replytype;//回复类型：1被添加回复，2关键字回复
        private int _refid;//关联Id：1为0,2-5素材ID，6-7页面ID，8为0
        private int _reftype;//类型： 1文字，2图片，3图文，4音频，5视频
        private string _body = "";//正文
        private string _url = "";//自定义链接url
        private int _state;//是否可用：0否，1是
        private DateTime _createtime;//创建时间
        private string _companyid="";

        /// <summary>
        /// 自动回复规则表
        /// </summary> 
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
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
        /// 回复类型：1被添加回复，2关键字回复
        /// </summary> 
        public int ReplyType
        {
            get { return _replytype; }
            set { _replytype = value; }
        }
        /// <summary>
        /// 关联Id：1为0,2-5素材ID，6-7页面ID，8为0
        /// </summary> 
        public int RefID
        {
            get { return _refid; }
            set { _refid = value; }
        }
        /// <summary>
        /// 类型： 1文字，2图片，3图文，4音频，5视频
        /// </summary> 
        public int RefType
        {
            get { return _reftype; }
            set { _reftype = value; }
        }
        /// <summary>
        /// 正文
        /// </summary> 
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        /// <summary>
        /// 自定义链接url
        /// </summary> 
        public string URL
        {
            get { return _url; }
            set { _url = value; }
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