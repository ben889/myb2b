using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //wx_Material
    [Property("wx_Material")]
    [Serializable]
    public class wx_MaterialInfo
    {

        private int _wx_materialid;//素材表id
        private string _name = "";//名称
        private int _parentid;//父级id
        private int _type;//类型（ 1文字，2图片，3图文，4音频，5视频）
        private string _author = "";//作者
        private string _paper = "";//摘要
        private string _body = "";//正文
        private string _imgurl = "";//封面图
        private string _url = "";//原文链接
        private DateTime _createtime;//创建时间
        private string _companyid="";

        

        /// <summary>
        /// 素材表id
        /// </summary> 
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int wx_MaterialID
        {
            get { return _wx_materialid; }
            set { _wx_materialid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 父级id
        /// </summary> 
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 类型（ 1文字，2图片，3图文，4音频，5视频）
        /// </summary> 
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 作者
        /// </summary> 
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        /// <summary>
        /// 摘要
        /// </summary> 
        public string Paper
        {
            get { return _paper; }
            set { _paper = value; }
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
        /// 封面图
        /// </summary> 
        public string ImgUrl
        {
            get { return _imgurl; }
            set { _imgurl = value; }
        }
        /// <summary>
        /// 原文链接
        /// </summary> 
        public string Url
        {
            get { return _url; }
            set { _url = value; }
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