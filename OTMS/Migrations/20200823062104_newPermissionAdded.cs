using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class newPermissionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 6100L, "myexam.manage", null, 55L, 7L, "Manage" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 56L, null, null, true, false, "Requisition", null, null, 0L });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 7101L, "requisition.create", null, 56L, 3L, "Create" },
                    { 7102L, "requisition.update", null, 56L, 3L, "Update" },
                    { 7105L, "requisition.list", null, 56L, 3L, "List" },
                    { 7103L, "requisition.delete", null, 56L, 3L, "Delete" },
                    { 7104L, "requisition.manage", null, 56L, 3L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 6100L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7102L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 56L);
        }
    }
}
