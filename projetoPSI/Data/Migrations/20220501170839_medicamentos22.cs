using Microsoft.EntityFrameworkCore.Migrations;

namespace projetoPSI.Data.Migrations
{
    public partial class medicamentos22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicamento",
                keyColumn: "MedicId",
                keyValue: 1,
                column: "Descricao",
                value: "Olá eu sou o Ramos e sou um atrasado mental");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicamento",
                keyColumn: "MedicId",
                keyValue: 1,
                column: "Descricao",
                value: null);
        }
    }
}
