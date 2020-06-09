using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Marks",
                schema: "training",
                table: "CourseModule",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InventoryEntryDate",
                schema: "asset",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                schema: "asset",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryEntryDate",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AlterColumn<string>(
                name: "Marks",
                schema: "training",
                table: "CourseModule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
