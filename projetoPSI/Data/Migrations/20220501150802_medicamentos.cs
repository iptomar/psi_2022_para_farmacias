using Microsoft.EntityFrameworkCore.Migrations;

namespace projetoPSI.Data.Migrations
{
    public partial class medicamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    MedicId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.MedicId);
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "MedicId", "Nome", "Preco" },
                values: new object[] { 1, "Benuron", 5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicamento");
        }
    }
}
