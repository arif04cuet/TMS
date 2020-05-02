using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_MemberLibraryCard_MemberLibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropTable(
                name: "MemberLibraryCard",
                schema: "library");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_MemberLibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "MemberLibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.AddColumn<long>(
                name: "CurrentCardId",
                schema: "library",
                table: "LibraryMember",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "library",
                table: "LibraryCard",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "library",
                table: "LibraryCard",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CardStatusId",
                schema: "library",
                table: "LibraryCard",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MemberId",
                schema: "library",
                table: "LibraryCard",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryCardId",
                schema: "library",
                table: "BookIssue",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_CurrentCardId",
                schema: "library",
                table: "LibraryMember",
                column: "CurrentCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_CardStatusId",
                schema: "library",
                table: "LibraryCard",
                column: "CardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_MemberId",
                schema: "library",
                table: "LibraryCard",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_LibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_LibraryCard_LibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryCardId",
                principalSchema: "library",
                principalTable: "LibraryCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCard_LibraryCardStatus_CardStatusId",
                schema: "library",
                table: "LibraryCard",
                column: "CardStatusId",
                principalSchema: "library",
                principalTable: "LibraryCardStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCard_User_MemberId",
                schema: "library",
                table: "LibraryCard",
                column: "MemberId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMember_LibraryCard_CurrentCardId",
                schema: "library",
                table: "LibraryMember",
                column: "CurrentCardId",
                principalSchema: "library",
                principalTable: "LibraryCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_LibraryCard_LibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCard_LibraryCardStatus_CardStatusId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCard_User_MemberId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMember_LibraryCard_CurrentCardId",
                schema: "library",
                table: "LibraryMember");

            migrationBuilder.DropIndex(
                name: "IX_LibraryMember_CurrentCardId",
                schema: "library",
                table: "LibraryMember");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCard_CardStatusId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCard_MemberId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_LibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropColumn(
                name: "CurrentCardId",
                schema: "library",
                table: "LibraryMember");

            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "CardStatusId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "MemberId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "LibraryCardId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "library",
                table: "LibraryCard",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "library",
                table: "LibraryCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MemberLibraryCardId",
                schema: "library",
                table: "BookIssue",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberLibraryCard",
                schema: "library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardStatusId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LibraryCardId = table.Column<long>(type: "bigint", nullable: false),
                    LibraryId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLibraryCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_LibraryCardStatus_CardStatusId",
                        column: x => x.CardStatusId,
                        principalSchema: "library",
                        principalTable: "LibraryCardStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_LibraryCard_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalSchema: "library",
                        principalTable: "LibraryCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_MemberLibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "MemberLibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_CardStatusId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "CardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_LibraryCardId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_LibraryId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_UserId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_MemberLibraryCard_MemberLibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "MemberLibraryCardId",
                principalSchema: "library",
                principalTable: "MemberLibraryCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
