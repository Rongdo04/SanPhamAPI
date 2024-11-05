using SanPhamAPI.Entity;
using SanPhamAPI.Constant;


namespace SanPhamAPI.IServices {
    interface ISanPhamServices {
        public ErrorMessage ThemHoaDonChoSanPham(HoaDon hd, int SanPhamID);
        public ErrorMessage SuaHoaDon(HoaDon hd);
        public ErrorMessage XoaHoaDon(int HoaDonID);

        public PageResult<HoaDon> ShowSP(int pageNumber = 1, int pageSize = 10);
        public IEnumerable<HoaDon> HoaDonSapXepTheoTGTao();
        public IEnumerable<HoaDon> HoaDonTheoNamTHang(int year, int month);
        public IEnumerable<HoaDon> HoaDonTaoTheoNgay(DateTime fromDate, DateTime toDate);
        public IEnumerable<HoaDon> HoaDonTheoTongTien(float minAmount, float maxAmount);
        public IEnumerable<HoaDon> HoaDonTheoMaGGorTenHoaDon(string searchKeyword);


    }
}
