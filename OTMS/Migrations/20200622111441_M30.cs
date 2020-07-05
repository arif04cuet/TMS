using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionProgress",
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
                    TopicId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    SheetGenerated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionProgress_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionProgress_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionProgress_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_BatchScheduleId",
                schema: "training",
                table: "SessionProgress",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_CourseModuleId",
                schema: "training",
                table: "SessionProgress",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_TopicId",
                schema: "training",
                table: "SessionProgress",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionProgress",
                schema: "training");
        }
    }
}
