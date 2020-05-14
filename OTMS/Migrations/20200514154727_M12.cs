using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Category_CategoryId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropIndex(
                name: "IX_Consumable_CategoryId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.AddColumn<int>(
                name: "Available",
                schema: "asset",
                table: "ItemCode",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                schema: "asset",
                table: "ItemCode",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemCodeId",
                schema: "asset",
                table: "Consumable",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_ItemCodeId",
                schema: "asset",
                table: "Consumable",
                column: "ItemCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_ItemCode_ItemCodeId",
                schema: "asset",
                table: "Consumable",
                column: "ItemCodeId",
                principalSchema: "asset",
                principalTable: "ItemCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_ItemCode_ItemCodeId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropIndex(
                name: "IX_Consumable_ItemCodeId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Available",
                schema: "asset",
                table: "ItemCode");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                schema: "asset",
                table: "ItemCode");

            migrationBuilder.DropColumn(
                name: "ItemCodeId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "asset",
                table: "Consumable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_CategoryId",
                schema: "asset",
                table: "Consumable",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Category_CategoryId",
                schema: "asset",
                table: "Consumable",
                column: "CategoryId",
                principalSchema: "asset",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
