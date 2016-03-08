using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("Ad")]
    [Serializable]
    public class AdInfo
    {
        /// <summary>
        /// adid
        /// </summary>		
        private int _adid;
        /// <summary>
        /// 名称
        /// </summary>		
        private string _adname = "";
        /// <summary>
        /// 图片
        /// </summary>		
        private string _adimg = "";
        /// <summary>
        /// 链接
        /// </summary>		
        private string _adlink = "";
        /// <summary>
        /// 打开方式
        /// </summary>		
        private int _adblank;
        /// <summary>
        /// 状态
        /// </summary>		
        private int _status;
        /// <summary>
        /// 点击数
        /// </summary>		
        private int _click;
        /// <summary>
        /// adpositionid
        /// </summary>		
        private int _adpositionid;
        /// <summary>
        /// 后缀
        /// </summary>		
        private string _suffix = "";

        /// <summary>
        /// adid
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int adid
        {
            get { return _adid; }
            set { _adid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>	
        public string adname
        {
            get { return _adname; }
            set { _adname = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>	
        public string adimg
        {
            get { return _adimg; }
            set { _adimg = value; }
        }
        /// <summary>
        /// 链接
        /// </summary>	
        public string adlink
        {
            get { return _adlink; }
            set { _adlink = value; }
        }
        /// <summary>
        /// 打开方式
        /// </summary>	
        public int adblank
        {
            get { return _adblank; }
            set { _adblank = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>	
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 点击数
        /// </summary>	
        public int click
        {
            get { return _click; }
            set { _click = value; }
        }
        /// <summary>
        /// adpositionid
        /// </summary>	
        public int adpositionid
        {
            get { return _adpositionid; }
            set { _adpositionid = value; }
        }
        /// <summary>
        /// 后缀
        /// </summary>	
        public string suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

    }
}