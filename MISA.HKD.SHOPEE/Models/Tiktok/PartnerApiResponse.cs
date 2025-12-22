using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class PartnerApiResponse
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PartnerApiResponse() { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public PartnerApiResponse(int code, bool success, object data = null, string message = null)
        {
            this.Code = code;
            this.Success = success;
            this.Data = data;
            this.Message = message;
        }
        /// <summary>
        /// Thành công hay không
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Nội dung lỗi
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int Code { get; set; } = 200;
        /// <summary>
        /// Dữ liệu gói tin trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Dữ liệu custom nội bộ trả về
        /// </summary>
        public object DataExtend { get; set; }
        /// <summary>
        /// Lỗi
        /// </summary>
        public object Error { get; set; }
        /// <summary>
        /// Thông tin subcode từ api bên ngoài trả về (như facebook) nếu có
        /// </summary>
        public int ErrorPartner { get; set; }

        #region Method
        public override string ToString()
        {
            if (Success)
            {
                return $"success";
            }
            else
            {
                return $"failed - code: {Code} - message: {Message}";
            }
        }

        /// <summary>
        /// Gán giá trị trả về cho trường hợp success
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// <param name="data">Data trả về</param>
        /// ndchien (15/08/24)
        public void OnSuccess(object data = null, string message = "", int code = 200)
        {
            this.Success = true;
            this.Message = message;
            this.Data = data;
            this.Code = code;
        }
        public void OnTokenExpires()
        {
            this.Success = false;
            this.Code = 401;
        }
        /// <summary>
        /// Gán giá trị cho ApiResponse khi gặp Exception
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="ex">Exception object</param>
        /// ndchien (15/08/24)
        public void OnException(Exception ex)
        {
            if (ex != null)
            {
                this.Success = false;
                this.Code = 500;
                this.Message = ex.Message;
            }
        }
        public void OnException(string exmessage, int code = 500)
        {
            this.Success = false;
            this.Code = (int)code;
            this.Message = exmessage;
        }

        /// <summary>
        /// Gán giá trị khi request không hợp lệ
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// ndchien (15/08/24)
        public void OnInvalidRequest(string message = "")
        {
            this.Success = false;
            this.Code = 400;
            this.Message = string.IsNullOrWhiteSpace(message) ? "Invalid request" : message;
        }

        /// <summary>
        /// Gán giá trị khi gặp lỗi
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// <param name="message">Message custom</param>
        /// <param name="data">Data trả về khi gặp lỗi</param>
        /// ndchien (15/08/24)
        public void OnError(string message = "Error when process request", object data = null, int code = 500)
        {
            this.Success = false;
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Gán giá trị khi gặp lỗi, chỉ gán mã lỗi, ko gán message
        /// </summary>
        /// <param name="res">ApiResponse</param>
        /// ndchien (15/08/24)
        public void OnError(int code)
        {
            this.Success = false;
            this.Code = code;
        }
        #endregion
    }
}