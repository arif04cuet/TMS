using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class addCategoryToContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "cms",
                table: "Content",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryId",
                schema: "cms",
                table: "Content",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Category_CategoryId",
                schema: "cms",
                table: "Content",
                column: "CategoryId",
                principalSchema: "cms",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Category_CategoryId",
                schema: "cms",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_CategoryId",
                schema: "cms",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "cms",
                table: "Content");
        }
    }
}
