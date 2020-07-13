using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseModule_Course",
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
                    CourseId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModule_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModule_Course_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModule_Course_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_Course_CourseId",
                schema: "training",
                table: "CourseModule_Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_Course_CourseModuleId",
                schema: "training",
                table: "CourseModule_Course",
                column: "CourseModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseModule_Course",
                schema: "training");
        }
    }
}
