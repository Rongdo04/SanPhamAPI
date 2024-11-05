using SanPhamAPI.Constant;
using SanPhamAPI.Controllers;
using SanPhamAPI.Entity;
using SanPhamAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace SanPhamAPI.Services {
    public class SanPhamServices : ISanPhamServices {
        public readonly AppDbContext dbContext;
        public SanPhamServices() {
            dbContext = new AppDbContext();
        }

        public PageResult<HoaDon> ShowSP(int pageNumber = 1, int pageSize = 20) {
            var query = dbContext.HoaDon.AsQueryable();
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int totalItems = query.Count();
            var pageResult = new PageResult<HoaDon>(query.ToList(), totalItems, pageNumber, pageSize);
            return pageResult;

        }

       
        ErrorMessage ISanPhamServices.SuaHoaDon(HoaDon hd) {
            var HoaDonTonTai = dbContext.HoaDon.FirstOrDefault(x => x.HoaDonID == hd.HoaDonID);
            if (HoaDonTonTai != null) {
                HoaDonTonTai.TenHoaDon = hd.TenHoaDon;
                HoaDonTonTai.ChiTietHoaDon = hd.ChiTietHoaDon;
                HoaDonTonTai.KhachHangID = hd.KhachHangID;
                HoaDonTonTai.ThoiGianCapNhap = DateTime.Now;
                HoaDonTonTai.GhiChu = hd.GhiChu;
                HoaDonTonTai.TongTien = hd.TongTien;
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;

            }
            else {
                return ErrorMessage.HoaDonChuaTonTai;
            }
        }
        ErrorMessage ISanPhamServices.XoaHoaDon(int hdid) {
            var hoaDonTonTai = dbContext.HoaDon.FirstOrDefault(x => x.HoaDonID == hdid);
            var cts = dbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hdid).ToList();

            if (hoaDonTonTai != null) {
                dbContext.HoaDon.Remove(hoaDonTonTai);
                dbContext.SaveChanges();
                foreach(var ct in cts) {
                    dbContext.ChiTietHoaDon.Remove(ct);
                }
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else {
                return ErrorMessage.HoaDonChuaTonTai;
            }
        }

        ErrorMessage ISanPhamServices.ThemHoaDonChoSanPham(HoaDon hd, int SanPhamID) {
            var hoaDonTonTai = dbContext.HoaDon.FirstOrDefault(x => x.HoaDonID == hd.HoaDonID);
            var spTonTai = dbContext.SanPham.FirstOrDefault(x => x.SanPhamID == SanPhamID);
            var chitiet = dbContext.ChiTietHoaDon.FirstOrDefault(x => x.SanPhamID == SanPhamID && x.HoaDonID == hd.HoaDonID);
            if (hoaDonTonTai == null) {
                if (spTonTai == null) {
                    // Sản phẩm chưa tồn tại trong hóa đơn, thực hiện các hành động tương ứng
                    // Xóa hóa đơn vừa tạo
                    return ErrorMessage.SanPhamKhongTonTai;
                } else {
                    hd.ThoiGianTao = DateTime.Now;
                    hd.TongTien = 0;
                    string formattedDate = DateTime.Now.ToString("yyyyMMdd");
                    int currentInvoiceIndex = GetInvoiceIndex(formattedDate);
                    string maGiaoDich = $"{formattedDate}_{currentInvoiceIndex:D3}";
                    hd.MaGiaoDich = maGiaoDich;
                    currentInvoiceIndex++;
                    SaveInvoiceIndex(formattedDate, currentInvoiceIndex);
                    int GetInvoiceIndex(string date) {
                        return 1;
                    }
                    void SaveInvoiceIndex(string date, int index) {
                        // Lưu chỉ số vào cơ sở dữ liệu hoặc nơi lưu trữ khác
                    }
                    dbContext.HoaDon.Add(hd);
                    dbContext.SaveChanges();
                    ChiTietHoaDon ct = new ChiTietHoaDon() {
                        HoaDonID = hd.HoaDonID,
                        SanPhamID = SanPhamID,
                        SoLuong = 6,
                        DVT = "Cái",
                    };
                    dbContext.ChiTietHoaDon.Add(ct);
                    ct.ThanhTien = ct.SoLuong * spTonTai.GiaThanh;
                    dbContext.SaveChanges();
                    return ErrorMessage.ThanhCong;
                }


            } else {
                return ErrorMessage.HoaDonDaTonTai;
            }
        }

        public IEnumerable<HoaDon> HoaDonSapXepTheoTGTao() {
            var ListHoaDon = dbContext.HoaDon.ToList().OrderByDescending(x => x.ThoiGianTao);
            return ListHoaDon.AsQueryable();
        }

        public IEnumerable<HoaDon> HoaDonTheoNamTHang(int year, int month) {
            
            var hoaDons = dbContext.HoaDon.Where(x => x.ThoiGianTao.Value.Year == year && x.ThoiGianTao.Value.Month == month).ToList();
            return hoaDons.AsQueryable();
           
        }

        public IEnumerable<HoaDon> HoaDonTaoTheoNgay(DateTime fromDate, DateTime toDate) {
            var hoaDons = dbContext.HoaDon.Where(x => x.ThoiGianTao >= fromDate && x.ThoiGianTao <= toDate).ToList();
            return hoaDons.AsQueryable();
        }

        public IEnumerable<HoaDon> HoaDonTheoTongTien(float minAmount, float maxAmount) {
            var hoaDons = dbContext.HoaDon
               .Where(x => x.TongTien >= minAmount && x.TongTien <= maxAmount)
               .ToList();
            return hoaDons.AsQueryable();
        }

        public IEnumerable<HoaDon> HoaDonTheoMaGGorTenHoaDon(string searchKeyword) {
            var hoaDons = dbContext.HoaDon
                    .Where(x => x.MaGiaoDich.Contains(searchKeyword) || x.TenHoaDon.Contains(searchKeyword))
                    .ToList();
            return hoaDons.AsQueryable();

        }

        
    }
}
