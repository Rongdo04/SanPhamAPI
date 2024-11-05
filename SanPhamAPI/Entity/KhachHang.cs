namespace SanPhamAPI.Entity {
    public class KhachHang {
        public int KhachHangID { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh  { get; set; }
        public string SDT { get; set; }
        public IEnumerable<HoaDon>? HoaDons { get; set; }
    }
}
