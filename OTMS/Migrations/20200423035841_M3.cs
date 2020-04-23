using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                table: "BookIssue");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_BookItemId",
                table: "BookIssue");

            migrationBuilder.AlterColumn<long>(
                name: "BookItemId",
                table: "BookIssue",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_BookItemId",
                table: "BookIssue",
                column: "BookItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                table: "BookIssue",
                column: "BookItemId",
                principalTable: "BookItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                table: "BookIssue");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_BookItemId",
                table: "BookIssue");

            migrationBuilder.AlterColumn<long>(
                name: "BookItemId",
                table: "BookIssue",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_BookItemId",
                table: "BookIssue",
                column: "BookItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_BookItem_BookItemId",
                table: "BookIssue",
                column: "BookItemId",
                principalTable: "BookItem",
                principalColumn: "Id");
        }
    }
}
