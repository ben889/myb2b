using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("Roles")]
    public class RoleInfo
    {

        /// <summary>
        /// RoleID
        /// </summary>		
        private int _roleid;
        /// <summary>
        /// RoleName
        /// </summary>		
        private string _rolename = "";
        /// <summary>
        /// Description
        /// </summary>		
        private string _description = "";
        /// <summary>
        /// 自动分配
        /// </summary>		
        private bool _autoassignment;
        /// <summary>
        /// IconFile
        /// </summary>		
        private string _iconfile = "";
        /// <summary>
        /// CreatedByUserID
        /// </summary>		
        private int _createdbyuserid;
        /// <summary>
        /// CreatedOnDate
        /// </summary>		
        private DateTime? _createdondate = DateTime.Now;
        /// <summary>
        /// LastModifiedByUserID
        /// </summary>		
        private int _lastmodifiedbyuserid;
        /// <summary>
        /// LastModifiedOnDate
        /// </summary>		
        private DateTime? _lastmodifiedondate = DateTime.Now;

        /// <summary>
        /// RoleID
        /// </summary>	
        [Property(ColumnTypes.Identity)]
        public int RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        /// <summary>
        /// RoleName
        /// </summary>	
        public string RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
        /// <summary>
        /// Description
        /// </summary>	
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 自动分配
        /// </summary>	
        public bool AutoAssignment
        {
            get { return _autoassignment; }
            set { _autoassignment = value; }
        }
        /// <summary>
        /// IconFile
        /// </summary>	
        public string IconFile
        {
            get { return _iconfile; }
            set { _iconfile = value; }
        }
        /// <summary>
        /// CreatedByUserID
        /// </summary>	
        public int CreatedByUserID
        {
            get { return _createdbyuserid; }
            set { _createdbyuserid = value; }
        }
        /// <summary>
        /// CreatedOnDate
        /// </summary>	
        public DateTime? CreatedOnDate
        {
            get { return _createdondate; }
            set { _createdondate = value; }
        }
        /// <summary>
        /// LastModifiedByUserID
        /// </summary>	
        public int LastModifiedByUserID
        {
            get { return _lastmodifiedbyuserid; }
            set { _lastmodifiedbyuserid = value; }
        }
        /// <summary>
        /// LastModifiedOnDate
        /// </summary>	
        public DateTime? LastModifiedOnDate
        {
            get { return _lastmodifiedondate; }
            set { _lastmodifiedondate = value; }
        }

    }
}