using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeGetShippingDocumentRequest : ShopeeBaseRequest
    {
        /// <summary>
        /// Loại tài liệu vận chuyển.
        /// Các giá trị có thể: NORMAL_AIR_WAYBILL,THERMAL_AIR_WAYBILL,NORMAL_JOB_AIR_WAYBILL,THERMAL_JOB_AIR_WAYBILL
        /// ShopeeConstants.ShippingDocumentType
        /// </summary>
        public string shipping_document_type { get; set; } = "NORMAL_AIR_WAYBILL";
        // Danh sách đơn hàng
        public List<ShopeeOrderGetShippingDto> order_list { get; set; }
    }

    // lấy thông tin vận chuyển của đơn hàng Shopee
    public class ShopeeOrderGetShippingDto
    {
        /// <summary>
        /// ID đơn hàng
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// Mã định danh duy nhất của Shopee cho gói hàng dưới một đơn hàng.
        /// Bạn không nên điền trường này với chuỗi trống khi không có số gói hàng.
        /// </summary>
        public string package_number { get; set; }
    }

    public class DownloadOrderRequest : ShopeeBaseRequest
    {
       
        // Danh sách đơn hàng
        public List<ShopeeOrderGetShippingDto> order_list { get; set; }
        /// <summary>
        /// route
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// Chuỗi query string trong path chỉ dùng cho method Get
        /// </summary>
        public string PathTension { get; set; } = "";

        /// <summary>
        /// method call dữ liệu
        /// </summary>
        public Method Method { get; set; } = Method.POST;

        /// <summary>
        /// Token của shop trên shopee
        /// </summary>
        public string AccessToken { get; set; }
        public bool IsPublishAPI { get; set; }


    }

}