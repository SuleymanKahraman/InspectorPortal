using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class addMufettisIDToKullanicilar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MufettisId",
                table: "Kullanicilar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_MufettisId",
                table: "Kullanicilar",
                column: "MufettisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Mufettisler_MufettisId",
                table: "Kullanicilar",
                column: "MufettisId",
                principalTable: "Mufettisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Mufettisler_MufettisId",
                table: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_MufettisId",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "MufettisId",
                table: "Kullanicilar");
        }
    }
}
