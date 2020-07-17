using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class addColumnsToResourcePersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltEmail",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltMobile",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CvId",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingAddress",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeAddress",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhotoId",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_CvId",
                schema: "training",
                table: "ResourcePerson",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_PhotoId",
                schema: "training",
                table: "ResourcePerson",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePerson_Media_CvId",
                schema: "training",
                table: "ResourcePerson",
                column: "CvId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePerson_Media_PhotoId",
                schema: "training",
                table: "ResourcePerson",
                column: "PhotoId",
                principalSchema: "core",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePerson_Media_CvId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePerson_Media_PhotoId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropIndex(
                name: "IX_ResourcePerson_CvId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropIndex(
                name: "IX_ResourcePerson_PhotoId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "AltEmail",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "AltMobile",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "CvId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "MailingAddress",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "OfficeAddress",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                schema: "training",
                table: "ResourcePerson");
        }
    }
}
