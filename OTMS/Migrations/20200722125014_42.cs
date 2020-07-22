using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class _42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Building_BuildingId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.AddColumn<long>(
                name: "BedId",
                schema: "training",
                table: "BatchScheduleAllocation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                schema: "training",
                table: "BatchScheduleAllocation",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HostelId",
                schema: "training",
                table: "Allocation",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FloorId",
                schema: "training",
                table: "Allocation",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "BuildingId",
                schema: "training",
                table: "Allocation",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_BedId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_RoomId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleAllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_BatchScheduleAllocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleAllocationId",
                principalSchema: "training",
                principalTable: "BatchScheduleAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Building_BuildingId",
                schema: "training",
                table: "Allocation",
                column: "BuildingId",
                principalSchema: "training",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchScheduleAllocation_Bed_BedId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "BedId",
                principalSchema: "training",
                principalTable: "Bed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchScheduleAllocation_Room_RoomId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "RoomId",
                principalSchema: "training",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_BatchScheduleAllocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Building_BuildingId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchScheduleAllocation_Bed_BedId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchScheduleAllocation_Room_RoomId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BatchScheduleAllocation_BedId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BatchScheduleAllocation_RoomId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "BedId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropColumn(
                name: "RoomId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropColumn(
                name: "BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.AlterColumn<long>(
                name: "HostelId",
                schema: "training",
                table: "Allocation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FloorId",
                schema: "training",
                table: "Allocation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BuildingId",
                schema: "training",
                table: "Allocation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BatchScheduleId",
                schema: "training",
                table: "Allocation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BatchScheduleId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleId",
                principalSchema: "training",
                principalTable: "BatchSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Building_BuildingId",
                schema: "training",
                table: "Allocation",
                column: "BuildingId",
                principalSchema: "training",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
