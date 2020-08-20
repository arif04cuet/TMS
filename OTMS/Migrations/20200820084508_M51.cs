using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 2406L, "asset.audit.create", null, 17L, 3L, "Create" },
                    { 3905L, "topic.list", null, 42L, 5L, "List" },
                    { 3903L, "topic.delete", null, 42L, 5L, "Delete" },
                    { 3904L, "topic.manage", null, 42L, 5L, "Manage" },
                    { 4001L, "course.category.create", null, 43L, 5L, "Create" },
                    { 4002L, "course.category.update", null, 43L, 5L, "Update" },
                    { 4005L, "course.category.list", null, 43L, 5L, "List" },
                    { 3902L, "topic.update", null, 42L, 5L, "Update" },
                    { 4003L, "course.category.delete", null, 43L, 5L, "Delete" },
                    { 4101L, "method.create", null, 44L, 5L, "Create" },
                    { 4102L, "method.update", null, 44L, 5L, "Update" },
                    { 4105L, "method.list", null, 44L, 5L, "List" },
                    { 4103L, "method.delete", null, 44L, 5L, "Delete" },
                    { 4104L, "method.manage", null, 44L, 5L, "Manage" },
                    { 4201L, "evaluation.method.create", null, 45L, 5L, "Create" },
                    { 4004L, "course.category.manage", null, 43L, 5L, "Manage" },
                    { 3901L, "topic.create", null, 42L, 5L, "Create" },
                    { 3804L, "module.manage", null, 41L, 5L, "Manage" },
                    { 3803L, "module.delete", null, 41L, 5L, "Delete" },
                    { 3503L, "room.type.delete", null, 32L, 4L, "Delete" },
                    { 3504L, "room.type.manage", null, 32L, 4L, "Manage" },
                    { 3601L, "room.facilities.create", null, 33L, 4L, "Create" },
                    { 3602L, "room.facilities.update", null, 33L, 4L, "Update" },
                    { 3605L, "room.facilities.list", null, 33L, 4L, "List" },
                    { 3603L, "room.facilities.delete", null, 33L, 4L, "Delete" },
                    { 3604L, "room.facilities.manage", null, 33L, 4L, "Manage" },
                    { 3701L, "course.create", null, 40L, 5L, "Create" },
                    { 3702L, "course.update", null, 40L, 5L, "Update" },
                    { 3705L, "course.list", null, 40L, 5L, "List" },
                    { 3703L, "course.delete", null, 40L, 5L, "Delete" },
                    { 3704L, "course.manage", null, 40L, 5L, "Manage" },
                    { 3801L, "module.create", null, 41L, 5L, "Create" },
                    { 3802L, "module.update", null, 41L, 5L, "Update" },
                    { 3805L, "module.list", null, 41L, 5L, "List" },
                    { 4202L, "evaluation.method.update", null, 45L, 5L, "Update" },
                    { 4205L, "evaluation.method.list", null, 45L, 5L, "List" },
                    { 4203L, "evaluation.method.delete", null, 45L, 5L, "Delete" },
                    { 4204L, "evaluation.method.manage", null, 45L, 5L, "Manage" },
                    { 4704L, "batch.manage", null, 51L, 5L, "Manage" },
                    { 4801L, "batch.allocation.create", null, 52L, 5L, "Create" },
                    { 4802L, "batch.allocation.update", null, 52L, 5L, "Update" },
                    { 4805L, "batch.allocation.list", null, 52L, 5L, "List" },
                    { 4803L, "batch.allocation.delete", null, 52L, 5L, "Delete" },
                    { 4804L, "batch.allocation.manage", null, 52L, 5L, "Manage" },
                    { 4901L, "question.create", null, 53L, 5L, "Create" },
                    { 4902L, "question.update", null, 53L, 5L, "Update" },
                    { 4905L, "question.list", null, 53L, 5L, "List" },
                    { 4903L, "question.delete", null, 53L, 5L, "Delete" },
                    { 4904L, "question.manage", null, 53L, 5L, "Manage" },
                    { 5101L, "honorarium.head.create", null, 54L, 5L, "Create" },
                    { 5102L, "honorarium.head.update", null, 54L, 5L, "Update" },
                    { 5105L, "honorarium.head.list", null, 54L, 5L, "List" },
                    { 5103L, "honorarium.head.delete", null, 54L, 5L, "Delete" },
                    { 4703L, "batch.delete", null, 51L, 5L, "Delete" },
                    { 3505L, "room.type.list", null, 32L, 4L, "List" },
                    { 4705L, "batch.list", null, 51L, 5L, "List" },
                    { 4701L, "batch.create", null, 51L, 5L, "Create" },
                    { 4401L, "expertise.create", null, 47L, 5L, "Create" },
                    { 4402L, "expertise.update", null, 47L, 5L, "Update" },
                    { 4405L, "expertise.list", null, 47L, 5L, "List" },
                    { 4403L, "expertise.delete", null, 47L, 5L, "Delete" },
                    { 4404L, "expertise.manage", null, 47L, 5L, "Manage" },
                    { 4501L, "resource.person.create", null, 48L, 5L, "Create" },
                    { 4502L, "resource.person.update", null, 48L, 5L, "Update" },
                    { 4505L, "resource.person.list", null, 48L, 5L, "List" },
                    { 4503L, "resource.person.delete", null, 48L, 5L, "Delete" },
                    { 4504L, "resource.person.manage", null, 48L, 5L, "Manage" },
                    { 4601L, "schedule.create", null, 50L, 5L, "Create" },
                    { 4602L, "schedule.update", null, 50L, 5L, "Update" },
                    { 4605L, "schedule.list", null, 50L, 5L, "List" },
                    { 4603L, "schedule.delete", null, 50L, 5L, "Delete" },
                    { 4604L, "schedule.manage", null, 50L, 5L, "Manage" },
                    { 4702L, "batch.update", null, 51L, 5L, "Update" },
                    { 5104L, "honorarium.head.manage", null, 54L, 5L, "Manage" },
                    { 3502L, "room.type.update", null, 32L, 4L, "Update" },
                    { 3404L, "bed.manage", null, 31L, 4L, "Manage" },
                    { 2462L, "supplier.delete", null, 25L, 3L, "Delete" },
                    { 2464L, "supplier.manage", null, 25L, 3L, "Manage" },
                    { 2470L, "depreciation.create", null, 25L, 3L, "Create" },
                    { 2471L, "depreciation.update", null, 25L, 3L, "Update" },
                    { 2473L, "depreciation.list", null, 25L, 3L, "List" },
                    { 2472L, "depreciation.delete", null, 25L, 3L, "Delete" },
                    { 2463L, "supplier.list", null, 25L, 3L, "List" },
                    { 2474L, "depreciation.manage", null, 25L, 3L, "Manage" },
                    { 2481L, "manufacturer.update", null, 25L, 3L, "Update" },
                    { 2483L, "manufacturer.list", null, 25L, 3L, "List" },
                    { 2482L, "manufacturer.delete", null, 25L, 3L, "Delete" },
                    { 2484L, "manufacturer.manage", null, 25L, 3L, "Manage" },
                    { 2490L, "asset.status.create", null, 25L, 3L, "Create" },
                    { 2491L, "asset.status.update", null, 25L, 3L, "Update" },
                    { 2480L, "manufacturer.create", null, 25L, 3L, "Create" },
                    { 2461L, "supplier.update", null, 25L, 3L, "Update" },
                    { 2460L, "supplier.create", null, 25L, 3L, "Create" },
                    { 2454L, "item.code.manage", null, 25L, 3L, "Manage" },
                    { 2407L, "asset.bulk.checkout", null, 17L, 3L, "Create" },
                    { 2420L, "consumable.create", null, 24L, 3L, "Create" },
                    { 2421L, "consumable.update", null, 24L, 3L, "Update" },
                    { 2423L, "consumable.list", null, 24L, 3L, "List" },
                    { 2422L, "consumable.delete", null, 24L, 3L, "Delete" },
                    { 2424L, "consumable.manage", null, 24L, 3L, "Manage" },
                    { 2440L, "asset.model.create", null, 25L, 3L, "Create" },
                    { 2441L, "asset.model.update", null, 25L, 3L, "Update" },
                    { 2443L, "asset.model.list", null, 25L, 3L, "List" },
                    { 2442L, "asset.model.delete", null, 25L, 3L, "Delete" },
                    { 2444L, "asset.model.manage", null, 25L, 3L, "Manage" },
                    { 2450L, "item.code.create", null, 25L, 3L, "Create" },
                    { 2451L, "item.code.update", null, 25L, 3L, "Update" },
                    { 2453L, "item.code.list", null, 25L, 3L, "List" },
                    { 2452L, "item.code.delete", null, 25L, 3L, "Delete" },
                    { 2493L, "asset.status.list", null, 25L, 3L, "List" },
                    { 2492L, "asset.status.delete", null, 25L, 3L, "Delete" },
                    { 2494L, "asset.status.manage", null, 25L, 3L, "Manage" },
                    { 2594L, "asset.category.create", null, 25L, 3L, "Create" },
                    { 3104L, "hostel.manage", null, 28L, 4L, "Manage" },
                    { 3201L, "building.create", null, 29L, 4L, "Create" },
                    { 3202L, "building.update", null, 29L, 4L, "Update" },
                    { 3205L, "building.list", null, 29L, 4L, "List" },
                    { 3203L, "building.delete", null, 29L, 4L, "Delete" },
                    { 3204L, "building.manage", null, 29L, 4L, "Manage" },
                    { 3301L, "room.create", null, 30L, 4L, "Create" },
                    { 3302L, "room.update", null, 30L, 4L, "Update" },
                    { 3305L, "room.list", null, 30L, 4L, "List" },
                    { 3303L, "room.delete", null, 30L, 4L, "Delete" },
                    { 3304L, "room.manage", null, 30L, 4L, "Manage" },
                    { 3401L, "bed.create", null, 31L, 4L, "Create" },
                    { 3402L, "bed.update", null, 31L, 4L, "Update" },
                    { 3405L, "bed.list", null, 31L, 4L, "List" },
                    { 3403L, "bed.delete", null, 31L, 4L, "Delete" },
                    { 3103L, "hostel.delete", null, 28L, 4L, "Delete" },
                    { 3501L, "room.type.create", null, 32L, 4L, "Create" },
                    { 3105L, "hostel.list", null, 28L, 4L, "List" },
                    { 3101L, "hostel.create", null, 28L, 4L, "Create" },
                    { 2495L, "asset.category.update", null, 25L, 3L, "Update" },
                    { 2498L, "asset.category.list", null, 25L, 3L, "List" },
                    { 2496L, "asset.category.delete", null, 25L, 3L, "Delete" },
                    { 2497L, "asset.category.manage", null, 25L, 3L, "Manage" },
                    { 2584L, "report.activity.log", null, 26L, 3L, "Create" },
                    { 2485L, "report.audit.log", null, 26L, 3L, "Create" },
                    { 2486L, "report.depreciation", null, 26L, 3L, "Create" },
                    { 2487L, "report.license", null, 26L, 3L, "Create" },
                    { 2488L, "report.maintenance", null, 26L, 3L, "Create" },
                    { 2489L, "report.asset", null, 26L, 3L, "Create" },
                    { 3001L, "allocation.create", null, 27L, 4L, "Create" },
                    { 3002L, "allocation.update", null, 27L, 4L, "Update" },
                    { 3005L, "allocation.list", null, 27L, 4L, "List" },
                    { 3003L, "allocation.delete", null, 27L, 4L, "Delete" },
                    { 3004L, "allocation.manage", null, 27L, 4L, "Manage" },
                    { 3102L, "hostel.update", null, 28L, 4L, "Update" }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 46L, null, null, true, false, "Grade", null, null, 0L });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 4301L, "grade.create", null, 46L, 5L, "Create" },
                    { 4302L, "grade.update", null, 46L, 5L, "Update" },
                    { 4305L, "grade.list", null, 46L, 5L, "List" },
                    { 4303L, "grade.delete", null, 46L, 5L, "Delete" },
                    { 4304L, "grade.manage", null, 46L, 5L, "Manage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2406L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2407L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2420L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2421L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2422L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2423L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2424L);

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
                keyValue: 2485L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2486L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2487L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2488L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2489L);

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
                keyValue: 2584L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2594L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3001L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3002L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3003L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3004L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3005L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3102L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3201L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3202L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3203L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3204L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3205L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3301L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3302L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3303L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3304L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3305L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3401L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3402L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3403L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3404L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3405L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3501L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3502L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3503L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3504L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3505L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3601L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3602L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3603L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3604L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3605L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3701L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3702L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3703L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3704L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3705L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3801L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3802L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3803L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3804L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3805L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3901L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3902L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3903L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3904L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3905L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4001L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4002L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4003L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4004L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4005L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4102L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4201L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4202L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4203L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4204L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4205L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4301L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4302L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4303L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4304L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4305L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4401L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4402L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4403L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4404L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4405L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4501L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4502L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4503L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4504L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4505L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4601L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4602L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4603L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4604L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4605L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4701L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4702L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4703L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4704L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4705L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4801L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4802L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4803L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4804L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4805L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4901L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4902L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4903L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4904L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4905L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5102L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "PermissionGroup",
                keyColumn: "Id",
                keyValue: 46L);
        }
    }
}
