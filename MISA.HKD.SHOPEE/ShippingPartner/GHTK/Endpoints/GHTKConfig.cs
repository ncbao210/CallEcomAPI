using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHTKConfig
    {
        /// <summary>
        /// Url API của GHTK
        /// </summary>
        public string ApiUrl { get; set; } = "https://services-staging.ghtklab.com";
        /// <summary>
        /// Token tài khoản chính của MISA OCM trên hệ thống của GHTK
        /// </summary>
        public string Token { get; set; } = "C558B6825299843f03E280eCe4E0b67f3037190a";
    }
}