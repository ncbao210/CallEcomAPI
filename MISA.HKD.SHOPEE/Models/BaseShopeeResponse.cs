using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class BaseShopeeResponse
    {
        /// <summary>
        /// Lỗi từ Shopee trả về
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// Id request
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string error { get; set; }
    }
}