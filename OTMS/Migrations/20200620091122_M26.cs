using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
