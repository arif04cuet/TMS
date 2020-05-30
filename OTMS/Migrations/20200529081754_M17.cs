using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fees",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "library",
                table: "Fine");

            migrationBuilder.AddColumn<float>(
                name: "CardFee",
                schema: "library",
                table: "LibraryCard",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LateFee",
                schema: "library",
                table: "LibraryCard",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LateFineAmount",
                schema: "library",
                table: "Fine",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LostFineAmount",
                schema: "library",
                table: "Fine",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalAmount",
                schema: "library",
                table: "Fine",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                schema: "asset",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardFee",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "LateFee",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "LateFineAmount",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "LostFineAmount",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AddColumn<float>(
                name: "Fees",
                schema: "library",
                table: "LibraryCard",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                schema: "library",
                table: "Fine",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
