using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserProfileMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967b430c-e4e4-4f7c-9dcd-a0f30486c126");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff9b8644-a302-46fb-98b4-04f16bdd117f");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserProfiles",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_Username",
                table: "UserProfiles",
                newName: "IX_UserProfiles_UserName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10331202-cf2a-4431-995d-098e5c867718", null, "User", "USER" },
                    { "fda2a9ec-6588-4dd5-b7ba-4c59d41c861e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10331202-cf2a-4431-995d-098e5c867718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda2a9ec-6588-4dd5-b7ba-4c59d41c861e");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserProfiles",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_UserName",
                table: "UserProfiles",
                newName: "IX_UserProfiles_Username");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "967b430c-e4e4-4f7c-9dcd-a0f30486c126", null, "Admin", "ADMIN" },
                    { "ff9b8644-a302-46fb-98b4-04f16bdd117f", null, "User", "USER" }
                });
        }
    }
}
