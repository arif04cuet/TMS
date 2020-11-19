using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class makeDepriciationFieldNullableForLicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Depreciation_DepreciationId",
                schema: "asset",
                table: "License");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "License",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Depreciation_DepreciationId",
                schema: "asset",
                table: "License",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Depreciation_DepreciationId",
                schema: "asset",
                table: "License");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "License",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_License_Depreciation_DepreciationId",
                schema: "asset",
                table: "License",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
