using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class BaseEcomAccountParam : ShopeeBaseParam
    {
        /// <summary>
        /// code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public string ApplicationId { get; set; }
        /// <summary>
        /// kênh sàn thương mại điện tử
        /// </summary>
        public ChanelEcom ChannelId { get; set; }
        /// <summary>
        /// Mã công ty
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Tên shop
        /// </summary>
        public string SellerName { get; set; }
    }
}