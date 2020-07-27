using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExamId",
                schema: "training",
                table: "ExamAnswer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswer_ExamId",
                schema: "training",
                table: "ExamAnswer",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamAnswer_Exam_ExamId",
                schema: "training",
                table: "ExamAnswer",
                column: "ExamId",
                principalSchema: "training",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamAnswer_Exam_ExamId",
                schema: "training",
                table: "ExamAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ExamAnswer_ExamId",
                schema: "training",
                table: "ExamAnswer");

            migrationBuilder.DropColumn(
                name: "ExamId",
                schema: "training",
                table: "ExamAnswer");
        }
    }
}
