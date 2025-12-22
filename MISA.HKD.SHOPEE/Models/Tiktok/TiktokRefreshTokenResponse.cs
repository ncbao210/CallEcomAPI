using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class TiktokRefreshTokenResponse
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// Hạn token
        /// </summary>
        public long access_token_expire_in { get; set; }

        /// <summary>
        /// Hạn refresh token
        /// </summary>
        public long refresh_token_expire_in { get; set; }
    }
}