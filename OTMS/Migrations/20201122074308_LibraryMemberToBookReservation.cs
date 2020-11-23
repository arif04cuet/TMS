using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class LibraryMemberToBookReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReservationById",
                schema: "library",
                table: "BookReservation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_ReservationById",
                schema: "library",
                table: "BookReservation",
                column: "ReservationById");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservation_LibraryMember_ReservationById",
                schema: "library",
                table: "BookReservation",
                column: "ReservationById",
                principalSchema: "library",
                principalTable: "LibraryMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_LibraryMember_ReservationById",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropIndex(
                name: "IX_BookReservation_ReservationById",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropColumn(
                name: "ReservationById",
                schema: "library",
                table: "BookReservation");
        }
    }
}
