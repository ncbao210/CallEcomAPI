using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHNConfig
    {
        /// <summary>
        /// API Url GHN
        /// </summary>
        public string ApiUrl { get; set; } = "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/";

        /// <summary>
        /// Token của GHN
        /// </summary>
        public string Token { get; set; }
    }
}