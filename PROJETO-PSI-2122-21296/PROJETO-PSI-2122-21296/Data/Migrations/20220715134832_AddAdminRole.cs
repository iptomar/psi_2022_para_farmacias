using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJETO_PSI_2122_21296.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a", "13047109-d8f4-45e6-a30f-2740764a49d3", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a");
        }
    }
}
