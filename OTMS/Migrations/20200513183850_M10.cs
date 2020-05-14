using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCheckout_Asset_AssetId",
                schema: "asset",
                table: "AssetCheckout");

            migrationBuilder.DropIndex(
                name: "IX_AssetCheckout_AssetId",
                schema: "asset",
                table: "AssetCheckout");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "asset",
                table: "AssetCheckout");

            migrationBuilder.AddColumn<long>(
                name: "ChekoutToAssetId",
                schema: "asset",
                table: "AssetCheckout",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CheckoutId",
                schema: "asset",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CheckoutId",
                schema: "asset",
                table: "Asset",
                column: "CheckoutId",
                unique: true,
                filter: "[CheckoutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_AssetCheckout_CheckoutId",
                schema: "asset",
                table: "Asset",
                column: "CheckoutId",
                principalSchema: "asset",
                principalTable: "AssetCheckout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_AssetCheckout_CheckoutId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_CheckoutId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ChekoutToAssetId",
                schema: "asset",
                table: "AssetCheckout");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "asset",
                table: "AssetCheckout",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_AssetId",
                schema: "asset",
                table: "AssetCheckout",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCheckout_Asset_AssetId",
                schema: "asset",
                table: "AssetCheckout",
                column: "AssetId",
                principalSchema: "asset",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
