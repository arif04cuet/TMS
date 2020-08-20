using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class ACLGroupUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 23L, null, null, true, false, "License", null, null, 0L },
                    { 52L, null, null, true, false, "Participant Approval", null, null, 0L },
                    { 51L, null, null, true, false, "Batch Schedule", null, null, 0L },
                    { 50L, null, null, true, false, "Course Schedule", null, null, 0L },
                    { 48L, null, null, true, false, "Resource Person", null, null, 0L },
                    { 47L, null, null, true, false, "Exertise", null, null, 0L },
                    { 45L, null, null, true, false, "Evaluation Method", null, null, 0L },
                    { 44L, null, null, true, false, "Training Method", null, null, 0L },
                    { 43L, null, null, true, false, "Course Category", null, null, 0L },
                    { 42L, null, null, true, false, "Session", null, null, 0L },
                    { 41L, null, null, true, false, "Module", null, null, 0L },
                    { 40L, null, null, true, false, "Course", null, null, 0L },
                    { 33L, null, null, true, false, "Room facilities", null, null, 0L },
                    { 32L, null, null, true, false, "Room Type", null, null, 0L },
                    { 31L, null, null, true, false, "Bed", null, null, 0L },
                    { 30L, null, null, true, false, "Room", null, null, 0L },
                    { 29L, null, null, true, false, "Building", null, null, 0L },
                    { 28L, null, null, true, false, "Hostels", null, null, 0L },
                    { 27L, null, null, true, false, "Hostel Allocation", null, null, 0L },
                    { 26L, null, null, true, false, "Report", null, null, 0L },
                    { 25L, null, null, true, false, "Setting", null, null, 0L },
                    { 24L, null, null, true, false, "Consumable", null, null, 0L },
                    { 53L, null, null, true, false, "Question", null, null, 0L },
                    { 54L, null, null, true, false, "Honorarium Head", null, null, 0L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 54L);
        }
    }
}
