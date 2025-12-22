using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class TiktokGetTokenResponse
    {
        /// <summary>
        /// Token để truy cập tài nguyên.
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Thời gian hết hạn của token truy cập.
        /// </summary>
        public long access_token_expire_in { get; set; }

        /// <summary>
        /// Token để làm mới (refresh) tài nguyên.
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// Thời gian hết hạn của token làm mới (refresh).
        /// </summary>
        public long refresh_token_expire_in { get; set; }

        /// <summary>
        /// ID mở của người dùng.
        /// </summary>
        public string open_id { get; set; }

        /// <summary>
        /// Tên của người bán.
        /// </summary>
        public string seller_name { get; set; }

        /// <summary>
        /// Khu vực cơ sở của người bán.
        /// </summary>
        public string seller_base_region { get; set; }

        /// <summary>
        /// Loại người dùng.
        /// </summary>
        public int user_type { get; set; }
    }
}