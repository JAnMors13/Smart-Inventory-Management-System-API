using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updatingDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "309ff8a7-8f0d-4138-89c6-133c089432aa", null, "Manager", "MANAGER" },
                    { "7fb7ce3d-4de1-4ff4-860c-412e0b479a2d", null, "Employee", "EMPLOYEE" },
                    { "8840b4c5-b0f8-48c3-acf6-674e68977b75", null, "User", "USER" },
                    { "ea476108-f253-4591-a4d0-d809bfbf87e9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "309ff8a7-8f0d-4138-89c6-133c089432aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb7ce3d-4de1-4ff4-860c-412e0b479a2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8840b4c5-b0f8-48c3-acf6-674e68977b75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea476108-f253-4591-a4d0-d809bfbf87e9");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
