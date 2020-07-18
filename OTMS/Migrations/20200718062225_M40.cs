using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleGalleryItem_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                column: "BatchScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchScheduleGalleryItem_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                column: "BatchScheduleId",
                principalSchema: "training",
                principalTable: "BatchSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchScheduleGalleryItem_BatchSchedule_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem");

            migrationBuilder.DropIndex(
                name: "IX_BatchScheduleGalleryItem_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem");

            migrationBuilder.DropColumn(
                name: "BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem");
        }
    }
}
