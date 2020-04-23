using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IssuedToId",
                table: "BookItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReservedForId",
                table: "BookItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_IssuedToId",
                table: "BookItem",
                column: "IssuedToId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_ReservedForId",
                table: "BookItem",
                column: "ReservedForId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItem_User_IssuedToId",
                table: "BookItem",
                column: "IssuedToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookItem_User_ReservedForId",
                table: "BookItem",
                column: "ReservedForId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_User_IssuedToId",
                table: "BookItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_User_ReservedForId",
                table: "BookItem");

            migrationBuilder.DropIndex(
                name: "IX_BookItem_IssuedToId",
                table: "BookItem");

            migrationBuilder.DropIndex(
                name: "IX_BookItem_ReservedForId",
                table: "BookItem");

            migrationBuilder.DropColumn(
                name: "IssuedToId",
                table: "BookItem");

            migrationBuilder.DropColumn(
                name: "ReservedForId",
                table: "BookItem");
        }
    }
}
