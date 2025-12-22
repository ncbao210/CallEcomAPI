using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
 /// Các thông tin để call API của Shopee để thông tin chi tiết đơn hàng
 /// </summary>
    public class ShopeeGetOrderDetailRequest : BaseShopeeRequest
    {
        /// <summary>
        /// Danh sách số hóa đơn
        /// </summary>
        public List<string> ordersn_list { get; set; }
    }
}