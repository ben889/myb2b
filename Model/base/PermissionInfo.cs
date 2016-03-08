
using BS.Components.Data.Entity;
/*
	作者	  :
	创建时间:2011-03-11 22:11:27
*/
using System;
using System.Configuration;
using System.Data;
namespace Model
{
    [Property("Permission")]
	[Serializable]
	public partial class PermissionInfo
  	{
        
        public PermissionInfo(int PermissionID, string PermissionCode, string PermissionKey, string PermissionName,int TabID)
        {
            _permissionid = PermissionID; _permissioncode = PermissionCode; _permissionkey = PermissionKey;
            _permissionname = PermissionName; _tabid = TabID;
        }
        public PermissionInfo(){}

		#region 私有变量
		private int  _permissionid ;
        private string _permissioncode = "";
		private int  _moduleid ;
        private string _permissionkey = "";
        private string _permissionname = "";
		private int  _vieworder =9999;
		private int  _createdbyuserid ;
		private DateTime?  _createdondate = DateTime.Now;
		private int  _lastmodifiedbyuserid ;
        private DateTime? _lastmodifiedondate = DateTime.Now;
        private int _tabid;

        
		#endregion
		
		#region 属性
		/// <summary>
		/// 
		///默认值:
		/// </summary>
        [Property(ColumnTypes.Identity)]
		public int  PermissionID
		{
			get{
				return _permissionid;
			}
			set{
				_permissionid=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public string  PermissionCode
		{
			get{
				return _permissioncode;
			}
			set{
				_permissioncode=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public int  ModuleID
		{
			get{
				return _moduleid;
			}
			set{
				_moduleid=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public string  PermissionKey
		{
			get{
				return _permissionkey;
			}
			set{
				_permissionkey=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public string  PermissionName
		{
			get{
				return _permissionname;
			}
			set{
				_permissionname=value;
			}
		}
		/// <summary>
		/// 
		///默认值:9999
		/// </summary>
		public int  ViewOrder
		{
			get{
				return _vieworder;
			}
			set{
				_vieworder=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public int  CreatedByUserID
		{
			get{
				return _createdbyuserid;
			}
			set{
				_createdbyuserid=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public DateTime?  CreatedOnDate
		{
			get{
				return _createdondate;
			}
			set{
				_createdondate=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public int  LastModifiedByUserID
		{
			get{
				return _lastmodifiedbyuserid;
			}
			set{
				_lastmodifiedbyuserid=value;
			}
		}
		/// <summary>
		/// 
		///默认值:
		/// </summary>
		public DateTime?  LastModifiedOnDate
		{
			get{
				return _lastmodifiedondate;
			}
			set{
				_lastmodifiedondate=value;
			}
		}
        public int TabID
        {
            get { return _tabid; }
            set { _tabid = value; }
        }
		#endregion
	}
}
