using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    /// <summary>
    /// Base phản hồi từ viettelpost
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VTPBaseResponse<T>
    {
        /// <summary>
        /// Trạng thái phản hồi
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Có lỗi không
        /// </summary>
        public bool error { get; set; }

        /// <summary>
        /// Tin nhắn phản hồi
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public T data { get; set; }

    }
}