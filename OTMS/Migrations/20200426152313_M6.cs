using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_BookItemId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.AddColumn<long>(
                name: "CurrentIssueId",
                schema: "library",
                table: "BookItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_CurrentIssueId",
                schema: "library",
                table: "BookItem",
                column: "CurrentIssueId",
                unique: true,
                filter: "[CurrentIssueId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItem_BookIssue_CurrentIssueId",
                schema: "library",
                table: "BookItem",
                column: "CurrentIssueId",
                principalSchema: "library",
                principalTable: "BookIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_BookIssue_CurrentIssueId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropIndex(
                name: "IX_BookItem_CurrentIssueId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropColumn(
                name: "CurrentIssueId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_BookItemId",
                schema: "library",
                table: "BookIssue",
                column: "BookItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                schema: "library",
                table: "BookIssue",
                column: "BookItemId",
                principalSchema: "library",
                principalTable: "BookItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
