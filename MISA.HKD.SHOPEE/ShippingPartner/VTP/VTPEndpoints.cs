using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    /// <summary>
    /// Danh sách các API của dịch vụ ViettelPost
    /// </summary>
    public class VTPEndpoints
    {
        /// <summary>
        /// Đường dẫn tới API Tính cước cho vận đơn
        /// </summary>
        public const string GetPrice = "/order/getPrice";

        /// <summary>
        /// Đường dẫn tới API tạo mới vận đơn
        /// </summary>
        public const string CreateOrder = "/order/createOrder";

        /// <summary>
        /// Đường dẫn APi cập nhật trạng thái vận đơn
        /// </summary>
        public const string UpdateOrder = "/order/UpdateOrder";

        /// <summary>
        /// Lấy danh sách các đơn hàng có trong kho
        /// </summary>
        public const string ListInventory = "/user/listInventory";

        /// <summary>
        /// Đường dẫn tới API đăng nhập tài khoản đối tác Viettel
        /// </summary>
        public const string Login = "/user/Login";

        /// <summary>
        /// Đường dẫn API kết nối tài khoản khách hàng
        /// </summary>
        public const string OwnerConnect = "/user/ownerconnect";

        /// <summary>
        /// Đường dẫn tới API đăng ký tài khoản khách hàng
        /// </summary>
        public const string OwnerRegister = "/user/ownerRegister";

        /// <summary>
        /// Đường dẫn tới API lấy danh sách các dịch vụ
        /// </summary>
        public const string ListService = "/categories/listService";

        /// <summary>
        ///
        /// </summary>
        public const string GetPriceAll = "/order/getPriceAll";

        /// <summary>
        /// Đường dẫn tới APi gọi để gửi lại yêu cầu bắn lại webhook từ ViettelPost
        /// </summary>
        public const string RegisterOrderHook = "/order/registerOrderHook";

        /// <summary>
        /// Endpoint lấy link in phiếu giao hàng
        /// </summary>
        public const string GetLinkPrintOrder = "/order/encryptLinkPrint";


        public const string CreateStore = "/user/registerInventory";
    }
}