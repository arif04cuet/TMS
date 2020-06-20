using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRoutine",
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
                    BatchScheduleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoutineModule",
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
                    ClassRoutineId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoutineModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoutineModule_ClassRoutine_ClassRoutineId",
                        column: x => x.ClassRoutineId,
                        principalSchema: "training",
                        principalTable: "ClassRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoutineModule_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleRoutine",
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
                    ModuleId = table.Column<long>(nullable: false),
                    TrainingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleRoutine_ClassRoutineModule_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "training",
                        principalTable: "ClassRoutineModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutinePeriod",
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
                    RoutineId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: true),
                    TrainingDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ResourcePersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutinePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_ResourcePerson_ResourcePersonId",
                        column: x => x.ResourcePersonId,
                        principalSchema: "training",
                        principalTable: "ResourcePerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_ModuleRoutine_RoutineId",
                        column: x => x.RoutineId,
                        principalSchema: "training",
                        principalTable: "ModuleRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_CourseModuleTopic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "CourseModuleTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_BatchScheduleId",
                schema: "training",
                table: "ClassRoutine",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutineModule_ClassRoutineId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "ClassRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutineModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRoutine_ModuleId",
                schema: "training",
                table: "ModuleRoutine",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_ResourcePersonId",
                schema: "training",
                table: "RoutinePeriod",
                column: "ResourcePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_RoutineId",
                schema: "training",
                table: "RoutinePeriod",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_TopicId",
                schema: "training",
                table: "RoutinePeriod",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutinePeriod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ModuleRoutine",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ClassRoutineModule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ClassRoutine",
                schema: "training");
        }
    }
}
