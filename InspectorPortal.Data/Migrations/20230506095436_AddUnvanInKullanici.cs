using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUnvanInKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unvan",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unvan",
                table: "Kullanicilar");
        }
    }
}
