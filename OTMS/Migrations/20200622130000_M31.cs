using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                schema: "training",
                table: "RoutinePeriod",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "SessionCompleted",
                schema: "training",
                table: "RoutinePeriod",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                schema: "training",
                table: "RoutinePeriod",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.DropColumn(
                name: "SessionCompleted",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "training",
                table: "RoutinePeriod");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "training",
                table: "RoutinePeriod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "training",
                table: "RoutinePeriod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
