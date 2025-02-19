using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdIntoString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserProfiles_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "UserProfiles");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserName",
                table: "UserProfiles",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserProfiles_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
