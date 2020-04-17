using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "District",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "District",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "District",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "District",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "District",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "District",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "District",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 6L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 7L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 8L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 9L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 10L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 11L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 12L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 13L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 14L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 15L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 16L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 17L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 18L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 19L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 20L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 21L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 22L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 23L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 24L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 25L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 26L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 27L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 28L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 29L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 30L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 31L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 32L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 33L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 34L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 35L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 36L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 37L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 38L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 39L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 40L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 41L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 42L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 43L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 44L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 45L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 46L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 47L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 48L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 49L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 50L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 51L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 52L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 53L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 54L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 55L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 56L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 57L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 58L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 59L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 60L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 61L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 62L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 63L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 64L,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "District");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "District");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "District");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "District");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "District");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "District");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "District");
        }
    }
}
