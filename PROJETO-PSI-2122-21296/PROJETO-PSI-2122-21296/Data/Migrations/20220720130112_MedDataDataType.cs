using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJETO_PSI_2122_21296.Data.Migrations
{
    public partial class MedDataDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "1b1147ed-e0b1-40cf-a56e-00ca9ef8fea1");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "adminuser0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e9bd811-c874-49fd-ad7d-f299d14cef29", "AQAAAAEAACcQAAAAEKzNOCJEOBW77CuCjQtyqAkggCJpI49mRzd/JA2CbveHa6gQYwm5pLc0gvBUB6AazA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "0d8af847-66eb-4fd3-a5ea-ad9c8ffba5b8");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "adminuser0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93bf0b19-677d-40cb-b70d-70b6d68f0a27", "AQAAAAEAACcQAAAAEC3PLSJmaR6VY9/DcU3WHCt6h1YP0W+ZI6GQidErDL4UiwwZ14ZWq7Mc62t269CLRg==" });
        }
    }
}
