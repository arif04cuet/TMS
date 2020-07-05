using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mark",
                schema: "training",
                table: "CourseEvaluationMethod",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TotalMark",
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
                    BatchScheduleId = table.Column<long>(nullable: false),
                    EvaluationMethodId = table.Column<long>(nullable: true),
                    ParticipantId = table.Column<long>(nullable: true),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalMark_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalMark_CourseEvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "CourseEvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TotalMark_BatchScheduleAllocation_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "training",
                        principalTable: "BatchScheduleAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_BatchScheduleId",
                schema: "training",
                table: "TotalMark",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_EvaluationMethodId",
                schema: "training",
                table: "TotalMark",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_ParticipantId",
                schema: "training",
                table: "TotalMark",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalMark",
                schema: "training");

            migrationBuilder.DropColumn(
                name: "Mark",
                schema: "training",
                table: "CourseEvaluationMethod");
        }
    }
}
