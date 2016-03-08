using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    /// <summary>
    /// 订单评价图册表
    /// </summary>
    [Property("g_order_evaluation_imgs")]
    [Serializable]
    public class g_order_evaluation_imgsInfo
    {

        private int _evaluaimg_id;//订单评价图册表
        private int _evalua_id;//评价ID
        private string _img = "";//img
        private string _description = "";//描述
        private long _uid;//uid

        /// <summary>
        /// 订单评价图册表
        /// </summary>
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int evaluaimg_id
        {
            get { return _evaluaimg_id; }
            set { _evaluaimg_id = value; }
        }
        /// <summary>
        /// 评价ID
        /// </summary>
        public int evalua_id
        {
            get { return _evalua_id; }
            set { _evalua_id = value; }
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
        /// 描述
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// uid
        /// </summary>
        public long uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

    }
}