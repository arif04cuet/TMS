using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseScheduleId",
                schema: "training",
                table: "Budget",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CourseScheduleId",
                schema: "training",
                table: "Budget",
                column: "CourseScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_CourseSchedule_CourseScheduleId",
                schema: "training",
                table: "Budget",
                column: "CourseScheduleId",
                principalSchema: "training",
                principalTable: "CourseSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_CourseSchedule_CourseScheduleId",
                schema: "training",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_CourseScheduleId",
                schema: "training",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "CourseScheduleId",
                schema: "training",
                table: "Budget");
        }
    }
}
