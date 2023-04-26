using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mufettisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DogumYeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BabaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedeniHal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MezunOkul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IseBaslama = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KurumSicilNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MufettisNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CalismaDurumu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mufettisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İsim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SicilNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniteBirimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirimSorumlusu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirimID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteBirimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniteBirimler_UniteBirimler_BirimID",
                        column: x => x.BirimID,
                        principalTable: "UniteBirimler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevTipi = table.Column<int>(type: "int", nullable: false),
                    Konusu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    VerilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KamuZarari = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorevler_UniteBirimler_UnitID",
                        column: x => x.UnitID,
                        principalTable: "UniteBirimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisiplinCezalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisiplinKuruluOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onaylanan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisiplinCezalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisiplinCezalari_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HukukiIslemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onaylanan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HukukiIslemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HukukiIslemler_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdariTedbirler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onaylanan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdariTedbirler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdariTedbirler_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "MufettisGorevleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MufettisID = table.Column<int>(type: "int", nullable: false),
                    GorevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MufettisGorevleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MufettisGorevleri_Gorevler_GorevID",
                        column: x => x.GorevID,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MufettisGorevleri_Mufettisler_MufettisID",
                        column: x => x.MufettisID,
                        principalTable: "Mufettisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriyodikTeftisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeftisDonemi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GorevID = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_DisiplinCezalari_GorevID",
                table: "DisiplinCezalari",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_UnitID",
                table: "Gorevler",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_HukukiIslemler_GorevID",
                table: "HukukiIslemler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_IdariTedbirler_GorevID",
                table: "IdariTedbirler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_Incelemeler_GorevID",
                table: "Incelemeler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_MufettisGorevleri_GorevID",
                table: "MufettisGorevleri",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_MufettisGorevleri_MufettisID",
                table: "MufettisGorevleri",
                column: "MufettisID");

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

            migrationBuilder.CreateIndex(
                name: "IX_UniteBirimler_BirimID",
                table: "UniteBirimler",
                column: "BirimID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisiplinCezalari");

            migrationBuilder.DropTable(
                name: "HukukiIslemler");

            migrationBuilder.DropTable(
                name: "IdariTedbirler");

            migrationBuilder.DropTable(
                name: "Incelemeler");

            migrationBuilder.DropTable(
                name: "MufettisGorevleri");

            migrationBuilder.DropTable(
                name: "PeriyodikTeftisler");

            migrationBuilder.DropTable(
                name: "Sorusturmalar");

            migrationBuilder.DropTable(
                name: "Mufettisler");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "UniteBirimler");
        }
    }
}
