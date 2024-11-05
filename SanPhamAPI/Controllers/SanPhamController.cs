using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SanPhamAPI.IServices;
using SanPhamAPI.Services;
using SanPhamAPI.Entity;
using SanPhamAPI.Constant;


namespace SanPhamAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase {
        private readonly ISanPhamServices sanPhamServices;

        public SanPhamController() {
            sanPhamServices = new SanPhamServices();
        }
        [HttpPost("ThemHoaDon")]
        public IActionResult ThemHoaDon([FromBody] HoaDon hoaDon) {
            var res = sanPhamServices.ThemHoaDonChoSanPham(hoaDon, 6);
            if (res == ErrorMessage.ThanhCong) {
                return Ok("Thao tac thanh cong");
            }
            else {
                return BadRequest("Thao tac that bai");
            }
        }
        
        [HttpGet("DSsanpham")]
        public IActionResult Show([FromQuery]int pageNumber, [FromQuery] int pageSize) {
            
            var res = sanPhamServices.ShowSP(pageNumber, pageSize);
                return Ok(res);
           
        }
        [HttpDelete("XoaHD")]
        public IActionResult Xoa([FromQuery] int id) {
            var res = sanPhamServices.XoaHoaDon(id);
            return Accepted(res);
        }
        [HttpPut("SuaHD")]
        public IActionResult Sua([FromBody] HoaDon hd) {
            var res = sanPhamServices.SuaHoaDon(hd);
            if(res == ErrorMessage.ThanhCong) {
                return Ok(res);
            }
            else {
                return BadRequest(res);
            }
        }
        [HttpGet("ShowHDTheoNamThang")] 
        public IActionResult ShowHD() {
            var res = sanPhamServices.HoaDonTheoNamTHang(2023,10);
            return Ok(res);
        }
        [HttpGet("HoaDonTaoTheoNgay")]
        public IActionResult ShowHDTheoNgay() {
            var res = sanPhamServices.HoaDonTaoTheoNgay(new DateTime(2023,10,1),new DateTime(2023,11,1));
            return Ok(res);
        }
        [HttpGet("HoaDonTheoTongTien")]
        public IActionResult ShowHDTheoTongTien() {
            var res = sanPhamServices.HoaDonTheoTongTien(0, 500);
            return Ok(res);
        }
        [HttpGet("HoaDonTheoMaGGorTenHoaDon")]
        public IActionResult ShowHDMGGvaTenHoaDon() {
            var res = sanPhamServices.HoaDonTheoMaGGorTenHoaDon("2023");
            return Ok(res);
        }
        [HttpGet("HoaDonSapXepTheoTGTao")]
        public IActionResult ShowHDTGTao() {
            var res = sanPhamServices.HoaDonSapXepTheoTGTao();
            return Ok(res);
        }
    }
}
