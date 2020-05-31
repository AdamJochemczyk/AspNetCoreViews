using Microsoft.EntityFrameworkCore.Migrations;

namespace zaj9.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_LAB",
                table: "Probki",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Kosztbadania",
                table: "Probki",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAZWALAB = table.Column<string>(maxLength: 20, nullable: false),
                    iloscPracownikow = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "ID", "NAZWALAB", "iloscPracownikow" },
                values: new object[] { 1, "ZTM", 6 });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "ID", "NAZWALAB", "iloscPracownikow" },
                values: new object[] { 2, "GRC", 15 });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "ID", "NAZWALAB", "iloscPracownikow" },
                values: new object[] { 3, "MTU", 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Probki_FK_LAB",
                table: "Probki",
                column: "FK_LAB");

            migrationBuilder.AddForeignKey(
                name: "FK_Probki_Lab_FK_LAB",
                table: "Probki",
                column: "FK_LAB",
                principalTable: "Lab",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Probki_Lab_FK_LAB",
                table: "Probki");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropIndex(
                name: "IX_Probki_FK_LAB",
                table: "Probki");

            migrationBuilder.DropColumn(
                name: "FK_LAB",
                table: "Probki");

            migrationBuilder.DropColumn(
                name: "Kosztbadania",
                table: "Probki");
        }
    }
}
