using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("TabPermission")]
    [Serializable]
    public class TabPermissionInfo
    {

        /// <summary>
        /// TabPermissionID
        /// </summary>		
        private int _tabpermissionid;
        /// <summary>
        /// TabID
        /// </summary>		
        private int _tabid;
        /// <summary>
        /// PermissionID
        /// </summary>		
        private int _permissionid;
        /// <summary>
        /// AllowAccess
        /// </summary>		
        private bool _allowaccess;
        /// <summary>
        /// RoleID
        /// </summary>		
        private int _roleid;
        /// <summary>
        /// UserID
        /// </summary>		
        private int _userid;
        /// <summary>
        /// CreatedByUserID
        /// </summary>		
        private int _createdbyuserid;
        /// <summary>
        /// CreatedOnDate
        /// </summary>		
        private DateTime _createdondate = DateTime.Now;
        /// <summary>
        /// LastModifiedByUserID
        /// </summary>		
        private int _lastmodifiedbyuserid;
        /// <summary>
        /// LastModifiedOnDate
        /// </summary>		
        private DateTime _lastmodifiedondate = DateTime.Parse("1900-1-1");

        /// <summary>
        /// TabPermissionID
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int TabPermissionID
        {
            get { return _tabpermissionid; }
            set { _tabpermissionid = value; }
        }
        /// <summary>
        /// TabID
        /// </summary>	
        public int TabID
        {
            get { return _tabid; }
            set { _tabid = value; }
        }
        /// <summary>
        /// PermissionID
        /// </summary>	
        public int PermissionID
        {
            get { return _permissionid; }
            set { _permissionid = value; }
        }
        /// <summary>
        /// AllowAccess
        /// </summary>	
        public bool AllowAccess
        {
            get { return _allowaccess; }
            set { _allowaccess = value; }
        }
        /// <summary>
        /// RoleID
        /// </summary>	
        public int RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>	
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
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
        public DateTime CreatedOnDate
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
        public DateTime LastModifiedOnDate
        {
            get { return _lastmodifiedondate; }
            set { _lastmodifiedondate = value; }
        }

    }
}