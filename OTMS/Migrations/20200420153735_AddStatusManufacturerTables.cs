using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class AddStatusManufacturerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Status",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
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
                    Url = table.Column<string>(nullable: true),
                    SupportUrl = table.Column<string>(nullable: true),
                    SupportPhone = table.Column<string>(nullable: true),
                    SupportEmail = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status1",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Status1",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Pending", null, null, 0L },
                    { 2L, null, null, true, false, "Approved", null, null, 0L },
                    { 3L, null, null, true, false, "Active", null, null, 0L },
                    { 4L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_MediaId",
                table: "Manufacturer",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status1_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Status1_StatusId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Status1");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Status");

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Pending", null, null, 0L },
                    { 2L, null, null, true, false, "Approved", null, null, 0L },
                    { 3L, null, null, true, false, "Active", null, null, 0L },
                    { 4L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
