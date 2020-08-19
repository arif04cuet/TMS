using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class CMSSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Module",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 4L, null, null, true, false, "Hostel Management", null, null, 0L },
                    { 5L, null, null, true, false, "Training Management", null, null, 0L },
                    { 6L, null, null, true, false, "Contents Management", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 19L, null, null, true, false, "Contents Category", null, null, 0L },
                    { 20L, null, null, true, false, "Contents", null, null, 0L },
                    { 21L, null, null, true, false, "Contents Faq", null, null, 0L },
                    { 22L, null, null, true, false, "Contents Banner", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 4L, null, null, true, false, "Inventory Manager", null, null, 0L },
                    { 5L, null, null, true, false, "Hostel Manager", null, null, 0L },
                    { 6L, null, null, true, false, "Course Director", null, null, 0L },
                    { 7L, null, null, true, false, "Course Coordinator", null, null, 0L },
                    { 8L, null, null, true, false, "Principle", null, null, 0L },
                    { 9L, null, null, true, false, "Vice Principle", null, null, 0L },
                    { 10L, null, null, true, false, "Participant", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 2600L, "content.category.create", null, 19L, 6L, "Create" },
                    { 2903L, "content.banner.list", null, 22L, 6L, "List" },
                    { 2901L, "content.banner.update", null, 22L, 6L, "Update" },
                    { 2900L, "content.banner.create", null, 22L, 6L, "Create" },
                    { 2804L, "content.faq.manage", null, 21L, 6L, "Manage" },
                    { 2801L, "content.faq.delete", null, 21L, 6L, "Delete" },
                    { 2803L, "content.faq.list", null, 21L, 6L, "List" },
                    { 2800L, "content.faq.update", null, 21L, 6L, "Update" },
                    { 2802L, "content.faq.create", null, 21L, 6L, "Create" },
                    { 2704L, "content.manage", null, 20L, 6L, "Manage" },
                    { 2702L, "content.delete", null, 20L, 6L, "Delete" },
                    { 2703L, "content.list", null, 20L, 6L, "List" },
                    { 2700L, "content.update", null, 20L, 6L, "Update" },
                    { 2701L, "content.create", null, 20L, 6L, "Create" },
                    { 2604L, "content.category.manage", null, 19L, 6L, "Manage" },
                    { 2602L, "content.category.delete", null, 19L, 6L, "Delete" },
                    { 2603L, "content.category.list", null, 19L, 6L, "List" },
                    { 2601L, "content.category.update", null, 19L, 6L, "Update" },
                    { 2902L, "content.banner.delete", null, 22L, 6L, "Delete" },
                    { 2904L, "content.banner.manage", null, 22L, 6L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Module",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Module",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2600L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2601L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2602L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2603L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2604L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2700L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2701L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2702L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2703L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2704L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2800L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2801L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2802L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2803L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2804L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2900L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2901L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2902L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2903L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2904L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Role",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Module",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 22L);
        }
    }
}
