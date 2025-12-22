using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// Danh sách endpoint
    /// </summary>
    public class ShopeeEndPoints
    {
        /// <summary>
        /// Cập nhật giá
        /// </summary>
        public string UpdateStock = "/api/v2/product/update_stock";
        /// <summary>
        /// Lấy thông tin shop
        /// </summary>
        public string GetShopInfor = "/api/v2/shop/get_shop_info";

        
        /// <summary>
        /// Lấy thông tin token
        /// </summary>
        public string GetAccessToken = "/api/v2/auth/token/get";
        /// <summary>
        /// Sử dụng api này để nhận thông tin cơ bản về mặt hàng theo danh sách item_id.
        /// </summary>
        public string GetItemBase = "/api/v2/product/get_item_base_info";
        /// <summary>
        /// Lấy DS model
        /// </summary>
        public string GetModelBase = "/api/v2/product/get_model_list";
        /// <summary>
        /// Lấy DS danh mục
        /// </summary>
        public string GetItemList = "/api/v2/product/get_item_list";
        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken = "/api/v2/auth/access_token/get";
        /// <summary>
        /// Sử dụng api này để tìm kiếm đơn hàng. Bạn cũng có thể lọc chúng theo trạng thái nếu cần.
        /// </summary>
        public string GetListBaseOrder = "/api/v2/order/get_order_list";
        /// <summary>
        /// Sử dụng api này để nhận chi tiết đơn hàng.
        /// </summary>
        public string GetListDetailOrder = "/api/v2/order/get_order_detail";
        /// <summary>
        /// Sử dụng API này để lấy chi tiết kế toán của đơn hàng.
        /// </summary>
        public string GetEscrowDetail = "/api/v2/payment/get_escrow_detail";
        /// <summary>
        /// Sử dụng api này để khởi tạo hậu cần bao gồm sắp xếp việc nhận hàng, trả hàng hoặc giao hàng cho các kênh hậu cần không tích hợp
        /// </summary>
        public string ReadyToShip = "/api/v2/logistics/ship_order";
        /// <summary>
        /// Nhận địa chỉ nhận hàng cho đơn hàng ở chế độ nhận hàng.
        /// </summary>
        public string GetAdressPickUp = "/api/v2/logistics/get_address_list";
        /// <summary>
        /// Sử dụng api này để lấy tham số "info_needed" từ phản hồi để kiểm tra xem đơn hàng có tùy chọn nhận hàng hay trả hàng hay không hoặc không có tùy chọn tích hợp. Api này cũng sẽ trả về địa chỉ và tùy chọn id thời gian nhận hàng cho phương thức nhận hàng. Đối với trả hàng, nó có thể trả về id chi nhánh, tên thật của người gửi, v.v., tùy thuộc vào yêu cầu.
        /// </summary>
        public string GetParameterShip = "/api/v2/logistics/get_shipping_parameter";
        /// <summary>
        /// Sử dụng API này để tải lên nhiều tệp hình ảnh (ít hơn 9 hình ảnh).
        /// </summary>
        public string UploadImage = "/api/v2/media_space/upload_image";
        /// <summary>
        /// Nhận dữ liệu cây danh mục. Chi tiết hơn xem tại https://open.shopee.com/developer-guide/209
        /// </summary>
        public string GetCategory = "/api/v2/product/get_category";
        /// <summary>
        /// Lấy dữ liệu thuộc tính của một category. Chi tiết hơn vui lòng kiểm tra: https://open.shopee.com/developer-guide/209
        /// </summary>
        public string GetAttribute = "/api/v2/product/get_attributes";
        /// <summary>
        /// Lấy dữ liệu thương hiệu của một category. Chi tiết hơn vui lòng kiểm tra: https://open.shopee.com/developer-guide/209
        /// </summary>
        public string GetBrand = "/api/v2/product/get_brand_list";
        /// <summary>
        /// Tạo thương hiệu
        /// </summary>
        public string CreateBrand = "/api/v2/product/register_brand";
        /// <summary>
        /// Đăng ký nhận phiếu giao hàng
        /// </summary>
        public string CreateShippingDocument = "/api/v2/logistics/create_shipping_document";
        /// <summary>
        /// Lấy phiếu in từ shopee
        /// </summary>
        public string DownloadShippingDocument = "/api/v2/logistics/download_shipping_document";
        /// <summary>
        /// Sau khi sắp xếp lô hàng (v2.logistics.ship_order) cho kênh tích hợp, hãy sử dụng api này để lấy tracking_number, đây là tham số bắt buộc để tạo nhãn vận chuyển. Phản hồi api có thể trả về tracking_number rỗng, vì thông tin này phụ thuộc vào 3PL, do đó, được phép tiếp tục gọi api trong khoảng thời gian 5 phút, cho đến khi tracking_number được trả về.
        /// </summary>
        public string GetTrackingNumber = "/api/v2/logistics/get_tracking_number";
        /// <summary>
        /// Sử dụng api này để lấy thông tin theo dõi hậu cần của một đơn hàng.
        /// </summary>
        public string GetTrackingInfo = "/api/v2/logistics/get_tracking_info";
        /// <summary>
        /// Đăng hàng hóa
        /// </summary>
        public string PostProduct = "/api/v2/product/add_item";
        /// <summary>
        /// Bạn có thể thay đổi cấu trúc tầng thông qua API này. Nếu bạn chỉ định nghĩa màu sắc, thì đó là một tầng, nếu bạn định nghĩa màu sắc và kích thước, thì đó là hai tầng. Hỗ trợ tối đa hai cấu trúc tầng. API này có thể thay đổi không có tầng thành một tầng, không có tầng thành hai tầng, một tầng thành hai tầng, hai tầng thành một tầng, một tầng thành không có tầng, hai tầng thành không có tầng. Để biết thêm chi tiết, vui lòng kiểm tra: https:
        /// </summary>
        public string InitVariation = "/api/v2/product/init_tier_variation";
        /// <summary>
        /// Sử dụng api này để hủy đơn hàng. Hành động này chỉ có thể được thực hiện trước khi đơn hàng được chuyển đi.
        /// </summary>
        public string CancelOrder = "/api/v2/order/cancel_order";
        /// <summary>
        /// API lấy thông tin khuyến mại
        /// </summary>
        public string GetItemPromotion = "/api/v2/product/get_item_promotion";
        /// <summary>
        /// Đối với id cửa hàng và khu vực nhất định, hãy trả lại thông tin kho bao gồm id kho, id địa chỉ và id vị trí
        /// </summary>
        public string GetWarehouseDetail = "/api/v2/shop/get_warehouse_detail";
        /// <summary>
        /// Hủy kết nối
        /// </summary>
        public string CancelAuthPartner = "/api/v2/shop/cancel_auth_partner";
        /// <summary>
        /// Kết nối
        /// </summary>
        public string AuthPartner = "/api/v2/shop/auth_partner";


        #region Phần mở rộng của tham số lấy order shoppe

        /// <summary>
        /// PathTension lấy thông tin order
        /// </summary>
        public string PathTensionGetOrderList = "&time_range_field=update_time&time_from={0}&time_to={1}&page_size={2}&cursor={3}&response_optional_fields=order_status";

        public string GetReturnList = "/api/v2/returns/get_return_list";
        public string GetReturnListPathEnd = "&page_size={0}&page_no={1}&create_time_from={2}&create_time_to={3}";
        public string GetReturnListPathEndupdate = "&page_size={0}&page_no={1}&update_time_from={2}&update_time_to={3}";
        public string GetAvailableSolutions = "/api/v2/returns/get_available_solutions";
        public string GetAvailableSolutionsEndpoint = "&access_token={0}&partner_id={1}&return_sn={2}&shop_id={3}&sign={4}&timestamp={5}";
        


        /// <summary>
        /// PathTension lấy thông tin chi tiết order
        /// </summary>
        public string PathTensionGetOrderDetail = "&order_sn_list={0}&response_optional_fields=buyer_user_id,buyer_username,estimated_shipping_fee,recipient_address,actual_shipping_fee ,goods_to_declare,note,note_update_time,item_list,pay_time,dropshipper,dropshipper_phone,split_up,buyer_cancel_reason,cancel_by,cancel_reason,actual_shipping_fee_confirmed,buyer_cpf_id,fulfillment_flag,pickup_done_time,package_list,shipping_carrier,payment_method,total_amount,buyer_username,invoice_data, checkout_shipping_carrier, reverse_shipping_fee, order_chargeable_weight_gram";

        /// <summary>
        /// PathTension lấy thông đơn hàng theo mã đơn hàng
        /// </summary>
        public string PathTensionGetOrderByOrderCode = "&order_sn_list={0}&response_optional_fields=buyer_user_id,buyer_username,estimated_shipping_fee,recipient_address,actual_shipping_fee ,goods_to_declare,note,note_update_time,item_list,pay_time,dropshipper,dropshipper_phone,split_up,buyer_cancel_reason,cancel_by,cancel_reason,actual_shipping_fee_confirmed,buyer_cpf_id,fulfillment_flag,pickup_done_time,package_list,shipping_carrier,payment_method,total_amount,buyer_username,invoice_data, checkout_shipping_carrier, reverse_shipping_fee, order_chargeable_weight_gram";

        /// <summary>
        /// PathTension lấy thông tin khuyến mại
        /// </summary>
        public string PathTensionGetItemPromotion = "&item_id_list={0}";
        /// <summary>
        /// Lấy thông tin fat hành hóa đơn điện tử
        /// </summary>
        public string GetListShopeeInvoiceInformation = "/api/v2/order/get_buyer_invoice_info";
        #endregion
    }
}