using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class MyExamPermissionUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 6100L,
                columns: new[] { "GroupId", "ModuleId", "Name" },
                values: new object[] { 51L, 5L, "MyExam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 6100L,
                columns: new[] { "GroupId", "ModuleId", "Name" },
                values: new object[] { 55L, 7L, "Manage" });
        }
    }
}
