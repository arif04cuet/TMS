using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDepreciationSchedule_AssetDepreciation_AssetDepreciationId",
                schema: "asset",
                table: "AssetDepreciationSchedule");

            migrationBuilder.DropTable(
                name: "AssetDepreciation",
                schema: "asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "EOL",
                schema: "asset",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasDepreciated",
                schema: "asset",
                table: "Asset",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDepreciateDate",
                schema: "asset",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetDepreciationRevision",
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
                    AssetId = table.Column<long>(nullable: true),
                    EOL = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    RatePerFrequency = table.Column<float>(nullable: false),
                    ValuePerFrequency = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDepreciationRevision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetDepreciationRevision_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserForgotPasswordToken",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForgotPasswordToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserForgotPasswordToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciationRevision_AssetId",
                schema: "asset",
                table: "AssetDepreciationRevision",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForgotPasswordToken_UserId",
                schema: "core",
                table: "UserForgotPasswordToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDepreciationSchedule_AssetDepreciationRevision_AssetDepreciationId",
                schema: "asset",
                table: "AssetDepreciationSchedule",
                column: "AssetDepreciationId",
                principalSchema: "asset",
                principalTable: "AssetDepreciationRevision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetDepreciationSchedule_AssetDepreciationRevision_AssetDepreciationId",
                schema: "asset",
                table: "AssetDepreciationSchedule");

            migrationBuilder.DropTable(
                name: "AssetDepreciationRevision",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "UserForgotPasswordToken",
                schema: "core");

            migrationBuilder.DropColumn(
                name: "EOL",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "HasDepreciated",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "NextDepreciateDate",
                schema: "asset",
                table: "Asset");

            migrationBuilder.AddColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "Asset",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetDepreciation",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NextDepreciateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatePerFrequency = table.Column<float>(type: "real", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ValuePerFrequency = table.Column<float>(type: "real", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDepreciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetDepreciation_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_DepreciationId",
                schema: "asset",
                table: "Asset",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciation_AssetId",
                schema: "asset",
                table: "AssetDepreciation",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                schema: "asset",
                table: "Asset",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDepreciationSchedule_AssetDepreciation_AssetDepreciationId",
                schema: "asset",
                table: "AssetDepreciationSchedule",
                column: "AssetDepreciationId",
                principalSchema: "asset",
                principalTable: "AssetDepreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
