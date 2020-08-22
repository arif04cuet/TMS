using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M53 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionHistoryItem_RequisitionItem_RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionHistoryItem_RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.DropColumn(
                name: "ChangedQuantity",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.DropColumn(
                name: "RequestQuantity",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.DropColumn(
                name: "RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "asset",
                table: "RequisitionHistoryItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "asset",
                table: "RequisitionHistoryItem");

            migrationBuilder.AddColumn<int>(
                name: "ChangedQuantity",
                schema: "asset",
                table: "RequisitionHistoryItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestQuantity",
                schema: "asset",
                table: "RequisitionHistoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistoryItem_RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                column: "RequisitionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionHistoryItem_RequisitionItem_RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                column: "RequisitionItemId",
                principalSchema: "asset",
                principalTable: "RequisitionItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
