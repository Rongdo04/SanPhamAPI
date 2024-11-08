﻿namespace SanPhamAPI.Entity {
    public class SanPham {
        public int SanPhamID { get; set; }
        public int LoaiSanPhamID { get; set; }
        public LoaiSanPham? loaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double GiaThanh { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string KyHieuSanPham { get; set; }
        public IEnumerable<ChiTietHoaDon>? ChiTietHoaDon { get; set; }


    }
}
