using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class licensePermissionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2406L,
                column: "Name",
                value: "Audit");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2407L,
                column: "Name",
                value: "Bulk Checkout");

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 2408L, "lincese.create", null, 23L, 3L, "Create" },
                    { 2409L, "lincese.update", null, 23L, 3L, "Update" },
                    { 2411L, "lincese.list", null, 23L, 3L, "List" },
                    { 2410L, "lincese.delete", null, 23L, 3L, "Delete" },
                    { 2412L, "lincese.manage", null, 23L, 3L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2408L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2409L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2410L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2411L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2412L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2406L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2407L,
                column: "Name",
                value: "Create");
        }
    }
}
