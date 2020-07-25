using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class imageColumnToRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ImageId",
                schema: "training",
                table: "Room",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_ImageId",
                schema: "training",
                table: "Room",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Media_ImageId",
                schema: "training",
                table: "Room",
                column: "ImageId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Media_ImageId",
                schema: "training",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_ImageId",
                schema: "training",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "training",
                table: "Room");
        }
    }
}
