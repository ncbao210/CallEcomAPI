using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.HKD.SHOPEE.Models
{
    /// <summary>
    /// Param chung khi call tiktok
    /// </summary>
    public class TiktokBaseParam<TBody>
    {

        /// <summary>
        /// Accesstoken
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Đã thực hiện refresh token lần nào chưa
        /// </summary>
        public bool IsRefreshToken { get; set; }

        /// <summary>
        /// Body của request Method != Get
        /// </summary>
        public TBody Body { get; set; }

        /// <summary>
        /// Định danh shop
        /// </summary>
        public string ShopCipher { get; set; }

        /// <summary>
        /// Endpoint tiktok cần gọi
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// Method (Get, Put, Post, Delete)
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// Thông tin mở rộng khi gọi api tiktok
        /// </summary>
        public TiktokDataExtend DataExtend { get; set; }

        /// <summary>
        /// Có phải request đăng file lên tiktok không?
        /// </summary>
        public bool IsUploadFile { get; set; }

        /// <summary>
        /// File dang tiktok
        /// </summary>
        public Byte[] File { get; set; }

        public string ID { get; set; }
        public int PageSize { get; set; } = 100;
        public string PageToken { get; set; }

    }
    /// <summary>
    /// Thông tin mở rộng khi gọi api tiktok
    /// </summary>
    public class TiktokDataExtend
    {
        /// <summary>
        /// Token của shop trên tiktok
        /// </summary>
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// Chuỗi làm mới token của shop trên tiktok
        /// </summary>
        public string RefreshToken { get; set; } = "";
        /// <summary>
        /// Hạn token
        /// </summary>
        public DateTime? AccessTokenExpireIn { get; set; }

        /// <summary>
        /// Hạn RefreshToken
        /// </summary>
        public DateTime? RefreshTokenExpireIn { get; set; }


    }
}