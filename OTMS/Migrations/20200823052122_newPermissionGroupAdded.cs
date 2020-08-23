using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class newPermissionGroupAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Module",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 7L, null, null, true, false, "Others Management", null, null, 0L });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 55L, null, null, true, false, "Others", null, null, 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Module",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 55L);
        }
    }
}
