using Microsoft.EntityFrameworkCore.Migrations;

namespace projetoPSI.Data.Migrations
{
    public partial class medicamentos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Medicamento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Medicamento");
        }
    }
}
