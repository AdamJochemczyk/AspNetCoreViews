using Microsoft.EntityFrameworkCore.Migrations;

namespace zaj9.Migrations
{
    public partial class pierwsza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Probki",
                columns: table => new
                {
                    IdBadania = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_Probki = table.Column<string>(maxLength: 20, nullable: false),
                    Ilosc_Pojemnikow = table.Column<int>(maxLength: 3, nullable: false),
                    Waga_Probek = table.Column<double>(maxLength: 3, nullable: false),
                    zbadane = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probki", x => x.IdBadania);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Probki");
        }
    }
}
