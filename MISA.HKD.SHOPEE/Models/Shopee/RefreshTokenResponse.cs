using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class RefreshTokenResponse : ShopeeBaseResponse
    {
        /// <summary>
        /// Id shopee cung cấp
        /// </summary>
        public long partner_id { get; set; }
        /// <summary>
        /// Sử dụng Refresh_token để nhận access_token mới và có hiệu lực trong 30 ngày và được sử dụng một lần duy nhất
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// Mỗi access_token mới có hiệu lực 4 giờ.
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// Khoảng thời gian hiệu lực của access_token, tính bằng giây.
        /// </summary>
        public long expire_in { get; set; }
        /// <summary>
        /// Id của shop trên shoppee
        /// </summary>
        public long shop_id { get; set; }
        /// <summary>
        /// Merchant_id cho lần làm mới này, để xác định từng người bán.
        /// </summary>
        public int merchant_id { get; set; }
    }
}