using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ApiResponse
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ApiResponse() { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public ApiResponse(int code, bool success, object data = null, string message = null)
        {
            this.code = code;
            this.success = success;
            this.data = data;
            this.message = message;
        }

        public bool success { get; set; } = true;
        public string message { get; set; }
        public int code { get; set; } = 200;
        public object data { get; set; }
        public int error { get; set; }

        /// <summary>
        /// Có phải trang cuối cùng không
        /// </summary>
        public bool IsLastPage { get; set; } = false;
        /// <summary>
        /// Có phải trang cuối cùng không
        /// </summary>
        public string PimaryKeyValue { get; set; }

        /// <summary>
        /// Dữ liệu lỗi (dạng object thì đưa về string JSON)
        /// </summary>
        public string dataerror { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; set; }
        /// <summary>
        /// Thông tin subcode từ api bên ngoài trả về (như facebook) nếu có
        /// </summary>
        public int ErrorSubCode { get; set; }

        #region Method
        public override string ToString()
        {
            if (success)
            {
                return $"success";
            }
            else
            {
                return $"failed - code: {code} - message: {message}";
            }
        }

        /// <summary>
        /// Gán giá trị trả về cho trường hợp success
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// <param name="data">Data trả về</param>
        /// Created by qvliem - 08/03/2018
        public void OnSuccess(object data = null, string message = "")
        {
            this.success = true;
            this.message = message;
            this.data = data;
        }
        public void OnTokenExpires()
        {
            this.success = false;
            this.code = 401;
        }
        

        /// <summary>
        /// Gán giá trị khi request không hợp lệ
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// Created by qvliem - 07/03/2018
        public void OnInvalidRequest(string message = "")
        {
            this.success = false;
            this.code = 400;
            this.message = string.IsNullOrWhiteSpace(message) ? "Invalid request" : message;
        }

        /// <summary>
        /// Dữ liệu insert đã tồn tại
        /// </summary>
        /// <param name="message"></param>
        public void OnDuplicate(string message = "")
        {
            this.success = false;
            this.code = 503;
            this.message = string.IsNullOrWhiteSpace(message) ? "Duplicate data" : message;
        }

        /// <summary>
        /// Gán giá trị khi gặp lỗi
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// <param name="data">Data trả về khi gặp lỗi</param>
        /// Created by qvliem - 08/03/2018
        public void OnError(string message = "Error when process request", object data = null, int code = 500)
        {
            this.success = false;
            this.code = code;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// Id của object master sau khi save xong trường hợp id tự tăng
        /// </summary>
        public Int64 MasterId { get; set; }

        /// <summary>
        /// Số lượng bản ghi tìm thấy
        /// </summary>

        public long MatchedCount { get; set; }

        /// <summary>
        /// Số lượng bản ghi được cập nhật
        /// </summary>

        public long ModifiedCount { get; set; }

        /// <summary>
        /// Gán giá trị khi gặp lỗi, chỉ gán mã lỗi, ko gán message
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// Created by ntngoc - 27/02/2019
        public void OnError(int code)
        {
            this.success = false;
            this.code = code;
        }
        #endregion
    }
}