using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// ndchien (15/08/24)
    /// </summary>
    public class PartnerConstants
    {

        #region Shopee

        public const string SHOPEE_CONTAIN_INFO = "is required";
        public const string SHOPEE_CONTAIN_ATTRIBUTE = "attributes";
        public const string SHOPEE_CONTAIN_Image = "images download fail";
        public const string SHOPEE_CONTAIN_Enabled = "shop channel not enable for channel_id";
        public const string SHOPEE_CONTAIN_Logistic = "logistic";
        public const string SHOPEE_CONTAIN_AUTH = "no permission to current api";

        /// <summary>
        /// Mã lỗi đồng bộ tồn kho khi có tồn dữ trữ cho khuyến mại
        /// </summary>
        public const string ShopeeProductErrorBusi = "product.error_busi";

        /// <summary>
        /// Message lỗi đồng bộ tồn kho có tồn dự trữ
        /// </summary>
        public const string ShopeeErrorStockReserve = "reserve stock number";

        #endregion
    }
}