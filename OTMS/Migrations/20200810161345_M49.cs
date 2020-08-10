using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchScheduleAllocation_Certificate_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropIndex(
                name: "IX_BatchScheduleAllocation_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation");

            migrationBuilder.AddColumn<long>(
                name: "BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate",
                column: "BatchScheduleAllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_BatchScheduleAllocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate",
                column: "BatchScheduleAllocationId",
                principalSchema: "training",
                principalTable: "BatchScheduleAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_BatchScheduleAllocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "BatchScheduleAllocationId",
                schema: "training",
                table: "Certificate");

            migrationBuilder.AddColumn<long>(
                name: "CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation",
                type: "bigint",
                nullable: true);

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
    }
}
