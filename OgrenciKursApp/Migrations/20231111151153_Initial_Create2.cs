using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciKursApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OgnreciSoyad",
                table: "Ogrenciler",
                newName: "OgrenciSoyad");

            migrationBuilder.RenameColumn(
                name: "OgnreciAd",
                table: "Ogrenciler",
                newName: "OgrenciAd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OgrenciSoyad",
                table: "Ogrenciler",
                newName: "OgnreciSoyad");

            migrationBuilder.RenameColumn(
                name: "OgrenciAd",
                table: "Ogrenciler",
                newName: "OgnreciAd");
        }
    }
}
