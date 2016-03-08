using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BS.Components.Data.Entity;
namespace Model
{
    [Property("AdPosition")]
    [Serializable]
    public class AdPositionInfo
    {
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        /// <summary>
        /// 名称
        /// </summary>		
        private string _name = "";
        /// <summary>
        /// 长
        /// </summary>		
        private int _width;
        /// <summary>
        /// 宽
        /// </summary>		
        private int _height;
        /// <summary>
        /// 文件类型
        /// </summary>		
        private string _filetype = "";
        /// <summary>
        /// call_index
        /// </summary>		
        private string _call_index = "";

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
        /// 名称
        /// </summary>	
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 长
        /// </summary>	
        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 宽
        /// </summary>	
        public int height
        {
            get { return _height; }
            set { _height = value; }
        }
        /// <summary>
        /// 文件类型
        /// </summary>	
        public string filetype
        {
            get { return _filetype; }
            set { _filetype = value; }
        }
        /// <summary>
        /// call_index
        /// </summary>	
        public string call_index
        {
            get { return _call_index; }
            set { _call_index = value; }
        }

    }
}