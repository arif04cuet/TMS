using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requisition",
                schema: "asset",
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
                    Title = table.Column<string>(nullable: true),
                    InitiatorId = table.Column<long>(nullable: false),
                    CurrentApproverId = table.Column<long>(nullable: true),
                    CurrentRoleApproverId = table.Column<long>(nullable: true),
                    BatchScheduleId = table.Column<long>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisition_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisition_User_CurrentApproverId",
                        column: x => x.CurrentApproverId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisition_Role_CurrentRoleApproverId",
                        column: x => x.CurrentRoleApproverId,
                        principalSchema: "core",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisition_User_InitiatorId",
                        column: x => x.InitiatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionHistory",
                schema: "asset",
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
                    RequisitionId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    InitiatorId = table.Column<long>(nullable: false),
                    ApproverId = table.Column<long>(nullable: true),
                    RoleApproverId = table.Column<long>(nullable: true),
                    BatchScheduleId = table.Column<long>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionHistory_User_ApproverId",
                        column: x => x.ApproverId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequisitionHistory_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequisitionHistory_User_InitiatorId",
                        column: x => x.InitiatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionHistory_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalSchema: "asset",
                        principalTable: "Requisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequisitionHistory_Role_RoleApproverId",
                        column: x => x.RoleApproverId,
                        principalSchema: "core",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionItem",
                schema: "asset",
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
                    RequisitionId = table.Column<long>(nullable: false),
                    AssetId = table.Column<long>(nullable: false),
                    AssetType = table.Column<byte>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionItem_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalSchema: "asset",
                        principalTable: "Requisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionHistoryItem",
                schema: "asset",
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
                    RequisitionId = table.Column<long>(nullable: true),
                    RequisitionHistoryId = table.Column<long>(nullable: false),
                    RequisitionItemId = table.Column<long>(nullable: true),
                    AssetId = table.Column<long>(nullable: false),
                    AssetType = table.Column<byte>(nullable: false),
                    RequestQuantity = table.Column<int>(nullable: false),
                    ChangedQuantity = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionHistoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionHistoryItem_RequisitionHistory_RequisitionHistoryId",
                        column: x => x.RequisitionHistoryId,
                        principalSchema: "asset",
                        principalTable: "RequisitionHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionHistoryItem_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalSchema: "asset",
                        principalTable: "Requisition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequisitionHistoryItem_RequisitionItem_RequisitionItemId",
                        column: x => x.RequisitionItemId,
                        principalSchema: "asset",
                        principalTable: "RequisitionItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_BatchScheduleId",
                schema: "asset",
                table: "Requisition",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CurrentApproverId",
                schema: "asset",
                table: "Requisition",
                column: "CurrentApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_CurrentRoleApproverId",
                schema: "asset",
                table: "Requisition",
                column: "CurrentRoleApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_InitiatorId",
                schema: "asset",
                table: "Requisition",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistory_ApproverId",
                schema: "asset",
                table: "RequisitionHistory",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistory_BatchScheduleId",
                schema: "asset",
                table: "RequisitionHistory",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistory_InitiatorId",
                schema: "asset",
                table: "RequisitionHistory",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistory_RequisitionId",
                schema: "asset",
                table: "RequisitionHistory",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistory_RoleApproverId",
                schema: "asset",
                table: "RequisitionHistory",
                column: "RoleApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistoryItem_RequisitionHistoryId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                column: "RequisitionHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistoryItem_RequisitionId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionHistoryItem_RequisitionItemId",
                schema: "asset",
                table: "RequisitionHistoryItem",
                column: "RequisitionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionItem_RequisitionId",
                schema: "asset",
                table: "RequisitionItem",
                column: "RequisitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitionHistoryItem",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "RequisitionHistory",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "RequisitionItem",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Requisition",
                schema: "asset");
        }
    }
}
