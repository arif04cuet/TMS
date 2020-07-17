using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.AddColumn<long>(
                name: "BatchScheduleId",
                schema: "training",
                table: "Allocation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BatchScheduleGalleryItem",
                schema: "training",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Version = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MediaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchScheduleGalleryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchScheduleGalleryItem_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BatchScheduleId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleGalleryItem_MediaId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleId",
                principalSchema: "training",
                principalTable: "BatchSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropTable(
                name: "BatchScheduleGalleryItem",
                schema: "training");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "BatchScheduleId",
                schema: "training",
                table: "Allocation");

            migrationBuilder.AddColumn<long>(
                name: "ScheduleId",
                schema: "training",
                table: "Allocation",
                type: "bigint",
                nullable: true);
        }
    }
}
