using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //wx_diymenu
    [Property("wx_diymenu")]
    [Serializable]
    public class wx_diymenuInfo
    {

        private int _menuid;//MenuId
        private string _name;//Name
        private int _parentid;//ParentId
        private int _refid;//关联Id
        private int _reftype;//类型：0自定义链接， 1文字，2图片，3图文，4音频，5视频
        private string _body = "";//正文
        private string _url = "";//自定义链接url
        private int _sort;//排序
        private int _state;//是否可用：1可用，0不可用
        private DateTime _createtime;//创建时间
        private string _companyid="";//companyid

        /// <summary>
        /// MenuId
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// ParentId
        /// </summary>
        public int ParentId
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 关联Id：
        /// </summary>
        public int RefID
        {
            get { return _refid; }
            set { _refid = value; }
        }
        /// <summary>
        /// 类型： 0自定义链接， 1文字，2图片，3图文，4音频，5视频
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
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// 是否可用：1可用，0不可用
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
        /// <summary>
        /// companyid
        /// </summary>
        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

    }
}