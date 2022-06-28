using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parafarmacia.Data.Migrations
{
    public partial class increaseNameLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "262c279e-eda4-4732-9e0a-08d00c5240fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a6cbcf1f-4f30-4c5b-a196-e1d7bcf50b7b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Timestamp" },
                values: new object[] { "99fd8642-3f3a-4808-9435-eb601fd9f7d0", "AQAAAAEAACcQAAAAEATE/6P3o1uMEoapD7I7pdDWVOhmJM2oXNMPgps4Pr6MbudBA33gyMrjC7/hVEGZiA==", new DateTime(2022, 6, 15, 1, 35, 50, 642, DateTimeKind.Local).AddTicks(6950) });
        }
    }
}
