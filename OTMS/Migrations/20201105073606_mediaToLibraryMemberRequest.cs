using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class mediaToLibraryMemberRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                schema: "library",
                table: "LibraryMemberRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMemberRequest_MediaId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMemberRequest_Media_MediaId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "MediaId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMemberRequest_Media_MediaId",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropIndex(
                name: "IX_LibraryMemberRequest_MediaId",
                schema: "library",
                table: "LibraryMemberRequest");

            migrationBuilder.DropColumn(
                name: "MediaId",
                schema: "library",
                table: "LibraryMemberRequest");
        }
    }
}
