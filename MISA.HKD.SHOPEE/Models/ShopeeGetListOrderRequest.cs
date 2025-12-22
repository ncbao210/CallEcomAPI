using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// Model chứa tham số truyền lên lấy danh sách đơn hàng
    /// </summary>
    public class ShopeeGetListOrderRequest : BaseShopeeRequest
    {
        /// <summary>
        /// Thời gian tạo đơn hàng
        /// </summary>
        public long create_time_from { get; set; }

        /// <summary>
        /// Thời gian tạo đơn hàng tới
        /// </summary>
        public long create_time_to { get; set; }

        /// <summary>
        /// Thời gian cập nhật đơn hàng
        /// </summary>
        public long update_time_from { get; set; }

        /// <summary>
        /// Thời gian cập nhật đến
        /// </summary>
        public long update_time_to { get; set; }

        /// <summary>
        /// Số bản ghi lấy trong một lần
        /// </summary>
        public int pagination_entries_per_page { get; set; }

        /// <summary>
        /// Số bản ghi không lấy
        /// </summary>
        public int pagination_offset { get; set; }
    }
}