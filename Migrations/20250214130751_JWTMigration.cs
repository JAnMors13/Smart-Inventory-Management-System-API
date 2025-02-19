using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class JWTMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30004957-deaf-4990-805f-b68f30caa5da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b482486-a0ed-4d21-950c-5176fcf342fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c198b37-3050-4046-b2dc-0c7d07e8fc35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19d1e6d-7d8b-4fa4-b22b-2d59ee78723b");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30004957-deaf-4990-805f-b68f30caa5da", null, "Manager", "MANAGER" },
                    { "6b482486-a0ed-4d21-950c-5176fcf342fe", null, "Admin", "ADMIN" },
                    { "6c198b37-3050-4046-b2dc-0c7d07e8fc35", null, "Employee", "EMPLOYEE" },
                    { "f19d1e6d-7d8b-4fa4-b22b-2d59ee78723b", null, "User", "USER" }
                });
        }
    }
}
