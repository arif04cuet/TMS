using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFacebookUrlPublic",
                schema: "training",
                table: "ResourcePerson",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInstagramUrlPublic",
                schema: "training",
                table: "ResourcePerson",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLinkedinUrlPublic",
                schema: "training",
                table: "ResourcePerson",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsYouTubeUrlPublic",
                schema: "training",
                table: "ResourcePerson",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTubeUrl",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "IsFacebookUrlPublic",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "IsInstagramUrlPublic",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "IsLinkedinUrlPublic",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "IsYouTubeUrlPublic",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "YouTubeUrl",
                schema: "training",
                table: "ResourcePerson");
        }
    }
}
