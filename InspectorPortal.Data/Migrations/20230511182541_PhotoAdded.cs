using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class PhotoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniteBirimler_UniteBirimler_BirimID",
                table: "UniteBirimler");

            migrationBuilder.AlterColumn<int>(
                name: "BirimID",
                table: "UniteBirimler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Mufettisler",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UniteBirimler_UniteBirimler_BirimID",
                table: "UniteBirimler",
                column: "BirimID",
                principalTable: "UniteBirimler",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniteBirimler_UniteBirimler_BirimID",
                table: "UniteBirimler");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Mufettisler");

            migrationBuilder.AlterColumn<int>(
                name: "BirimID",
                table: "UniteBirimler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UniteBirimler_UniteBirimler_BirimID",
                table: "UniteBirimler",
                column: "BirimID",
                principalTable: "UniteBirimler",
                principalColumn: "Id");
        }
    }
}
