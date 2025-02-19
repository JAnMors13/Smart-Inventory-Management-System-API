using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addingOrderInAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4acf51e5-37c3-4cd2-8c5b-eb40687d5073");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cafc5a21-2d29-4ed1-a3af-456571c3c64b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfbcac62-ad8c-4536-a597-98dca9f4db66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec734223-909b-4da9-a643-90fd43954dfd");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

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
                    { "15e01c5b-08b4-4d78-a7ba-404a0b56ace7", null, "Employee", "EMPLOYEE" },
                    { "2679f817-bedb-4ed9-976b-a60e5396d7e2", null, "Manager", "MANAGER" },
                    { "b8342183-eb80-46ee-a097-3011ad9a313e", null, "User", "USER" },
                    { "cac62fbd-96c3-4e96-b05b-4fb713f5c0e1", null, "Admin", "ADMIN" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "15e01c5b-08b4-4d78-a7ba-404a0b56ace7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2679f817-bedb-4ed9-976b-a60e5396d7e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8342183-eb80-46ee-a097-3011ad9a313e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac62fbd-96c3-4e96-b05b-4fb713f5c0e1");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4acf51e5-37c3-4cd2-8c5b-eb40687d5073", null, "User", "USER" },
                    { "cafc5a21-2d29-4ed1-a3af-456571c3c64b", null, "Employee", "EMPLOYEE" },
                    { "cfbcac62-ad8c-4536-a597-98dca9f4db66", null, "Admin", "ADMIN" },
                    { "ec734223-909b-4da9-a643-90fd43954dfd", null, "Manager", "MANAGER" }
                });
        }
    }
}
