using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectorPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteOfThreeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisiplinCezalari");

            migrationBuilder.DropTable(
                name: "HukukiIslemler");

            migrationBuilder.DropTable(
                name: "IdariTedbirler");

            migrationBuilder.DropColumn(
                name: "GorevTipi",
                table: "Gorevler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GorevTipi",
                table: "Gorevler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DisiplinCezalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisiplinKuruluOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    BaskanlikOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MufettisOneri = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_DisiplinCezalari_GorevID",
                table: "DisiplinCezalari",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_HukukiIslemler_GorevID",
                table: "HukukiIslemler",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_IdariTedbirler_GorevID",
                table: "IdariTedbirler",
                column: "GorevID");
        }
    }
}
