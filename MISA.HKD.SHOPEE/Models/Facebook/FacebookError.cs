using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    /// <summary>
    /// Mã lỗi của Facebook
    /// </summary>
    public enum FacebookErrorCode : int
    {
        /// <summary>
        /// Lỗi không xác định
        /// </summary>
        UnknownError = 1,
        /// <summary>
        /// Lỗi token
        /// </summary>
        InvalidOAuthAccessToken = 190,
        /// <summary>
        /// Lỗi exception
        /// </summary>
        Exception = 100,
        /// <summary>
        /// Lỗi Exception
        /// </summary>
        SaveDataErrorException = 2,
        /// <summary>
        /// Lỗi lưu dữ liệu vào DB
        /// </summary>
        ErrorSave = 3,
        /// <summary>
        /// Lỗi ko lấy được thông tin comment cấp 1 từ facebook khi nhận được webhook tin nhắn, bình luận
        /// </summary>
        FacebookGetCommentLevel1Error = 4,
        /// <summary>
        /// Lỗi ko lấy được thông tin User từ facebook
        /// </summary>
        FacebookGetUserInfoError = 5,
        /// <summary>
        /// Lỗi không gửi được tin nhắn theo chính sách 24Hour của FB
        /// </summary>
        Message24Hour = 10,

        /// <summary>
        /// Lỗi gửi tin nhắn chính sách của Facebook
        /// </summary>
        SubCode_SendMessage = 2018278,
        /// <summary>
        /// Lỗi gửi tin nhắn ảnh
        /// </summary>
        SubCode_SendMessageImageUrlNotFetch = 2018008,

        /// <summary>
        /// Lỗi gửi tin nhắn facebook ko gửi đến người nhận được do người nhận ko tương tác vs Page
        /// </summary>
        FacebookError_SubCode_ReceipientInValid = 1545041

    }

    public class FacebookError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error_subcode")]
        public int ErrorSubCode { get; set; }

        [JsonProperty("fbtrace_id")]
        public string FbtraceId { get; set; }

        public override string ToString()
        {
            return $"Type: {Type} - Code: {Code} - Message: {Message}";
        }
    }
}