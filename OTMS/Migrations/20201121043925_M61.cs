using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 1306L, "book.reservation.cancel", null, 65L, 2L, "Manage" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 1307L, "book.reservation.issue", null, 65L, 2L, "Manage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1306L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1307L);
        }
    }
}
