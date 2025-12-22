using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// Obj chứa thông tin danh sách Order trả về từ Shopee
    /// </summary>
    /// Created by NPCuong - 08/03/2019
    public class ShopeeListOrder : BaseShopeeResponse
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("orders")]
        public List<ShopeeOrder> Orders { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("more")]
        public bool More { get; set; }
    }
}