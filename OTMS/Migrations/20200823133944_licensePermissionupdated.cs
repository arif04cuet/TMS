using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class licensePermissionupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2408L,
                column: "Code",
                value: "license.create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2409L,
                column: "Code",
                value: "license.update");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2410L,
                column: "Code",
                value: "license.delete");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2411L,
                column: "Code",
                value: "license.list");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2412L,
                column: "Code",
                value: "license.manage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2408L,
                column: "Code",
                value: "lincese.create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2409L,
                column: "Code",
                value: "lincese.update");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2410L,
                column: "Code",
                value: "lincese.delete");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2411L,
                column: "Code",
                value: "lincese.list");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2412L,
                column: "Code",
                value: "lincese.manage");
        }
    }
}
