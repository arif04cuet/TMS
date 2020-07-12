using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                schema: "training",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "EvaluationMethodId",
                schema: "training",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                schema: "training",
                table: "Topic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MethodId",
                schema: "training",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                schema: "training",
                table: "CourseModuleTopic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                schema: "training",
                table: "CourseModuleTopic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                schema: "training",
                table: "Course_CourseModule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                schema: "training",
                table: "Course_CourseModule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                schema: "training",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TopicResourcePerson",
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
                    TopicId = table.Column<long>(nullable: false),
                    ResourcePersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicResourcePerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicResourcePerson_ResourcePerson_ResourcePersonId",
                        column: x => x.ResourcePersonId,
                        principalSchema: "training",
                        principalTable: "ResourcePerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicResourcePerson_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_EvaluationMethodId",
                schema: "training",
                table: "Topic",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_MethodId",
                schema: "training",
                table: "Topic",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicResourcePerson_ResourcePersonId",
                schema: "training",
                table: "TopicResourcePerson",
                column: "ResourcePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicResourcePerson_TopicId",
                schema: "training",
                table: "TopicResourcePerson",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_EvaluationMethod_EvaluationMethodId",
                schema: "training",
                table: "Topic",
                column: "EvaluationMethodId",
                principalSchema: "training",
                principalTable: "EvaluationMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Method_MethodId",
                schema: "training",
                table: "Topic",
                column: "MethodId",
                principalSchema: "training",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_EvaluationMethod_EvaluationMethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Method_MethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "TopicResourcePerson",
                schema: "training");

            migrationBuilder.DropIndex(
                name: "IX_Topic_EvaluationMethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_MethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "EvaluationMethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Marks",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "MethodId",
                schema: "training",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "training",
                table: "CourseModuleTopic");

            migrationBuilder.DropColumn(
                name: "Marks",
                schema: "training",
                table: "CourseModuleTopic");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "training",
                table: "Course_CourseModule");

            migrationBuilder.DropColumn(
                name: "Marks",
                schema: "training",
                table: "Course_CourseModule");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "training",
                table: "Course");
        }
    }
}
