using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class removeUserFromBookReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_User_ReservationById",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReservationById",
                schema: "library",
                table: "BookReservation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_ReservationById",
                schema: "library",
                table: "BookReservation",
                column: "ReservationById");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservation_User_ReservationById",
                schema: "library",
                table: "BookReservation",
                column: "ReservationById",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
