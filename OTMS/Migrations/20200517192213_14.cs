using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                schema: "asset",
                table: "Consumable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "asset",
                table: "CheckoutHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "asset",
                table: "CheckoutHistory");
        }
    }
}
