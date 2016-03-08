using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Model
{
    /// <summary>
    /// 代理商帐务清单
    /// </summary>
    public class Companys_costlogInfo
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
        /// companyid
        /// </summary>		
        private int _companyid;
        /// <summary>
        /// companyid
        /// </summary>	
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// amount
        /// </summary>		
        private decimal _amount;
        /// <summary>
        /// amount
        /// </summary>	
        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// description
        /// </summary>		
        private string _description;
        /// <summary>
        /// description
        /// </summary>	
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// createtime
        /// </summary>		
        private DateTime _createtime;
        /// <summary>
        /// createtime
        /// </summary>	
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

    }
}