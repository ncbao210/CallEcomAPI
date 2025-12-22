using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// Obj chứa thông tin
    /// </summary>
    public class ShopeeOrder
    {
        /// <summary>
        /// Phí giao hàng dự kiến
        /// </summary>
        public string estimated_shipping_fee { get; set; }

        /// <summary>
        /// Phương thức thanh toán
        /// </summary>
        public string payment_method { get; set; }

        /// <summary>
        /// Thời gian cập nhật
        /// </summary>
        public int update_time { get; set; }

        /// <summary>
        /// Tin nhắn đến người bán
        /// </summary>
        public string message_to_seller { get; set; }

        /// <summary>
        /// Tên đơn vị vận chuyển
        /// </summary>
        public string shipping_carrier { get; set; }

        /// <summary>
        /// Tên đơn vị tiền tệ
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// Thời gian khởi tạo đơn hnafg
        /// </summary>
        public int create_time { get; set; }

        /// <summary>
        /// Thời gian thanh toán
        /// </summary>
        public int? pay_time { get; set; }

       

        /// <summary>
        /// Số thẻ thanh toán
        /// </summary>
        public string credit_card_number { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// Mã vận đơn của đối tác giao vận
        /// </summary>
        public string tracking_no { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public string order_status { get; set; }

        /// <summary>
        /// Thời gian cập nhật ghi chú
        /// </summary>
        public int note_update_time { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string dropshipper_phone { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string escrow_amount { get; set; }

        /// <summary>
        /// Số ngày vận chuyển ước tính
        /// </summary>
        public int days_to_ship { get; set; }

        /// <summary>
        /// Có phải vận chuyển hàng hóa không
        /// </summary>
        public bool goods_to_declare { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán
        /// </summary>
        public string total_amount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string service_code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string country { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string actual_shipping_cost { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool cod { get; set; }

        ///// <summary>
        /////
        ///// </summary>
        //public List<ShopeeOrderItem> items { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ordersn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string dropshipper { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string buyer_username { get; set; }
    }
}