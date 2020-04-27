using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class AssetTablesPrefixAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "LicenseSeat",
                newName: "LicenseSeat",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "License",
                newName: "License",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "ConsumableUser",
                newName: "ConsumableUser",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Consumable",
                newName: "Consumable",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "ComponentAsset",
                newName: "ComponentAsset",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "Component",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "AssetModel",
                newName: "AssetModel",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "AssetMaintenance",
                newName: "AssetMaintenance",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "AssetAudit",
                newName: "AssetAudit",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Asset",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "AccessoryUser",
                newName: "AccessoryUser",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Accessory",
                newName: "Accessory",
                newSchema: "asset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "LicenseSeat",
                schema: "asset",
                newName: "LicenseSeat");

            migrationBuilder.RenameTable(
                name: "License",
                schema: "asset",
                newName: "License");

            migrationBuilder.RenameTable(
                name: "ConsumableUser",
                schema: "asset",
                newName: "ConsumableUser");

            migrationBuilder.RenameTable(
                name: "Consumable",
                schema: "asset",
                newName: "Consumable");

            migrationBuilder.RenameTable(
                name: "ComponentAsset",
                schema: "asset",
                newName: "ComponentAsset");

            migrationBuilder.RenameTable(
                name: "Component",
                schema: "asset",
                newName: "Component");

            migrationBuilder.RenameTable(
                name: "AssetModel",
                schema: "asset",
                newName: "AssetModel");

            migrationBuilder.RenameTable(
                name: "AssetMaintenance",
                schema: "asset",
                newName: "AssetMaintenance");

            migrationBuilder.RenameTable(
                name: "AssetAudit",
                schema: "asset",
                newName: "AssetAudit");

            migrationBuilder.RenameTable(
                name: "Asset",
                schema: "asset",
                newName: "Asset");

            migrationBuilder.RenameTable(
                name: "AccessoryUser",
                schema: "asset",
                newName: "AccessoryUser");

            migrationBuilder.RenameTable(
                name: "Accessory",
                schema: "asset",
                newName: "Accessory");
        }
    }
}
