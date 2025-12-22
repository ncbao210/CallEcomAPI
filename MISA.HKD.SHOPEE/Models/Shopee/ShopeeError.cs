using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE.Models
{
    public enum ShopeeError
    {
        /// <summary>
        /// Lỗi trong dữ liệu đầu vào
        /// </summary>
        error_params,
        /// <summary>
        /// Lỗi authen. Ví dụ: signature is wrong
        /// </summary>
        error_auth,
        /// <summary>
        /// Lỗi serve
        /// </summary>
        error_server,
        /// <summary>
        /// Quá nhiều resquest. Tôi đa 1000 request trên phút
        /// </summary>
        error_too_many_request,
        /// <summary>
        /// Lỗi không hỗ trợ action
        /// </summary>
        error_not_support,
        /// <summary>
        /// Lỗi xảy ra bên trong
        /// </summary>
        error_inner_error,
        /// <summary>
        /// Lỗi trùng
        /// </summary>
        error_duplicate,
        /// <summary>
        /// Lỗi trong dữ liệu đầu vào
        /// </summary>
        error_param,
        /// <summary>
        /// Lỗi không xác định
        /// </summary>
        error_unknown,
        /// <summary>
        /// Mã lỗi shop đang tạm nghỉ
        /// </summary>
        error_holiday_on_add_item,
        /// <summary>
        /// Thông tin vận chuyển không hơp lệ
        /// </summary>
        error_invalid_logistic_info,
    }
}