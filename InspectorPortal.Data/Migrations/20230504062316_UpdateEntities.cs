using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incelemeler");

            migrationBuilder.DropTable(
                name: "PeriyodikTeftisler");

            migrationBuilder.DropTable(
                name: "Sorusturmalar");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropColumn(
                name: "BabaAdi",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "DogumYeri",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "IseBaslama",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "MedeniHal",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "MezunOkul",
                table: "Mufettisler");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Mufettisler");

            migrationBuilder.AlterColumn<string>(
                name: "Unvan",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MufettisNo",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KurumSicilNo",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CalismaDurumu",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Mufettisler",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unvan",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MufettisNo",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "KurumSicilNo",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CalismaDurumu",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Mufettisler",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "BabaAdi",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "Mufettisler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DogumYeri",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IseBaslama",
                table: "Mufettisler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MedeniHal",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MezunOkul",
                table: "Mufettisler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Mufettisler",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Incelemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incelemeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incelemeler_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriyodikTeftisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    TeftisDonemi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniteBirimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriyodikTeftisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriyodikTeftisler_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriyodikTeftisler_UniteBirimler_UniteBirimId",
                        column: x => x.UniteBirimId,
                        principalTable: "UniteBirimler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SicilNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    İsim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorusturmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorusturmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sorusturmalar_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sorusturmalar_Personeller_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incelemeler_GorevID",
                table: "Incelemeler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_PeriyodikTeftisler_GorevID",
                table: "PeriyodikTeftisler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_PeriyodikTeftisler_UniteBirimId",
                table: "PeriyodikTeftisler",
                column: "UniteBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Sorusturmalar_GorevID",
                table: "Sorusturmalar",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_Sorusturmalar_PersonelID",
                table: "Sorusturmalar",
                column: "PersonelID");
        }
    }
}
