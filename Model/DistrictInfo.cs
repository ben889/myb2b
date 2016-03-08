using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 区域表
    /// </summary>
    [Property("District")]
    [Serializable]
    public class DistrictInfo
    {

        private int _distid;//区域域表
        private string _name = "";//名称
        private int _parentid;//父类ID，等于0时，代表的是一级的分类
        private int _provinceid;//省ID
        private string _provincename = "";//省名称
        private int _cityid;//市ID
        private string _cityname = "";//市名称
        private int _areaid;//（区、县）ID
        private string _areaname = "";//（区、县）名称
        private int _districtid;//商区ID
        private string _districtname="";//商区名称
        private string _pinyininitials = "";//地名简称首字母
        private string _pinyin = "";//地名全拼
        private string _lng = "";//经度
        private string _lat = "";//纬度
        private int _sort;//排序
        private int _isrecommend;//是否推荐：0否，1是
        private int _isdefault;//是否为默认城市：0否，1是
        private DateTime _createtime;//创建时间
        private int _level;//级别
        private string _parentids = "";//父ID串如1,11,21,31
        private string _call_index="";//调用代码
        
        
        

        /// <summary>
        /// 区域表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int DistId
        {
            get { return _distid; }
            set { _distid = value; }
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
        /// 父类ID，等于0时，代表的是一级的分类
        /// </summary>
        public int ParentId
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 省ID
        /// </summary>
        public int ProvinceId
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// 省名称
        /// </summary>
        public string ProvinceName
        {
            get { return _provincename; }
            set { _provincename = value; }
        }
        /// <summary>
        /// 市ID
        /// </summary>
        public int CityId
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName
        {
            get { return _cityname; }
            set { _cityname = value; }
        }
        /// <summary>
        /// （区、县）ID
        /// </summary>
        public int AreaId
        {
            get { return _areaid; }
            set { _areaid = value; }
        }
        /// <summary>
        /// （区、县）名称
        /// </summary>
        public string AreaName
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        /// <summary>
        /// 商区ID
        /// </summary>
        public int DistrictId
        {
            get { return _districtid; }
            set { _districtid = value; }
        }
        /// <summary>
        /// 商区名称
        /// </summary>
        public string DistrictName
        {
            get { return _districtname; }
            set { _districtname = value; }
        }
        /// <summary>
        /// 地名简称首字母
        /// </summary>
        public string PinYinInitials
        {
            get { return _pinyininitials; }
            set { _pinyininitials = value; }
        }
        /// <summary>
        /// 地名全拼
        /// </summary>
        public string PinYin
        {
            get { return _pinyin; }
            set { _pinyin = value; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat
        {
            get { return _lat; }
            set { _lat = value; }
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
        /// 是否推荐：0否，1是
        /// </summary>
        public int IsRecommend
        {
            get { return _isrecommend; }
            set { _isrecommend = value; }
        }
        /// <summary>
        /// 是否为默认城市：0否，1是
        /// </summary>
        public int IsDefault
        {
            get { return _isdefault; }
            set { _isdefault = value; }
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
        /// 级别
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// 父ID串如1,11,21,31
        /// </summary>
        public string ParentIds
        {
            get { return _parentids; }
            set { _parentids = value; }
        }
        /// <summary>
        /// 调用代码
        /// </summary>
        public string call_index
        {
            get { return _call_index; }
            set { _call_index = value; }
        }
    }
}