using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddingIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10331202-cf2a-4431-995d-098e5c867718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda2a9ec-6588-4dd5-b7ba-4c59d41c861e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02e48aea-b219-47e7-9779-970ae8256a66", null, "Employee", "EMPLOYEE" },
                    { "1d9aa5d3-afe6-4408-a03f-7f49dfe29359", null, "Manager", "MANAGER" },
                    { "ef33da72-d3d8-47be-9b73-264a0115cc62", null, "User", "USER" },
                    { "f4b5cd26-efbe-40ad-8ca2-b29c565df629", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02e48aea-b219-47e7-9779-970ae8256a66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d9aa5d3-afe6-4408-a03f-7f49dfe29359");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef33da72-d3d8-47be-9b73-264a0115cc62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b5cd26-efbe-40ad-8ca2-b29c565df629");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10331202-cf2a-4431-995d-098e5c867718", null, "User", "USER" },
                    { "fda2a9ec-6588-4dd5-b7ba-4c59d41c861e", null, "Admin", "ADMIN" }
                });
        }
    }
}
