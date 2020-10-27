using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M58 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 2202L, "library.report.book.entry", null, 16L, 2L, "Book Entry" },
                    { 2203L, "library.report.at.a.glance", null, 16L, 2L, "At A Glance" },
                    { 2204L, "library.report.lost.books", null, 16L, 2L, "Lost Book" },
                    { 2205L, "library.report.new.books", null, 16L, 2L, "New Book" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2202L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2203L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2204L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2205L);
        }
    }
}
