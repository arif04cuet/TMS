using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_District_DistrictId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_Division_DivisionId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropColumn(
                name: "Upazila",
                schema: "core",
                table: "Address");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "core",
                table: "Upazila",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "core",
                table: "Upazila",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "core",
                table: "Address",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "core",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpazilaId",
                schema: "core",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                schema: "core",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_DivisionId",
                schema: "core",
                table: "Address",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpazilaId",
                schema: "core",
                table: "Address",
                column: "UpazilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Division_DivisionId",
                schema: "core",
                table: "Address",
                column: "DivisionId",
                principalSchema: "core",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Upazila_UpazilaId",
                schema: "core",
                table: "Address",
                column: "UpazilaId",
                principalSchema: "core",
                principalTable: "Upazila",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Upazila_District_DistrictId",
                schema: "core",
                table: "Upazila",
                column: "DistrictId",
                principalSchema: "core",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Upazila_Division_DivisionId",
                schema: "core",
                table: "Upazila",
                column: "DivisionId",
                principalSchema: "core",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Division_DivisionId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Upazila_UpazilaId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_District_DistrictId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_Division_DivisionId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropIndex(
                name: "IX_Address_DivisionId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UpazilaId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "core",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpazilaId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                schema: "core",
                table: "Address");

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "core",
                table: "Upazila",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "core",
                table: "Upazila",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Upazila",
                schema: "core",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Upazila_District_DistrictId",
                schema: "core",
                table: "Upazila",
                column: "DistrictId",
                principalSchema: "core",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upazila_Division_DivisionId",
                schema: "core",
                table: "Upazila",
                column: "DivisionId",
                principalSchema: "core",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
