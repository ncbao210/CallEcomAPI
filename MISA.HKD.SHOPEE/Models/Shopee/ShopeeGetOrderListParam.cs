using System.Collections.Generic;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeGetOrderListParam : ShopeeBaseParam
    {
        /// <summary>
        /// Mỗi kết quả được trả về dưới dạng một trang gồm nhiều mục nhập. Sử dụng bộ lọc "page_size" để kiểm soát số lượng mục nhập tối đa được truy xuất mỗi trang (tức là, mỗi lần gọi). Giá trị số nguyên này được sử dụng để chỉ định số lượng mục nhập tối đa trả về trong một "trang" dữ liệu. Giới hạn của page_size nằm giữa 1 và 100.
        /// [R]
        /// </summary>
        public int page_size { get; set; } = 100;
        /// <summary>
        /// 
        /// </summary>
        public int page_no { get; set; } = 1;
        /// <summary>
        /// Các trường tùy chọn trong phản hồi. Giá trị có sẵn: order_status.
        /// </summary>
        public string response_optional_fields { get; set; } = "order_status";
        /// <summary>
        //Bộ lọc order_status để truy xuất đơn hàng và mỗi lần chỉ yêu cầu một trạng thái. Giá trị có sẵn: UNPAID/READY_TO_SHIP/PROCESSED/SHIPPED/COMPLETED/IN_CANCEL/CANCELLED/INVOICE_PENDING
        /// </summary>
        public string order_status { get; set; }

        /// <summary>
        /// Chỉ định mục nhập bắt đầu của dữ liệu để trả về trong lần gọi hiện tại. Mặc định là "". Nếu dữ liệu nhiều hơn một trang, offset có thể là một số mục nhập nào đó để bắt đầu lần gọi tiếp theo.
        /// </summary>
        public string cursor { get; set; } = "";
        /// <summary>
        /// Loại của time_from và time_to. Giá trị có sẵn: create_time, update_time.
        /// [R]
        /// </summary>
        public string time_range_field { get; set; } = "create_time";
        /// <summary>
        //Các trường time_from và time_to chỉ định một khoảng thời gian để truy xuất đơn hàng (dựa trên time_range_field). Trường time_from là khoảng thời gian bắt đầu. Khoảng thời gian tối đa có thể chỉ định với các trường time_from và time_to là 15 ngày.
        /// [R]
        /// </summary>
        public long time_from { get; set; }
        /// <summary>
        /// Tạo đơn trả từ
        /// </summary>
        public long create_time_from { get; set; }
        /// <summary>
        /// Tạo đơn trả đến
        /// </summary>
        public long create_time_to { get; set; }
        public long update_time_from { get; set; }
        /// <summary>
        /// Tạo đơn trả đến
        /// </summary>
        public long update_time_to { get; set; }
        /// <summary>
        /// Các trường time_from và time_to chỉ định một khoảng thời gian để truy xuất đơn hàng (dựa trên time_range_field). Trường time_from là khoảng thời gian bắt đầu. Khoảng thời gian tối đa có thể chỉ định với các trường time_from và time_to là 15 ngày.
        /// [R]
        /// </summary>
        public long time_to { get; set; }

        /// <summary>
        //Tham số tương thích trong thời gian chuyển đổi, gửi True sẽ cho phép API hỗ trợ trạng thái PENDING, gửi False hoặc không gửi sẽ quay về logic cũ.
        /// </summary>
        public bool request_order_status_pending { get; set; }

    }

    public class AvailableSolutionParam : ShopeeBaseParam
    {
        /// <summary>
        /// mã đơn chuyển hoàn 
        /// </summary>
        public string return_sn { get; set; }
        

    }
    public class OrderDetailParam : ShopeeBaseParam
    {
        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public string order_sn_list { get; set; }


    }

    public class BuyerInvoiceInfoParam : ShopeeBaseRequest
    {
        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public List<BuyerInvoiceInf> queries { get; set; }


    }

    public class BuyerInvoiceInf
    {
        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public string order_sn { get; set; }


    }

    public class CreateShipping : ShopeeBaseParam
    {
       

        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public List<OrderShopee> order_list { get; set; }
    }

    public class GetBuyerInvoiceInfoParam : ShopeeBaseParam
    {


        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public List<OrderSnShopee> queries { get; set; }
    }

    public class GetBuyerInvoiceInfoRequest : ShopeeBaseRequest
    {


        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public List<OrderSnShopee> queries { get; set; }
    }

    public class OrderCreate : ShopeeBaseRequest
    {
        /// <summary>
        /// Danh sách các đơn cần lấy chi tiết, ngăn cách nhau dấu ,
        /// </summary>
        public List<OrderShopee> order_list { get; set; }


    }
    public class OrderSnShopee
    {
        /// <summary>
        /// mã dơn trên sàn
        /// </summary>
        public string order_sn { get; set; }
    }
    public class OrderShopee 
    {
        /// <summary>
        /// mã dơn trên sàn
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// mã vận đơn
        /// </summary>
        public string tracking_number { get; set; }



    }

}