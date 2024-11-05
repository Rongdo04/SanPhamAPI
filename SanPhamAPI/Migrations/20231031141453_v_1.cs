using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SanPhamAPI.Migrations
{
    /// <inheritdoc />
    public partial class v_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaGiaoDich",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaGiaoDich",
                table: "HoaDon",
                column: "MaGiaoDich",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HoaDon_MaGiaoDich",
                table: "HoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiaoDich",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
