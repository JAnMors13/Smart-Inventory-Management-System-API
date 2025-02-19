using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleinAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "30004957-deaf-4990-805f-b68f30caa5da", null, "Manager", "MANAGER" },
                    { "6b482486-a0ed-4d21-950c-5176fcf342fe", null, "Admin", "ADMIN" },
                    { "6c198b37-3050-4046-b2dc-0c7d07e8fc35", null, "Employee", "EMPLOYEE" },
                    { "f19d1e6d-7d8b-4fa4-b22b-2d59ee78723b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

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
    }
}
