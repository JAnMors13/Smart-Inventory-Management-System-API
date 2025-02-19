using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "116ef6a0-072c-4857-85e8-38d2d1cf9a5d", null, "Admin", "ADMIN" },
                    { "1c3d8ad5-ca66-4af6-9987-1e163abc27a6", null, "Manager", "MANAGER" },
                    { "c375fc8a-cbab-4313-bedb-ba132fd78ebe", null, "Employee", "EMPLOYEE" },
                    { "ef149dec-3ffd-4130-a8df-8c94a18d90cf", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "116ef6a0-072c-4857-85e8-38d2d1cf9a5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3d8ad5-ca66-4af6-9987-1e163abc27a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c375fc8a-cbab-4313-bedb-ba132fd78ebe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef149dec-3ffd-4130-a8df-8c94a18d90cf");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

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
        }
    }
}
