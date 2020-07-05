using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamParticipant_User_ParticipantId",
                schema: "training",
                table: "ExamParticipant");

            migrationBuilder.AlterColumn<long>(
                name: "ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                schema: "training",
                table: "ExamParticipant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamParticipant_BatchScheduleAllocation_ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                column: "ParticipantId",
                principalSchema: "training",
                principalTable: "BatchScheduleAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamParticipant_BatchScheduleAllocation_ParticipantId",
                schema: "training",
                table: "ExamParticipant");

            migrationBuilder.DropColumn(
                name: "Mark",
                schema: "training",
                table: "ExamParticipant");

            migrationBuilder.AlterColumn<long>(
                name: "ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamParticipant_User_ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                column: "ParticipantId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
