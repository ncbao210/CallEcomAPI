using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHNEndpoints
    {
        /// <summary>
        /// Sử dụng API này để lấy các gói dịch vụ theo tuyến.
        /// </summary>
        public const string GetService = "/shipping-order/available-services";
        /// <summary>
        /// Sử dụng API này để tính phí dịch vụ trước khi Tạo đơn qua GHN.
        /// </summary>
        public const string GetFeeOneService = "/shipping-order/fee";
        /// <summary>
        /// API Tạo đơn
        /// </summary>
        public const string CreateOrder = "/shipping-order/create";
        /// <summary>
        /// Sử dụng API này để lấy chi tiết thông tin của đơn hàng.
        /// </summary>
        public const string OrderInfo = "/shipping-order/detail";
        /// <summary>
        /// Sử dụng API này để thay đổi các thông tin đơn hàng ngoại trừ COD.
        /// </summary>
        public const string UpdateOrder = "/shipping-order/update";
        /// <summary>
        /// Sử dụng API này để thay đổi các thông tin đơn hàng ngoại trừ COD.
        /// </summary>
        public const string CancelOrder = "/switch-status/cancel";
        /// <summary>
        /// Sử dụng API này để trả lại hàng khi người gửi muốn hủy giao.
        /// </summary>
        public const string ReturnOrder = "/switch-status/return";
        /// <summary>
        /// Sử dụng API này để lấy danh sách cửa hàng.
        /// </summary>
        public const string GetShops = "/shop/all";
        /// <summary>
        /// Sử dụng API này để lấy ra danh sách bưu cục để tạo đơn hàng khi mang hàng ra bưu cục gửi.
        /// </summary>
        public const string GetPostOffice = "/station/get";
        /// <summary>
        /// Sử dụng API này để lấy danh sách các ca lấy.
        /// </summary>
        public const string PickShift = "/shift/date";
        /// <summary>
        /// Sử dụng API này để lấy OTP từ số điện thoại chủ cửa hàng
        /// </summary>
        public const string GetOTP = "/shop/affiliateOTP";
        /// <summary>
        /// Sử dụng API này để thêm nhân viên vào cửa hàng để quản lý cửa hàng thông qua việc gửi OTP về điện thoại chủ cửa hàng.
        /// </summary>
        public const string AddStaffToStore = "/shop/affiliateCreateWithShop";

        /// <summary>
        /// API In thông tin đơn hàng
        /// </summary>
        public const string GetTokenPrintOrder = "/a5/gen-token";

        /// <summary>
        /// Endpoint url in khổ 50x72
        /// </summary>
        public const string LinkPrint50x72 = "/print52x70?token={0}";
        /// <summary>
        /// Endpoint url in khổ 80x80
        /// </summary>
        public const string LinkPrint80x80 = "/print80x80?token={0}";
        /// <summary>
        /// Endpoint in khổ A5
        /// </summary>
        public const string LinkPrintA5 = "/printA5?token={0}";
    }
}