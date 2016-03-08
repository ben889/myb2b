using BS.Components.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Property("Tabs")]
    [Serializable]
    public partial class TabsInfo
    {
        #region 私有变量
        private int _TabID;
        private string _TabName="";
        private string _TabUrl = "";
        private int _ParentId;
        private int _Level;
        private int _OrderByNo;
        private string _icon = "";
        private bool _DisPlay;
        private string _TabKey = "";
        
        
        #endregion

        public TabsInfo()
        {

        }

        public TabsInfo(int TabID, string TabName, string TabUrl, int ParentId, string icon, bool DisPlay, string TabKey, int OrderByNo)
        {
            _TabID = TabID; _TabName = TabName; _TabUrl = TabUrl; _ParentId = ParentId;
            _icon = icon; _DisPlay = DisPlay; _TabKey = TabKey; _OrderByNo = OrderByNo;
        }
        [Property(ColumnTypes.Identity)]
        public int TabID
        {
            get
            {
                return _TabID;
            }
            set
            {
                _TabID = value;
            }
        }
        public string TabName
        {
            get
            {
                return _TabName;
            }
            set
            {
                _TabName = value;
            }
        }
        public string TabUrl
        {
            get
            {
                return _TabUrl;
            }
            set
            {
                _TabUrl = value;
            }
        }
        public int ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                _ParentId = value;
            }
        }
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
            }
        }
        public int OrderByNo
        {
            get
            {
                return _OrderByNo;
            }
            set
            {
                _OrderByNo = value;
            }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public bool DisPlay
        {
            get { return _DisPlay; }
            set { _DisPlay = value; }
        }

        //public string DisPlayStr
        //{ 
        //    get{
        //        if (DisPlay)
        //            return "显示";
        //        else
        //            return "<span style='color:red;'>隐藏</span>";
        //    }
        //}
        /// <summary>
        /// 页面Key
        /// </summary>
        public string TabKey
        {
            get { return _TabKey; }
            set { _TabKey = value; }
        }
    }
}
