using Microsoft.EntityFrameworkCore;

namespace SanPhamAPI.Entity {
    public class HoaDon {
        public int HoaDonID { get; set; }
        public int KhachHangID { get; set; }
        public KhachHang? KhachHang { get; set; }
        public string TenHoaDon { get; set; }
        public string? MaGiaoDich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhap { get; set; }
        public string GhiChu { get; set; }
        public double? TongTien { get; set; }
        public IEnumerable<ChiTietHoaDon>? ChiTietHoaDon { get; set; }



    }
}
