using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookBatchParam
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "batch")]
        public string Batch { get; set; }
    }

    public class FacebookBatchRequest
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; } = "GET";

        [JsonProperty(PropertyName = "relative_url")]
        public string RelativeUrl { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

    }

    /// <summary>
    /// Định nghĩa phản hồi từ một batch request gửi đến Facebook Graph API.
    /// </summary>
    public class FacebookBatchResponse
    {
        /// <summary>
        /// Mã code của FB phản hồi
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// Nội dung phản hồi dưới dạng chuỗi JSON. Bao gồm dữ liệu trả về hoặc thông báo lỗi từ Facebook Graph API.
        /// </summary>
        public string body { get; set; }
    }
}