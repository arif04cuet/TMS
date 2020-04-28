using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class AddOfficeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Address_LocationId",
                schema: "asset",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Address_LocationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Address_LocationId",
                schema: "asset",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Address_LocationId",
                schema: "asset",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_License_Address_LocationId",
                schema: "asset",
                table: "License");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "core",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                schema: "core",
                table: "Address");

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

            migrationBuilder.CreateTable(
                name: "Office",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Version = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OfficeName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    UpazilaId = table.Column<long>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "core",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "core",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Upazila_UpazilaId",
                        column: x => x.UpazilaId,
                        principalSchema: "core",
                        principalTable: "Upazila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Office_DistrictId",
                schema: "core",
                table: "Office",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_DivisionId",
                schema: "core",
                table: "Office",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_UpazilaId",
                schema: "core",
                table: "Office",
                column: "UpazilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Office_LocationId",
                table: "Accessory",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Office_LocationId",
                table: "Asset",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Office_LocationId",
                table: "Component",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Office_LocationId",
                table: "Consumable",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_License_Office_LocationId",
                table: "License",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessory_Office_LocationId",
                table: "Accessory");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Office_LocationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Office_LocationId",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_Office_LocationId",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_License_Office_LocationId",
                table: "License");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "core");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "core",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                schema: "core",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessory_Address_LocationId",
                schema: "asset",
                table: "Accessory",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Address_LocationId",
                schema: "asset",
                table: "Asset",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Address_LocationId",
                schema: "asset",
                table: "Component",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_Address_LocationId",
                schema: "asset",
                table: "Consumable",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_License_Address_LocationId",
                schema: "asset",
                table: "License",
                column: "LocationId",
                principalSchema: "core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
