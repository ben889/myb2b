using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //article
    public class articleInfo
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
        /// 类别ID
        /// </summary>		
        private int _category_id;
        /// <summary>
        /// 类别ID
        /// </summary>	
        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
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
        /// 标题
        /// </summary>		
        private string _title;
        /// <summary>
        /// 标题
        /// </summary>	
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 外部链接
        /// </summary>		
        private string _link_url = "";
        /// <summary>
        /// 外部链接
        /// </summary>	
        public string link_url
        {
            get { return _link_url; }
            set { _link_url = value; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>		
        private string _img_url = "";
        /// <summary>
        /// 图片地址
        /// </summary>	
        public string img_url
        {
            get { return _img_url; }
            set { _img_url = value; }
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
        /// <summary>
        /// 内容摘要
        /// </summary>		
        private string _zhaiyao = "";
        /// <summary>
        /// 内容摘要
        /// </summary>	
        public string zhaiyao
        {
            get { return _zhaiyao; }
            set { _zhaiyao = value; }
        }
        /// <summary>
        /// 详细内容
        /// </summary>		
        private string _content = "";
        /// <summary>
        /// 详细内容
        /// </summary>	
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        private int _orderby;
        /// <summary>
        /// 排序
        /// </summary>	
        public int orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>		
        private int _click;
        /// <summary>
        /// 浏览次数
        /// </summary>	
        public int click
        {
            get { return _click; }
            set { _click = value; }
        }
        /// <summary>
        /// 状态0正常1未审核2锁定
        /// </summary>		
        private int _status;
        /// <summary>
        /// 状态0正常1未审核2锁定
        /// </summary>	
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>		
        private int _is_top;
        /// <summary>
        /// 是否置顶
        /// </summary>	
        public int is_top
        {
            get { return _is_top; }
            set { _is_top = value; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>		
        private int _is_red;
        /// <summary>
        /// 是否推荐
        /// </summary>	
        public int is_red
        {
            get { return _is_red; }
            set { _is_red = value; }
        }
        /// <summary>
        /// 是否热门
        /// </summary>		
        private int _is_hot;
        /// <summary>
        /// 是否热门
        /// </summary>	
        public int is_hot
        {
            get { return _is_hot; }
            set { _is_hot = value; }
        }
        /// <summary>
        /// 是否幻灯片
        /// </summary>		
        private int _is_slide;
        /// <summary>
        /// 是否幻灯片
        /// </summary>	
        public int is_slide
        {
            get { return _is_slide; }
            set { _is_slide = value; }
        }
        /// <summary>
        /// userid
        /// </summary>		
        private int _userid;
        /// <summary>
        /// userid
        /// </summary>	
        public int userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        private string _username = "";
        /// <summary>
        /// 用户名
        /// </summary>	
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _add_time;
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>		
        private DateTime _update_time;
        /// <summary>
        /// 修改时间
        /// </summary>	
        public DateTime update_time
        {
            get { return _update_time; }
            set { _update_time = value; }
        }
        private int _companyid;

        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
    }
}
