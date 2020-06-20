using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
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
                    Name = table.Column<string>(nullable: true),
                    BatchScheduleId = table.Column<long>(nullable: false),
                    EvaluationMethodId = table.Column<long>(nullable: false),
                    Mark = table.Column<int>(nullable: false),
                    TotalMinutes = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ExamDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_EvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamParticipant",
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
                    ExamId = table.Column<long>(nullable: false),
                    ParticipantId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamParticipant_Exam_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "training",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamParticipant_User_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
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
                    ExamId = table.Column<long>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exam_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "training",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_BatchScheduleId",
                schema: "training",
                table: "Exam",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_EvaluationMethodId",
                schema: "training",
                table: "Exam",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipant_ExamId",
                schema: "training",
                table: "ExamParticipant",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipant_ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamId",
                schema: "training",
                table: "ExamQuestion",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionId",
                schema: "training",
                table: "ExamQuestion",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamParticipant",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ExamQuestion",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Exam",
                schema: "training");
        }
    }
}
