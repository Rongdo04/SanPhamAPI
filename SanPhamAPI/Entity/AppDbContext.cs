using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SanPhamAPI.Entity {
    public class AppDbContext : DbContext {
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Cấu hình kết nối đến cơ sở dữ liệu, ví dụ: SQL Server
            optionsBuilder.UseSqlServer("Server=DESKTOP-KBA58DG\\SQLEXPRESS;Database=SanPhamAPI;Trusted_Connection = true;TrustServerCertificate = true");

        }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<HoaDon>()
                .HasIndex(u => u.MaGiaoDich)
                .IsUnique();
        }
    }

}
