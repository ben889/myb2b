using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 商品类别
    /// </summary>
    [Property("goods_category")]
    [Serializable]
    public class goods_categoryInfo
    {

        private int _goods_category_id;//体验馆商品类别表
        private string _goods_category_name;//类别名称
        private int _parentid;//父ID
        private string _parentids = "";//父ID串如1,11,21,31
        
        private int _sort;//排序
        private string _img = "";//图标



        /// <summary>
        /// 体验馆商品类别表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int goods_category_id
        {
            get { return _goods_category_id; }
            set { _goods_category_id = value; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string goods_category_name
        {
            get { return _goods_category_name; }
            set { _goods_category_name = value; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 父ID串如1,11,21,31
        /// </summary>
        public string parentids
        {
            get { return _parentids; }
            set { _parentids = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
    }
}