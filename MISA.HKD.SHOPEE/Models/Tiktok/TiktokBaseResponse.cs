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
    public class TiktokBaseResponse<TData>
    {
        /// <summary>
        /// Mã trạng thái thành công hoặc thất bại được trả về trong phản hồi API
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// Thông báo thành công hoặc thất bại được trả về trong phản hồi API. Lý do thất bại sẽ được mô tả trong tin nhắn
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Id của request
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public TData data { get; set; }
    }
}