using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHTKCreateOrderBody
    {
        [JsonProperty("products")]
        public List<GHTKProduct> Products { get; set; }

        [JsonProperty("order")]
        public GHTKOrder Order { get; set; }
    }
    /// <summary>
    /// Thông tin sản phẩm trong đơn giao vận
    /// </summary>
    public class GHTKProduct
    {
        /// <summary>
        /// Tên sản phẩm.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Giá sản phẩm.
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        /// Trọng lượng sản phẩm (đơn vị: kg).
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Số lượng sản phẩm.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Mã sản phẩm.
        /// </summary>
        [JsonProperty("product_code")]
        public long ProductCode { get; set; }
    }

    /// <summary>
    /// Định nghĩa thông tin đơn hàng cho GHTK.
    /// </summary>
    public class GHTKOrder
    {
        /// <summary>
        /// Mã đơn hàng.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        #region Thông tin điểm lấy hàng

        /// <summary>
        /// Tên người liên hệ tại điểm lấy hàng.
        /// </summary>
        [JsonProperty("pick_name")]
        public string PickName { get; set; }

        /// <summary>
        /// Số tiền thu hộ tại điểm lấy hàng.
        /// </summary>
        [JsonProperty("pick_money")]
        public long PickMoney { get; set; }

        /// <summary>
        /// Mã địa chỉ lấy hàng.
        /// </summary>
        [JsonProperty("pick_address_id")]
        public string PickAddressId { get; set; }

        /// <summary>
        /// Địa chỉ lấy hàng.
        /// </summary>
        [JsonProperty("pick_address")]
        public string PickAddress { get; set; }

        /// <summary>
        /// Tỉnh/Thành phố nơi lấy hàng.
        /// </summary>
        [JsonProperty("pick_province")]
        public string PickProvince { get; set; }

        /// <summary>
        /// Quận/Huyện nơi lấy hàng.
        /// </summary>
        [JsonProperty("pick_district")]
        public string PickDistrict { get; set; }

        /// <summary>
        /// Phường/Xã nơi lấy hàng.
        /// </summary>
        [JsonProperty("pick_ward")]
        public string PickWard { get; set; }

        /// <summary>
        /// Đường/Phố nơi lấy hàng.
        /// </summary>
        [JsonProperty("pick_street")]
        public string PickStreet { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ tại điểm lấy hàng.
        /// </summary>
        [JsonProperty("pick_tel")]
        public string PickTel { get; set; }

        /// <summary>
        /// Email liên hệ tại điểm lấy hàng.
        /// </summary>
        [JsonProperty("pick_email")]
        public string PickEmail { get; set; }

        #endregion

        #region Thông tin điểm giao hàng

        /// <summary>
        /// Tên người nhận hàng.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Địa chỉ người nhận hàng.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Tỉnh/Thành phố người nhận hàng.
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// Quận/Huyện người nhận hàng.
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// Phường/Xã người nhận hàng.
        /// </summary>
        [JsonProperty("ward")]
        public string Ward { get; set; }

        /// <summary>
        /// Đường/Phố người nhận hàng.
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Số điện thoại người nhận hàng.
        /// </summary>
        [JsonProperty("tel")]
        public string Tel { get; set; }

        /// <summary>
        /// Ghi chú cho đơn hàng.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// Email người nhận hàng.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        #endregion

        #region Thông tin điểm trả hàng

        /// <summary>
        /// Sử dụng địa chỉ trả hàng khác.
        /// </summary>
        [JsonProperty("use_return_address")]
        public int UseReturnAddress { get; set; }

        /// <summary>
        /// Tên người liên hệ tại điểm trả hàng.
        /// </summary>
        [JsonProperty("return_name")]
        public string ReturnName { get; set; }

        /// <summary>
        /// Địa chỉ trả hàng.
        /// </summary>
        [JsonProperty("return_address")]
        public string ReturnAddress { get; set; }

        /// <summary>
        /// Tỉnh/Thành phố trả hàng.
        /// </summary>
        [JsonProperty("return_province")]
        public string ReturnProvince { get; set; }

        /// <summary>
        /// Quận/Huyện trả hàng.
        /// </summary>
        [JsonProperty("return_district")]
        public string ReturnDistrict { get; set; }

        /// <summary>
        /// Phường/Xã trả hàng.
        /// </summary>
        [JsonProperty("return_ward")]
        public string ReturnWard { get; set; }

        /// <summary>
        /// Đường/Phố trả hàng.
        /// </summary>
        [JsonProperty("return_street")]
        public string ReturnStreet { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ tại điểm trả hàng.
        /// </summary>
        [JsonProperty("return_tel")]
        public string ReturnTel { get; set; }

        /// <summary>
        /// Email liên hệ tại điểm trả hàng.
        /// </summary>
        [JsonProperty("return_email")]
        public string ReturnEmail { get; set; }

        #endregion

        #region Các thông tin thêm

        /// <summary>
        /// Đơn hàng miễn phí vận chuyển.
        /// </summary>
        [JsonProperty("is_freeship")]
        public int IsFreeship { get; set; }

        /// <summary>
        /// Tùy chọn cân nặng.
        /// </summary>
        [JsonProperty("weight_option")]
        public string WeightOption { get; set; }

        /// <summary>
        /// Tổng trọng lượng của đơn hàng.
        /// </summary>
        [JsonProperty("total_weight")]
        public long TotalWeight { get; set; }

        [JsonProperty("deliver_option")]
        public string DeliverOption { get; set; }

        [JsonProperty("pick_session")]
        public int PickSession { get; set; }

        /// <summary>
        /// Ca làm việc giao hàng.
        /// </summary>
        [JsonProperty("deliver_work_shift")]
        public int DeliverWorkShift { get; set; }

        /// <summary>
        /// Ca làm việc lấy hàng.
        /// </summary>
        [JsonProperty("pick_work_shift")]
        public int PickrWorkShift { get; set; }

        /// <summary>
        /// Mã nhãn dán.
        /// </summary>
        [JsonProperty("label_id")]
        public string LabelId { get; set; }

        /// <summary>
        /// Ngày lấy hàng.
        /// </summary>
        [JsonProperty("pick_date")]
        public string PickDate { get; set; }

        /// <summary>
        /// Tùy chọn lấy hàng.
        /// </summary>
        [JsonProperty("pick_option")]
        public string PickOption { get; set; }

        /// <summary>
        /// Ngày giao hàng.
        /// </summary>
        [JsonProperty("deliver_date")]
        public string DeliverDate { get; set; }

        /// <summary>
        /// Thời gian hết hạn của đơn hàng.
        /// </summary>
        [JsonProperty("expired")]
        public string Expired { get; set; }

        /// <summary>
        /// Giá trị đơn hàng.
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// Mã dịch vụ vận chuyển.
        /// </summary>
        [JsonProperty("opm")]
        public int Opm { get; set; }

        /// <summary>
        /// Phương thức vận chuyển.
        /// </summary>
        [JsonProperty("transport")]
        public string Transport { get; set; }

        /// <summary>
        /// Tên thôn/ấp/xóm/tổ,... mặc định là "Khác".
        /// </summary>
        [JsonProperty("hamlet")]
        public string Hamlet { get; set; } = "Khác";

        /// <summary>
        /// Danh sách các tag cho hàng hóa, ví dụ: hàng dễ vỡ.
        /// </summary>
        [JsonProperty("tags")]
        public List<GHTKTag> Tags { get; set; }

        #endregion
    }

    public enum GHTKTag
    {
        DeVo = 1, // Dễ vỡ
        GiaTriCaoDacBiet = 2, // Giá trị cao/Đặc biệt
        NongSanThucPhamKho = 7, // Nông sản/thực phẩm khô
        ChoXemHang = 10, // Cho xem hàng
        ChoThuHangDongKiem = 11, // Cho thử hàng/ đồng kiểm
        GoiShopKhiKhachKhongNhanHang = 13, // Gọi shop khi khách không nhận hàng, không liên lạc được, sai thông tin
        GiaoHang1PhanChonSanPham = 17, // Giao hàng 1 phần chọn sản phẩm
        GiaoHang1PhanDoiTraHang = 18, // Giao hàng 1 phần đổi trả hàng
        KhongGiaoDuocThu = 19, // Không giao được thu
        HangNguyenHop = 20, // Hàng nguyên hộp
        ThuTinTaiLieu = 22, // Thư tín, tài liệu
        ThucPhamTuoi = 39, // Thực phẩm tươi
        HangNho = 40, // Hàng nhỏ
        HangKhongXepChong = 41, // Hàng không xếp chồng
        HangYeuCauXepDungChieu = 42, // Hàng yêu cầu xếp đúng chiều
        HangCayCoi = 75 // Hàng cây cối
    }
}