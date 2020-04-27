using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class RemoveVendorLocationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "asset");

            migrationBuilder.CreateTable(
                name: "Accessory",
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
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Address_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessory_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetModel",
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
                    Name = table.Column<string>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    Eol = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    DepreciationId = table.Column<long>(nullable: false),
                    IsRequestable = table.Column<bool>(nullable: false),
                    MediaId = table.Column<long>(nullable: true),
                    AssetModelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetModel_AssetModel_AssetModelId",
                        column: x => x.AssetModelId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetModel_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Depreciation_DepreciationId",
                        column: x => x.DepreciationId,
                        principalSchema: "asset",
                        principalTable: "Depreciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Component",
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
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_Address_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Component_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumable",
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
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumable_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Address_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "License",
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
                    Name = table.Column<string>(nullable: true),
                    ProductKey = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    LicenseToName = table.Column<string>(nullable: true),
                    LicenseToEmail = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    DepreciationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Depreciation_DepreciationId",
                        column: x => x.DepreciationId,
                        principalSchema: "asset",
                        principalTable: "Depreciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Address_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryUser",
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
                    AccessoryId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoryUser_Accessory_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryUser_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
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
                    Barcode = table.Column<string>(nullable: true),
                    AssetModelId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    ItemNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<long>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Warrantly = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsRequestable = table.Column<bool>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetModel_AssetModelId",
                        column: x => x.AssetModelId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Address_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "asset",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetAudit",
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
                    AssetId = table.Column<long>(nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    NextAuditDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAudit_AssetModel_AssetId",
                        column: x => x.AssetId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintenance",
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
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    AssetId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: false),
                    IsWarrantyImprovement = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_AssetModel_AssetId",
                        column: x => x.AssetId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentAsset",
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
                    ComponentId = table.Column<long>(nullable: false),
                    IssuedToAssetId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentAsset_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentAsset_AssetModel_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableUser",
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
                    ConsumableId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableUser_Consumable_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumableUser_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseSeat",
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
                    Name = table.Column<string>(nullable: true),
                    LicenseId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssuedToAssetId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_AssetModel_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_CategoryId",
                table: "Accessory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_LocationId",
                table: "Accessory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_ManufacturerId",
                table: "Accessory",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_MediaId",
                table: "Accessory",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_SupplierId",
                table: "Accessory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryUser_AccessoryId",
                table: "AccessoryUser",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryUser_IssuedToUserId",
                table: "AccessoryUser",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetModelId",
                table: "Asset",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationId",
                table: "Asset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_MediaId",
                table: "Asset",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_StatusId",
                table: "Asset",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_SupplierId",
                table: "Asset",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAudit_AssetId",
                table: "AssetAudit",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_AssetId",
                table: "AssetMaintenance",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_SupplierId",
                table: "AssetMaintenance",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_AssetModelId",
                table: "AssetModel",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_CategoryId",
                table: "AssetModel",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_DepreciationId",
                table: "AssetModel",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_ManufacturerId",
                table: "AssetModel",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_MediaId",
                table: "AssetModel",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_CategoryId",
                table: "Component",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_LocationId",
                table: "Component",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_ManufacturerId",
                table: "Component",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_MediaId",
                table: "Component",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_SupplierId",
                table: "Component",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentAsset_ComponentId",
                table: "ComponentAsset",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentAsset_IssuedToAssetId",
                table: "ComponentAsset",
                column: "IssuedToAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_CategoryId",
                table: "Consumable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_LocationId",
                table: "Consumable",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_ManufacturerId",
                table: "Consumable",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_MediaId",
                table: "Consumable",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_SupplierId",
                table: "Consumable",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableUser_ConsumableId",
                table: "ConsumableUser",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableUser_IssuedToUserId",
                table: "ConsumableUser",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_License_CategoryId",
                table: "License",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_License_DepreciationId",
                table: "License",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_License_LocationId",
                table: "License",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_License_ManufacturerId",
                table: "License",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_License_SupplierId",
                table: "License",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_IssuedToAssetId",
                table: "LicenseSeat",
                column: "IssuedToAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_IssuedToUserId",
                table: "LicenseSeat",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_LicenseId",
                table: "LicenseSeat",
                column: "LicenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryUser");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetAudit");

            migrationBuilder.DropTable(
                name: "AssetMaintenance");

            migrationBuilder.DropTable(
                name: "ComponentAsset");

            migrationBuilder.DropTable(
                name: "ConsumableUser");

            migrationBuilder.DropTable(
                name: "LicenseSeat");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Consumable");

            migrationBuilder.DropTable(
                name: "AssetModel");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    VendorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "asset",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_StatusId",
                schema: "asset",
                table: "Vendor",
                column: "StatusId");
        }
    }
}
