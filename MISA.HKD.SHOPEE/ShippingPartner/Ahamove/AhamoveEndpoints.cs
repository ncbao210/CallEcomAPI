using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class AhamoveEndpoints
    {
        /// <summary>
        /// Đăng nhập tài khoản
        /// </summary>
        public const string SignIn = "/v1/partner/register_account";

        /// <summary>
        /// Tính phí vận chuyển đơn hàng
        /// </summary>
        public const string CalculateFee = "/v1/order/estimated_fee";



        /// <summary>
        /// Tạo đơn hàng trên AhaMove
        /// </summary>
        public const string CreateOrder = "/v1/order/create";

        /// <summary>
        /// Hủy đơn hàng
        /// </summary>
        public const string CancelOrder = "/v1/order/cancel";



        /// <summary>
        /// Lấy thông tin chi tiết đơn hàng
        /// </summary>
        public const string OrderDetail = "/v1/order/detail";

        /// <summary>
        /// Đường dẫn lấy danh sách dịch vụ AhaMove
        /// </summary>
        public const string GetServiceList = "/v1/order/service_types";

        /// <summary>
        /// Đường dẫn lấy thông tin khách hàng
        /// </summary>
        public const string GetUserInfo = "/v1/user/profile";
    }
}