using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class VTPConfig
    {
        /// <summary>
        /// Endpoint VTP
        /// </summary>
        public string ApiUrl { get; set; } = "https://partner.viettelpost.vn/v2";

        /// <summary>
        /// Email Tài khoản đăng nhập
        /// </summary>
        public string Email { get; set; } = "0397593863";

        /// <summary>
        /// Mật khẩu tài khoản đăng nhập
        /// </summary>
        public string Password { get; set; } = "12345678@Abc";
    }
}