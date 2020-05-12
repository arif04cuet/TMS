using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Status_StatusId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseSeat_AssetModel_IssuedToAssetId",
                schema: "asset",
                table: "LicenseSeat");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "asset");

            migrationBuilder.CreateTable(
                name: "AssetStatus",
                schema: "asset",
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
                    Type = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_AssetStatus_StatusId",
                schema: "asset",
                table: "Asset",
                column: "StatusId",
                principalSchema: "asset",
                principalTable: "AssetStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseSeat_Asset_IssuedToAssetId",
                schema: "asset",
                table: "LicenseSeat",
                column: "IssuedToAssetId",
                principalSchema: "asset",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_AssetStatus_StatusId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseSeat_Asset_IssuedToAssetId",
                schema: "asset",
                table: "LicenseSeat");

            migrationBuilder.DropTable(
                name: "AssetStatus",
                schema: "asset");

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Status_StatusId",
                schema: "asset",
                table: "Asset",
                column: "StatusId",
                principalSchema: "asset",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseSeat_AssetModel_IssuedToAssetId",
                schema: "asset",
                table: "LicenseSeat",
                column: "IssuedToAssetId",
                principalSchema: "asset",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
