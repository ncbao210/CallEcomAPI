using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeBaseRequest
    {
        public string refresh_token { get; set; }
        /// <summary>
        /// Mã đối tác
        /// </summary>
        public long partner_id { get; set; } = 1125741222;
        /// <summary>
        /// key đối tác
        /// </summary>
        public string partner_key { get; set; } = "8def79734c542e3f5a5bbbe19789c73973b64c4cfb89a8ff90b62e57a46f0eb5";
        /// <summary>
        /// Mã shop
        /// </summary>
        public long shop_id { get; set; }

        /// <summary>
        /// Thời gian call request
        /// </summary>
        public decimal timestamp { get; set; }
        /// <summary>
        /// chữ ký
        /// </summary>
        public string sign { get; set; }

    }
}