using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetCheckout",
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
                    AssetId = table.Column<long>(nullable: false),
                    ChekoutToUserId = table.Column<long>(nullable: true),
                    ChekoutToLocationId = table.Column<long>(nullable: true),
                    CheckoutDate = table.Column<DateTime>(nullable: true),
                    ExpectedChekinDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCheckout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCheckout_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckout_Office_ChekoutToLocationId",
                        column: x => x.ChekoutToLocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCheckout_User_ChekoutToUserId",
                        column: x => x.ChekoutToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_AssetId",
                schema: "asset",
                table: "AssetCheckout",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_ChekoutToLocationId",
                schema: "asset",
                table: "AssetCheckout",
                column: "ChekoutToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_ChekoutToUserId",
                schema: "asset",
                table: "AssetCheckout",
                column: "ChekoutToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetCheckout",
                schema: "asset");
        }
    }
}
