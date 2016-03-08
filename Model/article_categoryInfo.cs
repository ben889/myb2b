using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class article_categoryInfo
    {
        /// <summary>
        /// 自增ID
        /// </summary>		
        private int _id;
        /// <summary>
        /// 自增ID
        /// </summary>	
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>		
        private int _channel_id;
        /// <summary>
        /// 频道ID
        /// </summary>	
        public int channel_id
        {
            get { return _channel_id; }
            set { _channel_id = value; }
        }
        /// <summary>
        /// 类别标题
        /// </summary>		
        private string _title;
        /// <summary>
        /// 类别标题
        /// </summary>	
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 调用别名
        /// </summary>		
        private string _call_index = "";
        /// <summary>
        /// 调用别名
        /// </summary>	
        public string call_index
        {
            get { return _call_index; }
            set { _call_index = value; }
        }
        /// <summary>
        /// 父类别ID
        /// </summary>		
        private int _parentid;
        /// <summary>
        /// 父类别ID
        /// </summary>	
        public int parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 排序数字
        /// </summary>		
        private int _orderby;
        /// <summary>
        /// 排序数字
        /// </summary>	
        public int orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
        /// <summary>
        /// URL跳转地址
        /// </summary>		
        private string _link_url = "";
        /// <summary>
        /// URL跳转地址
        /// </summary>	
        public string link_url
        {
            get { return _link_url; }
            set { _link_url = value; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>		
        private string _img = "";
        /// <summary>
        /// 图片地址
        /// </summary>	
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>		
        private string _content = "";
        /// <summary>
        /// 备注说明
        /// </summary>	
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// SEO标题
        /// </summary>		
        private string _seo_title = "";
        /// <summary>
        /// SEO标题
        /// </summary>	
        public string seo_title
        {
            get { return _seo_title; }
            set { _seo_title = value; }
        }
        /// <summary>
        /// SEO关健字
        /// </summary>		
        private string _seo_keywords = "";
        /// <summary>
        /// SEO关健字
        /// </summary>	
        public string seo_keywords
        {
            get { return _seo_keywords; }
            set { _seo_keywords = value; }
        }
        /// <summary>
        /// SEO描述
        /// </summary>		
        private string _seo_description = "";
        /// <summary>
        /// SEO描述
        /// </summary>	
        public string seo_description
        {
            get { return _seo_description; }
            set { _seo_description = value; }
        }

        private int _companyid;

        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

	
        private string _companyname = "";
        public string companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
    }
}
