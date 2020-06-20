using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutineModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "CourseModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoutineModule_CourseModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "CourseModuleId",
                principalSchema: "training",
                principalTable: "CourseModule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoutineModule_CourseModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule");

            migrationBuilder.DropIndex(
                name: "IX_ClassRoutineModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule");

            migrationBuilder.DropColumn(
                name: "CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule");
        }
    }
}
