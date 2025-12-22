using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class TiktokGetShopInfoResponse
    {
        public List<ShopInfo> shops { get; set; }
    }
    public class ShopInfo
    {

        public string id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string seller_type { get; set; }
        public string cipher { get; set; }
        public string code { get; set; }
    }
}