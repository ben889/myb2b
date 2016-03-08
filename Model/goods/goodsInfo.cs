using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    //goods
    [Property("goods")]
    [Serializable]
    public class goodsInfo
    {

        private long _goodsid;//GoodsId
        private string _goodsname = "";//商品名称
        private string _img = "";//图片
        private decimal _price;//价格
        private int _sellerid;//商家ID
        private int _goodstype;//商品类别 1体验卷，2付费商品
        private int _companyid;//代理商ID
        private DateTime _startdate;//开始日期
        private DateTime _enddate;//结束日期
        private string _description = "";//描述
        private string _content = "";//内容
        private int _totalcount;//兑换数量，0表示无限
        private int _exchcount;//已经兑换的数量
        private int _viewcount;//浏览数
        private int _status;//1上架，0下架
        private int _auditstatus;//是否审核通过：0未审核，1审核通过，2未通过
        private string _auditremark = "";//审核备注
        private int _purchase;//每人限购数量：0不限制
        private DateTime _createtime;//创建时间
        //private string _siteid = "";//代理商ID
        private int _goods_category_id;//商品类别ID
        /// <summary>
        /// 是否推荐
        /// </summary>		
        private int _is_red;
        
        

        /// <summary>
        /// GoodsId
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public long GoodsId
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>	
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>	
        public string Img
        {
            get { return _img; }
            set { _img = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>	
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 商家ID
        /// </summary>	
        public int sellerid
        {
            get { return _sellerid; }
            set { _sellerid = value; }
        }
        /// <summary>
        /// 商品类别 1体验卷，2付费商品
        /// </summary>	
        public int GoodsType
        {
            get { return _goodstype; }
            set { _goodstype = value; }
        }
        /// <summary>
        /// 代理商ID
        /// </summary>	
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// 开始日期
        /// </summary>	
        public DateTime StartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>	
        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
        /// <summary>
        /// 描述
        /// </summary>	
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>	
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 兑换数量，0表示无限
        /// </summary>	
        public int TotalCount
        {
            get { return _totalcount; }
            set { _totalcount = value; }
        }
        /// <summary>
        /// 已经兑换的数量
        /// </summary>

        public int ExchCount
        {
            get { return _exchcount; }
            set { _exchcount = value; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>	
        public int ViewCount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }
        /// <summary>
        /// 1上架，0下架
        /// </summary>	
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 是否审核通过：0未审核，1审核通过，2未通过
        /// </summary>	
        public int AuditStatus
        {
            get { return _auditstatus; }
            set { _auditstatus = value; }
        }
        /// <summary>
        /// 审核备注
        /// </summary>	
        public string AuditRemark
        {
            get { return _auditremark; }
            set { _auditremark = value; }
        }
        /// <summary>
        /// 每人限购数量：0不限制
        /// </summary>	
        public int Purchase
        {
            get { return _purchase; }
            set { _purchase = value; }
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
        /// 代理商ID
        /// </summary>
        //public string siteid
        //{
        //    get { return _siteid; }
        //    set { _siteid = value; }
        //}

        /// <summary>
        /// 商品类别ID
        /// </summary>
        public int goods_category_id
        {
            get { return _goods_category_id; }
            set { _goods_category_id = value; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>	
        public int is_red
        {
            get { return _is_red; }
            set { _is_red = value; }
        }
    }
}