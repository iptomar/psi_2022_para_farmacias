using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parafarmacia.Data.Migrations
{
    public partial class userOrderRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e23365f5-b5fa-4deb-9caf-8dcbf7dbda8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "90ef9285-20ca-43bc-9b8e-9410190e5e90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Timestamp" },
                values: new object[] { "8486467d-3bcf-47ec-ad20-fbb253ee8ac8", "AQAAAAEAACcQAAAAEAmNEQtwyKuTje/FJgP9w7Dji9oF48J3NhEwXjsHeY4ZoPDpAGA6Is7ntld2OBiGjA==", new DateTime(2022, 6, 27, 19, 27, 49, 272, DateTimeKind.Local).AddTicks(1800) });
        }
    }
}
