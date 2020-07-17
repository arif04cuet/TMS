using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Staff1Id",
                schema: "training",
                table: "CourseSchedule",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Staff2Id",
                schema: "training",
                table: "CourseSchedule",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Staff3Id",
                schema: "training",
                table: "CourseSchedule",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Staff1Id",
                schema: "training",
                table: "BatchSchedule",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Staff2Id",
                schema: "training",
                table: "BatchSchedule",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Staff3Id",
                schema: "training",
                table: "BatchSchedule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff1Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff2Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff3Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff3Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff1Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff2Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff3Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchSchedule_User_Staff1Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff1Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchSchedule_User_Staff2Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff2Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchSchedule_User_Staff3Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff3Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedule_User_Staff1Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff1Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedule_User_Staff2Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff2Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedule_User_Staff3Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff3Id",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchSchedule_User_Staff1Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchSchedule_User_Staff2Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchSchedule_User_Staff3Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedule_User_Staff1Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedule_User_Staff2Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedule_User_Staff3Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropIndex(
                name: "IX_CourseSchedule_Staff1Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropIndex(
                name: "IX_CourseSchedule_Staff2Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropIndex(
                name: "IX_CourseSchedule_Staff3Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BatchSchedule_Staff1Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BatchSchedule_Staff2Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BatchSchedule_Staff3Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropColumn(
                name: "Staff1Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropColumn(
                name: "Staff2Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropColumn(
                name: "Staff3Id",
                schema: "training",
                table: "CourseSchedule");

            migrationBuilder.DropColumn(
                name: "Staff1Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropColumn(
                name: "Staff2Id",
                schema: "training",
                table: "BatchSchedule");

            migrationBuilder.DropColumn(
                name: "Staff3Id",
                schema: "training",
                table: "BatchSchedule");
        }
    }
}
