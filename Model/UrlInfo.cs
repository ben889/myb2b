using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("Url")]
    [Serializable]
    public class UrlInfo
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
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
        private string _name = "";
        /// <summary>
        /// name
        /// </summary>	
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// url
        /// </summary>		
        private string _url;
        /// <summary>
        /// url
        /// </summary>	
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        /// sys
        /// </summary>		
        private bool _sys;
        /// <summary>
        /// sys
        /// </summary>	
        public bool sys
        {
            get { return _sys; }
            set { _sys = value; }
        }
        private string _call_index = "";

        public string call_index
        {
            get { return _call_index; }
            set { _call_index = value; }
        }
        private string _companyid="";

        public string companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
    }
}