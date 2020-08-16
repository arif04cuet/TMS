using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 202L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 302L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 402L);

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 606L, "book.issue", null, 6L, 2L, "Issue" },
                    { 607L, "book.return", null, 6L, 2L, "Return" }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 7L, null, null, true, false, "Library", null, null, 0L },
                    { 8L, null, null, true, false, "Member", null, null, 0L },
                    { 9L, null, null, true, false, "Member Request", null, null, 0L },
                    { 10L, null, null, true, false, "Card", null, null, 0L },
                    { 11L, null, null, true, false, "Catalog", null, null, 0L },
                    { 12L, null, null, true, false, "Rack", null, null, 0L },
                    { 13L, null, null, true, false, "Author", null, null, 0L },
                    { 14L, null, null, true, false, "Publisher", null, null, 0L },
                    { 15L, null, null, true, false, "Category", null, null, 0L },
                    { 16L, null, null, true, false, "Report", null, null, 0L },
                    { 17L, null, null, true, false, "Asset", null, null, 0L },
                    { 18L, null, null, true, false, "Maintenance", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1400L, "library.create", null, 7L, 2L, "Create" },
                    { 700L, "author.create", null, 13L, 2L, "Create" },
                    { 701L, "author.update", null, 13L, 2L, "Update" },
                    { 704L, "author.list", null, 13L, 2L, "List" },
                    { 703L, "author.delete", null, 13L, 2L, "Delete" },
                    { 705L, "author.manage", null, 13L, 2L, "Manage" },
                    { 1200L, "publisher.create", null, 14L, 2L, "Create" },
                    { 1201L, "publisher.update", null, 14L, 2L, "Update" },
                    { 1204L, "publisher.list", null, 14L, 2L, "List" },
                    { 1203L, "publisher.delete", null, 14L, 2L, "Delete" },
                    { 1205L, "publisher.manage", null, 14L, 2L, "Manage" },
                    { 2100L, "book.category.create", null, 15L, 2L, "Create" },
                    { 2101L, "book.category.update", null, 15L, 2L, "Update" },
                    { 2104L, "book.category.list", null, 15L, 2L, "List" },
                    { 2103L, "book.category.delete", null, 15L, 2L, "Delete" },
                    { 2105L, "book.category.manage", null, 15L, 2L, "Manage" },
                    { 2200L, "library.report.issue", null, 16L, 2L, "Issue" },
                    { 2201L, "library.report.fine", null, 16L, 2L, "Fine" },
                    { 2300L, "asset.create", null, 17L, 3L, "Create" },
                    { 2301L, "asset.update", null, 17L, 3L, "Update" },
                    { 2304L, "asset.list", null, 17L, 3L, "List" },
                    { 2303L, "asset.delete", null, 17L, 3L, "Delete" },
                    { 2305L, "asset.manage", null, 17L, 3L, "Manage" },
                    { 2400L, "maintenance.create", null, 18L, 3L, "Create" },
                    { 2401L, "maintenance.update", null, 18L, 3L, "Update" },
                    { 2404L, "maintenance.list", null, 18L, 3L, "List" },
                    { 1505L, "rack.manage", null, 12L, 2L, "Manage" },
                    { 2403L, "maintenance.delete", null, 18L, 3L, "Delete" },
                    { 1503L, "rack.delete", null, 12L, 2L, "Delete" },
                    { 1501L, "rack.update", null, 12L, 2L, "Update" },
                    { 1401L, "library.update", null, 7L, 2L, "Update" },
                    { 1404L, "library.list", null, 7L, 2L, "List" },
                    { 1403L, "library.delete", null, 7L, 2L, "Delete" },
                    { 1405L, "library.manage", null, 7L, 2L, "Manage" },
                    { 1700L, "library.member.create", null, 8L, 2L, "Create" },
                    { 1701L, "library.member.update", null, 8L, 2L, "Update" },
                    { 1704L, "library.member.list", null, 8L, 2L, "List" },
                    { 1703L, "library.member.delete", null, 8L, 2L, "Delete" },
                    { 1705L, "library.member.manage", null, 8L, 2L, "Manage" },
                    { 1800L, "library.member.request.create", null, 9L, 2L, "Create" },
                    { 1801L, "library.member.request.update", null, 9L, 2L, "Update" },
                    { 1804L, "library.member.request.list", null, 9L, 2L, "List" },
                    { 1803L, "library.member.request.delete", null, 9L, 2L, "Delete" },
                    { 1805L, "library.member.request.manage", null, 9L, 2L, "Manage" },
                    { 1900L, "card.create", null, 10L, 2L, "Create" },
                    { 1901L, "card.update", null, 10L, 2L, "Update" },
                    { 1904L, "card.list", null, 10L, 2L, "List" },
                    { 1903L, "card.delete", null, 10L, 2L, "Delete" },
                    { 1905L, "card.manage", null, 10L, 2L, "Manage" },
                    { 2000L, "book.catalog.create", null, 11L, 2L, "Create" },
                    { 2001L, "book.catalog.update", null, 11L, 2L, "Update" },
                    { 2004L, "book.catalog.list", null, 11L, 2L, "List" },
                    { 2003L, "book.catalog.delete", null, 11L, 2L, "Delete" },
                    { 2005L, "book.catalog.manage", null, 11L, 2L, "Manage" },
                    { 1500L, "rack.create", null, 12L, 2L, "Create" },
                    { 1504L, "rack.list", null, 12L, 2L, "List" },
                    { 2405L, "maintenance.manage", null, 18L, 3L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 606L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 607L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 700L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 701L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 703L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 704L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 705L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1200L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1201L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1203L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1204L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1205L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1400L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1401L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1403L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1404L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1405L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1500L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1501L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1503L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1504L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1505L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1700L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1701L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1703L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1704L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1705L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1800L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1801L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1803L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1804L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1805L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1900L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1901L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1903L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1904L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1905L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2000L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2001L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2003L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2004L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2005L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2100L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2200L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2201L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2300L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2301L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2303L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2304L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2305L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2400L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2401L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2403L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2404L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2405L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 202L, "role.view", null, 2L, 1L, "View" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 302L, "designation.view", null, 3L, 1L, "View" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[] { 402L, "department.view", null, 4L, 1L, "View" });
        }
    }
}
