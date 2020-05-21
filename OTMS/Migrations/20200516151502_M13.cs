using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                schema: "library",
                table: "LibraryMember",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "LibraryMemberRequest",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMemberRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryMemberRequest_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryMemberRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMemberRequest_LibraryId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMemberRequest_UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryMemberRequest",
                schema: "library");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                schema: "library",
                table: "LibraryMember",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
