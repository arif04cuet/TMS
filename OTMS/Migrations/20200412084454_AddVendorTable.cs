using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class AddVendorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_Permission_PermissionId1",
                table: "UserPermission");

            migrationBuilder.DropTable(
                name: "Abcd");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_PermissionId1",
                table: "UserPermission");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 500L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 503L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 504L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 506L);

            migrationBuilder.DropColumn(
                name: "PermissionId1",
                table: "UserPermission");

            migrationBuilder.AlterColumn<long>(
                name: "PermissionId",
                table: "UserPermission",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Vendor",
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
                    VendorName = table.Column<string>(nullable: true),
                    VendorEmail = table.Column<string>(nullable: true),
                    AccountManagerName = table.Column<string>(nullable: true),
                    AccountManagerPhone = table.Column<string>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_StatusId",
                table: "Vendor",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_Permission_PermissionId",
                table: "UserPermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_Permission_PermissionId",
                table: "UserPermission");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_PermissionId",
                table: "UserPermission");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionId",
                table: "UserPermission",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PermissionId1",
                table: "UserPermission",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abcd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abcd", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 500L, "profile.create", null, 5L, 1L, "Create" },
                    { 504L, "profile.list", null, 5L, 1L, "List" },
                    { 503L, "profile.delete", null, 5L, 1L, "Delete" },
                    { 506L, "profile.filter", null, 5L, 1L, "Filter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId1",
                table: "UserPermission",
                column: "PermissionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_Permission_PermissionId1",
                table: "UserPermission",
                column: "PermissionId1",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
