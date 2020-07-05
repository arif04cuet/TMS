using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificate",
                schema: "training",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Version = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Serial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchScheduleAllocation_Certificate_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "CertificateId",
                principalSchema: "training",
                principalTable: "Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchScheduleAllocation_Certificate_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "training");

            migrationBuilder.DropIndex(
                name: "IX_BatchScheduleAllocation_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");
        }
    }
}
