using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookGetTokenResponse : FacebookBaseResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
    public class FacebookIDParam<T> : FaceBookBaseParam<T>
    {
        public string ID { get; set; }

    }
    /// <summary>
    /// Tham số để chỉnh sửa bài đăng đã xuất bản trên Facebook.
    /// </summary>
    public class UpdatePostParam : FacebookIDParam<UpdatePostBody>
    {
    }
    public class AttachMedia
    {
        public string media_fbid { get; set; }
    }
    /// <summary>
    /// Cơ thể của yêu cầu chỉnh sửa bài đăng.
    /// </summary>
    public class UpdatePostBody
    {
        /// <summary>
        /// Nội dung tin nhắn mới của bài đăng.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Danh sách các phương tiện đính kèm mới cho bài đăng.
        /// </summary>
        public List<AttachMedia> attached_media { get; set; }

        /// <summary>
        /// Mô tả bài viết (nếu là bài post video thì dùng trường này để update)
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Thời gian đặt lịch đăng
        /// </summary>
        public int? scheduled_publish_time { get; set; }

        /// <summary>
        /// Bài post có được publish luôn hay không
        /// Mặc định là Publish luôn
        /// Nếu false thì cần có scheduled_publish_time
        /// Nếu chuyển từ false -> true thì bài đăng sẽ được publish luôn
        /// </summary>
        public bool? is_published { get; set; }

        /// <summary>
        /// Có ghim bài viết hay không (nếu ghim sẽ vào phần "Đáng chú ý")
        /// </summary>
        public bool? is_pinned { get; set; }

        public bool? is_hidden { get; set; }

    }
}