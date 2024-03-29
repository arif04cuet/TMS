﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class fawTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faq",
                schema: "cms",
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
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faq",
                schema: "cms");
        }
    }
}
