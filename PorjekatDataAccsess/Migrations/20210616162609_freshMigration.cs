using Microsoft.EntityFrameworkCore.Migrations;

namespace PorjekatDataAccsess.Migrations
{
    public partial class freshMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "markaKola",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markaKola", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tip_auto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sedista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tip_auto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vozac",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    years = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vozac", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voznja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    vozacid = table.Column<int>(type: "int", nullable: true),
                    markaKolaid = table.Column<int>(type: "int", nullable: true),
                    Tip_Autaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voznja", x => x.id);
                    table.ForeignKey(
                        name: "FK_voznja_markaKola_markaKolaid",
                        column: x => x.markaKolaid,
                        principalTable: "markaKola",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_voznja_tip_auto_Tip_Autaid",
                        column: x => x.Tip_Autaid,
                        principalTable: "tip_auto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_voznja_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_voznja_vozac_vozacid",
                        column: x => x.vozacid,
                        principalTable: "vozac",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_voznja_markaKolaid",
                table: "voznja",
                column: "markaKolaid");

            migrationBuilder.CreateIndex(
                name: "IX_voznja_Tip_Autaid",
                table: "voznja",
                column: "Tip_Autaid");

            migrationBuilder.CreateIndex(
                name: "IX_voznja_userid",
                table: "voznja",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_voznja_vozacid",
                table: "voznja",
                column: "vozacid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voznja");

            migrationBuilder.DropTable(
                name: "markaKola");

            migrationBuilder.DropTable(
                name: "tip_auto");

            migrationBuilder.DropTable(
                name: "vozac");
        }
    }
}
