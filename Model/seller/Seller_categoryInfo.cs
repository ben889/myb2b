using BS.Components.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    
    /// <summary>
    /// 商家分类 （如电子，食品加工...）
    /// </summary>
    [Property("Seller_category")]
    [Serializable]
    public class Seller_categoryInfo
    {/// <summary>
        /// id
        /// </summary>		
        private int _id;
        /// <summary>
        /// name
        /// </summary>		
        private string _name;
        /// <summary>
        /// parentid
        /// </summary>		
        private int _parentid;
        /// <summary>
        /// orderby
        /// </summary>		
        private int _orderby;
        /// <summary>
        /// img
        /// </summary>		
        private string _img = "";
        /// <summary>
        /// companyid
        /// </summary>		
        //private int _companyid;

        /// <summary>
        /// id
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// name
        /// </summary>	
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// parentid
        /// </summary>	
        public int parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// orderby
        /// </summary>	
        public int orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
        /// <summary>
        /// img
        /// </summary>	
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
        /// <summary>
        /// 商圈
        /// </summary>	
        //public int companyid
        //{
        //    get { return _companyid; }
        //    set { _companyid = value; }
        //}   
    }
}
