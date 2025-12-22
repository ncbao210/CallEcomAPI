using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeConfig
    {
        public string RootUrl { get; set; } = "";
        /// <summary>
        /// Id kết nối được shopee cung cấp
        /// </summary>
        public string PartnerID { get; set; } = "2004299";
        /// <summary>
        /// Key kết nối được shopee cung cấp
        /// </summary>
        public string PartnerKey { get; set; } = "8def79734c542e3f5a5bbbe19789c73973b64c4cfb89a8ff90b62e57a46f0eb5";
        /// <summary>
        /// Phục gọi nội bộ proxy ra ngoài
        /// </summary>
        public string APIUrl { get; set; } = "https://partner.shopeemobile.com/";
        /// <summary>
        /// Domain internet shoppee
        /// </summary>
        public string ConnectAPIUrl { get; set; } = "https://partner.shopeemobile.com";
        /// <summary>
        /// Danh sách các endpoint shopee
        /// </summary>
        public ShopeeEndPoints ShopeeEndPointsConfig { get; set; } = new ShopeeEndPoints();
    }
}