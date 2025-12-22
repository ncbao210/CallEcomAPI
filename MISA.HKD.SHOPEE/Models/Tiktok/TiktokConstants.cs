using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// ntvu1 (15/08/24)
    /// </summary>
    public class TiktokConstants
    {
        /// <summary>
        /// Dùng để tạo URL cuối cho các lời gọi API yêu cầu xác định cửa hàng.
        /// </summary>
        public const string Pathend = "?timestamp={0}&app_key={1}&shop_cipher={2}";

        /// <summary>
        /// Dùng để tạo URL cuối cho các lời gọi API không yêu cầu xác định cửa hàng.
        /// </summary>
        public const string PathendNoCipher = "?timestamp={0}&app_key={1}";

        /// <summary>
        /// Dấu phân cách href với pathend
        /// </summary>
        public const char SplitterParam = '?';

        /// <summary>
        /// Version api key
        /// </summary>
        public const string VersionApiKey = "version_api";


        #region Appsetting key

        public const string TiktokAppKey = "AppKey";
        public const string AppKeySecret = "AppKeySecret";
        public const string TikTokWebHookUrl = "TikTokWebHookUrl";
        public const string TiktokAPIVersion = "TiktokAPIVersion";
        public const string TiktokAPIUrl = "TiktokAPIUrl";
        public const string TiktokAuthUrl = "TiktokAuthUrl";

        #endregion
    }
}