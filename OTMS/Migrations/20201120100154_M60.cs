using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 65L, null, null, true, false, "Book Reservation", null, null, 0L });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1300L, "book.reservation.create", null, 65L, 2L, "Create" },
                    { 1303L, "book.reservation.update", null, 65L, 2L, "Update" },
                    { 1305L, "book.reservation.view", null, 65L, 2L, "View" },
                    { 1301L, "book.reservation.list", null, 65L, 2L, "List" },
                    { 1304L, "book.reservation.delete", null, 65L, 2L, "Delete" },
                    { 1302L, "book.reservation.manage", null, 65L, 2L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1300L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1301L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1302L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1303L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1304L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1305L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 65L);
        }
    }
}
