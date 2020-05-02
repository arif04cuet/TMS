using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                schema: "library",
                table: "BookItem",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
