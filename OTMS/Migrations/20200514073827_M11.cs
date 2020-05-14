using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "asset",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "MinQuantity",
                schema: "asset",
                table: "ItemCode",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                schema: "asset",
                table: "Category",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "asset",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EULA", "IsActive", "IsDeleted", "IsRequireUserConfirmation", "IsSendEmail", "MediaId", "Name", "ParentId", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 1L, null, null, null, true, false, false, false, null, "Asset", null, null, null, 0L });

            migrationBuilder.InsertData(
                schema: "asset",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EULA", "IsActive", "IsDeleted", "IsRequireUserConfirmation", "IsSendEmail", "MediaId", "Name", "ParentId", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 2L, null, null, null, true, false, false, false, null, "Consumable", null, null, null, 0L });

            migrationBuilder.InsertData(
                schema: "asset",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EULA", "IsActive", "IsDeleted", "IsRequireUserConfirmation", "IsSendEmail", "MediaId", "Name", "ParentId", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 3L, null, null, null, true, false, false, false, null, "License", null, null, null, 0L });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "asset",
                table: "Category",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                schema: "asset",
                table: "Category",
                column: "ParentId",
                principalSchema: "asset",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                schema: "asset",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentId",
                schema: "asset",
                table: "Category");

            migrationBuilder.DeleteData(
                schema: "asset",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "asset",
                table: "Category",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "asset",
                table: "Category",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "asset",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "MinQuantity",
                schema: "asset",
                table: "ItemCode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "asset",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
