using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookGetUserInfo : FacebookBaseResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("picture")]
        public PictureProperty Picture { get; set; }
    }

    public class PictureProperty
    {
        [JsonProperty("data")]
        public PictureInfo Data { get; set; }
    }

    /// <summary>
    /// Lớp PictureInfo chứa thông tin về hình ảnh được lấy từ Facebook Graph API.
    /// </summary>
    public class PictureInfo
    {
        /// <summary>
        /// Chiều cao của hình ảnh.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Một giá trị boolean chỉ ra liệu hình ảnh có phải là một hình ảnh mặc định (silhouette) không.
        /// Trong trường hợp người dùng không cung cấp hình đại diện, Facebook sẽ trả về một hình ảnh silhouette mặc định.
        /// </summary>
        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }

        /// <summary>
        /// URL của hình ảnh. Đây là đường dẫn trực tiếp đến hình ảnh trên Facebook.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Chiều rộng của hình ảnh.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
    }
}