using Microsoft.EntityFrameworkCore.Migrations;

namespace PorjekatDataAccsess.Migrations
{
    public partial class messageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "MessageForAdmin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageForAdmin", x => x.id);
                    table.ForeignKey(
                        name: "FK_MessageForAdmin_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageForAdmin_userid",
                table: "MessageForAdmin",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageForAdmin");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "UserName");
        }
    }
}
