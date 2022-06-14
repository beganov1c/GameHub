using Microsoft.EntityFrameworkCore.Migrations;

namespace GameHub.Data.Migrations
{
    public partial class Migracija5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnikId",
                table: "KomentarIgrica",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "KomentarIgrica");
        }
    }
}
