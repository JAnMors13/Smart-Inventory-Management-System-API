using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderDateToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10914079-4df7-47d4-a7dd-4e64779e3330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19cfe25e-3ad6-4a15-b533-04f65cdad667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "210d575a-fec3-4a70-b11f-4c44bac8067b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69c50b44-6a36-4219-beb7-b7dc7cccd1ef");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "025d7911-e61a-4d18-957d-deb3425897b4", null, "Employee", "EMPLOYEE" },
                    { "03766f29-71a6-45a3-9b5b-7d75418842d5", null, "Manager", "MANAGER" },
                    { "3c550c2f-0fcb-4f06-9bb3-f12f9a1dc64a", null, "Admin", "ADMIN" },
                    { "6a5f8c98-abf4-420e-9d9d-68da57dd21a6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "025d7911-e61a-4d18-957d-deb3425897b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03766f29-71a6-45a3-9b5b-7d75418842d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c550c2f-0fcb-4f06-9bb3-f12f9a1dc64a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a5f8c98-abf4-420e-9d9d-68da57dd21a6");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10914079-4df7-47d4-a7dd-4e64779e3330", null, "User", "USER" },
                    { "19cfe25e-3ad6-4a15-b533-04f65cdad667", null, "Manager", "MANAGER" },
                    { "210d575a-fec3-4a70-b11f-4c44bac8067b", null, "Admin", "ADMIN" },
                    { "69c50b44-6a36-4219-beb7-b7dc7cccd1ef", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
