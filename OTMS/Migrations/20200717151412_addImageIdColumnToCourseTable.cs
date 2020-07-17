using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class addImageIdColumnToCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ImageId",
                schema: "training",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_ImageId",
                schema: "training",
                table: "Course",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Media_ImageId",
                schema: "training",
                table: "Course",
                column: "ImageId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Media_ImageId",
                schema: "training",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ImageId",
                schema: "training",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "training",
                table: "Course");
        }
    }
}
