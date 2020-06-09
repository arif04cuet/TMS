using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePerson_Designation_DesignationId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropIndex(
                name: "IX_ResourcePerson_DesignationId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropIndex(
                name: "IX_AssetModel_DepreciationId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "DepreciationId",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.DropColumn(
                name: "Eol",
                schema: "asset",
                table: "AssetModel");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "training",
                table: "ResourcePerson",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DirectorId",
                schema: "training",
                table: "CourseModule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalMark",
                schema: "training",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                schema: "asset",
                table: "Depreciation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AssetDepreciation",
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
                    AssetId = table.Column<long>(nullable: true),
                    Term = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    RatePerFrequency = table.Column<float>(nullable: false),
                    ValuePerFrequency = table.Column<float>(nullable: false),
                    NextDepreciateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDepreciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetDepreciation_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course_CourseModule",
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
                    CourseId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_CourseModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_CourseModule_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseModule_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEvaluationMethod",
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
                    CourseId = table.Column<long>(nullable: false),
                    EvaluationMethodId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvaluationMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseEvaluationMethod_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEvaluationMethod_EvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMethod",
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
                    CourseId = table.Column<long>(nullable: false),
                    MethodId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMethod_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMethod_Method_MethodId",
                        column: x => x.MethodId,
                        principalSchema: "training",
                        principalTable: "Method",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseModuleTopic",
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
                    CourseModuleId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModuleTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModuleTopic_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModuleTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePersonExpertise",
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
                    ResourcePersonId = table.Column<long>(nullable: false),
                    ExpertiseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePersonExpertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourcePersonExpertise_Expertise_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalSchema: "training",
                        principalTable: "Expertise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcePersonExpertise_ResourcePerson_ResourcePersonId",
                        column: x => x.ResourcePersonId,
                        principalSchema: "training",
                        principalTable: "ResourcePerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetDepreciationSchedule",
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
                    AssetId = table.Column<long>(nullable: true),
                    AssetDepreciationId = table.Column<long>(nullable: true),
                    CurrentDepreciation = table.Column<float>(nullable: false),
                    CummulativeValue = table.Column<float>(nullable: false),
                    CurrentValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDepreciationSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetDepreciationSchedule_AssetDepreciation_AssetDepreciationId",
                        column: x => x.AssetDepreciationId,
                        principalSchema: "asset",
                        principalTable: "AssetDepreciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetDepreciationSchedule_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_UserId",
                schema: "training",
                table: "ResourcePerson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_DirectorId",
                schema: "training",
                table: "CourseModule",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciation_AssetId",
                schema: "asset",
                table: "AssetDepreciation",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciationSchedule_AssetDepreciationId",
                schema: "asset",
                table: "AssetDepreciationSchedule",
                column: "AssetDepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDepreciationSchedule_AssetId",
                schema: "asset",
                table: "AssetDepreciationSchedule",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseModule_CourseId",
                schema: "training",
                table: "Course_CourseModule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseModule_CourseModuleId",
                schema: "training",
                table: "Course_CourseModule",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEvaluationMethod_CourseId",
                schema: "training",
                table: "CourseEvaluationMethod",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEvaluationMethod_EvaluationMethodId",
                schema: "training",
                table: "CourseEvaluationMethod",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMethod_CourseId",
                schema: "training",
                table: "CourseMethod",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMethod_MethodId",
                schema: "training",
                table: "CourseMethod",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModuleTopic_CourseModuleId",
                schema: "training",
                table: "CourseModuleTopic",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModuleTopic_TopicId",
                schema: "training",
                table: "CourseModuleTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePersonExpertise_ExpertiseId",
                schema: "training",
                table: "ResourcePersonExpertise",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePersonExpertise_ResourcePersonId",
                schema: "training",
                table: "ResourcePersonExpertise",
                column: "ResourcePersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseModule_User_DirectorId",
                schema: "training",
                table: "CourseModule",
                column: "DirectorId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePerson_User_UserId",
                schema: "training",
                table: "ResourcePerson",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseModule_User_DirectorId",
                schema: "training",
                table: "CourseModule");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourcePerson_User_UserId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropTable(
                name: "AssetDepreciationSchedule",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Course_CourseModule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseEvaluationMethod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseMethod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseModuleTopic",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ResourcePersonExpertise",
                schema: "training");

            migrationBuilder.DropTable(
                name: "AssetDepreciation",
                schema: "asset");

            migrationBuilder.DropIndex(
                name: "IX_ResourcePerson_UserId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropIndex(
                name: "IX_CourseModule_DirectorId",
                schema: "training",
                table: "CourseModule");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "training",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                schema: "training",
                table: "CourseModule");

            migrationBuilder.DropColumn(
                name: "TotalMark",
                schema: "training",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Frequency",
                schema: "asset",
                table: "Depreciation");

            migrationBuilder.AddColumn<long>(
                name: "DesignationId",
                schema: "training",
                table: "ResourcePerson",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "training",
                table: "ResourcePerson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "training",
                table: "ResourcePerson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "training",
                table: "ResourcePerson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DepreciationId",
                schema: "asset",
                table: "AssetModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Eol",
                schema: "asset",
                table: "AssetModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_DesignationId",
                schema: "training",
                table: "ResourcePerson",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_DepreciationId",
                schema: "asset",
                table: "AssetModel",
                column: "DepreciationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Depreciation_DepreciationId",
                schema: "asset",
                table: "AssetModel",
                column: "DepreciationId",
                principalSchema: "asset",
                principalTable: "Depreciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcePerson_Designation_DesignationId",
                schema: "training",
                table: "ResourcePerson",
                column: "DesignationId",
                principalSchema: "core",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
