using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAudit_AssetModel_AssetId",
                schema: "asset",
                table: "AssetAudit");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMaintenance_AssetModel_AssetId",
                schema: "asset",
                table: "AssetMaintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_AssetModel_AssetModelId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropIndex(
                name: "IX_AssetModel_AssetModelId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropColumn(
                name: "AssetModelId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                schema: "asset",
                table: "AssetMaintenance",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "AssetTag",
                schema: "asset",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAudit_Asset_AssetId",
                schema: "asset",
                table: "AssetAudit",
                column: "AssetId",
                principalSchema: "asset",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMaintenance_Asset_AssetId",
                schema: "asset",
                table: "AssetMaintenance",
                column: "AssetId",
                principalSchema: "asset",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAudit_Asset_AssetId",
                schema: "asset",
                table: "AssetAudit");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMaintenance_Asset_AssetId",
                schema: "asset",
                table: "AssetMaintenance");

            migrationBuilder.DropColumn(
                name: "AssetTag",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AddColumn<long>(
                name: "AssetModelId",
                schema: "asset",
                table: "AssetModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                schema: "asset",
                table: "AssetMaintenance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_AssetModelId",
                schema: "asset",
                table: "AssetModel",
                column: "AssetModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAudit_AssetModel_AssetId",
                schema: "asset",
                table: "AssetAudit",
                column: "AssetId",
                principalSchema: "asset",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMaintenance_AssetModel_AssetId",
                schema: "asset",
                table: "AssetMaintenance",
                column: "AssetId",
                principalSchema: "asset",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_AssetModel_AssetModelId",
                schema: "asset",
                table: "AssetModel",
                column: "AssetModelId",
                principalSchema: "asset",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
