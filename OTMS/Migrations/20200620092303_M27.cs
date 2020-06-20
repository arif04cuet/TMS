using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutinePeriod_CourseModuleTopic_TopicId",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutinePeriod_Topic_TopicId",
                schema: "training",
                table: "RoutinePeriod",
                column: "TopicId",
                principalSchema: "training",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutinePeriod_Topic_TopicId",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutinePeriod_CourseModuleTopic_TopicId",
                schema: "training",
                table: "RoutinePeriod",
                column: "TopicId",
                principalSchema: "training",
                principalTable: "CourseModuleTopic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
