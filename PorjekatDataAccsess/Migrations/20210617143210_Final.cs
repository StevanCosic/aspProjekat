using Microsoft.EntityFrameworkCore.Migrations;

namespace PorjekatDataAccsess.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "adresa",
                table: "voznja",
                type: "nvarchar(max)",
                nullable: true);

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageForAdmin_user_userid",
                table: "MessageForAdmin");

            migrationBuilder.DropColumn(
                name: "adresa",
                table: "voznja");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "MessageForAdmin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageForAdmin_user_userid",
                table: "MessageForAdmin",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
