using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("UserRoles")]
    [Serializable]
    public class UserRolesInfo
    {

        /// <summary>
        /// UserRoleID
        /// </summary>		
        private int _userroleid;
        /// <summary>
        /// UserID
        /// </summary>		
        private int _userid;
        /// <summary>
        /// RoleID
        /// </summary>		
        private int _roleid;
        /// <summary>
        /// CreatedByUserID
        /// </summary>		
        private int _createdbyuserid;
        /// <summary>
        /// CreatedOnDate
        /// </summary>		
        private DateTime? _createdondate = DateTime.Now;

        /// <summary>
        /// UserRoleID
        /// </summary>	
        [Property(ColumnTypes.Identity | ColumnTypes.Increment)]
        public int UserRoleID
        {
            get { return _userroleid; }
            set { _userroleid = value; }
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
        /// RoleID
        /// </summary>	
        public int RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
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

    }
}