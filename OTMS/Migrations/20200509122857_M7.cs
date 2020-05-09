using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentAsset_AssetModel_IssuedToAssetId",
                schema: "asset",
                table: "ComponentAsset");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentAsset_Asset_IssuedToAssetId",
                schema: "asset",
                table: "ComponentAsset",
                column: "IssuedToAssetId",
                principalSchema: "asset",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentAsset_Asset_IssuedToAssetId",
                schema: "asset",
                table: "ComponentAsset");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentAsset_AssetModel_IssuedToAssetId",
                schema: "asset",
                table: "ComponentAsset",
                column: "IssuedToAssetId",
                principalSchema: "asset",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
