using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parafarmacia.Data.Migrations
{
    public partial class cartOrderRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cart",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6fcb301b-e2b1-46f9-8474-dddf1ac4daf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "20a6211a-0bf4-47f2-a575-51622e862801");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Timestamp" },
                values: new object[] { "2c2f98df-0915-40dc-be62-68521eb64d0e", "AQAAAAEAACcQAAAAEJgzXOcaIhTbNGlDe7WgZuJwWTD0MI7/2es/LPexM2goUNPAGBWQrU3VhSgfPgL/YQ==", new DateTime(2022, 6, 28, 1, 29, 41, 136, DateTimeKind.Local).AddTicks(2420) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cart",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6111424b-3638-47a7-be04-f8c8e0c908ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a3a05083-32cd-40d0-bb50-51acda4121bc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Timestamp" },
                values: new object[] { "cc996dca-5330-4816-9248-9a11a026d41c", "AQAAAAEAACcQAAAAECJN057lBMM3zfHnvU80bBExmK8xsFQzPOVAh5r1JlX64brV3cUmOtetK38UO5IFhw==", new DateTime(2022, 6, 27, 23, 57, 29, 866, DateTimeKind.Local).AddTicks(2680) });
        }
    }
}
