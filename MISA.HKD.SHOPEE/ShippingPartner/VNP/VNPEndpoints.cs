using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class VNPEndPoints
    {
        /// <summary>
        /// Cấp token để dùng cho các API khác
        /// </summary>
        public const string GetAccessToken = "/customer-partner/GetAccessToken";
        /// <summary>
        /// Khách hàng/ Đối tác gọi API để lấy thông tin cước của các sản phẩm dịch vụ được phép sử dụng theo thông tin đơn hàng mà Khách hàng/ Đối tác đã truyền vào.
        /// </summary>
        public const string CalculateFee = "/customer-partner/ServicesCharge";
        /// <summary>
        /// Hệ thống MyVNPost cung cấp API cho phép hệ thống Khách hàng/ đối tác có thể gọi để truyền các thông tin đơn hàng trong nước mới cần tạo trên hệ thống MyVNPost.
        /// Điều kiện ràng buộc để đối tác tạo được đơn hàng cho khách hàng trên MyVNPost qua kênh API:
        // Đối tác:
        //Chỉ được phép tạo đơn cho khách hàng khi khách hàng khai báo cho phép đối tác tạo đơn trên MyVNPost
        //Trạng thái Đối tác đang hoạt động
        // Khách hàng:
        //Có tài khoản còn hiệu lực trên MyVNPost, không bắt buộc phải ký hợp đồng với VNPost
        /// </summary>
        public const string CreateOrder = "/customer-partner/CreateOrder";

        /// <summary>
        /// Hệ thống MyVNPost cung cấp API cho phép hệ thống Khách hàng/ đối tác có thể hủy đơn hàng trong nước/quốc tế qua API. Khách hàng/ đối tác chỉ được phép hủy những đơn hàng do chính khách hàng đã tạo trên MyVNPost qua kênh API và đơn hàng đó chưa được lấy hàng thành công.
        /// </summary>
        public const string CancelOrder = "/customer-partner/orderCancel";

        /// <summary>
        /// API lấy chi tiết đơn hàng
        /// </summary>
        public const string OrderDetails = "/customer-partner/getOrder";

    }
}