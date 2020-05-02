using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_Media_MediaId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropIndex(
                name: "IX_BookItem_MediaId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropColumn(
                name: "MediaId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                schema: "library",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_MediaId",
                schema: "library",
                table: "Book",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Media_MediaId",
                schema: "library",
                table: "Book",
                column: "MediaId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Media_MediaId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_MediaId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "MediaId",
                schema: "library",
                table: "Book");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                schema: "library",
                table: "BookItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_MediaId",
                schema: "library",
                table: "BookItem",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItem_Media_MediaId",
                schema: "library",
                table: "BookItem",
                column: "MediaId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
