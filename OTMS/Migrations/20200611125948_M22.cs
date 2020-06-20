using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HonorariumHead_User_HonorariumForId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropIndex(
                name: "IX_HonorariumHead_HonorariumForId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "HonorariumForId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                schema: "training",
                table: "HonorariumHead",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "DesignationId",
                schema: "training",
                table: "HonorariumHead",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                schema: "training",
                table: "HonorariumHead",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HonorariumId",
                schema: "training",
                table: "HonorariumHead",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                schema: "training",
                table: "CourseScheduleEligible",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Honorarium",
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
                    HonorariumFor = table.Column<byte>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honorarium", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_DesignationId",
                schema: "training",
                table: "HonorariumHead",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_HonorariumId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumId");

            migrationBuilder.AddForeignKey(
                name: "FK_HonorariumHead_Designation_DesignationId",
                schema: "training",
                table: "HonorariumHead",
                column: "DesignationId",
                principalSchema: "core",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HonorariumHead_Honorarium_HonorariumId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumId",
                principalSchema: "training",
                principalTable: "Honorarium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HonorariumHead_Designation_DesignationId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropForeignKey(
                name: "FK_HonorariumHead_Honorarium_HonorariumId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropTable(
                name: "Honorarium",
                schema: "training");

            migrationBuilder.DropIndex(
                name: "IX_HonorariumHead_DesignationId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropIndex(
                name: "IX_HonorariumHead_HonorariumId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "Head",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "HonorariumId",
                schema: "training",
                table: "HonorariumHead");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "training",
                table: "CourseScheduleEligible");

            migrationBuilder.AddColumn<long>(
                name: "HonorariumForId",
                schema: "training",
                table: "HonorariumHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "training",
                table: "HonorariumHead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_HonorariumForId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumForId");

            migrationBuilder.AddForeignKey(
                name: "FK_HonorariumHead_User_HonorariumForId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumForId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
