using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "UserProfile",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "OfficeAddressId",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FullName", "StatusId" },
                values: new object[] { "Administrator", 3L });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_OfficeAddressId",
                table: "UserProfile",
                column: "OfficeAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Address_OfficeAddressId",
                table: "UserProfile",
                column: "OfficeAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Address_OfficeAddressId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_OfficeAddressId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "OfficeAddressId",
                table: "UserProfile");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "UserProfile",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FullName", "StatusId" },
                values: new object[] { null, null });
        }
    }
}
