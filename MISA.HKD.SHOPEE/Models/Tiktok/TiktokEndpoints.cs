using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class TiktokEndpoints
    {
        /// <summary>
        /// API lấy token của shop
        /// </summary>
        public const string GetAuthInforUser = "/api/v2/token/get?app_key={0}&auth_code={1}&app_secret={2}&grant_type=authorized_code";

        /// <summary>
        /// 0: version của api
        /// Lấy thông tin shop
        /// </summary>
        public const string GetAuthInforShop = "/authorization/version_api/shops";
        /// <summary>
        /// 0: version của api
        /// Lấy thông tin shop
        /// </summary>
        public const string RegisterWebhook = "/event/version_api/webhooks";
        /// <summary>
        /// 0: version của api
        /// Lấy thông tin shop
        /// </summary>
        public const string RefreshtokenSeller = "/api/v2/token/refresh?app_key={0}&refresh_token={1}&app_secret={2}&grant_type=refresh_token";

        /// <summary>
        /// API lấy danh sách hàng hóa
        /// 0: số bản ghi cần lấy trong 1 trang
        /// 1: id của shop
        /// 2: token trang tiếp theo
        /// </summary>
        public const string SearchProducts = "/product/version_api/products/search?page_size={0}&shop_id={1}&page_token={2}";

        /// <summary>
        /// API lấy chi tiết 1 hàng hóa theo id
        /// 0: id hàng hóa cần lấy
        /// 1: id của shop
        /// 2: truy xuất thông tin ảnh chụp nhanh của các sản phẩm đang được xem xét
        /// </summary>
        public const string GetProduct = "/product/version_api/products/{0}?return_under_review_version={1}";

        /// <summary>
        /// Lấy đơn hàng tiktok
        /// </summary>
        public const string GetListOrders = "/order/version_api/orders/search?page_size={0}&page_token={1}&sort_field=update_time";
        /// <summary>
        /// Lấy đơn hàng tiktok theo ids
        /// </summary>
        public const string GetListOrderByIds = "/order/version_api/orders?ids={0}";

        /// <summary>
        /// Lấy thông tin giao dịch
        /// </summary>
        public const string GetTransactionOrder = "/finance/version_api/orders/{0}/statement_transactions";

        /// <summary>
        /// Lấy thông tin giao dịch
        /// </summary>
        public const string GetTransactionOrderOld = "/api/finance/order/settlements?access_token={0}&version={1}&order_id={2}";

        /// <summary>
        /// Lấy thông tin giao dịch
        /// </summary>
        //public const string GetTransactionOrder = "/finance/202309/statements";

        /// <summary>
        /// Cập nhật tồn kho
        /// 0: product_id
        /// </summary>
        public const string UpdateInventory = "/product/version_api/products/{0}/inventory/update";

        /// <summary>
        /// Lấy danh sách kho tiktok
        /// </summary>
        public const string GetMultiWareHouse = "/logistics/version_api/warehouses";
        /// <summary>
        /// Sẵn sàng giao hàng tikltok
        /// </summary>

        public const string ShipPackage = "/fulfillment/version_api/packages/{0}/ship";

        /// <summary>
        /// Sẵn sàng giao hàng tikltok
        /// </summary>

        public const string GetDetailPackage = "/fulfillment/version_api/packages/{0}";

        /// <summary>
        /// Hủy đơn hàng
        /// </summary>
        public const string CancelOrder = "/return_refund/version_api/cancellations";

        /// <summary>
        /// Upload ảnh lên Tiktok
        /// </summary>
        public const string UploadImage = "/product/version_api/images/upload";

        /// <summary>
        /// Lấy danh sách danh mục hàng hóa
        /// </summary>
        public const string GetCategories = "/product/version_api/categories";

        /// <summary>
        /// Đăng hàng hóa lên tiktok
        /// </summary>
        public const string CreateProduct = "/product/version_api/products";

        /// <summary>
        /// Lấy danh sách thương hiệu từ sàn
        /// </summary>
        public const string GetBrand = "/product/version_api/brands?page_size={0}&page_token={1}";

        /// <summary>
        /// Thêm thương hiệu lên sàn
        /// </summary>
        public const string CreateCustomBrands = "/product/version_api/brands";

    }
}