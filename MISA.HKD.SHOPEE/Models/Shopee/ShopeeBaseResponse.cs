using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeBaseResponse
    {
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// Lỗi từ Shopee trả về
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Lỗi từ Shopee trả về
        /// </summary>
        public string warning { get; set; }

        /// <summary>
        /// Id request
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// Id request
        /// </summary>
        public object response { get; set; }

    }

    public class ShopeePaging
    {
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        public bool has_next_page { get; set; }

        /// <summary>
        /// Lỗi từ Shopee trả về
        /// </summary>
        public List<object> item { get; set; }

        /// <summary>
        /// Lỗi từ Shopee trả về
        /// </summary>
        public string next { get; set; }

        /// <summary>
        /// Id request
        /// </summary>
        public int next_offset { get; set; }

        /// <summary>
        /// Id request
        /// </summary>
        public int total_count { get; set; }

    }
}