﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SanPhamAPI.Entity;

#nullable disable

namespace SanPhamAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241022145519_v_3")]
    partial class v_3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SanPhamAPI.Entity.ChiTietHoaDon", b =>
                {
                    b.Property<int>("ChiTietHoaDonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietHoaDonID"));

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoaDonID")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("ChiTietHoaDonID");

                    b.HasIndex("HoaDonID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.HoaDon", b =>
                {
                    b.Property<int>("HoaDonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonID"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangID")
                        .HasColumnType("int");

                    b.Property<string>("MaGiaoDich")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThoiGianCapNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("HoaDonID");

                    b.HasIndex("KhachHangID");

                    b.HasIndex("MaGiaoDich")
                        .IsUnique()
                        .HasFilter("[MaGiaoDich] IS NOT NULL");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.KhachHang", b =>
                {
                    b.Property<int>("KhachHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhachHangID"));

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhachHangID");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.LoaiSanPham", b =>
                {
                    b.Property<int>("LoaiSanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiSanPhamID"));

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiSanPhamID");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.SanPham", b =>
                {
                    b.Property<int>("SanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamID"));

                    b.Property<double>("GiaThanh")
                        .HasColumnType("float");

                    b.Property<string>("KyHieuSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiSanPhamID")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanPhamID");

                    b.HasIndex("LoaiSanPhamID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.ChiTietHoaDon", b =>
                {
                    b.HasOne("SanPhamAPI.Entity.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("HoaDonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SanPhamAPI.Entity.SanPham", "SanPham")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.HoaDon", b =>
                {
                    b.HasOne("SanPhamAPI.Entity.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("KhachHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.SanPham", b =>
                {
                    b.HasOne("SanPhamAPI.Entity.LoaiSanPham", "loaiSanPham")
                        .WithMany("SanPhamList")
                        .HasForeignKey("LoaiSanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiSanPham");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDon");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhamList");
                });

            modelBuilder.Entity("SanPhamAPI.Entity.SanPham", b =>
                {
                    b.Navigation("ChiTietHoaDon");
                });
#pragma warning restore 612, 618
        }
    }
}