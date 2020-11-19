using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class makeManufacturerFieldNullableForAssetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "AssetModel",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "AssetModel",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.AlterColumn<long>(
                name: "ManufacturerId",
                schema: "asset",
                table: "AssetModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Manufacturer_ManufacturerId",
                schema: "asset",
                table: "AssetModel",
                column: "ManufacturerId",
                principalSchema: "asset",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
