using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 206L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 306L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 406L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 606L);

            migrationBuilder.DropColumn(
                name: "HasEBook",
                table: "BookEdition");

            migrationBuilder.CreateTable(
                name: "LibraryCardType",
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
                    table.PrimaryKey("PK_LibraryCardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryMember",
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
                    LibraryId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    MemberSince = table.Column<DateTime>(nullable: false),
                    TotalBooksCheckout = table.Column<long>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryMember_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryMember_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_CardTypeId",
                table: "LibraryCard",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_LibraryId",
                table: "LibraryMember",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_UserId",
                table: "LibraryMember",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCard_LibraryCardType_CardTypeId",
                table: "LibraryCard",
                column: "CardTypeId",
                principalTable: "LibraryCardType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCard_LibraryCardType_CardTypeId",
                table: "LibraryCard");

            migrationBuilder.DropTable(
                name: "LibraryCardType");

            migrationBuilder.DropTable(
                name: "LibraryMember");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCard_CardTypeId",
                table: "LibraryCard");

            migrationBuilder.AddColumn<bool>(
                name: "HasEBook",
                table: "BookEdition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LibraryId = table.Column<long>(type: "bigint", nullable: false),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBooksCheckout = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 106L, "user.filter", null, 1L, 1L, "Filter" },
                    { 206L, "role.filter", null, 2L, 1L, "Filter" },
                    { 306L, "designation.filter", null, 3L, 1L, "Filter" },
                    { 406L, "department.filter", null, 4L, 1L, "Filter" },
                    { 606L, "book.filter", null, 6L, 2L, "Filter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_LibraryId",
                table: "Member",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId");
        }
    }
}
