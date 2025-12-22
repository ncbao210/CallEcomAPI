using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeGetShopInfoResponse : ShopeeBaseResponse
    {
        /// <summary>
        /// tên shop
        /// </summary>
        public string shop_name { get; set; }
        /// <summary>
        /// vùng
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// trạng thái
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// DS shop liên kết
        /// </summary>
        public List<ShopeeAffiShop> sip_affi_shops { get; set; }
        /// <summary>
        /// Có phải của hàng xuyên biên giới
        /// </summary>
        public bool is_cb { get; set; }
        /// <summary>
        /// có được nâng nên CNSC
        /// </summary>
        public bool is_cnsc { get; set; }
        /// <summary>
        /// có được nâng nên CNSC/KRSC/UNUPGRADED
        /// </summary>
        public string shop_cbsc { get; set; }
        /// <summary>
        /// Thời gian cửa hàng được ủy quyền cho OCM
        /// </summary>
        public decimal auth_time { get; set; }
        /// <summary>
        /// thời gian hết hạn ủy quyền của cửa hàng với OCM
        /// </summary>
        public decimal expire_time { get; set; }
        /// <summary>
        /// Có SIP gọi
        /// </summary>
        public bool is_sip { get; set; }
    }

    /// <summary>
    /// Thông tin các shop liên kết
    /// </summary>
    public class ShopeeAffiShop
    {
        /// <summary>
        /// Affliate shop id
        /// </summary>
        public string affi_shop_id { get; set; }
        /// <summary>
        /// khu vực Affliate shop
        /// </summary>
        public string region { get; set; }
    }
}