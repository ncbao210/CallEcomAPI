using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public class ShopeeBaseParam
    {
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

        /// <summary>
        /// Chuỗi làm mới token của shop trên shopee
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Đã thực hiện RefreshToken lần nào chưa
        /// </summary>
        public bool IsRefreshToken { get; set; } = false;

        /// <summary>
        /// Dữ liệu của services trả về
        /// </summary>
        public DataExtend DataExtend { get; set; }

        /// <summary>
        /// Gói tin gửi shopee
        /// </summary>
        public ShopeeBaseRequest objRequest { get; set; }

        /// <summary>
        /// Có phải call api publish không, nếu có thì không cần accessToken
        /// </summary>
        public bool IsPublishAPI { get; set; }

        /// <summary>
        /// Có phải call api publish không, nếu có thì không cần accessToken
        /// </summary>
        public long ShopId { get; set; }

        /// <summary>
        /// Có phải call api publish không, nếu có thì không cần accessToken
        /// </summary>
        public Dictionary<string, object> ObjectExtends { get; set; }
    }

    public class DataExtend
    {

        /// <summary>
        /// Token của shop trên shopee
        /// </summary>
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// Chuỗi làm mới token của shop trên shopee
        /// </summary>
        public string RefreshToken { get; set; } = "";
    }
}