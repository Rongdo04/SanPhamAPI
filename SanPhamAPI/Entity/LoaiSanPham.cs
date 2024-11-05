namespace SanPhamAPI.Entity {
    public class LoaiSanPham {
        public int LoaiSanPhamID { get; set; }
        public string TenLoaiSanPham { get; set; }
        public IEnumerable<SanPham>? SanPhamList { get; set;}
    }
}
