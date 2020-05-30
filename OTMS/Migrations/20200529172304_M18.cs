using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Maintenance",
                schema: "asset",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Asset_DepreciationId",
                schema: "asset",
                table: "Asset",
                column: "DepreciationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                schema: "asset",
                table: "Asset",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "DepreciationId",
                schema: "asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Maintenance",
                schema: "asset",
                table: "Asset");
        }
    }
}
