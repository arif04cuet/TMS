using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMemberRequest_User_UserId",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSchedule",
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
                    CourseId = table.Column<long>(nullable: false),
                    CoordinatorId = table.Column<long>(nullable: true),
                    CoCoordinatorId = table.Column<long>(nullable: true),
                    TotalSeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_CoCoordinatorId",
                        column: x => x.CoCoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HonorariumHead",
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
                    HonorariumForId = table.Column<long>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HonorariumHead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HonorariumHead_User_HonorariumForId",
                        column: x => x.HonorariumForId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
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
                    Title = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatchSchedule",
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
                    CourseScheduleId = table.Column<long>(nullable: false),
                    CoordinatorId = table.Column<long>(nullable: true),
                    CoCoordinatorId = table.Column<long>(nullable: true),
                    TotalSeat = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_CoCoordinatorId",
                        column: x => x.CoCoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_CourseSchedule_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalSchema: "training",
                        principalTable: "CourseSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseScheduleEligible",
                schema: "training",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseScheduleId = table.Column<long>(nullable: false),
                    DesignationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseScheduleEligible", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseScheduleEligible_CourseSchedule_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalSchema: "training",
                        principalTable: "CourseSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseScheduleEligible_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "core",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOption",
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
                    Option = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CoCoordinatorId",
                schema: "training",
                table: "BatchSchedule",
                column: "CoCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CoordinatorId",
                schema: "training",
                table: "BatchSchedule",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CourseScheduleId",
                schema: "training",
                table: "BatchSchedule",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CoCoordinatorId",
                schema: "training",
                table: "CourseSchedule",
                column: "CoCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CoordinatorId",
                schema: "training",
                table: "CourseSchedule",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CourseId",
                schema: "training",
                table: "CourseSchedule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleEligible_CourseScheduleId",
                schema: "training",
                table: "CourseScheduleEligible",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleEligible_DesignationId",
                schema: "training",
                table: "CourseScheduleEligible",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_HonorariumForId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumForId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOption_QuestionId",
                schema: "training",
                table: "QuestionOption",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMemberRequest_User_UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMemberRequest_User_UserId",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropTable(
                name: "BatchSchedule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseScheduleEligible",
                schema: "training");

            migrationBuilder.DropTable(
                name: "HonorariumHead",
                schema: "training");

            migrationBuilder.DropTable(
                name: "QuestionOption",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseSchedule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "training");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMemberRequest_User_UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
