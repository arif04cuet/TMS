using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BatchScheduleAllocation",
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
                    CourseId = table.Column<long>(nullable: true),
                    TraineeId = table.Column<long>(nullable: false),
                    AppliedDate = table.Column<DateTime>(nullable: false),
                    AllocationDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchScheduleAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_User_TraineeId",
                        column: x => x.TraineeId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
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
                    Serial = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetItem",
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
                    BudgetId = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetItem_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalSchema: "training",
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson",
                column: "HonorariumHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_CourseId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_TraineeId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItem_BudgetId",
                schema: "training",
                table: "BudgetItem",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePerson_HonorariumHead_HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson",
                column: "HonorariumHeadId",
                principalSchema: "training",
                principalTable: "HonorariumHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePerson_HonorariumHead_HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropTable(
                name: "BatchScheduleAllocation",
                schema: "training");

            migrationBuilder.DropTable(
                name: "BudgetItem",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Budget",
                schema: "training");

            migrationBuilder.DropIndex(
                name: "IX_ResourcePerson_HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson");
        }
    }
}
