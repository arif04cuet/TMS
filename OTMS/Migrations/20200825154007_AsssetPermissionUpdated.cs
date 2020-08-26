using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class AsssetPermissionUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2485L,
                column: "Name",
                value: "Audit Log");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2486L,
                column: "Name",
                value: "Depreciation");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2487L,
                column: "Name",
                value: "License");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2488L,
                column: "Name",
                value: "Maintenance");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2489L,
                column: "Name",
                value: "Asset");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2584L,
                column: "Name",
                value: "Activity Log");

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 58L, null, null, true, false, "Asset Setting Model", null, null, 0L },
                    { 59L, null, null, true, false, "Asset Setting Item Code", null, null, 0L },
                    { 60L, null, null, true, false, "Asset Setting Supplier", null, null, 0L },
                    { 61L, null, null, true, false, "Asset Setting Depreciation", null, null, 0L },
                    { 62L, null, null, true, false, "Asset Setting Manufacturer", null, null, 0L },
                    { 63L, null, null, true, false, "Asset Setting Status", null, null, 0L },
                    { 64L, null, null, true, false, "Asset Setting Category", null, null, 0L }
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2440L,
                column: "GroupId",
                value: 58L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2441L,
                column: "GroupId",
                value: 58L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2442L,
                column: "GroupId",
                value: 58L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2443L,
                column: "GroupId",
                value: 58L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2444L,
                column: "GroupId",
                value: 58L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2450L,
                column: "GroupId",
                value: 59L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2451L,
                column: "GroupId",
                value: 59L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2452L,
                column: "GroupId",
                value: 59L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2453L,
                column: "GroupId",
                value: 59L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2454L,
                column: "GroupId",
                value: 59L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2460L,
                column: "GroupId",
                value: 60L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2461L,
                column: "GroupId",
                value: 60L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2462L,
                column: "GroupId",
                value: 60L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2463L,
                column: "GroupId",
                value: 60L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2464L,
                column: "GroupId",
                value: 60L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2470L,
                column: "GroupId",
                value: 61L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2471L,
                column: "GroupId",
                value: 61L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2472L,
                column: "GroupId",
                value: 61L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2473L,
                column: "GroupId",
                value: 61L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2474L,
                column: "GroupId",
                value: 61L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2480L,
                column: "GroupId",
                value: 62L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2481L,
                column: "GroupId",
                value: 62L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2482L,
                column: "GroupId",
                value: 62L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2483L,
                column: "GroupId",
                value: 62L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2484L,
                column: "GroupId",
                value: 62L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2490L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2491L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2492L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2493L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2494L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2495L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2496L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2497L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2498L,
                column: "GroupId",
                value: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2594L,
                column: "GroupId",
                value: 63L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2440L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2441L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2442L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2443L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2444L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2450L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2451L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2452L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2453L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2454L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2460L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2461L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2462L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2463L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2464L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2470L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2471L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2472L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2473L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2474L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2480L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2481L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2482L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2483L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2484L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2490L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2491L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2492L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2493L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2494L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2495L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2496L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2497L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2498L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2594L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2485L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2486L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2487L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2488L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2489L,
                column: "Name",
                value: "Create");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2584L,
                column: "Name",
                value: "Create");

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 2484L, "manufacturer.manage", null, 25L, 3L, "Manage" },
                    { 2490L, "asset.status.create", null, 25L, 3L, "Create" },
                    { 2491L, "asset.status.update", null, 25L, 3L, "Update" },
                    { 2493L, "asset.status.list", null, 25L, 3L, "List" },
                    { 2464L, "supplier.manage", null, 25L, 3L, "Manage" },
                    { 2494L, "asset.status.manage", null, 25L, 3L, "Manage" },
                    { 2594L, "asset.category.create", null, 25L, 3L, "Create" },
                    { 2495L, "asset.category.update", null, 25L, 3L, "Update" },
                    { 2498L, "asset.category.list", null, 25L, 3L, "List" },
                    { 2496L, "asset.category.delete", null, 25L, 3L, "Delete" },
                    { 2497L, "asset.category.manage", null, 25L, 3L, "Manage" },
                    { 2463L, "supplier.list", null, 25L, 3L, "List" },
                    { 2462L, "supplier.delete", null, 25L, 3L, "Delete" },
                    { 2492L, "asset.status.delete", null, 25L, 3L, "Delete" },
                    { 2470L, "depreciation.create", null, 25L, 3L, "Create" },
                    { 2473L, "depreciation.list", null, 25L, 3L, "List" },
                    { 2441L, "asset.model.update", null, 25L, 3L, "Update" },
                    { 2440L, "asset.model.create", null, 25L, 3L, "Create" },
                    { 2461L, "supplier.update", null, 25L, 3L, "Update" },
                    { 2460L, "supplier.create", null, 25L, 3L, "Create" },
                    { 2454L, "item.code.manage", null, 25L, 3L, "Manage" },
                    { 2452L, "item.code.delete", null, 25L, 3L, "Delete" },
                    { 2453L, "item.code.list", null, 25L, 3L, "List" },
                    { 2451L, "item.code.update", null, 25L, 3L, "Update" },
                    { 2450L, "item.code.create", null, 25L, 3L, "Create" },
                    { 2444L, "asset.model.manage", null, 25L, 3L, "Manage" },
                    { 2442L, "asset.model.delete", null, 25L, 3L, "Delete" },
                    { 2482L, "manufacturer.delete", null, 25L, 3L, "Delete" },
                    { 2483L, "manufacturer.list", null, 25L, 3L, "List" },
                    { 2481L, "manufacturer.update", null, 25L, 3L, "Update" },
                    { 2480L, "manufacturer.create", null, 25L, 3L, "Create" },
                    { 2474L, "depreciation.manage", null, 25L, 3L, "Manage" },
                    { 2472L, "depreciation.delete", null, 25L, 3L, "Delete" },
                    { 2471L, "depreciation.update", null, 25L, 3L, "Update" },
                    { 2443L, "asset.model.list", null, 25L, 3L, "List" }
                });
        }
    }
}
