using Microsoft.EntityFrameworkCore.Migrations;

namespace GameHub.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igrica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrednjaOcjena = table.Column<double>(type: "float", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zanr = table.Column<int>(type: "int", nullable: false),
                    RRated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KomentarIgrica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    IgricaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentarIgrica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KomentarObjava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lajkovi = table.Column<int>(type: "int", nullable: false),
                    ObjavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentarObjava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lajkovi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objava", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igrica");

            migrationBuilder.DropTable(
                name: "KomentarIgrica");

            migrationBuilder.DropTable(
                name: "KomentarObjava");

            migrationBuilder.DropTable(
                name: "Objava");
        }
    }
}
