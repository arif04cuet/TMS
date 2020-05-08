using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Office_LocationId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Supplier_SupplierId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Office_LocationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Supplier_SupplierId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Office_LocationId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Supplier_SupplierId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Office_LocationId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Supplier_SupplierId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Warrantly",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Consumable",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Consumable",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Consumable",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Available",
                schema: "asset",
                table: "Consumable",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Component",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "asset",
                table: "Component",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Component",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Component",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "AssetModel",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Warranty",
                schema: "asset",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Accessory",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "asset",
                table: "Accessory",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "PurchaseCost",
                schema: "asset",
                table: "Accessory",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Accessory",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Accessory",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Office_LocationId",
                schema: "asset",
                table: "Accessory",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Accessory",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Supplier_SupplierId",
                schema: "asset",
                table: "Accessory",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Office_LocationId",
                schema: "asset",
                table: "Asset",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Supplier_SupplierId",
                schema: "asset",
                table: "Asset",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Office_LocationId",
                schema: "asset",
                table: "Component",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Component",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Supplier_SupplierId",
                schema: "asset",
                table: "Component",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Office_LocationId",
                schema: "asset",
                table: "Consumable",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Consumable",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Supplier_SupplierId",
                schema: "asset",
                table: "Consumable",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Office_LocationId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Supplier_SupplierId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Office_LocationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Supplier_SupplierId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Office_LocationId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Supplier_SupplierId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Office_LocationId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Supplier_SupplierId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Available",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Warranty",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Consumable",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Consumable",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Consumable",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Component",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "asset",
                table: "Component",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Component",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Component",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "AssetModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Asset",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Asset",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Warrantly",
                schema: "asset",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                schema: "asset",
                table: "Accessory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "asset",
                table: "Accessory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchaseCost",
                schema: "asset",
                table: "Accessory",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "Accessory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                schema: "asset",
                table: "Accessory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Office_LocationId",
                schema: "asset",
                table: "Accessory",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Accessory",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Supplier_SupplierId",
                schema: "asset",
                table: "Accessory",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Office_LocationId",
                schema: "asset",
                table: "Asset",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Supplier_SupplierId",
                schema: "asset",
                table: "Asset",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Office_LocationId",
                schema: "asset",
                table: "Component",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Component",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Supplier_SupplierId",
                schema: "asset",
                table: "Component",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Office_LocationId",
                schema: "asset",
                table: "Consumable",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "Consumable",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Supplier_SupplierId",
                schema: "asset",
                table: "Consumable",
                column: "SupplierId",
                principalSchema: "asset",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
