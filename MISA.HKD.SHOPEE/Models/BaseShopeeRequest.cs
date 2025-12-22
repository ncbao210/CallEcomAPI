using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class BaseShopeeRequest
    {
        /// <summary>
        /// Mã đối tác
        /// </summary>
        public Int64 partner_id { get; set; } = 2004299;

        /// <summary>
        /// Mã shop
        /// </summary>
        public Int64 shopid { get; set; }

        /// <summary>
        /// Thời gian call request
        /// </summary>
        public Int32 timestamp { get; set; }
    }
}