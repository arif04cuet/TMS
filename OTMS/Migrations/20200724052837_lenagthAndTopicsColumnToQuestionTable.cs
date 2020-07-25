using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class lenagthAndTopicsColumnToQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerLength",
                schema: "training",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TopicQuestion",
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
                    TopicId = table.Column<long>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicQuestion_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicQuestion_QuestionId",
                schema: "training",
                table: "TopicQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicQuestion_TopicId",
                schema: "training",
                table: "TopicQuestion",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicQuestion",
                schema: "training");

            migrationBuilder.DropColumn(
                name: "AnswerLength",
                schema: "training",
                table: "Question");
        }
    }
}
