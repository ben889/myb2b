using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.weixin.Model
{
    [Serializable]
    public class QRCode
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        public string ticket { set; get; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { set; get; }
    }
}
