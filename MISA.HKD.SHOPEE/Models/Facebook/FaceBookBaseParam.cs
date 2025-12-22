using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FaceBookBaseParam<Tbody>
    {
        /// <summary>
        /// Token truy cập được sử dụng để xác thực các yêu cầu gửi đến API của Facebook.
        /// BE truyền lên
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Thể hiện dữ liệu cơ thể của yêu cầu, kiểu dữ liệu này có thể được chỉ định bởi Tbody và có thể là null.
        /// BE truyền lên
        /// </summary>
        public Tbody Body { get; set; }


        /// <summary>
        /// Dữ liệu mở rộng, có thể chứa bất kỳ thông tin bổ sung nào cần thiết cho yêu cầu hoặc xử lý phản hồi.
        /// </summary>
        public object DataExtend { get; set; }


        /// <summary>
        /// Bộ sưu tập các tham số được gửi kèm trong yêu cầu, với khóa là tên tham số và giá trị tương ứng của nó.
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }
    }
}