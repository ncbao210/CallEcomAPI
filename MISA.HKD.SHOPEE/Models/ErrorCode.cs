using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MISA.HKD.SHOPEE.Models
{
    public enum Code
    {
        OK = 200,
        Error = 500,
        NotFound = 404,
        Duplicate = 600,
        /// <summary>
        /// Trùng mã
        /// </summary>
        DuplicateCode = 601,

        /// <summary>
        /// Trùng mã vạch
        /// </summary>
        DuplicateBarCode = 602,

        Invalid = 400,
        Unauthorized = 401,

        NotCompanyId = 402,
        PeriodInvalid = 403,
        NotReasonId = 405,

        Exception = 404,

        /// <summary>
        /// Tham số không hợp lệ
        /// </summary>
        Error_Param = 510,

        /// <summary>
        /// Đã phát sinh dữ liệu
        /// </summary>
        Refercene = 700,

        /// <summary>
        /// Lỗi tài khoản đối tác
        /// </summary>
        EcomAccount_Error = 1001,

        /// <summary>
        /// Lỗi tài khoản sàn đã kết nối đến domain khác
        /// </summary>
        EcomAccount_IsConnectedWithOtherDomain = 1002,
        /// <summary>
        /// Lỗi tài khoản sàn ko tìm thấy hoăc ko hợp lệ
        /// </summary>
        EcomAccount_InvalidSellerId = 1003,
        /// <summary>
        /// Lỗi mã bảo mật sàn ko tìm thấy hoăc ko hợp lệ
        /// </summary>
        EcomAccount_InvalidSecretkey = 1004,
        #region dải 1200-1300 mã lỗi mysql

        /// <summary>
        /// Deadlock MySQL
        /// </summary>
        Deadlock = 1200,

        /// <summary>
        /// Lỗi lưu dữ liệu bị conflict khóa ngoại
        /// </summary>
        Contraint = 1201,

        #endregion dải 1200-1300 mã lỗi mysql

        #region Dải 2000 - 2100: Lỗi Social

        /// <summary>
        /// Lỗi đồng bộ conversation đang tạm thời chặn
        /// </summary>
        SyncConversationIsPending = 2000,
        /// <summary>
        /// Lỗi đồng bộ conversation id của Page trống
        /// </summary>
        SyncConversationPageIsNull = 2001,
        /// <summary>
        /// Lỗi đồng bộ conversation chưa đến thời gian được phép đồng bộ
        /// </summary>
        SyncConversationIsNotTime = 2002,
        /// <summary>
        /// Lỗi domain đang được connect đến 1 tài khoản facebook khác
        /// </summary>
        CompanyIsConnectedToAnotherFacebook = 2003,
        #endregion

        #region Dải 2101 - 2200: Lỗi Shopee
        /// <summary>
        /// Tài khoản Shopee đã được kết nối đến domain khác rồi
        /// </summary>
        ShopeeAccountIsConnectedWithOtherDomain = 2101,
        /// <summary>
        /// There are errors in the input parameters
        /// </summary>
        Shopee_Error_Params = 2102,
        /// <summary>
        /// The request is not authenticated. Ex: signature is wrong
        /// </summary>
        Shopee_Error_Auth = 2103,
        /// <summary>
        /// An error has occurred
        /// </summary>
        Shopee_Error_Server = 2104,
        /// <summary>
        /// Too many request.Exceed 1000 request per min will be banned for an hour
        /// </summary>
        Shopee_Error_Too_Many_Request = 2105,
        /// <summary>
        /// Not support action
        /// </summary>
        Shopee_Error_Not_Support = 2106,
        /// <summary>
        /// An inner error has occurred
        /// </summary>
        Shopee_Error_Inner_Error = 2107,
        /// <summary>
        /// Khi hủy kết nối shopee trên 1 domain lỗi domain đó đã tồn tại kết nối đến tk shopee khác vs tk đang hủy
        /// </summary>
        Shopee_Disconnect_ExistedOtherEccomAccount = 2108,
        /// <summary>
        /// Khi 1 domain tranh kết nối vs 1 tk shopee đã kết nối vs domain này nhưng chính domain này lại đang kết nối đến tk khác
        /// </summary>
        Shopee_DomainIsConnecting_WhenConnectWithExistedShopeeAccount = 2109,
        /// <summary>
        /// Lỗi khi đăng hàng hóa, hàng hóa đó đã có trên shopee
        /// </summary>
        Shopee_Error_Duplicate = 2010,

        /// <summary>
        /// Lỗi khi đăng hàng hóa trọng lượng quá giới hạn cho phép
        /// </summary>
        Shopee_Invalid_Weight = 2011,
        /// <summary>
        /// Lỗi tham số truyền lên
        /// </summary>
        Shopee_Error_Param = 2012,
        /// <summary>
        /// Độ dai mô tả hàng hóa không hợp lệ
        /// </summary>
        Shopee_Error_Description = 2013,

        /// <summary>
        /// Lỗi không lấy được dữ liệu trên Shopee
        /// </summary>
        Shopee_Error_GetData = 2014,
        /// <summary>
        /// Thiếu thông tin bắt buộc
        /// </summary>
        Shopee_Error_Info = 2015,
        /// <summary>
        /// Thieu thông tin thuộc tinhd
        /// </summary>
        Shopee_Error_Attribute = 2016,
        /// <summary>
        /// Upload image shopee lỗi
        /// </summary>
        Shopee_Error_Image = 2017,
        /// <summary>
        /// Mã lỗi khách hàng ngăt kết nối với đối tác từ chính trên App của khách hàng
        /// </summary>
        Shopee_Error_AuthConnect = 2018,
        /// <summary>
        ///
        /// </summary>
        Shopee_Contain_Logistic = 2019,
        /// <summary>
        /// Lỗi đồng bộ tồn kho khi có tồn kho dự trữ cho khuyến mại
        /// </summary>
        Shopee_Error_Stock_Reserve = 2020,
        /// <summary>
        /// Refresh token thành công
        /// </summary>
        RefreshTokenShopeeSuccess = 2298,
        /// <summary>
        /// Unknown
        /// </summary>
        Shopee_Error_Unknown = 2199,
        /// <summary>
        /// Shop đang chế độ nghỉ
        /// </summary>
        Shopee_Vacation_Mode = 2200,

        #endregion

        #region Dải lỗi của Haravan
        [Display(Name = "Dữ liệu không hợp lệ")]
        Haravan_Unprocessable_Entity = 422,
        Haravan_Disconnect_ExistedOtherEccomAccount = 8000,
        Haravan_DomainIsConnecting_WhenConnectWithExistedHaravanAccount = 8001,
        [Display(Name = "Không lấy được thông tin shop tren Haravan")]
        Haravan_Error_Infoshop = 8005,
        /// <summary>
        /// Lỗi token haravan
        /// </summary>
        Haravan_IllegalAccessToken = 8006,
        #endregion

        #region Dải 2201-2300 lỗi của Ecom
        /// <summary>
        /// Lỗi trả về khi đồng bộ của tính năng đó đang được chạy rồi
        /// </summary>
        RunSyncEcom = 2201,
        /// <summary>
        /// Chưa đồng bộ hàng hóa
        /// </summary>
        NotSyncEcomProduct = 2202,
        /// <summary>
        /// Hủy đơn hàng chưa nhận xử lý
        /// </summary>
        CancelOrderStatusUnprocessing = 2239,
        #endregion

        #region Dải lỗi của sendo
        /// <summary>
        /// Lỗi tranh chấp domain
        /// </summary>
        SendoAccountIsConnectedWithOtherDomain = 2401,
        /// <summary>
        /// Khi 1 domain tranh kết nối vs 1 tk sendo đã kết nối vs domain này nhưng chính domain này lại đang kết nối đến tk khác
        /// </summary>
        Sendo_DomainIsConnecting_WhenConnectWithExistedSendoAccount = 2402,
        /// <summary>
        /// Sai Clientkey
        /// </summary>
        Sendo_ClientKeyFail = 2403,
        /// <summary>
        /// Lấy access token lỗi
        /// </summary>
        Sendo_GetTokenFail = 2404,
        /// <summary>
        /// Refresh token lỗi
        /// </summary>
        Sendo_RefreshTokenFail = 2405,
        /// <summary>
        /// Mã SKu không hợp lệ
        /// </summary>
        Ecom_SKuInValid = 2406,
        /// <summary>
        /// Trùng mã SKU
        /// </summary>
        Ecom_SKuDuplicate = 2407,
        /// <summary>
        /// Thông tin mô tả hoặc tên chứa kí tự cấm
        /// </summary>
        Ecom_DescriptionInvalid = 2408,
        #endregion

        #region Dải lỗi xử lý đơn hàng
        //Dải 2200 - 2300: Dải lỗi xử ký đơn hàng
        /// <summary>
        /// Đơn hàng đã được xử lý bởi thu ngân khác
        /// </summary>
        ProcessedByAnotherCashier = 2201,
        /// <summary>
        /// Không cho phép xuất kho âm
        /// </summary>
        DenyOutward = 2202,
        /// <summary>
        /// Cảnh báo khi xuất kho âm
        /// </summary>
        WarningOutward = 2203,
        /// <summary>
        /// Chưa mapping hàng hóa để xử lý đơn hàng
        /// </summary>
        NotMappingProduct = 2204,
        /// <summary>
        /// Chưa sẵn sàng giao hàng
        /// </summary>
        NotReadyToShip = 2205,
        /// <summary>
        /// Xử lý hủy đơn hàng
        /// </summary>
        CancelOrder = 2206,
        /// <summary>
        /// Xử lý chuyển hoàn đơn hàng
        /// </summary>
        ReturnOrder = 2207,
        /// <summary>
        /// Xử lý hoàn thành,Thất bại đơn hàng
        /// </summary>
        HandleOrder = 2208,
        /// <summary>
        /// Xử lý giao hàng thất bại
        /// </summary>
        DeliveryFailed = 2209,
        /// <summary>
        /// Xử lý hủy những đơn trang thương mại điện tử
        /// </summary>
        CancelOrderEcom = 2210,
        /// <summary>
        /// Xử lý hủy đơn hàng lazada
        /// </summary>
        CancelOrderEcomLazada = 2211,
        /// <summary>
        ///Không thể hủy đơn
        /// </summary>
        NotCancelOrder = 2212,
        /// <summary>
        ///Thiếu thông tin giao hàng
        /// </summary>
        NotEnoughInfoDelivery = 2213,
        /// <summary>
        /// Caal hàm xử lý đơn hàng
        /// </summary>
        ProcessOrder = 2214,
        /// <summary>
        /// Không có dịch vụ giao hàng
        /// </summary>
        NotServiceShipping = 2215,
        /// <summary>
        /// Xử lý thu COD
        /// </summary>
        ReceiveCOD = 2216,
        /// <summary>
        /// Chưa có thông tin bưu cục
        /// </summary>
        NotPostal = 2217,
        /// <summary>
        ///Không thể sửa đơn hàng
        /// </summary>
        NotEditOrder = 2218,
        /// <summary>
        ///Không thể sửa đơn hàng
        /// </summary>
        NotCancelReason = 2219,
        /// <summary>
        /// Không đồng ý xử lý bằng tay
        /// </summary>
        NotChangehandMade = 2220,
        /// <summary>
        /// Không thể sinh refNo bên Mshop
        /// </summary>
        NotGenerateRefNo = 2221,
        /// <summary>
        /// Đẩy vào queue Mshop bị lỗi
        /// </summary>
        PushQueueMshopError = 2222,
        /// <summary>
        /// Đơn hàng đã tồn tại trong hệ thống đối tác
        /// </summary>
        ShippingPartnerError = 2223,
        /// <summary>
        /// Không tồn tại đơn hàng
        /// </summary>
        NotExistOrder = 2224,
        /// <summary>
        /// Lỗi đồng bộ đơn hàng
        /// </summary>
        SyncOrderError = 2225,
        /// <summary>
        /// Thông tin quận, huyện,thành phố FromDistrictID,FromProvinceOrCityID,FromWardOrCommuneID bị trống
        /// </summary>
        InfoAddressOrderEmpty = 2226,
        /// <summary>
        /// Thông tin dịch vụ bị trống
        /// </summary>
        UpdateOrderFail = 2227,
        /// <summary>
        /// Thông tin dịch vụ bị trống
        /// </summary>
        ReceptionIdEmpty = 2228,
        /// <summary>
        /// Thông tin đối tác giao hàng bị trống
        /// </summary>
        ShippingPartnerIdEmpty = 2229,
        /// <summary>
        /// Thông tin tên hoặc SDT đối tác giao hàng cá nhân bị null
        /// </summary>
        InfoPartnerEmpty = 2230,
        /// <summary>
        /// Đơn hàng ko có chi tiết
        /// </summary>
        OrderHasnotDetail = 2231,
        /// <summary>
        /// Khối lượng đơn hàng vượt quá quy định
        /// </summary>
        InvalidWeightOrderMax = 2232,
        /// <summary>
        /// Khối lượng đơn hàng < quy định
        /// </summary>
        InvalidWeightOrderMin = 2233,
        /// <summary>
        /// Trạng thai đơn hàng không hợp lệ
        /// </summary>
        OrderStatusInvalid = 2235,
        /// <summary>
        /// Ngày thu COD ko hợp lệ
        /// </summary>
        PaymentDateNotValid = 2236,
        /// <summary>
        /// Gửi đơn lên DTGH thất bại
        /// </summary>
        SendOrderToPartnerFailse = 2237,
        /// <summary>
        /// Khách hàng yêu cầu hủy trên sàn
        /// </summary>
        CustomerRequireCancle = 2238,
        /// <summary>
        /// Đơn hàng đang được phân bổ
        /// </summary>
        OrdersWaitingAllocation = 2239,
        #endregion
        #region Dải lỗi đồng bộ hàng hóa bên Mshop về OCM
        /// <summary>
        /// Mã lỗi thêm mới hàng hóa
        /// </summary>
        Error_Insert_Product = 2500,
        /// <summary>
        /// Lỗi thêm mới thành phần combo bị lỗi
        /// </summary>
        Error_Insert_ComponentCombo = 2501,
        /// <summary>
        /// Lỗi cập nhật tồn kho
        /// </summary>

        Error_UpdateStock = 2502,
        /// <summary>
        /// Lỗi thêm mới tồn kho
        /// </summary>

        Error_InsertStock = 2503,
        /// <summary>
        /// Lỗi cập nhật tồn kho
        /// </summary>

        Error_UpdateInorder = 2504,
        /// <summary>
        /// Lỗi thêm mới tồn kho
        /// </summary>

        Error_InsertInOrder = 2505,
        /// <summary>
        /// Thông tin EcomAccount không tồn tại
        /// </summary>
        EcomAccount_NotExisted = 2506,
        /// <summary>
        /// BranchId null
        /// </summary>
        BranchIdNull = 2507,
        /// <summary>
        /// Không có danh sách mã đơn từ sàn
        /// </summary>
        NotListEcomOrder = 2508,
        /// <summary>
        /// Không tìm thấy hàng hóa trên sàn
        /// </summary>
        EcomProductNotExist = 2509,

        /// <summary>
        /// Lỗi mã ưu đãi
        /// </summary>
        CouponInvalid = 2510,

        /// <summary>
        /// Lỗi mã ưu đãi
        /// </summary>
        CouponNotExis = 2511,
        /// <summary>
        /// Trung mã ưu đãi
        /// </summary>
        CouponDuplicate = 2512,
        /// <summary>
        /// Lỗi không có seriIMEI
        /// </summary>
        SerialIMEIError = 2513,
        #endregion

        #region Dải 3000 -> : Các lỗi chung khác trên hệ thống
        /// <summary>
        /// Chưa có license OCM
        /// </summary>
        HasNotLicenseOCM = 3000,
        /// <summary>
        /// License OCM hết hạn
        /// </summary>
        LicenseOCMIsExpired = 3001,
        /// <summary>
        /// License Mshop hết hạn
        /// </summary>
        LicenseMShopIsExpired = 3002,

        /// <summary>
        /// Định dạng file không được phép upload
        /// </summary>
        NotAllowUploadExtension = 3003,
        #endregion

        #region Lazada error
        /// <summary>
        /// Khi hủy kết nối Lazada trên 1 domain lỗi domain đó đã tồn tại kết nối đến tk shopee khác vs tk đang hủy
        /// </summary>
        Lazada_Disconnect_ExistedOtherEccomAccount = 4000,
        /// <summary>
        /// Khi 1 domain tranh kết nối vs 1 tk Lazada đã kết nối vs domain này nhưng chính domain này lại đang kết nối đến tk khác
        /// </summary>
        Lazada_DomainIsConnecting_WhenConnectWithExistedShopeeAccount = 4001,
        /// <summary>
        /// Tài khoản Lazada đã được kết nối đến domain khác rồi
        /// </summary>
        LazadaAccountIsConnectedWithOtherDomain = 4002,

        /// <summary>
        /// Lỗi không lấy được thông tin trên Lazada
        /// </summary>
        Lazada_Error_GetData = 4003,
        /// <summary>
        /// Lỗi không lấy được token tren lazada
        /// </summary>
        Lazada_Error_GenerateToken = 4004,
        /// <summary>
        /// Lỗi không lấy được thông tin shop tren lazada
        /// </summary>
        Lazada_Error_Infoshop = 4005,
        /// <summary>
        /// Sắn sàng giao hàng lazada bị lỗi
        /// </summary>
        Lazada_ReadyToship_Fail = 4006,

        /// <summary>
        /// Lỗi token lazada
        /// </summary>
        Lazada_IllegalAccessToken = 4401,

        #endregion

        #region Dải 6000 -> : Lỗi Zalo
        /// <summary>
        /// Tài khoản Zalo đã được kết nối đến domain khác rồi
        /// </summary>
        ZaloAccountIsConnectedWithOtherDomain = 6000,

        /// <summary>
        /// Khi 1 domain tranh kết nối vs 1 tk Zalo shop đã kết nối vs domain này nhưng chính domain này lại đang kết nối đến tk khác
        /// </summary>
        Zalo_DomainIsConnecting_WhenConnectWithExistedZaloAccount = 6001,

        /// <summary>
        /// Khi hủy kết nối Zalo trên 1 domain lỗi domain đó đã tồn tại kết nối đến tk Zalo khác vs tk đang hủy
        /// </summary>
        Zalo_Disconnect_ExistedOtherEccomAccount = 6002,

        /// <summary>
        /// Tham số không hợp lệ
        /// </summary>
        Zalo_Invalid_Param = 6201,

        /// <summary>
        /// MAC không hợp lệ
        /// </summary>
        Zalo_Invalid_MAC = 6202,

        /// <summary>
        /// Official Account đã bị xóa
        /// </summary>
        Zalo_Deleted_Shop = 6204,

        /// <summary>
        /// Official Account không tồn tại
        /// </summary>
        Zalo_Not_Exist_Shop = 6205,

        /// <summary>
        /// Official Account chưa đăng ký làm 3rd party
        /// </summary>
        Zalo_Not_Register_3rdParty = 6207,

        /// <summary>
        /// Official Account chưa có secret key
        /// </summary>
        Zalo_Not_Have_Secret_Key = 6208,

        /// <summary>
        /// Api này không được hỗ trợ
        /// </summary>
        Zalo_Not_Support_Api = 6209,

        /// <summary>
        /// tham số vượt quá giới hạn cho phép
        /// </summary>
        Zalo_Out_Of_Params = 6210,

        /// <summary>
        /// Hết quota
        /// </summary>
        Zalo_Out_Of_Quota = 6211,

        /// <summary>
        /// Official Account chưa đăng ký api này
        /// </summary>
        Zalo_Not_Register_Api = 6212,

        /// <summary>
        /// Người dùng chưa quan tâm Official Account
        /// </summary>
        Zalo_Not_Follow_OA = 6213,

        /// <summary>
        /// Bài viết đang được xử lý
        /// </summary>
        Zalo_Processing_Post = 6214,

        /// <summary>
        /// App id không hợp lệ
        /// </summary>
        Zalo_Invalid_AppId = 6215,

        /// <summary>
        /// Access token không hợp lệ
        /// </summary>
        Zalo_Invalid_Token = 6216,

        /// <summary>
        /// Người dùng đã chặn tin nhắn mời quan tâm
        /// </summary>
        Zalo_User_Blocked_InviteMsg = 6217,

        /// <summary>
        /// Hết quota nhận
        /// </summary>
        Zalo_Out_Of_Received_Quota = 6218,

        /// <summary>
        /// Không thể gửi tin nhắn mời quan tâm đến người dùng này
        /// </summary>
        Zalo_Cannot_Send_InvitedMsg = 6219,

        /// <summary>
        /// Thành công
        /// </summary>
        Zalo_Sent_InvitedMsg_Success = 6200,

        /// <summary>
        /// Api đã được gọi thành công
        /// </summary>
        Zalo_Call_Api_Success = 6100,

        /// <summary>
        /// Gửi tin nhắn đến số điện thoại hoặc tài khoản chưa quan tâm OA
        /// </summary>
        Zalo_Phone_Or_User_Not_Follow_OA = 6220,

        /// <summary>
        /// Hình không tồn tại hoặc không hợp lệ
        /// </summary>
        Zalo_Invalid_Image = 6221,

        #endregion
        #region Dải lỗi sendo
        /// <summary>
        /// Xác nhận còn hàng sendo bị lỗi
        /// </summary>
        Sendo_Confirm_InStock_Error = 7001,

        #endregion Dải lỗi sendo
        #region Dải mã lỗi 7200->7300 thông tin tài khoản

        /// <summary>
        /// Mật khẩu không bảo mật không theo chuẩn CSA-Star : ít nhất 8 ký tự gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt
        /// </summary>
        PasswordInsecure = 7200,
        /// <summary>
        /// Mật khẩu cũ không đúng
        /// </summary>
        OldPasswordNotMatch = 7201,
        /// <summary>
        /// Tên đăng nhập không hợp lệ
        /// </summary>
        UsernameInvalid = 7202,
        /// <summary>
        /// tài khoản đang bị khóa
        /// </summary>
        AccountLocked = 7203,
        /// <summary>
        /// Xảy ra lỗi exception bên misaID
        /// </summary>
        MISAIDException = 7204,
        /// <summary>
        /// Số điện thoại hoặc email không đúng định dạng bên misaID
        /// </summary>
        InvalidEmailOrPhoneNumber = 7205,
        /// <summary>
        /// Tên domain không hợp lệ
        /// </summary>
        InvalidDomain = 7206,
        /// <summary>
        /// Không có dữ liệu token
        /// </summary>
        TokenEmpty = 7207,
        /// <summary>
        /// Đăng nhâp thất bại
        /// </summary>
        LoginFail = 7208,
        /// <summary>
        /// Username hoặc PassWord không chính xác
        /// </summary>
        UserOrPassIncorrect = 7209,
        /// <summary>
        /// bạn không có quyền truy cập
        /// </summary>
        NotPermission = 7210,
        /// <summary>
        /// tài khoản này không tông tại trong hẹ thông
        /// </summary>
        NotExistAccount = 7211

        #endregion
    }
}