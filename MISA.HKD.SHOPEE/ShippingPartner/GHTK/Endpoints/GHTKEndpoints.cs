using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.ShippingPartner.Endpoints
{
    public class GHTKEndpoints
    {
        /// <summary>
        /// Tính phí vận chuyển
        /// </summary>
        public const string CalculateFee = "/services/shipment/fee";
        /// <summary>
        /// Đăng đơn hàng
        /// </summary>
        public const string CreateOrder = "/services/shipment/order";
        /// <summary>
        /// Chi tiết đơn hàng
        /// </summary>
        public const string GetOrderStatus = "/services/shipment/v2/";
        /// <summary>
        /// In đơn hàng
        /// </summary>
        public const string PrintOrderInfo = "/services/label/";
        /// <summary>
        /// Hủy đơn hàng
        /// </summary>
        public const string CancelOrder = "/services/shipment/cancel/";
        /// <summary>
        /// Đăng nhập
        /// </summary>
        public const string SignIn = "/services/shops/token";
        /// <summary>
        /// Đăng ký
        /// </summary>
        public const string SignUp = "/services/shops/add";
        /// <summary>
        /// Đăng ký webhook
        /// </summary>
        public const string AddWebhook = "/services/webhook/add";
        /// <summary>
        /// Xóa hook
        /// </summary>
        public const string DeleteWebhook = "/services/webhook/del";
        /// <summary>
        /// Thông tin log đơn hàng
        /// </summary>
        public const string GetOrderLogs = "/GetOrderLogs";
        /// <summary>
        /// Lấy địa chỉ cấp 4
        /// </summary>
        public const string GetProvincelV4 = "/services/address/getAddressLevel4";

        public const string GetListPickAdd = "/services/shipment/list_pick_add";
    }
}