using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "asset");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "library");

            migrationBuilder.EnsureSchema(
                name: "training");

            migrationBuilder.CreateTable(
                name: "AssetStatus",
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
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depreciation",
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
                    Name = table.Column<string>(nullable: true),
                    Term = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
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
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodGroup",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true),
                    BnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassingYear = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                schema: "core",
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
                    Template = table.Column<string>(nullable: true),
                    Event = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                schema: "core",
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
                    Size = table.Column<long>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    IsInUse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "core",
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
                    Token = table.Column<string>(nullable: true),
                    ExpiresIn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookFormat",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFormat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStatus",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EBookFormat",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBookFormat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCardStatus",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCardStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCardType",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberStatus",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EvaluationMethod",
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
                    Name = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    UseInExam = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expertise",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
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
                    Name = table.Column<string>(nullable: true),
                    From = table.Column<int>(nullable: false),
                    To = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Honorarium",
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
                    HonorariumFor = table.Column<byte>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honorarium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Method",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Method", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
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
                    Title = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    AnswerLength = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
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
                    Name = table.Column<string>(nullable: true),
                    Rent = table.Column<float>(nullable: false),
                    DesignationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomType_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "core",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true),
                    BnName = table.Column<string>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "core",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    Name = table.Column<string>(nullable: true),
                    EULA = table.Column<string>(nullable: true),
                    IsRequireUserConfirmation = table.Column<bool>(nullable: false),
                    IsSendEmail = table.Column<bool>(nullable: false),
                    MediaId = table.Column<long>(nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
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
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    SupportUrl = table.Column<string>(nullable: true),
                    SupportPhone = table.Column<string>(nullable: true),
                    SupportEmail = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupId = table.Column<long>(nullable: false),
                    ModuleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "core",
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "core",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "core",
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
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    StatusId = table.Column<long>(nullable: true),
                    DesignationId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "core",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "core",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "core",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
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
                    Name = table.Column<string>(nullable: true),
                    ImageId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    Objective = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalMark = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "training",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Media_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HonorariumHead",
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
                    HonorariumId = table.Column<long>(nullable: false),
                    DesignationId = table.Column<long>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HonorariumHead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HonorariumHead_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "core",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HonorariumHead_Honorarium_HonorariumId",
                        column: x => x.HonorariumId,
                        principalSchema: "training",
                        principalTable: "Honorarium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
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
                    Name = table.Column<string>(nullable: true),
                    Objectives = table.Column<string>(nullable: true),
                    Outcomes = table.Column<string>(nullable: true),
                    CourseMaterials = table.Column<string>(nullable: true),
                    CourseDetails = table.Column<string>(nullable: true),
                    MethodId = table.Column<long>(nullable: true),
                    EvaluationMethodId = table.Column<long>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_EvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_Method_MethodId",
                        column: x => x.MethodId,
                        principalSchema: "training",
                        principalTable: "Method",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOption",
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
                    Option = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazila",
                schema: "core",
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
                    Name = table.Column<string>(nullable: true),
                    BnName = table.Column<string>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazila_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "core",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Upazila_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "core",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCode",
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
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: true),
                    Available = table.Column<int>(nullable: true),
                    MinQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCode_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetModel",
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
                    Name = table.Column<string>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    IsRequestable = table.Column<bool>(nullable: false),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetModel_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    PermissionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "core",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "core",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistory",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionById = table.Column<long>(nullable: true),
                    TargetId = table.Column<long>(nullable: true),
                    TargetType = table.Column<byte>(nullable: false),
                    ItemId = table.Column<long>(nullable: true),
                    ItemType = table.Column<byte>(nullable: false),
                    Action = table.Column<byte>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistory_User_ActionById",
                        column: x => x.ActionById,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    PermissionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "core",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "core",
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
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "core",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    RefreshTokenId = table.Column<long>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    ExpiresIn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_RefreshToken_RefreshTokenId",
                        column: x => x.RefreshTokenId,
                        principalSchema: "core",
                        principalTable: "RefreshToken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseModule",
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
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    Objectives = table.Column<string>(nullable: true),
                    DirectorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModule_User_DirectorId",
                        column: x => x.DirectorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    EvaluationMethodId = table.Column<long>(nullable: false),
                    Mark = table.Column<int>(nullable: false)
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
                name: "CourseSchedule",
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
                    Name = table.Column<string>(nullable: true),
                    CourseId = table.Column<long>(nullable: false),
                    CoordinatorId = table.Column<long>(nullable: true),
                    CoCoordinatorId = table.Column<long>(nullable: true),
                    Staff1Id = table.Column<long>(nullable: true),
                    Staff2Id = table.Column<long>(nullable: true),
                    Staff3Id = table.Column<long>(nullable: true),
                    TotalSeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_CoCoordinatorId",
                        column: x => x.CoCoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_Staff1Id",
                        column: x => x.Staff1Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_Staff2Id",
                        column: x => x.Staff2Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_User_Staff3Id",
                        column: x => x.Staff3Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicQuestion",
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
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicQuestion_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "core",
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
                    ContactName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    UpazilaId = table.Column<long>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "core",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "core",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Upazila_UpazilaId",
                        column: x => x.UpazilaId,
                        principalSchema: "core",
                        principalTable: "Upazila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                schema: "core",
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
                    OfficeName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    UpazilaId = table.Column<long>(nullable: true),
                    DivisionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "core",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "core",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Upazila_UpazilaId",
                        column: x => x.UpazilaId,
                        principalSchema: "core",
                        principalTable: "Upazila",
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
                    CourseModuleId = table.Column<long>(nullable: false),
                    Marks = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
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
                name: "CourseModule_Course",
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
                    table.PrimaryKey("PK_CourseModule_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModule_Course_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseModule_Course_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
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
                    TopicId = table.Column<long>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false)
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
                name: "BatchSchedule",
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
                    Name = table.Column<string>(nullable: true),
                    CourseScheduleId = table.Column<long>(nullable: false),
                    CoordinatorId = table.Column<long>(nullable: true),
                    CoCoordinatorId = table.Column<long>(nullable: true),
                    Staff1Id = table.Column<long>(nullable: true),
                    Staff2Id = table.Column<long>(nullable: true),
                    Staff3Id = table.Column<long>(nullable: true),
                    TotalSeat = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_CoCoordinatorId",
                        column: x => x.CoCoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_CourseSchedule_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalSchema: "training",
                        principalTable: "CourseSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_Staff1Id",
                        column: x => x.Staff1Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_Staff2Id",
                        column: x => x.Staff2Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchSchedule_User_Staff3Id",
                        column: x => x.Staff3Id,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
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
                    CourseScheduleId = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_CourseSchedule_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalSchema: "training",
                        principalTable: "CourseSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseScheduleEligible",
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
                    CourseScheduleId = table.Column<long>(nullable: false),
                    DesignationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseScheduleEligible", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseScheduleEligible_CourseSchedule_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalSchema: "training",
                        principalTable: "CourseSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseScheduleEligible_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "core",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: "core",
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
                    NID = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true),
                    BloodGroupId = table.Column<long>(nullable: true),
                    GenderId = table.Column<long>(nullable: true),
                    MaritalStatusId = table.Column<long>(nullable: true),
                    ReligionId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    MediaId = table.Column<long>(nullable: true),
                    ContactAddressId = table.Column<long>(nullable: true),
                    PermanentAddressId = table.Column<long>(nullable: true),
                    OfficeAddressId = table.Column<long>(nullable: true),
                    EducationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_BloodGroup_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalSchema: "core",
                        principalTable: "BloodGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Address_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Education_EducationId",
                        column: x => x.EducationId,
                        principalSchema: "core",
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Gender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "core",
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_MaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "core",
                        principalTable: "MaritalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Address_OfficeAddressId",
                        column: x => x.OfficeAddressId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Address_PermanentAddressId",
                        column: x => x.PermanentAddressId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_Religion_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "core",
                        principalTable: "Religion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    LibrarianId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Library_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Library_User_LibrarianId",
                        column: x => x.LibrarianId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hostel",
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
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hostel_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accessory",
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
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    LocationId = table.Column<long>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    PurchaseCost = table.Column<double>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessory_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessory_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessory_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetCheckout",
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
                    ChekoutToAssetId = table.Column<long>(nullable: true),
                    ChekoutToUserId = table.Column<long>(nullable: true),
                    ChekoutToLocationId = table.Column<long>(nullable: true),
                    CheckoutDate = table.Column<DateTime>(nullable: true),
                    ExpectedChekinDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCheckout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCheckout_Office_ChekoutToLocationId",
                        column: x => x.ChekoutToLocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCheckout_User_ChekoutToUserId",
                        column: x => x.ChekoutToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Component",
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
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    LocationId = table.Column<long>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Component_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Component_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Component_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumable",
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
                    Name = table.Column<string>(nullable: true),
                    ItemCodeId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    LocationId = table.Column<long>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true),
                    Available = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumable_ItemCode_ItemCodeId",
                        column: x => x.ItemCodeId,
                        principalSchema: "asset",
                        principalTable: "ItemCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumable_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "License",
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
                    Name = table.Column<string>(nullable: true),
                    ProductKey = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    LicenseToName = table.Column<string>(nullable: true),
                    LicenseToEmail = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    DepreciationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Depreciation_DepreciationId",
                        column: x => x.DepreciationId,
                        principalSchema: "asset",
                        principalTable: "Depreciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePerson",
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
                    ShortName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    OfficeId = table.Column<long>(nullable: true),
                    HonorariumHeadId = table.Column<long>(nullable: true),
                    NID = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    AltEmail = table.Column<string>(nullable: true),
                    AltMobile = table.Column<string>(nullable: true),
                    MailingAddress = table.Column<string>(nullable: true),
                    OfficeAddress = table.Column<string>(nullable: true),
                    CvId = table.Column<long>(nullable: true),
                    PhotoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourcePerson_Media_CvId",
                        column: x => x.CvId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourcePerson_HonorariumHead_HonorariumHeadId",
                        column: x => x.HonorariumHeadId,
                        principalSchema: "training",
                        principalTable: "HonorariumHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourcePerson_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourcePerson_Media_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourcePerson_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchScheduleGalleryItem",
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
                    MediaId = table.Column<long>(nullable: false),
                    BatchScheduleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchScheduleGalleryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchScheduleGalleryItem_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchScheduleGalleryItem_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoutine",
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
                    BatchScheduleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoutine_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
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
                    Name = table.Column<string>(nullable: true),
                    BatchScheduleId = table.Column<long>(nullable: false),
                    EvaluationMethodId = table.Column<long>(nullable: false),
                    EvaluationType = table.Column<byte>(nullable: true),
                    QuestionType = table.Column<byte>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    TotalMinutes = table.Column<int>(nullable: false),
                    ExtraTime = table.Column<int>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ExamDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_EvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionProgress",
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
                    BatchScheduleId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    SheetGenerated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionProgress_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionProgress_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionProgress_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetItem",
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
                    BudgetId = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetItem_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalSchema: "training",
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Excerpt = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    LanguageId = table.Column<long>(nullable: false),
                    PublisherId = table.Column<long>(nullable: true),
                    AuthorId = table.Column<long>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "library",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "core",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "library",
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EBook",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    MediaId = table.Column<long>(nullable: false),
                    IsDownloadable = table.Column<bool>(nullable: false),
                    FormatId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EBook_EBookFormat_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "library",
                        principalTable: "EBookFormat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EBook_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EBook_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    DueAmount = table.Column<float>(nullable: false),
                    TotalAmount = table.Column<float>(nullable: false),
                    LostFineAmount = table.Column<float>(nullable: false),
                    LateFineAmount = table.Column<float>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fine_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCard",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    CardTypeId = table.Column<long>(nullable: false),
                    CardFee = table.Column<float>(nullable: false),
                    LateFee = table.Column<float>(nullable: false),
                    MaxIssueCount = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<long>(nullable: true),
                    CardStatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryCard_LibraryCardStatus_CardStatusId",
                        column: x => x.CardStatusId,
                        principalSchema: "library",
                        principalTable: "LibraryCardStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryCard_LibraryCardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalSchema: "library",
                        principalTable: "LibraryCardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryCard_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryCard_User_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryMemberRequest",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMemberRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryMemberRequest_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryMemberRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rack",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true),
                    FloorNo = table.Column<int>(nullable: false),
                    BuildingName = table.Column<string>(nullable: true),
                    LibraryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rack_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Building",
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
                    Name = table.Column<string>(nullable: true),
                    HostelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "training",
                        principalTable: "Hostel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryUser",
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
                    AccessoryId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoryUser_Accessory_AccessoryId",
                        column: x => x.AccessoryId,
                        principalSchema: "asset",
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryUser_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
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
                    Barcode = table.Column<string>(nullable: true),
                    AssetTag = table.Column<string>(nullable: true),
                    AssetModelId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    ItemNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    InventoryEntryDate = table.Column<DateTime>(nullable: true),
                    PurchaseCost = table.Column<double>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    OrderNo = table.Column<string>(nullable: true),
                    InvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    Warranty = table.Column<int>(nullable: false),
                    Maintenance = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsRequestable = table.Column<bool>(nullable: false),
                    LocationId = table.Column<long>(nullable: true),
                    DepreciationId = table.Column<long>(nullable: true),
                    MediaId = table.Column<long>(nullable: true),
                    CheckoutId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetModel_AssetModelId",
                        column: x => x.AssetModelId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetCheckout_CheckoutId",
                        column: x => x.CheckoutId,
                        principalSchema: "asset",
                        principalTable: "AssetCheckout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Depreciation_DepreciationId",
                        column: x => x.DepreciationId,
                        principalSchema: "asset",
                        principalTable: "Depreciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_AssetStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "asset",
                        principalTable: "AssetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableUser",
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
                    ConsumableId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableUser_Consumable_ConsumableId",
                        column: x => x.ConsumableId,
                        principalSchema: "asset",
                        principalTable: "Consumable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumableUser_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "ClassRoutineModule",
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
                    ClassRoutineId = table.Column<long>(nullable: false),
                    CourseModuleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoutineModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoutineModule_ClassRoutine_ClassRoutineId",
                        column: x => x.ClassRoutineId,
                        principalSchema: "training",
                        principalTable: "ClassRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoutineModule_CourseModule_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalSchema: "training",
                        principalTable: "CourseModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
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
                    ExamId = table.Column<long>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exam_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "training",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                schema: "library",
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
                    BookId = table.Column<long>(nullable: false),
                    AuthorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "library",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSubject",
                schema: "library",
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
                    Name = table.Column<string>(nullable: true),
                    BookId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSubject_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "library",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookEdition",
                schema: "library",
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
                    BookId = table.Column<long>(nullable: false),
                    EBookId = table.Column<long>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    NumberOfPage = table.Column<int>(nullable: false),
                    NumberOfCopy = table.Column<int>(nullable: false),
                    Edition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEdition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEdition_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEdition_EBook_EBookId",
                        column: x => x.EBookId,
                        principalSchema: "library",
                        principalTable: "EBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryMember",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    MemberSince = table.Column<DateTime>(nullable: true),
                    TotalBooksCheckout = table.Column<long>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    CurrentCardId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryMember_LibraryCard_CurrentCardId",
                        column: x => x.CurrentCardId,
                        principalSchema: "library",
                        principalTable: "LibraryCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryMember_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryMember_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
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
                    Name = table.Column<string>(nullable: true),
                    BuildingId = table.Column<long>(nullable: false),
                    HostelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "training",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Floor_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "training",
                        principalTable: "Hostel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetAudit",
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
                    AuditDate = table.Column<DateTime>(nullable: false),
                    NextAuditDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAudit_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "AssetMaintenance",
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
                    Type = table.Column<int>(nullable: false),
                    AssetId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: false),
                    IsWarrantyImprovement = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentAsset",
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
                    ComponentId = table.Column<long>(nullable: false),
                    IssuedToAssetId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentAsset_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "asset",
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentAsset_Asset_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseSeat",
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
                    Name = table.Column<string>(nullable: true),
                    LicenseId = table.Column<long>(nullable: false),
                    IssuedToUserId = table.Column<long>(nullable: true),
                    IssuedToAssetId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_Asset_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalSchema: "asset",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_User_IssuedToUserId",
                        column: x => x.IssuedToUserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseSeat_License_LicenseId",
                        column: x => x.LicenseId,
                        principalSchema: "asset",
                        principalTable: "License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleRoutine",
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
                    ModuleId = table.Column<long>(nullable: false),
                    TrainingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleRoutine_ClassRoutineModule_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "training",
                        principalTable: "ClassRoutineModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
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
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: false),
                    BuildingId = table.Column<long>(nullable: false),
                    FloorId = table.Column<long>(nullable: false),
                    HostelId = table.Column<long>(nullable: false),
                    IsBooked = table.Column<bool>(nullable: false),
                    ImageId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "training",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Floor_FloorId",
                        column: x => x.FloorId,
                        principalSchema: "training",
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "training",
                        principalTable: "Hostel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Media_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "training",
                        principalTable: "RoomType",
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

            migrationBuilder.CreateTable(
                name: "RoutinePeriod",
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
                    RoutineId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: true),
                    TrainingDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    ResourcePersonId = table.Column<long>(nullable: false),
                    SessionCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutinePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_ResourcePerson_ResourcePersonId",
                        column: x => x.ResourcePersonId,
                        principalSchema: "training",
                        principalTable: "ResourcePerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_ModuleRoutine_RoutineId",
                        column: x => x.RoutineId,
                        principalSchema: "training",
                        principalTable: "ModuleRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutinePeriod_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "training",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bed",
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
                    Name = table.Column<string>(nullable: true),
                    BuildingId = table.Column<long>(nullable: false),
                    FloorId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: false),
                    HostelId = table.Column<long>(nullable: false),
                    IsBooked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bed_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "training",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bed_Floor_FloorId",
                        column: x => x.FloorId,
                        principalSchema: "training",
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "training",
                        principalTable: "Hostel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bed_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "training",
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacilities",
                schema: "training",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<long>(nullable: false),
                    FacilitiesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalSchema: "training",
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "training",
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchScheduleAllocation",
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
                    BatchScheduleId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: true),
                    TraineeId = table.Column<long>(nullable: false),
                    AppliedDate = table.Column<DateTime>(nullable: false),
                    AllocationDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CertificateId = table.Column<long>(nullable: true),
                    BedId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchScheduleAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_Bed_BedId",
                        column: x => x.BedId,
                        principalSchema: "training",
                        principalTable: "Bed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalSchema: "training",
                        principalTable: "Certificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "training",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "training",
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchScheduleAllocation_User_TraineeId",
                        column: x => x.TraineeId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allocation",
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
                    Name = table.Column<string>(nullable: true),
                    CheckinDate = table.Column<DateTime>(nullable: true),
                    CheckoutDate = table.Column<DateTime>(nullable: true),
                    BedId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    BatchScheduleAllocationId = table.Column<long>(nullable: true),
                    BuildingId = table.Column<long>(nullable: true),
                    FloorId = table.Column<long>(nullable: true),
                    HostelId = table.Column<long>(nullable: true),
                    Days = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allocation_BatchScheduleAllocation_BatchScheduleAllocationId",
                        column: x => x.BatchScheduleAllocationId,
                        principalSchema: "training",
                        principalTable: "BatchScheduleAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_Bed_BedId",
                        column: x => x.BedId,
                        principalSchema: "training",
                        principalTable: "Bed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "training",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_Floor_FloorId",
                        column: x => x.FloorId,
                        principalSchema: "training",
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "training",
                        principalTable: "Hostel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "training",
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Allocation_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamAnswer",
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
                    AllocationId = table.Column<long>(nullable: false),
                    QuestionId = table.Column<long>(nullable: true),
                    McqAnswerId = table.Column<long>(nullable: true),
                    WrittenAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamAnswer_BatchScheduleAllocation_AllocationId",
                        column: x => x.AllocationId,
                        principalSchema: "training",
                        principalTable: "BatchScheduleAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamAnswer_QuestionOption_McqAnswerId",
                        column: x => x.McqAnswerId,
                        principalSchema: "training",
                        principalTable: "QuestionOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamAnswer_ExamQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "training",
                        principalTable: "ExamQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamParticipant",
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
                    ExamId = table.Column<long>(nullable: false),
                    Mark = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamParticipant_Exam_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "training",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamParticipant_BatchScheduleAllocation_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "training",
                        principalTable: "BatchScheduleAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TotalMark",
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
                    BatchScheduleId = table.Column<long>(nullable: false),
                    EvaluationMethodId = table.Column<long>(nullable: true),
                    ParticipantId = table.Column<long>(nullable: true),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalMark_BatchSchedule_BatchScheduleId",
                        column: x => x.BatchScheduleId,
                        principalSchema: "training",
                        principalTable: "BatchSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalMark_CourseEvaluationMethod_EvaluationMethodId",
                        column: x => x.EvaluationMethodId,
                        principalSchema: "training",
                        principalTable: "CourseEvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TotalMark_BatchScheduleAllocation_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "training",
                        principalTable: "BatchScheduleAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookIssue",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    BookId = table.Column<long>(nullable: false),
                    BookItemId = table.Column<long>(nullable: true),
                    MemberId = table.Column<long>(nullable: true),
                    LibraryCardId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    ActualReturnDate = table.Column<DateTime>(nullable: true),
                    FineId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ConvertedFromReservationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookIssue_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIssue_Fine_FineId",
                        column: x => x.FineId,
                        principalSchema: "library",
                        principalTable: "Fine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookIssue_LibraryCard_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalSchema: "library",
                        principalTable: "LibraryCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookIssue_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookIssue_User_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookItem",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    PurchagePrice = table.Column<float>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    BookId = table.Column<long>(nullable: false),
                    FormatId = table.Column<long>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    RackId = table.Column<long>(nullable: true),
                    EditionId = table.Column<long>(nullable: true),
                    DateOfPurchage = table.Column<DateTime>(nullable: true),
                    IssuedToId = table.Column<long>(nullable: true),
                    CurrentIssueId = table.Column<long>(nullable: true),
                    ReservedForId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookItem_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookItem_BookIssue_CurrentIssueId",
                        column: x => x.CurrentIssueId,
                        principalSchema: "library",
                        principalTable: "BookIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_BookEdition_EditionId",
                        column: x => x.EditionId,
                        principalSchema: "library",
                        principalTable: "BookEdition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_BookFormat_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "library",
                        principalTable: "BookFormat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_User_IssuedToId",
                        column: x => x.IssuedToId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_Rack_RackId",
                        column: x => x.RackId,
                        principalSchema: "library",
                        principalTable: "Rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_User_ReservedForId",
                        column: x => x.ReservedForId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookItem_BookStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "library",
                        principalTable: "BookStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookReservation",
                schema: "library",
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
                    LibraryId = table.Column<long>(nullable: true),
                    BookId = table.Column<long>(nullable: false),
                    BookItemId = table.Column<long>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    ReservationById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReservation_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReservation_BookItem_BookItemId",
                        column: x => x.BookItemId,
                        principalSchema: "library",
                        principalTable: "BookItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookReservation_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookReservation_User_ReservationById",
                        column: x => x.ReservationById,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookReservation_ReservationStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "library",
                        principalTable: "ReservationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "asset",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EULA", "IsActive", "IsDeleted", "IsRequireUserConfirmation", "IsSendEmail", "MediaId", "Name", "ParentId", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, null, true, false, false, false, null, "Asset", null, null, null, 0L },
                    { 2L, null, null, null, true, false, false, false, null, "Consumable", null, null, null, 0L },
                    { 3L, null, null, null, true, false, false, false, null, "License", null, null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "BloodGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 8L, null, null, true, false, "O-", null, null, 0L },
                    { 7L, null, null, true, false, "O+", null, null, 0L },
                    { 5L, null, null, true, false, "AB+", null, null, 0L },
                    { 6L, null, null, true, false, "AB-", null, null, 0L },
                    { 3L, null, null, true, false, "B+", null, null, 0L },
                    { 2L, null, null, true, false, "A-", null, null, 0L },
                    { 1L, null, null, true, false, "A+", null, null, 0L },
                    { 4L, null, null, true, false, "B-", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Designation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 8L, null, null, true, false, "Additional Secretary", null, null, 0L },
                    { 12L, null, null, true, false, "Honorable Guest Speaker", null, null, 0L },
                    { 11L, null, null, true, false, "Deputy Secretary", null, null, 0L },
                    { 10L, null, null, true, false, "Joint Secretary", null, null, 0L },
                    { 9L, null, null, true, false, "Secretary", null, null, 0L },
                    { 7L, null, null, true, false, "Social services officer 2nd Class Gazetted or Equivalent", null, null, 0L },
                    { 3L, null, null, true, false, "Additional Director", null, null, 0L },
                    { 5L, null, null, true, false, "Assistant Director or Equivalent", null, null, 0L },
                    { 4L, null, null, true, false, "Deputy Director or Equivalent", null, null, 0L },
                    { 2L, null, null, true, false, "Director", null, null, 0L },
                    { 1L, null, null, true, false, "Director General", null, null, 0L },
                    { 6L, null, null, true, false, "Social services officer 1st Class Gazetted or Equivalent", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Division",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 6L, "ঢাকা", null, null, true, false, "Dhaka", null, null, 0L },
                    { 8L, "ময়মনসিংহ", null, null, true, false, "Mymensingh", null, null, 0L },
                    { 7L, "রংপুর", null, null, true, false, "Rangpur", null, null, 0L },
                    { 5L, "সিলেট", null, null, true, false, "Sylhet", null, null, 0L },
                    { 2L, "রাজশাহী", null, null, true, false, "Rajshahi", null, null, 0L },
                    { 3L, "খুলনা", null, null, true, false, "Khulna", null, null, 0L },
                    { 1L, "চট্টগ্রাম", null, null, true, false, "Chattagram", null, null, 0L },
                    { 4L, "বরিশাল", null, null, true, false, "Barisal", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Gender",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Male", null, null, 0L },
                    { 2L, null, null, true, false, "Female", null, null, 0L },
                    { 3L, null, null, true, false, "Other", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Language",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Bangla", null, null, 0L },
                    { 2L, null, null, true, false, "English", null, null, 0L },
                    { 3L, null, null, true, false, "Arabic", null, null, 0L },
                    { 4L, null, null, true, false, "Hindi", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "MaritalStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 5L, null, null, true, false, "Never married", null, null, 0L },
                    { 4L, null, null, true, false, "Divorced", null, null, 0L },
                    { 1L, null, null, true, false, "Married", null, null, 0L },
                    { 2L, null, null, true, false, "Un married", null, null, 0L },
                    { 3L, null, null, true, false, "Widowed", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Module",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "User Management", null, null, 0L },
                    { 2L, null, null, true, false, "Library Management", null, null, 0L },
                    { 3L, null, null, true, false, "Asset Management", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "PermissionGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 5L, null, null, true, false, "Profile", null, null, 0L },
                    { 6L, null, null, true, false, "Book", null, null, 0L },
                    { 4L, null, null, true, false, "Department", null, null, 0L },
                    { 2L, null, null, true, false, "Role", null, null, 0L },
                    { 1L, null, null, true, false, "User", null, null, 0L },
                    { 3L, null, null, true, false, "Designation", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Religion",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 8L, null, null, true, false, "Other", null, null, 0L },
                    { 6L, null, null, true, false, "Jainism", null, null, 0L },
                    { 5L, null, null, true, false, "Buddhism", null, null, 0L },
                    { 7L, null, null, true, false, "Sikhism", null, null, 0L },
                    { 3L, null, null, true, false, "Hinduism", null, null, 0L },
                    { 2L, null, null, true, false, "Judaism", null, null, 0L },
                    { 1L, null, null, true, false, "Islam", null, null, 0L },
                    { 4L, null, null, true, false, "Christianity", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Administrator", null, null, 0L },
                    { 2L, null, null, true, false, "Librarian", null, null, 0L },
                    { 3L, null, null, true, false, "Library Member", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Status",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 3L, null, null, true, false, "Active", null, null, 0L },
                    { 1L, null, null, true, false, "Pending", null, null, 0L },
                    { 2L, null, null, true, false, "Approved", null, null, 0L },
                    { 4L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "BookFormat",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 6L, null, null, true, false, "Magazine", null, null, 0L },
                    { 7L, null, null, true, false, "Journal", null, null, 0L },
                    { 5L, null, null, true, false, "Newspaper", null, null, 0L },
                    { 4L, null, null, true, false, "Ebook", null, null, 0L },
                    { 3L, null, null, true, false, "Audiobook", null, null, 0L },
                    { 2L, null, null, true, false, "Paperback", null, null, 0L },
                    { 1L, null, null, true, false, "Hardcover", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "BookStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Available", null, null, 0L },
                    { 2L, null, null, true, false, "Reserved", null, null, 0L },
                    { 3L, null, null, true, false, "Loned", null, null, 0L },
                    { 4L, null, null, true, false, "Lost", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "EBookFormat",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "PDF", null, null, 0L },
                    { 2L, null, null, true, false, "ePUB", null, null, 0L },
                    { 3L, null, null, true, false, "WordDocument", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "LibraryCardStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 3L, null, null, true, false, "Lost", null, null, 0L },
                    { 1L, null, null, true, false, "Active", null, null, 0L },
                    { 2L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "LibraryCardType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Normal", null, null, 0L },
                    { 2L, null, null, true, false, "Premium", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "MemberStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 5L, null, null, true, false, "None", null, null, 0L },
                    { 1L, null, null, true, false, "Active", null, null, 0L },
                    { 2L, null, null, true, false, "Closed", null, null, 0L },
                    { 3L, null, null, true, false, "Canceled", null, null, 0L },
                    { 4L, null, null, true, false, "Blacklisted", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "ReservationStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 3L, null, null, true, false, "Completed", null, null, 0L },
                    { 4L, null, null, true, false, "Canceled", null, null, 0L },
                    { 1L, null, null, true, false, "Waiting", null, null, 0L },
                    { 2L, null, null, true, false, "Pending", null, null, 0L },
                    { 5L, null, null, true, false, "None", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "District",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, "কুমিল্লা", null, null, 1L, true, false, "Comilla", null, null, 0L },
                    { 35L, "বরগুনা", null, null, 4L, true, false, "Barguna", null, null, 0L },
                    { 36L, "সিলেট", null, null, 5L, true, false, "Sylhet", null, null, 0L },
                    { 37L, "মৌলভীবাজার", null, null, 5L, true, false, "Moulvibazar", null, null, 0L },
                    { 38L, "হবিগঞ্জ", null, null, 5L, true, false, "Habiganj", null, null, 0L },
                    { 39L, "সুনামগঞ্জ", null, null, 5L, true, false, "Sunamganj", null, null, 0L },
                    { 40L, "নরসিংদী", null, null, 6L, true, false, "Narsingdi", null, null, 0L },
                    { 41L, "গাজীপুর", null, null, 6L, true, false, "Gazipur", null, null, 0L },
                    { 42L, "শরীয়তপুর", null, null, 6L, true, false, "Shariatpur", null, null, 0L },
                    { 43L, "নারায়ণগঞ্জ", null, null, 6L, true, false, "Narayanganj", null, null, 0L },
                    { 44L, "টাঙ্গাইল", null, null, 6L, true, false, "Tangail", null, null, 0L },
                    { 45L, "কিশোরগঞ্জ", null, null, 6L, true, false, "Kishoreganj", null, null, 0L },
                    { 46L, "মানিকগঞ্জ", null, null, 6L, true, false, "Manikganj", null, null, 0L },
                    { 47L, "ঢাকা", null, null, 6L, true, false, "Dhaka", null, null, 0L },
                    { 48L, "মুন্সিগঞ্জ", null, null, 6L, true, false, "Munshiganj", null, null, 0L },
                    { 50L, "মাদারীপুর", null, null, 6L, true, false, "Madaripur", null, null, 0L },
                    { 51L, "গোপালগঞ্জ", null, null, 6L, true, false, "Gopalganj", null, null, 0L },
                    { 52L, "ফরিদপুর", null, null, 6L, true, false, "Faridpur", null, null, 0L },
                    { 53L, "পঞ্চগড়", null, null, 7L, true, false, "Panchagarh", null, null, 0L },
                    { 54L, "দিনাজপুর", null, null, 7L, true, false, "Dinajpur", null, null, 0L },
                    { 55L, "লালমনিরহাট", null, null, 7L, true, false, "Lalmonirhat", null, null, 0L },
                    { 56L, "নীলফামারী", null, null, 7L, true, false, "Nilphamari", null, null, 0L },
                    { 57L, "গাইবান্ধা", null, null, 7L, true, false, "Gaibandha", null, null, 0L },
                    { 58L, "ঠাকুরগাঁও", null, null, 7L, true, false, "Thakurgaon", null, null, 0L },
                    { 59L, "রংপুর", null, null, 7L, true, false, "Rangpur", null, null, 0L },
                    { 60L, "কুড়িগ্রাম", null, null, 7L, true, false, "Kurigram", null, null, 0L },
                    { 61L, "শেরপুর", null, null, 8L, true, false, "Sherpur", null, null, 0L },
                    { 62L, "ময়মনসিংহ", null, null, 8L, true, false, "Mymensingh", null, null, 0L },
                    { 63L, "জামালপুর", null, null, 8L, true, false, "Jamalpur", null, null, 0L },
                    { 64L, "নেত্রকোণা", null, null, 8L, true, false, "Netrokona", null, null, 0L },
                    { 34L, "ভোলা", null, null, 4L, true, false, "Bhola", null, null, 0L },
                    { 33L, "বরিশাল", null, null, 4L, true, false, "Barisal", null, null, 0L },
                    { 49L, "রাজবাড়ী", null, null, 6L, true, false, "Rajbari", null, null, 0L },
                    { 31L, "পটুয়াখালী", null, null, 4L, true, false, "Patuakhali", null, null, 0L },
                    { 32L, "পিরোজপুর", null, null, 4L, true, false, "Pirojpur", null, null, 0L },
                    { 2L, "ফেনী", null, null, 1L, true, false, "Feni", null, null, 0L },
                    { 3L, "ব্রাহ্মণবাড়িয়া", null, null, 1L, true, false, "Brahmanbaria", null, null, 0L },
                    { 4L, "রাঙ্গামাটি", null, null, 1L, true, false, "Rangamati", null, null, 0L },
                    { 5L, "নোয়াখালী", null, null, 1L, true, false, "Noakhali", null, null, 0L },
                    { 6L, "চাঁদপুর", null, null, 1L, true, false, "Chandpur", null, null, 0L },
                    { 7L, "লক্ষ্মীপুর", null, null, 1L, true, false, "Lakshmipur", null, null, 0L },
                    { 8L, "চট্টগ্রাম", null, null, 1L, true, false, "Chattogram", null, null, 0L },
                    { 10L, "খাগড়াছড়ি", null, null, 1L, true, false, "Khagrachhari", null, null, 0L },
                    { 11L, "বান্দরবান", null, null, 1L, true, false, "Bandarban", null, null, 0L },
                    { 12L, "সিরাজগঞ্জ", null, null, 2L, true, false, "Sirajganj", null, null, 0L },
                    { 13L, "পাবনা", null, null, 2L, true, false, "Pabna", null, null, 0L },
                    { 14L, "বগুড়া", null, null, 2L, true, false, "Bogura", null, null, 0L },
                    { 15L, "রাজশাহী", null, null, 2L, true, false, "Rajshahi", null, null, 0L },
                    { 16L, "নাটোর", null, null, 2L, true, false, "Natore", null, null, 0L },
                    { 9L, "কক্সবাজার", null, null, 1L, true, false, "Coxsbazar", null, null, 0L },
                    { 17L, "জয়পুরহাট", null, null, 2L, true, false, "Joypurhat", null, null, 0L },
                    { 30L, "ঝালকাঠি", null, null, 4L, true, false, "Jhalakathi", null, null, 0L },
                    { 29L, "ঝিনাইদহ", null, null, 3L, true, false, "Jhenaidah", null, null, 0L },
                    { 28L, "বাগেরহাট", null, null, 3L, true, false, "Bagerhat", null, null, 0L },
                    { 27L, "খুলনা", null, null, 3L, true, false, "Khulna", null, null, 0L },
                    { 25L, "কুষ্টিয়া", null, null, 3L, true, false, "Kushtia", null, null, 0L },
                    { 24L, "চুয়াডাঙ্গা", null, null, 3L, true, false, "Chuadanga", null, null, 0L },
                    { 26L, "মাগুরা", null, null, 3L, true, false, "Magura", null, null, 0L },
                    { 22L, "মেহেরপুর", null, null, 3L, true, false, "Meherpur", null, null, 0L },
                    { 21L, "সাতক্ষীরা", null, null, 3L, true, false, "Satkhira", null, null, 0L },
                    { 20L, "যশোর", null, null, 3L, true, false, "Jashore", null, null, 0L },
                    { 19L, "নওগাঁ", null, null, 2L, true, false, "Naogaon", null, null, 0L },
                    { 18L, "চাঁপাইনবাবগঞ্জ", null, null, 2L, true, false, "Chapainawabganj", null, null, 0L },
                    { 23L, "নড়াইল", null, null, 3L, true, false, "Narail", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 400L, "department.create", null, 4L, 1L, "Create" },
                    { 405L, "department.manage", null, 4L, 1L, "Manage" },
                    { 401L, "department.update", null, 4L, 1L, "Update" },
                    { 402L, "department.view", null, 4L, 1L, "View" },
                    { 404L, "department.list", null, 4L, 1L, "List" },
                    { 403L, "department.delete", null, 4L, 1L, "Delete" },
                    { 501L, "profile.update", null, 5L, 1L, "Update" },
                    { 604L, "book.list", null, 6L, 2L, "List" },
                    { 505L, "profile.manage", null, 5L, 1L, "Manage" },
                    { 600L, "book.create", null, 6L, 2L, "Create" },
                    { 601L, "book.update", null, 6L, 2L, "Update" },
                    { 602L, "book.view", null, 6L, 2L, "View" },
                    { 603L, "book.delete", null, 6L, 2L, "Delete" },
                    { 305L, "designation.manage", null, 3L, 1L, "Manage" },
                    { 502L, "profile.view", null, 5L, 1L, "View" },
                    { 303L, "designation.delete", null, 3L, 1L, "Delete" },
                    { 101L, "user.update", null, 1L, 1L, "Update" },
                    { 302L, "designation.view", null, 3L, 1L, "View" },
                    { 605L, "book.manage", null, 6L, 2L, "Manage" },
                    { 100L, "user.create", null, 1L, 1L, "Create" },
                    { 102L, "user.view", null, 1L, 1L, "View" },
                    { 104L, "user.list", null, 1L, 1L, "List" },
                    { 103L, "user.delete", null, 1L, 1L, "Delete" },
                    { 105L, "user.manage", null, 1L, 1L, "Manage" },
                    { 304L, "designation.list", null, 3L, 1L, "List" },
                    { 200L, "role.create", null, 2L, 1L, "Create" },
                    { 202L, "role.view", null, 2L, 1L, "View" },
                    { 204L, "role.list", null, 2L, 1L, "List" },
                    { 203L, "role.delete", null, 2L, 1L, "Delete" },
                    { 205L, "role.manage", null, 2L, 1L, "Manage" },
                    { 300L, "designation.create", null, 3L, 1L, "Create" },
                    { 301L, "designation.update", null, 3L, 1L, "Update" },
                    { 201L, "role.update", null, 2L, 1L, "Update" }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DepartmentId", "DesignationId", "Email", "EmailConfirmed", "EmployeeId", "FullName", "IsActive", "IsDeleted", "Mobile", "Password", "StatusId", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 1L, null, null, null, null, "admin@gmail.com", false, null, "Administrator", true, false, null, "l+0iiqNIdYjDQHR9FwJTzA==", 3L, false, null, null, 0L });

            migrationBuilder.InsertData(
                schema: "core",
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 5L, 505L, 1L },
                    { 4L, 405L, 1L },
                    { 3L, 305L, 1L },
                    { 2L, 205L, 1L },
                    { 1L, 105L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 327L, "ডামুড্যা", null, null, 42L, null, true, false, "Damudya", null, null, 0L },
                    { 328L, "আড়াইহাজার", null, null, 43L, null, true, false, "Araihazar", null, null, 0L },
                    { 329L, "বন্দর", null, null, 43L, null, true, false, "Bandar", null, null, 0L },
                    { 330L, "নারায়নগঞ্জ সদর", null, null, 43L, null, true, false, "Narayanganj Sadar", null, null, 0L },
                    { 331L, "রূপগঞ্জ", null, null, 43L, null, true, false, "Rupganj", null, null, 0L },
                    { 334L, "ভুয়াপুর", null, null, 44L, null, true, false, "Bhuapur", null, null, 0L },
                    { 333L, "বাসাইল", null, null, 44L, null, true, false, "Basail", null, null, 0L },
                    { 326L, "ভেদরগঞ্জ", null, null, 42L, null, true, false, "Bhedarganj", null, null, 0L },
                    { 335L, "দেলদুয়ার", null, null, 44L, null, true, false, "Delduar", null, null, 0L },
                    { 336L, "ঘাটাইল", null, null, 44L, null, true, false, "Ghatail", null, null, 0L },
                    { 337L, "গোপালপুর", null, null, 44L, null, true, false, "Gopalpur", null, null, 0L },
                    { 332L, "সোনারগাঁ", null, null, 43L, null, true, false, "Sonargaon", null, null, 0L },
                    { 325L, "গোসাইরহাট", null, null, 42L, null, true, false, "Gosairhat", null, null, 0L },
                    { 323L, "নড়িয়া", null, null, 42L, null, true, false, "Naria", null, null, 0L },
                    { 338L, "মধুপুর", null, null, 44L, null, true, false, "Madhupur", null, null, 0L },
                    { 322L, "শরিয়তপুর সদর", null, null, 42L, null, true, false, "Shariatpur Sadar", null, null, 0L },
                    { 321L, "শ্রীপুর", null, null, 41L, null, true, false, "Sreepur", null, null, 0L },
                    { 320L, "গাজীপুর সদর", null, null, 41L, null, true, false, "Gazipur Sadar", null, null, 0L },
                    { 319L, "কাপাসিয়া", null, null, 41L, null, true, false, "Kapasia", null, null, 0L },
                    { 318L, "কালিয়াকৈর", null, null, 41L, null, true, false, "Kaliakair", null, null, 0L },
                    { 317L, "কালীগঞ্জ", null, null, 41L, null, true, false, "Kaliganj", null, null, 0L },
                    { 316L, "শিবপুর", null, null, 40L, null, true, false, "Shibpur", null, null, 0L },
                    { 315L, "রায়পুরা", null, null, 40L, null, true, false, "Raipura", null, null, 0L },
                    { 314L, "পলাশ", null, null, 40L, null, true, false, "Palash", null, null, 0L },
                    { 313L, "নরসিংদী সদর", null, null, 40L, null, true, false, "Narsingdi Sadar", null, null, 0L },
                    { 312L, "মনোহরদী", null, null, 40L, null, true, false, "Monohardi", null, null, 0L },
                    { 324L, "জাজিরা", null, null, 42L, null, true, false, "Zajira", null, null, 0L },
                    { 339L, "মির্জাপুর", null, null, 44L, null, true, false, "Mirzapur", null, null, 0L },
                    { 342L, "টাঙ্গাইল সদর", null, null, 44L, null, true, false, "Tangail Sadar", null, null, 0L },
                    { 341L, "সখিপুর", null, null, 44L, null, true, false, "Sakhipur", null, null, 0L },
                    { 368L, "নবাবগঞ্জ", null, null, 47L, null, true, false, "Nawabganj", null, null, 0L },
                    { 367L, "কেরাণীগঞ্জ", null, null, 47L, null, true, false, "Keraniganj", null, null, 0L },
                    { 366L, "ধামরাই", null, null, 47L, null, true, false, "Dhamrai", null, null, 0L },
                    { 365L, "সাভার", null, null, 47L, null, true, false, "Savar", null, null, 0L },
                    { 364L, "সিংগাইর", null, null, 46L, null, true, false, "Singiar", null, null, 0L },
                    { 363L, "দৌলতপুর", null, null, 46L, null, true, false, "Doulatpur", null, null, 0L },
                    { 362L, "শিবালয়", null, null, 46L, null, true, false, "Shibaloy", null, null, 0L },
                    { 361L, "ঘিওর", null, null, 46L, null, true, false, "Gior", null, null, 0L },
                    { 360L, "মানিকগঞ্জ সদর", null, null, 46L, null, true, false, "Manikganj Sadar", null, null, 0L },
                    { 359L, "সাটুরিয়া", null, null, 46L, null, true, false, "Saturia", null, null, 0L },
                    { 358L, "হরিরামপুর", null, null, 46L, null, true, false, "Harirampur", null, null, 0L },
                    { 357L, "নিকলী", null, null, 45L, null, true, false, "Nikli", null, null, 0L },
                    { 356L, "মিঠামইন", null, null, 45L, null, true, false, "Mithamoin", null, null, 0L },
                    { 355L, "অষ্টগ্রাম", null, null, 45L, null, true, false, "Austagram", null, null, 0L },
                    { 354L, "বাজিতপুর", null, null, 45L, null, true, false, "Bajitpur", null, null, 0L },
                    { 353L, "করিমগঞ্জ", null, null, 45L, null, true, false, "Karimgonj", null, null, 0L },
                    { 352L, "কিশোরগঞ্জ সদর", null, null, 45L, null, true, false, "Kishoreganj Sadar", null, null, 0L },
                    { 351L, "কুলিয়ারচর", null, null, 45L, null, true, false, "Kuliarchar", null, null, 0L },
                    { 350L, "পাকুন্দিয়া", null, null, 45L, null, true, false, "Pakundia", null, null, 0L },
                    { 349L, "হোসেনপুর", null, null, 45L, null, true, false, "Hossainpur", null, null, 0L },
                    { 348L, "তাড়াইল", null, null, 45L, null, true, false, "Tarail", null, null, 0L },
                    { 347L, "ভৈরব", null, null, 45L, null, true, false, "Bhairab", null, null, 0L },
                    { 346L, "কটিয়াদী", null, null, 45L, null, true, false, "Katiadi", null, null, 0L },
                    { 345L, "ইটনা", null, null, 45L, null, true, false, "Itna", null, null, 0L },
                    { 344L, "ধনবাড়ী", null, null, 44L, null, true, false, "Dhanbari", null, null, 0L },
                    { 343L, "কালিহাতী", null, null, 44L, null, true, false, "Kalihati", null, null, 0L },
                    { 311L, "বেলাবো", null, null, 40L, null, true, false, "Belabo", null, null, 0L },
                    { 340L, "নাগরপুর", null, null, 44L, null, true, false, "Nagarpur", null, null, 0L },
                    { 310L, "দিরাই", null, null, 39L, null, true, false, "Derai", null, null, 0L },
                    { 308L, "জামালগঞ্জ", null, null, 39L, null, true, false, "Jamalganj", null, null, 0L },
                    { 369L, "দোহার", null, null, 47L, null, true, false, "Dohar", null, null, 0L },
                    { 276L, "ফেঞ্চুগঞ্জ", null, null, 36L, null, true, false, "Fenchuganj", null, null, 0L },
                    { 275L, "কোম্পানীগঞ্জ", null, null, 36L, null, true, false, "Companiganj", null, null, 0L },
                    { 274L, "বিশ্বনাথ", null, null, 36L, null, true, false, "Bishwanath", null, null, 0L },
                    { 273L, "বিয়ানীবাজার", null, null, 36L, null, true, false, "Beanibazar", null, null, 0L },
                    { 272L, "বালাগঞ্জ", null, null, 36L, null, true, false, "Balaganj", null, null, 0L },
                    { 271L, "তালতলি", null, null, 35L, null, true, false, "Taltali", null, null, 0L },
                    { 270L, "পাথরঘাটা", null, null, 35L, null, true, false, "Pathorghata", null, null, 0L },
                    { 269L, "বামনা", null, null, 35L, null, true, false, "Bamna", null, null, 0L },
                    { 268L, "বেতাগী", null, null, 35L, null, true, false, "Betagi", null, null, 0L },
                    { 267L, "বরগুনা সদর", null, null, 35L, null, true, false, "Barguna Sadar", null, null, 0L },
                    { 266L, "আমতলী", null, null, 35L, null, true, false, "Amtali", null, null, 0L },
                    { 265L, "লালমোহন", null, null, 34L, null, true, false, "Lalmohan", null, null, 0L },
                    { 277L, "গোলাপগঞ্জ", null, null, 36L, null, true, false, "Golapganj", null, null, 0L },
                    { 264L, "তজুমদ্দিন", null, null, 34L, null, true, false, "Tazumuddin", null, null, 0L },
                    { 262L, "দৌলতখান", null, null, 34L, null, true, false, "Doulatkhan", null, null, 0L },
                    { 261L, "চরফ্যাশন", null, null, 34L, null, true, false, "Charfesson", null, null, 0L },
                    { 260L, "বোরহান উদ্দিন", null, null, 34L, null, true, false, "Borhan Sddin", null, null, 0L },
                    { 259L, "ভোলা সদর", null, null, 34L, null, true, false, "Bhola Sadar", null, null, 0L },
                    { 258L, "হিজলা", null, null, 33L, null, true, false, "Hizla", null, null, 0L },
                    { 257L, "মুলাদী", null, null, 33L, null, true, false, "Muladi", null, null, 0L },
                    { 256L, "মেহেন্দিগঞ্জ", null, null, 33L, null, true, false, "Mehendiganj", null, null, 0L },
                    { 255L, "আগৈলঝাড়া", null, null, 33L, null, true, false, "Agailjhara", null, null, 0L },
                    { 254L, "গৌরনদী", null, null, 33L, null, true, false, "Gournadi", null, null, 0L },
                    { 253L, "বানারীপাড়া", null, null, 33L, null, true, false, "Banaripara", null, null, 0L },
                    { 252L, "উজিরপুর", null, null, 33L, null, true, false, "Wazirpur", null, null, 0L },
                    { 251L, "বাবুগঞ্জ", null, null, 33L, null, true, false, "Babuganj", null, null, 0L },
                    { 263L, "মনপুরা", null, null, 34L, null, true, false, "Monpura", null, null, 0L },
                    { 278L, "গোয়াইনঘাট", null, null, 36L, null, true, false, "Gowainghat", null, null, 0L },
                    { 279L, "জৈন্তাপুর", null, null, 36L, null, true, false, "Jaintiapur", null, null, 0L },
                    { 280L, "কানাইঘাট", null, null, 36L, null, true, false, "Kanaighat", null, null, 0L },
                    { 307L, "ধর্মপাশা", null, null, 39L, null, true, false, "Dharmapasha", null, null, 0L },
                    { 306L, "তাহিরপুর", null, null, 39L, null, true, false, "Tahirpur", null, null, 0L },
                    { 305L, "দোয়ারাবাজার", null, null, 39L, null, true, false, "Dowarabazar", null, null, 0L },
                    { 304L, "জগন্নাথপুর", null, null, 39L, null, true, false, "Jagannathpur", null, null, 0L },
                    { 303L, "ছাতক", null, null, 39L, null, true, false, "Chhatak", null, null, 0L },
                    { 302L, "বিশ্বম্ভরপুর", null, null, 39L, null, true, false, "Bishwambarpur", null, null, 0L },
                    { 301L, "দক্ষিণ সুনামগঞ্জ", null, null, 39L, null, true, false, "South Sunamganj", null, null, 0L },
                    { 300L, "সুনামগঞ্জ সদর", null, null, 39L, null, true, false, "Sunamganj Sadar", null, null, 0L },
                    { 299L, "মাধবপুর", null, null, 38L, null, true, false, "Madhabpur", null, null, 0L },
                    { 298L, "হবিগঞ্জ সদর", null, null, 38L, null, true, false, "Habiganj Sadar", null, null, 0L },
                    { 297L, "চুনারুঘাট", null, null, 38L, null, true, false, "Chunarughat", null, null, 0L },
                    { 296L, "লাখাই", null, null, 38L, null, true, false, "Lakhai", null, null, 0L },
                    { 295L, "বানিয়াচং", null, null, 38L, null, true, false, "Baniachong", null, null, 0L },
                    { 294L, "আজমিরীগঞ্জ", null, null, 38L, null, true, false, "Ajmiriganj", null, null, 0L },
                    { 293L, "বাহুবল", null, null, 38L, null, true, false, "Bahubal", null, null, 0L },
                    { 292L, "নবীগঞ্জ", null, null, 38L, null, true, false, "Nabiganj", null, null, 0L },
                    { 291L, "জুড়ী", null, null, 37L, null, true, false, "Juri", null, null, 0L },
                    { 290L, "শ্রীমঙ্গল", null, null, 37L, null, true, false, "Sreemangal", null, null, 0L },
                    { 289L, "রাজনগর", null, null, 37L, null, true, false, "Rajnagar", null, null, 0L },
                    { 288L, "মৌলভীবাজার সদর", null, null, 37L, null, true, false, "Moulvibazar Sadar", null, null, 0L },
                    { 287L, "কুলাউড়া", null, null, 37L, null, true, false, "Kulaura", null, null, 0L },
                    { 286L, "কমলগঞ্জ", null, null, 37L, null, true, false, "Kamolganj", null, null, 0L },
                    { 285L, "বড়লেখা", null, null, 37L, null, true, false, "Barlekha", null, null, 0L },
                    { 284L, "ওসমানী নগর", null, null, 36L, null, true, false, "Osmaninagar", null, null, 0L },
                    { 283L, "দক্ষিণ সুরমা", null, null, 36L, null, true, false, "Dakshinsurma", null, null, 0L },
                    { 282L, "জকিগঞ্জ", null, null, 36L, null, true, false, "Zakiganj", null, null, 0L },
                    { 281L, "সিলেট সদর", null, null, 36L, null, true, false, "Sylhet Sadar", null, null, 0L },
                    { 309L, "শাল্লা", null, null, 39L, null, true, false, "Shalla", null, null, 0L },
                    { 370L, "মুন্সিগঞ্জ সদর", null, null, 48L, null, true, false, "Munshiganj Sadar", null, null, 0L },
                    { 373L, "লৌহজং", null, null, 48L, null, true, false, "Louhajanj", null, null, 0L },
                    { 372L, "সিরাজদিখান", null, null, 48L, null, true, false, "Sirajdikhan", null, null, 0L },
                    { 460L, "নকলা", null, null, 61L, null, true, false, "Nokla", null, null, 0L },
                    { 459L, "শ্রীবরদী", null, null, 61L, null, true, false, "Sreebordi", null, null, 0L },
                    { 458L, "নালিতাবাড়ী", null, null, 61L, null, true, false, "Nalitabari", null, null, 0L },
                    { 457L, "শেরপুর সদর", null, null, 61L, null, true, false, "Sherpur Sadar", null, null, 0L },
                    { 456L, "চর রাজিবপুর", null, null, 60L, null, true, false, "Charrajibpur", null, null, 0L },
                    { 455L, "রৌমারী", null, null, 60L, null, true, false, "Rowmari", null, null, 0L },
                    { 454L, "চিলমারী", null, null, 60L, null, true, false, "Chilmari", null, null, 0L },
                    { 453L, "উলিপুর", null, null, 60L, null, true, false, "Ulipur", null, null, 0L },
                    { 452L, "রাজারহাট", null, null, 60L, null, true, false, "Rajarhat", null, null, 0L },
                    { 451L, "ফুলবাড়ী", null, null, 60L, null, true, false, "Phulbari", null, null, 0L },
                    { 450L, "ভুরুঙ্গামারী", null, null, 60L, null, true, false, "Bhurungamari", null, null, 0L },
                    { 449L, "নাগেশ্বরী", null, null, 60L, null, true, false, "Nageshwari", null, null, 0L },
                    { 461L, "ঝিনাইগাতী", null, null, 61L, null, true, false, "Jhenaigati", null, null, 0L },
                    { 448L, "কুড়িগ্রাম সদর", null, null, 60L, null, true, false, "Kurigram Sadar", null, null, 0L },
                    { 446L, "কাউনিয়া", null, null, 59L, null, true, false, "Kaunia", null, null, 0L },
                    { 445L, "পীরগঞ্জ", null, null, 59L, null, true, false, "Pirgonj", null, null, 0L },
                    { 444L, "মিঠাপুকুর", null, null, 59L, null, true, false, "Mithapukur", null, null, 0L },
                    { 443L, "বদরগঞ্জ", null, null, 59L, null, true, false, "Badargonj", null, null, 0L },
                    { 442L, "তারাগঞ্জ", null, null, 59L, null, true, false, "Taragonj", null, null, 0L },
                    { 441L, "গংগাচড়া", null, null, 59L, null, true, false, "Gangachara", null, null, 0L },
                    { 440L, "রংপুর সদর", null, null, 59L, null, true, false, "Rangpur Sadar", null, null, 0L },
                    { 439L, "বালিয়াডাঙ্গী", null, null, 58L, null, true, false, "Baliadangi", null, null, 0L },
                    { 438L, "হরিপুর", null, null, 58L, null, true, false, "Haripur", null, null, 0L },
                    { 437L, "রাণীশংকৈল", null, null, 58L, null, true, false, "Ranisankail", null, null, 0L },
                    { 436L, "পীরগঞ্জ", null, null, 58L, null, true, false, "Pirganj", null, null, 0L },
                    { 435L, "ঠাকুরগাঁও সদর", null, null, 58L, null, true, false, "Thakurgaon Sadar", null, null, 0L },
                    { 447L, "পীরগাছা", null, null, 59L, null, true, false, "Pirgacha", null, null, 0L },
                    { 462L, "ফুলবাড়ীয়া", null, null, 62L, null, true, false, "Fulbaria", null, null, 0L },
                    { 463L, "ত্রিশাল", null, null, 62L, null, true, false, "Trishal", null, null, 0L },
                    { 464L, "ভালুকা", null, null, 62L, null, true, false, "Bhaluka", null, null, 0L },
                    { 491L, "নেত্রকোণা সদর", null, null, 64L, null, true, false, "Netrokona Sadar", null, null, 0L },
                    { 490L, "পূর্বধলা", null, null, 64L, null, true, false, "Purbadhala", null, null, 0L },
                    { 489L, "মোহনগঞ্জ", null, null, 64L, null, true, false, "Mohongonj", null, null, 0L },
                    { 488L, "কলমাকান্দা", null, null, 64L, null, true, false, "Kalmakanda", null, null, 0L },
                    { 487L, "খালিয়াজুরী", null, null, 64L, null, true, false, "Khaliajuri", null, null, 0L },
                    { 486L, "মদন", null, null, 64L, null, true, false, "Madan", null, null, 0L },
                    { 485L, "আটপাড়া", null, null, 64L, null, true, false, "Atpara", null, null, 0L },
                    { 484L, "কেন্দুয়া", null, null, 64L, null, true, false, "Kendua", null, null, 0L },
                    { 483L, "দুর্গাপুর", null, null, 64L, null, true, false, "Durgapur", null, null, 0L },
                    { 482L, "বারহাট্টা", null, null, 64L, null, true, false, "Barhatta", null, null, 0L },
                    { 481L, "বকশীগঞ্জ", null, null, 63L, null, true, false, "Bokshiganj", null, null, 0L },
                    { 480L, "মাদারগঞ্জ", null, null, 63L, null, true, false, "Madarganj", null, null, 0L },
                    { 479L, "সরিষাবাড়ী", null, null, 63L, null, true, false, "Sarishabari", null, null, 0L },
                    { 478L, "দেওয়ানগঞ্জ", null, null, 63L, null, true, false, "Dewangonj", null, null, 0L },
                    { 477L, "ইসলামপুর", null, null, 63L, null, true, false, "Islampur", null, null, 0L },
                    { 476L, "মেলান্দহ", null, null, 63L, null, true, false, "Melandah", null, null, 0L },
                    { 475L, "জামালপুর সদর", null, null, 63L, null, true, false, "Jamalpur Sadar", null, null, 0L },
                    { 474L, "তারাকান্দা", null, null, 62L, null, true, false, "Tarakanda", null, null, 0L },
                    { 473L, "নান্দাইল", null, null, 62L, null, true, false, "Nandail", null, null, 0L },
                    { 472L, "ঈশ্বরগঞ্জ", null, null, 62L, null, true, false, "Iswarganj", null, null, 0L },
                    { 471L, "গফরগাঁও", null, null, 62L, null, true, false, "Gafargaon", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 470L, "গৌরীপুর", null, null, 62L, null, true, false, "Gouripur", null, null, 0L },
                    { 469L, "হালুয়াঘাট", null, null, 62L, null, true, false, "Haluaghat", null, null, 0L },
                    { 468L, "ফুলপুর", null, null, 62L, null, true, false, "Phulpur", null, null, 0L },
                    { 467L, "ধোবাউড়া", null, null, 62L, null, true, false, "Dhobaura", null, null, 0L },
                    { 466L, "ময়মনসিংহ সদর", null, null, 62L, null, true, false, "Mymensingh Sadar", null, null, 0L },
                    { 465L, "মুক্তাগাছা", null, null, 62L, null, true, false, "Muktagacha", null, null, 0L },
                    { 434L, "ফুলছড়ি", null, null, 57L, null, true, false, "Phulchari", null, null, 0L },
                    { 433L, "সুন্দরগঞ্জ", null, null, 57L, null, true, false, "Sundarganj", null, null, 0L },
                    { 432L, "গোবিন্দগঞ্জ", null, null, 57L, null, true, false, "Gobindaganj", null, null, 0L },
                    { 431L, "সাঘাটা", null, null, 57L, null, true, false, "Saghata", null, null, 0L },
                    { 399L, "পঞ্চগড় সদর", null, null, 53L, null, true, false, "Panchagarh Sadar", null, null, 0L },
                    { 398L, "সালথা", null, null, 52L, null, true, false, "Saltha", null, null, 0L },
                    { 397L, "মধুখালী", null, null, 52L, null, true, false, "Madhukhali", null, null, 0L },
                    { 396L, "চরভদ্রাসন", null, null, 52L, null, true, false, "Charbhadrasan", null, null, 0L },
                    { 395L, "ভাঙ্গা", null, null, 52L, null, true, false, "Bhanga", null, null, 0L },
                    { 394L, "নগরকান্দা", null, null, 52L, null, true, false, "Nagarkanda", null, null, 0L },
                    { 393L, "সদরপুর", null, null, 52L, null, true, false, "Sadarpur", null, null, 0L },
                    { 392L, "বোয়ালমারী", null, null, 52L, null, true, false, "Boalmari", null, null, 0L },
                    { 391L, "আলফাডাঙ্গা", null, null, 52L, null, true, false, "Alfadanga", null, null, 0L },
                    { 390L, "ফরিদপুর সদর", null, null, 52L, null, true, false, "Faridpur Sadar", null, null, 0L },
                    { 389L, "মুকসুদপুর", null, null, 51L, null, true, false, "Muksudpur", null, null, 0L },
                    { 388L, "কোটালীপাড়া", null, null, 51L, null, true, false, "Kotalipara", null, null, 0L },
                    { 387L, "টুংগীপাড়া", null, null, 51L, null, true, false, "Tungipara", null, null, 0L },
                    { 386L, "কাশিয়ানী", null, null, 51L, null, true, false, "Kashiani", null, null, 0L },
                    { 385L, "গোপালগঞ্জ সদর", null, null, 51L, null, true, false, "Gopalganj Sadar", null, null, 0L },
                    { 384L, "রাজৈর", null, null, 50L, null, true, false, "Rajoir", null, null, 0L },
                    { 383L, "কালকিনি", null, null, 50L, null, true, false, "Kalkini", null, null, 0L },
                    { 382L, "শিবচর", null, null, 50L, null, true, false, "Shibchar", null, null, 0L },
                    { 381L, "মাদারীপুর সদর", null, null, 50L, null, true, false, "Madaripur Sadar", null, null, 0L },
                    { 380L, "কালুখালী", null, null, 49L, null, true, false, "Kalukhali", null, null, 0L },
                    { 379L, "বালিয়াকান্দি", null, null, 49L, null, true, false, "Baliakandi", null, null, 0L },
                    { 378L, "পাংশা", null, null, 49L, null, true, false, "Pangsa", null, null, 0L },
                    { 377L, "গোয়ালন্দ", null, null, 49L, null, true, false, "Goalanda", null, null, 0L },
                    { 376L, "রাজবাড়ী সদর", null, null, 49L, null, true, false, "Rajbari Sadar", null, null, 0L },
                    { 375L, "টংগীবাড়ি", null, null, 48L, null, true, false, "Tongibari", null, null, 0L },
                    { 374L, "গজারিয়া", null, null, 48L, null, true, false, "Gajaria", null, null, 0L },
                    { 250L, "বাকেরগঞ্জ", null, null, 33L, null, true, false, "Bakerganj", null, null, 0L },
                    { 400L, "দেবীগঞ্জ", null, null, 53L, null, true, false, "Debiganj", null, null, 0L },
                    { 371L, "শ্রীনগর", null, null, 48L, null, true, false, "Sreenagar", null, null, 0L },
                    { 401L, "বোদা", null, null, 53L, null, true, false, "Boda", null, null, 0L },
                    { 403L, "তেতুলিয়া", null, null, 53L, null, true, false, "Tetulia", null, null, 0L },
                    { 430L, "পলাশবাড়ী", null, null, 57L, null, true, false, "Palashbari", null, null, 0L },
                    { 429L, "গাইবান্ধা সদর", null, null, 57L, null, true, false, "Gaibandha Sadar", null, null, 0L },
                    { 428L, "সাদুল্লাপুর", null, null, 57L, null, true, false, "Sadullapur", null, null, 0L },
                    { 427L, "নীলফামারী সদর", null, null, 56L, null, true, false, "Nilphamari Sadar", null, null, 0L },
                    { 426L, "কিশোরগঞ্জ", null, null, 56L, null, true, false, "Kishorganj", null, null, 0L },
                    { 425L, "জলঢাকা", null, null, 56L, null, true, false, "Jaldhaka", null, null, 0L },
                    { 424L, "ডিমলা", null, null, 56L, null, true, false, "Dimla", null, null, 0L },
                    { 423L, "ডোমার", null, null, 56L, null, true, false, "Domar", null, null, 0L },
                    { 422L, "সৈয়দপুর", null, null, 56L, null, true, false, "Syedpur", null, null, 0L },
                    { 421L, "আদিতমারী", null, null, 55L, null, true, false, "Aditmari", null, null, 0L },
                    { 420L, "পাটগ্রাম", null, null, 55L, null, true, false, "Patgram", null, null, 0L },
                    { 419L, "হাতীবান্ধা", null, null, 55L, null, true, false, "Hatibandha", null, null, 0L },
                    { 418L, "কালীগঞ্জ", null, null, 55L, null, true, false, "Kaliganj", null, null, 0L },
                    { 417L, "লালমনিরহাট সদর", null, null, 55L, null, true, false, "Lalmonirhat Sadar", null, null, 0L },
                    { 416L, "চিরিরবন্দর", null, null, 54L, null, true, false, "Chirirbandar", null, null, 0L },
                    { 415L, "বিরল", null, null, 54L, null, true, false, "Birol", null, null, 0L },
                    { 414L, "খানসামা", null, null, 54L, null, true, false, "Khansama", null, null, 0L },
                    { 413L, "হাকিমপুর", null, null, 54L, null, true, false, "Hakimpur", null, null, 0L },
                    { 412L, "দিনাজপুর সদর", null, null, 54L, null, true, false, "Dinajpur Sadar", null, null, 0L },
                    { 411L, "ফুলবাড়ী", null, null, 54L, null, true, false, "Fulbari", null, null, 0L },
                    { 410L, "কাহারোল", null, null, 54L, null, true, false, "Kaharol", null, null, 0L },
                    { 409L, "বোচাগঞ্জ", null, null, 54L, null, true, false, "Bochaganj", null, null, 0L },
                    { 408L, "পার্বতীপুর", null, null, 54L, null, true, false, "Parbatipur", null, null, 0L },
                    { 407L, "বিরামপুর", null, null, 54L, null, true, false, "Birampur", null, null, 0L },
                    { 406L, "ঘোড়াঘাট", null, null, 54L, null, true, false, "Ghoraghat", null, null, 0L },
                    { 405L, "বীরগঞ্জ", null, null, 54L, null, true, false, "Birganj", null, null, 0L },
                    { 404L, "নবাবগঞ্জ", null, null, 54L, null, true, false, "Nawabganj", null, null, 0L },
                    { 402L, "আটোয়ারী", null, null, 53L, null, true, false, "Atwari", null, null, 0L },
                    { 1L, "দেবিদ্বার", null, null, 1L, null, true, false, "Debidwar", null, null, 0L },
                    { 249L, "বরিশাল সদর", null, null, 33L, null, true, false, "Barisal Sadar", null, null, 0L },
                    { 247L, "মঠবাড়ীয়া", null, null, 32L, null, true, false, "Mathbaria", null, null, 0L },
                    { 90L, "পানছড়ি", null, null, 10L, null, true, false, "Panchari", null, null, 0L },
                    { 89L, "দিঘীনালা", null, null, 10L, null, true, false, "Dighinala", null, null, 0L },
                    { 88L, "খাগড়াছড়ি সদর", null, null, 10L, null, true, false, "Khagrachhari Sadar", null, null, 0L },
                    { 87L, "টেকনাফ", null, null, 9L, null, true, false, "Teknaf", null, null, 0L },
                    { 86L, "রামু", null, null, 9L, null, true, false, "Ramu", null, null, 0L },
                    { 85L, "পেকুয়া", null, null, 9L, null, true, false, "Pekua", null, null, 0L },
                    { 84L, "মহেশখালী", null, null, 9L, null, true, false, "Moheshkhali", null, null, 0L },
                    { 83L, "উখিয়া", null, null, 9L, null, true, false, "Ukhiya", null, null, 0L },
                    { 82L, "কুতুবদিয়া", null, null, 9L, null, true, false, "Kutubdia", null, null, 0L },
                    { 81L, "চকরিয়া", null, null, 9L, null, true, false, "Chakaria", null, null, 0L },
                    { 80L, "কক্সবাজার সদর", null, null, 9L, null, true, false, "Coxsbazar Sadar", null, null, 0L },
                    { 79L, "কর্ণফুলী", null, null, 8L, null, true, false, "Karnafuli", null, null, 0L },
                    { 78L, "রাউজান", null, null, 8L, null, true, false, "Raozan", null, null, 0L },
                    { 77L, "ফটিকছড়ি", null, null, 8L, null, true, false, "Fatikchhari", null, null, 0L },
                    { 76L, "হাটহাজারী", null, null, 8L, null, true, false, "Hathazari", null, null, 0L },
                    { 75L, "লোহাগাড়া", null, null, 8L, null, true, false, "Lohagara", null, null, 0L },
                    { 74L, "সাতকানিয়া", null, null, 8L, null, true, false, "Satkania", null, null, 0L },
                    { 73L, "চন্দনাইশ", null, null, 8L, null, true, false, "Chandanaish", null, null, 0L },
                    { 72L, "আনোয়ারা", null, null, 8L, null, true, false, "Anwara", null, null, 0L },
                    { 71L, "বোয়ালখালী", null, null, 8L, null, true, false, "Boalkhali", null, null, 0L },
                    { 70L, "বাঁশখালী", null, null, 8L, null, true, false, "Banshkhali", null, null, 0L },
                    { 69L, "সন্দ্বীপ", null, null, 8L, null, true, false, "Sandwip", null, null, 0L },
                    { 68L, "পটিয়া", null, null, 8L, null, true, false, "Patiya", null, null, 0L },
                    { 67L, "মীরসরাই", null, null, 8L, null, true, false, "Mirsharai", null, null, 0L },
                    { 66L, "সীতাকুন্ড", null, null, 8L, null, true, false, "Sitakunda", null, null, 0L },
                    { 65L, "রাঙ্গুনিয়া", null, null, 8L, null, true, false, "Rangunia", null, null, 0L },
                    { 64L, "রামগঞ্জ", null, null, 7L, null, true, false, "Ramganj", null, null, 0L },
                    { 91L, "লক্ষীছড়ি", null, null, 10L, null, true, false, "Laxmichhari", null, null, 0L },
                    { 63L, "রামগতি", null, null, 7L, null, true, false, "Ramgati", null, null, 0L },
                    { 92L, "মহালছড়ি", null, null, 10L, null, true, false, "Mohalchari", null, null, 0L },
                    { 94L, "রামগড়", null, null, 10L, null, true, false, "Ramgarh", null, null, 0L },
                    { 121L, "ফরিদপুর", null, null, 13L, null, true, false, "Faridpur", null, null, 0L },
                    { 120L, "সাঁথিয়া", null, null, 13L, null, true, false, "Santhia", null, null, 0L },
                    { 119L, "চাটমোহর", null, null, 13L, null, true, false, "Chatmohar", null, null, 0L },
                    { 118L, "আটঘরিয়া", null, null, 13L, null, true, false, "Atghoria", null, null, 0L },
                    { 117L, "বেড়া", null, null, 13L, null, true, false, "Bera", null, null, 0L },
                    { 116L, "পাবনা সদর", null, null, 13L, null, true, false, "Pabna Sadar", null, null, 0L },
                    { 115L, "ভাঙ্গুড়া", null, null, 13L, null, true, false, "Bhangura", null, null, 0L },
                    { 114L, "ঈশ্বরদী", null, null, 13L, null, true, false, "Ishurdi", null, null, 0L },
                    { 113L, "সুজানগর", null, null, 13L, null, true, false, "Sujanagar", null, null, 0L },
                    { 112L, "উল্লাপাড়া", null, null, 12L, null, true, false, "Ullapara", null, null, 0L },
                    { 111L, "তাড়াশ", null, null, 12L, null, true, false, "Tarash", null, null, 0L },
                    { 110L, "সিরাজগঞ্জ সদর", null, null, 12L, null, true, false, "Sirajganj Sadar", null, null, 0L },
                    { 109L, "শাহজাদপুর", null, null, 12L, null, true, false, "Shahjadpur", null, null, 0L },
                    { 108L, "রায়গঞ্জ", null, null, 12L, null, true, false, "Raigonj", null, null, 0L },
                    { 107L, "কাজীপুর", null, null, 12L, null, true, false, "Kazipur", null, null, 0L },
                    { 106L, "কামারখন্দ", null, null, 12L, null, true, false, "Kamarkhand", null, null, 0L },
                    { 105L, "চৌহালি", null, null, 12L, null, true, false, "Chauhali", null, null, 0L },
                    { 104L, "বেলকুচি", null, null, 12L, null, true, false, "Belkuchi", null, null, 0L },
                    { 103L, "থানচি", null, null, 11L, null, true, false, "Thanchi", null, null, 0L },
                    { 102L, "রুমা", null, null, 11L, null, true, false, "Ruma", null, null, 0L },
                    { 101L, "লামা", null, null, 11L, null, true, false, "Lama", null, null, 0L },
                    { 100L, "রোয়াংছড়ি", null, null, 11L, null, true, false, "Rowangchhari", null, null, 0L },
                    { 99L, "নাইক্ষ্যংছড়ি", null, null, 11L, null, true, false, "Naikhongchhari", null, null, 0L },
                    { 98L, "আলীকদম", null, null, 11L, null, true, false, "Alikadam", null, null, 0L },
                    { 97L, "বান্দরবান সদর", null, null, 11L, null, true, false, "Bandarban Sadar", null, null, 0L },
                    { 96L, "গুইমারা", null, null, 10L, null, true, false, "Guimara", null, null, 0L },
                    { 95L, "মাটিরাঙ্গা", null, null, 10L, null, true, false, "Matiranga", null, null, 0L },
                    { 93L, "মানিকছড়ি", null, null, 10L, null, true, false, "Manikchari", null, null, 0L },
                    { 122L, "কাহালু", null, null, 14L, null, true, false, "Kahaloo", null, null, 0L },
                    { 62L, "রায়পুর", null, null, 7L, null, true, false, "Raipur", null, null, 0L },
                    { 60L, "লক্ষ্মীপুর সদর", null, null, 7L, null, true, false, "Lakshmipur Sadar", null, null, 0L },
                    { 28L, "আশুগঞ্জ", null, null, 3L, null, true, false, "Ashuganj", null, null, 0L },
                    { 27L, "সরাইল", null, null, 3L, null, true, false, "Sarail", null, null, 0L },
                    { 26L, "নাসিরনগর", null, null, 3L, null, true, false, "Nasirnagar", null, null, 0L },
                    { 25L, "কসবা", null, null, 3L, null, true, false, "Kasba", null, null, 0L },
                    { 24L, "ব্রাহ্মণবাড়িয়া সদর", null, null, 3L, null, true, false, "Brahmanbaria Sadar", null, null, 0L },
                    { 23L, "দাগনভূঞা", null, null, 2L, null, true, false, "Daganbhuiyan", null, null, 0L },
                    { 22L, "পরশুরাম", null, null, 2L, null, true, false, "Parshuram", null, null, 0L },
                    { 21L, "ফুলগাজী", null, null, 2L, null, true, false, "Fulgazi", null, null, 0L },
                    { 20L, "সোনাগাজী", null, null, 2L, null, true, false, "Sonagazi", null, null, 0L },
                    { 19L, "ফেনী সদর", null, null, 2L, null, true, false, "Feni Sadar", null, null, 0L },
                    { 18L, "ছাগলনাইয়া", null, null, 2L, null, true, false, "Chhagalnaiya", null, null, 0L },
                    { 17L, "লালমাই", null, null, 1L, null, true, false, "Lalmai", null, null, 0L },
                    { 16L, "বুড়িচং", null, null, 1L, null, true, false, "Burichang", null, null, 0L },
                    { 15L, "তিতাস", null, null, 1L, null, true, false, "Titas", null, null, 0L },
                    { 14L, "সদর দক্ষিণ", null, null, 1L, null, true, false, "Sadarsouth", null, null, 0L },
                    { 13L, "মনোহরগঞ্জ", null, null, 1L, null, true, false, "Monohargonj", null, null, 0L },
                    { 12L, "মেঘনা", null, null, 1L, null, true, false, "Meghna", null, null, 0L },
                    { 11L, "কুমিল্লা সদর", null, null, 1L, null, true, false, "Comilla Sadar", null, null, 0L },
                    { 10L, "নাঙ্গলকোট", null, null, 1L, null, true, false, "Nangalkot", null, null, 0L },
                    { 9L, "মুরাদনগর", null, null, 1L, null, true, false, "Muradnagar", null, null, 0L },
                    { 8L, "লাকসাম", null, null, 1L, null, true, false, "Laksam", null, null, 0L },
                    { 7L, "হোমনা", null, null, 1L, null, true, false, "Homna", null, null, 0L },
                    { 6L, "দাউদকান্দি", null, null, 1L, null, true, false, "Daudkandi", null, null, 0L },
                    { 5L, "চৌদ্দগ্রাম", null, null, 1L, null, true, false, "Chauddagram", null, null, 0L },
                    { 4L, "চান্দিনা", null, null, 1L, null, true, false, "Chandina", null, null, 0L },
                    { 3L, "ব্রাহ্মণপাড়া", null, null, 1L, null, true, false, "Brahmanpara", null, null, 0L },
                    { 2L, "বরুড়া", null, null, 1L, null, true, false, "Barura", null, null, 0L },
                    { 29L, "আখাউড়া", null, null, 3L, null, true, false, "Akhaura", null, null, 0L },
                    { 61L, "কমলনগর", null, null, 7L, null, true, false, "Kamalnagar", null, null, 0L },
                    { 30L, "নবীনগর", null, null, 3L, null, true, false, "Nabinagar", null, null, 0L },
                    { 32L, "বিজয়নগর", null, null, 3L, null, true, false, "Bijoynagar", null, null, 0L },
                    { 59L, "ফরিদগঞ্জ", null, null, 6L, null, true, false, "Faridgonj", null, null, 0L },
                    { 58L, "মতলব উত্তর", null, null, 6L, null, true, false, "Matlab North", null, null, 0L },
                    { 57L, "হাজীগঞ্জ", null, null, 6L, null, true, false, "Hajiganj", null, null, 0L },
                    { 56L, "মতলব দক্ষিণ", null, null, 6L, null, true, false, "Matlab South", null, null, 0L },
                    { 55L, "চাঁদপুর সদর", null, null, 6L, null, true, false, "Chandpur Sadar", null, null, 0L },
                    { 54L, "শাহরাস্তি", null, null, 6L, null, true, false, "Shahrasti", null, null, 0L },
                    { 53L, "কচুয়া", null, null, 6L, null, true, false, "Kachua", null, null, 0L },
                    { 52L, "হাইমচর", null, null, 6L, null, true, false, "Haimchar", null, null, 0L },
                    { 51L, "সোনাইমুড়ী", null, null, 5L, null, true, false, "Sonaimori", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 50L, "চাটখিল", null, null, 5L, null, true, false, "Chatkhil", null, null, 0L },
                    { 49L, "সেনবাগ", null, null, 5L, null, true, false, "Senbug", null, null, 0L },
                    { 48L, "কবিরহাট", null, null, 5L, null, true, false, "Kabirhat", null, null, 0L },
                    { 47L, "সুবর্ণচর", null, null, 5L, null, true, false, "Subarnachar", null, null, 0L },
                    { 46L, "হাতিয়া", null, null, 5L, null, true, false, "Hatia", null, null, 0L },
                    { 45L, "বেগমগঞ্জ", null, null, 5L, null, true, false, "Begumganj", null, null, 0L },
                    { 44L, "কোম্পানীগঞ্জ", null, null, 5L, null, true, false, "Companiganj", null, null, 0L },
                    { 43L, "নোয়াখালী সদর", null, null, 5L, null, true, false, "Noakhali Sadar", null, null, 0L },
                    { 42L, "নানিয়ারচর", null, null, 4L, null, true, false, "Naniarchar", null, null, 0L },
                    { 41L, "জুরাছড়ি", null, null, 4L, null, true, false, "Juraichari", null, null, 0L },
                    { 40L, "বিলাইছড়ি", null, null, 4L, null, true, false, "Belaichari", null, null, 0L },
                    { 39L, "রাজস্থলী", null, null, 4L, null, true, false, "Rajasthali", null, null, 0L },
                    { 38L, "লংগদু", null, null, 4L, null, true, false, "Langadu", null, null, 0L },
                    { 37L, "বরকল", null, null, 4L, null, true, false, "Barkal", null, null, 0L },
                    { 36L, "বাঘাইছড়ি", null, null, 4L, null, true, false, "Baghaichari", null, null, 0L },
                    { 35L, "কাউখালী", null, null, 4L, null, true, false, "Kawkhali", null, null, 0L },
                    { 34L, "কাপ্তাই", null, null, 4L, null, true, false, "Kaptai", null, null, 0L },
                    { 33L, "রাঙ্গামাটি সদর", null, null, 4L, null, true, false, "Rangamati Sadar", null, null, 0L },
                    { 31L, "বাঞ্ছারামপুর", null, null, 3L, null, true, false, "Bancharampur", null, null, 0L },
                    { 123L, "বগুড়া সদর", null, null, 14L, null, true, false, "Bogra Sadar", null, null, 0L },
                    { 124L, "সারিয়াকান্দি", null, null, 14L, null, true, false, "Shariakandi", null, null, 0L },
                    { 125L, "শাজাহানপুর", null, null, 14L, null, true, false, "Shajahanpur", null, null, 0L },
                    { 215L, "ফকিরহাট", null, null, 28L, null, true, false, "Fakirhat", null, null, 0L },
                    { 214L, "কয়রা", null, null, 27L, null, true, false, "Koyra", null, null, 0L },
                    { 213L, "দাকোপ", null, null, 27L, null, true, false, "Dakop", null, null, 0L },
                    { 212L, "বটিয়াঘাটা", null, null, 27L, null, true, false, "Botiaghata", null, null, 0L },
                    { 211L, "ডুমুরিয়া", null, null, 27L, null, true, false, "Dumuria", null, null, 0L },
                    { 210L, "তেরখাদা", null, null, 27L, null, true, false, "Terokhada", null, null, 0L },
                    { 209L, "রূপসা", null, null, 27L, null, true, false, "Rupsha", null, null, 0L },
                    { 208L, "দিঘলিয়া", null, null, 27L, null, true, false, "Digholia", null, null, 0L },
                    { 207L, "ফুলতলা", null, null, 27L, null, true, false, "Fultola", null, null, 0L },
                    { 206L, "পাইকগাছা", null, null, 27L, null, true, false, "Paikgasa", null, null, 0L },
                    { 205L, "মহম্মদপুর", null, null, 26L, null, true, false, "Mohammadpur", null, null, 0L },
                    { 204L, "মাগুরা সদর", null, null, 26L, null, true, false, "Magura Sadar", null, null, 0L },
                    { 203L, "শ্রীপুর", null, null, 26L, null, true, false, "Sreepur", null, null, 0L },
                    { 202L, "শালিখা", null, null, 26L, null, true, false, "Shalikha", null, null, 0L },
                    { 201L, "ভেড়ামারা", null, null, 25L, null, true, false, "Bheramara", null, null, 0L },
                    { 200L, "দৌলতপুর", null, null, 25L, null, true, false, "Daulatpur", null, null, 0L },
                    { 199L, "মিরপুর", null, null, 25L, null, true, false, "Mirpur", null, null, 0L },
                    { 198L, "খোকসা", null, null, 25L, null, true, false, "Khoksa", null, null, 0L },
                    { 197L, "কুমারখালী", null, null, 25L, null, true, false, "Kumarkhali", null, null, 0L },
                    { 196L, "কুষ্টিয়া সদর", null, null, 25L, null, true, false, "Kushtia Sadar", null, null, 0L },
                    { 195L, "জীবননগর", null, null, 24L, null, true, false, "Jibannagar", null, null, 0L },
                    { 194L, "দামুড়হুদা", null, null, 24L, null, true, false, "Damurhuda", null, null, 0L },
                    { 193L, "আলমডাঙ্গা", null, null, 24L, null, true, false, "Alamdanga", null, null, 0L },
                    { 192L, "চুয়াডাঙ্গা সদর", null, null, 24L, null, true, false, "Chuadanga Sadar", null, null, 0L },
                    { 191L, "কালিয়া", null, null, 23L, null, true, false, "Kalia", null, null, 0L },
                    { 190L, "লোহাগড়া", null, null, 23L, null, true, false, "Lohagara", null, null, 0L },
                    { 189L, "নড়াইল সদর", null, null, 23L, null, true, false, "Narail Sadar", null, null, 0L },
                    { 216L, "বাগেরহাট সদর", null, null, 28L, null, true, false, "Bagerhat Sadar", null, null, 0L },
                    { 188L, "গাংনী", null, null, 22L, null, true, false, "Gangni", null, null, 0L },
                    { 217L, "মোল্লাহাট", null, null, 28L, null, true, false, "Mollahat", null, null, 0L },
                    { 219L, "রামপাল", null, null, 28L, null, true, false, "Rampal", null, null, 0L },
                    { 246L, "ভান্ডারিয়া", null, null, 32L, null, true, false, "Bhandaria", null, null, 0L },
                    { 245L, "জিয়ানগর", null, null, 32L, null, true, false, "Zianagar", null, null, 0L },
                    { 244L, "কাউখালী", null, null, 32L, null, true, false, "Kawkhali", null, null, 0L },
                    { 243L, "নাজিরপুর", null, null, 32L, null, true, false, "Nazirpur", null, null, 0L },
                    { 242L, "পিরোজপুর সদর", null, null, 32L, null, true, false, "Pirojpur Sadar", null, null, 0L },
                    { 241L, "রাঙ্গাবালী", null, null, 31L, null, true, false, "Rangabali", null, null, 0L },
                    { 240L, "গলাচিপা", null, null, 31L, null, true, false, "Galachipa", null, null, 0L },
                    { 239L, "মির্জাগঞ্জ", null, null, 31L, null, true, false, "Mirzaganj", null, null, 0L },
                    { 238L, "কলাপাড়া", null, null, 31L, null, true, false, "Kalapara", null, null, 0L },
                    { 237L, "দশমিনা", null, null, 31L, null, true, false, "Dashmina", null, null, 0L },
                    { 236L, "দুমকি", null, null, 31L, null, true, false, "Dumki", null, null, 0L },
                    { 235L, "পটুয়াখালী সদর", null, null, 31L, null, true, false, "Patuakhali Sadar", null, null, 0L },
                    { 234L, "বাউফল", null, null, 31L, null, true, false, "Bauphal", null, null, 0L },
                    { 233L, "রাজাপুর", null, null, 30L, null, true, false, "Rajapur", null, null, 0L },
                    { 232L, "নলছিটি", null, null, 30L, null, true, false, "Nalchity", null, null, 0L },
                    { 231L, "কাঠালিয়া", null, null, 30L, null, true, false, "Kathalia", null, null, 0L },
                    { 230L, "ঝালকাঠি সদর", null, null, 30L, null, true, false, "Jhalakathi Sadar", null, null, 0L },
                    { 229L, "মহেশপুর", null, null, 29L, null, true, false, "Moheshpur", null, null, 0L },
                    { 228L, "কোটচাঁদপুর", null, null, 29L, null, true, false, "Kotchandpur", null, null, 0L },
                    { 227L, "কালীগঞ্জ", null, null, 29L, null, true, false, "Kaliganj", null, null, 0L },
                    { 226L, "হরিণাকুন্ডু", null, null, 29L, null, true, false, "Harinakundu", null, null, 0L },
                    { 225L, "শৈলকুপা", null, null, 29L, null, true, false, "Shailkupa", null, null, 0L },
                    { 224L, "ঝিনাইদহ সদর", null, null, 29L, null, true, false, "Jhenaidah Sadar", null, null, 0L },
                    { 223L, "চিতলমারী", null, null, 28L, null, true, false, "Chitalmari", null, null, 0L },
                    { 222L, "মোংলা", null, null, 28L, null, true, false, "Mongla", null, null, 0L },
                    { 221L, "কচুয়া", null, null, 28L, null, true, false, "Kachua", null, null, 0L },
                    { 220L, "মোড়েলগঞ্জ", null, null, 28L, null, true, false, "Morrelganj", null, null, 0L },
                    { 218L, "শরণখোলা", null, null, 28L, null, true, false, "Sarankhola", null, null, 0L },
                    { 187L, "মেহেরপুর সদর", null, null, 22L, null, true, false, "Meherpur Sadar", null, null, 0L },
                    { 186L, "মুজিবনগর", null, null, 22L, null, true, false, "Mujibnagar", null, null, 0L },
                    { 185L, "কালিগঞ্জ", null, null, 21L, null, true, false, "Kaliganj", null, null, 0L },
                    { 152L, "ক্ষেতলাল", null, null, 17L, null, true, false, "Khetlal", null, null, 0L },
                    { 151L, "কালাই", null, null, 17L, null, true, false, "Kalai", null, null, 0L },
                    { 150L, "আক্কেলপুর", null, null, 17L, null, true, false, "Akkelpur", null, null, 0L },
                    { 149L, "নলডাঙ্গা", null, null, 16L, null, true, false, "Naldanga", null, null, 0L },
                    { 148L, "গুরুদাসপুর", null, null, 16L, null, true, false, "Gurudaspur", null, null, 0L },
                    { 147L, "লালপুর", null, null, 16L, null, true, false, "Lalpur", null, null, 0L },
                    { 146L, "বাগাতিপাড়া", null, null, 16L, null, true, false, "Bagatipara", null, null, 0L },
                    { 145L, "বড়াইগ্রাম", null, null, 16L, null, true, false, "Baraigram", null, null, 0L },
                    { 144L, "সিংড়া", null, null, 16L, null, true, false, "Singra", null, null, 0L },
                    { 143L, "নাটোর সদর", null, null, 16L, null, true, false, "Natore Sadar", null, null, 0L },
                    { 142L, "বাগমারা", null, null, 15L, null, true, false, "Bagmara", null, null, 0L },
                    { 141L, "তানোর", null, null, 15L, null, true, false, "Tanore", null, null, 0L },
                    { 140L, "গোদাগাড়ী", null, null, 15L, null, true, false, "Godagari", null, null, 0L },
                    { 139L, "বাঘা", null, null, 15L, null, true, false, "Bagha", null, null, 0L },
                    { 138L, "পুঠিয়া", null, null, 15L, null, true, false, "Puthia", null, null, 0L },
                    { 137L, "চারঘাট", null, null, 15L, null, true, false, "Charghat", null, null, 0L },
                    { 136L, "মোহনপুর", null, null, 15L, null, true, false, "Mohonpur", null, null, 0L },
                    { 135L, "দুর্গাপুর", null, null, 15L, null, true, false, "Durgapur", null, null, 0L },
                    { 134L, "পবা", null, null, 15L, null, true, false, "Paba", null, null, 0L },
                    { 133L, "শিবগঞ্জ", null, null, 14L, null, true, false, "Shibganj", null, null, 0L },
                    { 132L, "শেরপুর", null, null, 14L, null, true, false, "Sherpur", null, null, 0L },
                    { 131L, "গাবতলী", null, null, 14L, null, true, false, "Gabtali", null, null, 0L },
                    { 130L, "ধুনট", null, null, 14L, null, true, false, "Dhunot", null, null, 0L },
                    { 129L, "সোনাতলা", null, null, 14L, null, true, false, "Sonatala", null, null, 0L },
                    { 128L, "নন্দিগ্রাম", null, null, 14L, null, true, false, "Nondigram", null, null, 0L },
                    { 127L, "আদমদিঘি", null, null, 14L, null, true, false, "Adamdighi", null, null, 0L },
                    { 126L, "দুপচাচিঁয়া", null, null, 14L, null, true, false, "Dupchanchia", null, null, 0L },
                    { 153L, "পাঁচবিবি", null, null, 17L, null, true, false, "Panchbibi", null, null, 0L },
                    { 154L, "জয়পুরহাট সদর", null, null, 17L, null, true, false, "Joypurhat Sadar", null, null, 0L },
                    { 155L, "চাঁপাইনবাবগঞ্জ সদর", null, null, 18L, null, true, false, "Chapainawabganj Sadar", null, null, 0L },
                    { 156L, "গোমস্তাপুর", null, null, 18L, null, true, false, "Gomostapur", null, null, 0L },
                    { 184L, "তালা", null, null, 21L, null, true, false, "Tala", null, null, 0L },
                    { 183L, "শ্যামনগর", null, null, 21L, null, true, false, "Shyamnagar", null, null, 0L },
                    { 182L, "সাতক্ষীরা সদর", null, null, 21L, null, true, false, "Satkhira Sadar", null, null, 0L },
                    { 181L, "কলারোয়া", null, null, 21L, null, true, false, "Kalaroa", null, null, 0L },
                    { 180L, "দেবহাটা", null, null, 21L, null, true, false, "Debhata", null, null, 0L },
                    { 179L, "আশাশুনি", null, null, 21L, null, true, false, "Assasuni", null, null, 0L },
                    { 178L, "শার্শা", null, null, 20L, null, true, false, "Sharsha", null, null, 0L },
                    { 177L, "যশোর সদর", null, null, 20L, null, true, false, "Jessore Sadar", null, null, 0L },
                    { 176L, "কেশবপুর", null, null, 20L, null, true, false, "Keshabpur", null, null, 0L },
                    { 175L, "ঝিকরগাছা", null, null, 20L, null, true, false, "Jhikargacha", null, null, 0L },
                    { 174L, "চৌগাছা", null, null, 20L, null, true, false, "Chougachha", null, null, 0L },
                    { 173L, "বাঘারপাড়া", null, null, 20L, null, true, false, "Bagherpara", null, null, 0L },
                    { 172L, "অভয়নগর", null, null, 20L, null, true, false, "Abhaynagar", null, null, 0L },
                    { 248L, "নেছারাবাদ", null, null, 32L, null, true, false, "Nesarabad", null, null, 0L },
                    { 171L, "মণিরামপুর", null, null, 20L, null, true, false, "Manirampur", null, null, 0L },
                    { 169L, "পোরশা", null, null, 19L, null, true, false, "Porsha", null, null, 0L },
                    { 168L, "নওগাঁ সদর", null, null, 19L, null, true, false, "Naogaon Sadar", null, null, 0L },
                    { 167L, "রাণীনগর", null, null, 19L, null, true, false, "Raninagar", null, null, 0L },
                    { 166L, "আত্রাই", null, null, 19L, null, true, false, "Atrai", null, null, 0L },
                    { 165L, "মান্দা", null, null, 19L, null, true, false, "Manda", null, null, 0L },
                    { 164L, "নিয়ামতপুর", null, null, 19L, null, true, false, "Niamatpur", null, null, 0L },
                    { 163L, "ধামইরহাট", null, null, 19L, null, true, false, "Dhamoirhat", null, null, 0L },
                    { 162L, "পত্নিতলা", null, null, 19L, null, true, false, "Patnitala", null, null, 0L },
                    { 161L, "বদলগাছী", null, null, 19L, null, true, false, "Badalgachi", null, null, 0L },
                    { 160L, "মহাদেবপুর", null, null, 19L, null, true, false, "Mohadevpur", null, null, 0L },
                    { 159L, "শিবগঞ্জ", null, null, 18L, null, true, false, "Shibganj", null, null, 0L },
                    { 158L, "ভোলাহাট", null, null, 18L, null, true, false, "Bholahat", null, null, 0L },
                    { 157L, "নাচোল", null, null, 18L, null, true, false, "Nachol", null, null, 0L },
                    { 170L, "সাপাহার", null, null, 19L, null, true, false, "Sapahar", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "UserRole",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedBy", "UserId", "Version" },
                values: new object[] { 1L, null, null, true, false, 1L, null, null, 1L, 0L });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_CategoryId",
                schema: "asset",
                table: "Accessory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_LocationId",
                schema: "asset",
                table: "Accessory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_ManufacturerId",
                schema: "asset",
                table: "Accessory",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_MediaId",
                schema: "asset",
                table: "Accessory",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_SupplierId",
                schema: "asset",
                table: "Accessory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryUser_AccessoryId",
                schema: "asset",
                table: "AccessoryUser",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryUser_IssuedToUserId",
                schema: "asset",
                table: "AccessoryUser",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetModelId",
                schema: "asset",
                table: "Asset",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CheckoutId",
                schema: "asset",
                table: "Asset",
                column: "CheckoutId",
                unique: true,
                filter: "[CheckoutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_DepreciationId",
                schema: "asset",
                table: "Asset",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationId",
                schema: "asset",
                table: "Asset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_MediaId",
                schema: "asset",
                table: "Asset",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_StatusId",
                schema: "asset",
                table: "Asset",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_SupplierId",
                schema: "asset",
                table: "Asset",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAudit_AssetId",
                schema: "asset",
                table: "AssetAudit",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_ChekoutToLocationId",
                schema: "asset",
                table: "AssetCheckout",
                column: "ChekoutToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckout_ChekoutToUserId",
                schema: "asset",
                table: "AssetCheckout",
                column: "ChekoutToUserId");

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
                name: "IX_AssetMaintenance_AssetId",
                schema: "asset",
                table: "AssetMaintenance",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_SupplierId",
                schema: "asset",
                table: "AssetMaintenance",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_CategoryId",
                schema: "asset",
                table: "AssetModel",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_ManufacturerId",
                schema: "asset",
                table: "AssetModel",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_MediaId",
                schema: "asset",
                table: "AssetModel",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MediaId",
                schema: "asset",
                table: "Category",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "asset",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistory_ActionById",
                schema: "asset",
                table: "CheckoutHistory",
                column: "ActionById");

            migrationBuilder.CreateIndex(
                name: "IX_Component_CategoryId",
                schema: "asset",
                table: "Component",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_LocationId",
                schema: "asset",
                table: "Component",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_ManufacturerId",
                schema: "asset",
                table: "Component",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_MediaId",
                schema: "asset",
                table: "Component",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_SupplierId",
                schema: "asset",
                table: "Component",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentAsset_ComponentId",
                schema: "asset",
                table: "ComponentAsset",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentAsset_IssuedToAssetId",
                schema: "asset",
                table: "ComponentAsset",
                column: "IssuedToAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_ItemCodeId",
                schema: "asset",
                table: "Consumable",
                column: "ItemCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_LocationId",
                schema: "asset",
                table: "Consumable",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_ManufacturerId",
                schema: "asset",
                table: "Consumable",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_MediaId",
                schema: "asset",
                table: "Consumable",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_SupplierId",
                schema: "asset",
                table: "Consumable",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableUser_ConsumableId",
                schema: "asset",
                table: "ConsumableUser",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableUser_IssuedToUserId",
                schema: "asset",
                table: "ConsumableUser",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCode_CategoryId",
                schema: "asset",
                table: "ItemCode",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_License_CategoryId",
                schema: "asset",
                table: "License",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_License_DepreciationId",
                schema: "asset",
                table: "License",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_License_LocationId",
                schema: "asset",
                table: "License",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_License_ManufacturerId",
                schema: "asset",
                table: "License",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_License_SupplierId",
                schema: "asset",
                table: "License",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_IssuedToAssetId",
                schema: "asset",
                table: "LicenseSeat",
                column: "IssuedToAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_IssuedToUserId",
                schema: "asset",
                table: "LicenseSeat",
                column: "IssuedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSeat_LicenseId",
                schema: "asset",
                table: "LicenseSeat",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_MediaId",
                schema: "asset",
                table: "Manufacturer",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                schema: "core",
                table: "Address",
                column: "DistrictId");

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

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                schema: "core",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_DistrictId",
                schema: "core",
                table: "Office",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_DivisionId",
                schema: "core",
                table: "Office",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_UpazilaId",
                schema: "core",
                table: "Office",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_GroupId",
                schema: "core",
                table: "Permission",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ModuleId",
                schema: "core",
                table: "Permission",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "core",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                schema: "core",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazila_DistrictId",
                schema: "core",
                table: "Upazila",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazila_DivisionId",
                schema: "core",
                table: "Upazila",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                schema: "core",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DesignationId",
                schema: "core",
                table: "User",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                schema: "core",
                table: "User",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                schema: "core",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserId",
                schema: "core",
                table: "UserPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_BloodGroupId",
                schema: "core",
                table: "UserProfile",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ContactAddressId",
                schema: "core",
                table: "UserProfile",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_EducationId",
                schema: "core",
                table: "UserProfile",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_GenderId",
                schema: "core",
                table: "UserProfile",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_MaritalStatusId",
                schema: "core",
                table: "UserProfile",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_MediaId",
                schema: "core",
                table: "UserProfile",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_OfficeAddressId",
                schema: "core",
                table: "UserProfile",
                column: "OfficeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_PermanentAddressId",
                schema: "core",
                table: "UserProfile",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ReligionId",
                schema: "core",
                table: "UserProfile",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                schema: "core",
                table: "UserProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "core",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "core",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RefreshTokenId",
                schema: "core",
                table: "UserToken",
                column: "RefreshTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                schema: "core",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "library",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LanguageId",
                schema: "library",
                table: "Book",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LibraryId",
                schema: "library",
                table: "Book",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_MediaId",
                schema: "library",
                table: "Book",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                schema: "library",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                schema: "library",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                schema: "library",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEdition_BookId",
                schema: "library",
                table: "BookEdition",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEdition_EBookId",
                schema: "library",
                table: "BookEdition",
                column: "EBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_BookId",
                schema: "library",
                table: "BookIssue",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_ConvertedFromReservationId",
                schema: "library",
                table: "BookIssue",
                column: "ConvertedFromReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_FineId",
                schema: "library",
                table: "BookIssue",
                column: "FineId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_LibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_LibraryId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_MemberId",
                schema: "library",
                table: "BookIssue",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_BookId",
                schema: "library",
                table: "BookItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_CurrentIssueId",
                schema: "library",
                table: "BookItem",
                column: "CurrentIssueId",
                unique: true,
                filter: "[CurrentIssueId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_EditionId",
                schema: "library",
                table: "BookItem",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_FormatId",
                schema: "library",
                table: "BookItem",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_IssuedToId",
                schema: "library",
                table: "BookItem",
                column: "IssuedToId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_LibraryId",
                schema: "library",
                table: "BookItem",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_RackId",
                schema: "library",
                table: "BookItem",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_ReservedForId",
                schema: "library",
                table: "BookItem",
                column: "ReservedForId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_StatusId",
                schema: "library",
                table: "BookItem",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_BookId",
                schema: "library",
                table: "BookReservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_BookItemId",
                schema: "library",
                table: "BookReservation",
                column: "BookItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_LibraryId",
                schema: "library",
                table: "BookReservation",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_ReservationById",
                schema: "library",
                table: "BookReservation",
                column: "ReservationById");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_StatusId",
                schema: "library",
                table: "BookReservation",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubject_BookId",
                schema: "library",
                table: "BookSubject",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubject_SubjectId",
                schema: "library",
                table: "BookSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EBook_FormatId",
                schema: "library",
                table: "EBook",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_EBook_LibraryId",
                schema: "library",
                table: "EBook",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_EBook_MediaId",
                schema: "library",
                table: "EBook",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_LibraryId",
                schema: "library",
                table: "Fine",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Library_AddressId",
                schema: "library",
                table: "Library",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Library_LibrarianId",
                schema: "library",
                table: "Library",
                column: "LibrarianId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_CardStatusId",
                schema: "library",
                table: "LibraryCard",
                column: "CardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_CardTypeId",
                schema: "library",
                table: "LibraryCard",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_LibraryId",
                schema: "library",
                table: "LibraryCard",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_MemberId",
                schema: "library",
                table: "LibraryCard",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_CurrentCardId",
                schema: "library",
                table: "LibraryMember",
                column: "CurrentCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_LibraryId",
                schema: "library",
                table: "LibraryMember",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMember_UserId",
                schema: "library",
                table: "LibraryMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMemberRequest_LibraryId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMemberRequest_UserId",
                schema: "library",
                table: "LibraryMemberRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rack_LibraryId",
                schema: "library",
                table: "Rack",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BatchScheduleAllocationId",
                schema: "training",
                table: "Allocation",
                column: "BatchScheduleAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BedId",
                schema: "training",
                table: "Allocation",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_BuildingId",
                schema: "training",
                table: "Allocation",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_FloorId",
                schema: "training",
                table: "Allocation",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_HostelId",
                schema: "training",
                table: "Allocation",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_RoomId",
                schema: "training",
                table: "Allocation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_UserId",
                schema: "training",
                table: "Allocation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CoCoordinatorId",
                schema: "training",
                table: "BatchSchedule",
                column: "CoCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CoordinatorId",
                schema: "training",
                table: "BatchSchedule",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_CourseScheduleId",
                schema: "training",
                table: "BatchSchedule",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff1Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff2Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchSchedule_Staff3Id",
                schema: "training",
                table: "BatchSchedule",
                column: "Staff3Id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_BedId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_CertificateId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_CourseId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_RoomId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleAllocation_TraineeId",
                schema: "training",
                table: "BatchScheduleAllocation",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleGalleryItem_BatchScheduleId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchScheduleGalleryItem_MediaId",
                schema: "training",
                table: "BatchScheduleGalleryItem",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_BuildingId",
                schema: "training",
                table: "Bed",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_FloorId",
                schema: "training",
                table: "Bed",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_HostelId",
                schema: "training",
                table: "Bed",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomId",
                schema: "training",
                table: "Bed",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CourseScheduleId",
                schema: "training",
                table: "Budget",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItem_BudgetId",
                schema: "training",
                table: "BudgetItem",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_HostelId",
                schema: "training",
                table: "Building",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutine_BatchScheduleId",
                schema: "training",
                table: "ClassRoutine",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutineModule_ClassRoutineId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "ClassRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoutineModule_CourseModuleId",
                schema: "training",
                table: "ClassRoutineModule",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                schema: "training",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ImageId",
                schema: "training",
                table: "Course",
                column: "ImageId");

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
                name: "IX_CourseModule_DirectorId",
                schema: "training",
                table: "CourseModule",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_Course_CourseId",
                schema: "training",
                table: "CourseModule_Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModule_Course_CourseModuleId",
                schema: "training",
                table: "CourseModule_Course",
                column: "CourseModuleId");

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
                name: "IX_CourseSchedule_CoCoordinatorId",
                schema: "training",
                table: "CourseSchedule",
                column: "CoCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CoordinatorId",
                schema: "training",
                table: "CourseSchedule",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CourseId",
                schema: "training",
                table: "CourseSchedule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff1Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff2Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_Staff3Id",
                schema: "training",
                table: "CourseSchedule",
                column: "Staff3Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleEligible_CourseScheduleId",
                schema: "training",
                table: "CourseScheduleEligible",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleEligible_DesignationId",
                schema: "training",
                table: "CourseScheduleEligible",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_BatchScheduleId",
                schema: "training",
                table: "Exam",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_EvaluationMethodId",
                schema: "training",
                table: "Exam",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswer_AllocationId",
                schema: "training",
                table: "ExamAnswer",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswer_McqAnswerId",
                schema: "training",
                table: "ExamAnswer",
                column: "McqAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAnswer_QuestionId",
                schema: "training",
                table: "ExamAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipant_ExamId",
                schema: "training",
                table: "ExamParticipant",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamParticipant_ParticipantId",
                schema: "training",
                table: "ExamParticipant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamId",
                schema: "training",
                table: "ExamQuestion",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionId",
                schema: "training",
                table: "ExamQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                schema: "training",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_HostelId",
                schema: "training",
                table: "Floor",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_DesignationId",
                schema: "training",
                table: "HonorariumHead",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_HonorariumHead_HonorariumId",
                schema: "training",
                table: "HonorariumHead",
                column: "HonorariumId");

            migrationBuilder.CreateIndex(
                name: "IX_Hostel_AddressId",
                schema: "training",
                table: "Hostel",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRoutine_ModuleId",
                schema: "training",
                table: "ModuleRoutine",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOption_QuestionId",
                schema: "training",
                table: "QuestionOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_CvId",
                schema: "training",
                table: "ResourcePerson",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_HonorariumHeadId",
                schema: "training",
                table: "ResourcePerson",
                column: "HonorariumHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_OfficeId",
                schema: "training",
                table: "ResourcePerson",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_PhotoId",
                schema: "training",
                table: "ResourcePerson",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_UserId",
                schema: "training",
                table: "ResourcePerson",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                schema: "training",
                table: "Room",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorId",
                schema: "training",
                table: "Room",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HostelId",
                schema: "training",
                table: "Room",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ImageId",
                schema: "training",
                table: "Room",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TypeId",
                schema: "training",
                table: "Room",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_FacilitiesId",
                schema: "training",
                table: "RoomFacilities",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_RoomId",
                schema: "training",
                table: "RoomFacilities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_DesignationId",
                schema: "training",
                table: "RoomType",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_ResourcePersonId",
                schema: "training",
                table: "RoutinePeriod",
                column: "ResourcePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_RoutineId",
                schema: "training",
                table: "RoutinePeriod",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutinePeriod_TopicId",
                schema: "training",
                table: "RoutinePeriod",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_BatchScheduleId",
                schema: "training",
                table: "SessionProgress",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_CourseModuleId",
                schema: "training",
                table: "SessionProgress",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProgress_TopicId",
                schema: "training",
                table: "SessionProgress",
                column: "TopicId");

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
                name: "IX_TopicQuestion_QuestionId",
                schema: "training",
                table: "TopicQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicQuestion_TopicId",
                schema: "training",
                table: "TopicQuestion",
                column: "TopicId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_BatchScheduleId",
                schema: "training",
                table: "TotalMark",
                column: "BatchScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_EvaluationMethodId",
                schema: "training",
                table: "TotalMark",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalMark_ParticipantId",
                schema: "training",
                table: "TotalMark",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_BookReservation_ConvertedFromReservationId",
                schema: "library",
                table: "BookIssue",
                column: "ConvertedFromReservationId",
                principalSchema: "library",
                principalTable: "BookReservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Media_MediaId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_EBook_Media_MediaId",
                schema: "library",
                table: "EBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_User_MemberId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_User_IssuedToId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_User_ReservedForId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_User_ReservationById",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Library_User_LibrarianId",
                schema: "library",
                table: "Library");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCard_User_MemberId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District_DistrictId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_District_DistrictId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Division_DivisionId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Upazila_Division_DivisionId",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Upazila_UpazilaId",
                schema: "core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Library_Address_AddressId",
                schema: "library",
                table: "Library");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Language_LanguageId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Library_LibraryId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_Library_LibraryId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_Library_LibraryId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_Library_LibraryId",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_EBook_Library_LibraryId",
                schema: "library",
                table: "EBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Fine_Library_LibraryId",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCard_Library_LibraryId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Library_LibraryId",
                schema: "library",
                table: "Rack");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                schema: "library",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEdition_Book_BookId",
                schema: "library",
                table: "BookEdition");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_Book_BookId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_BookItem_Book_BookId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_Book_BookId",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEdition_EBook_EBookId",
                schema: "library",
                table: "BookEdition");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIssue_BookReservation_ConvertedFromReservationId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropTable(
                name: "AccessoryUser",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetAudit",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetDepreciationSchedule",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetMaintenance",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "CheckoutHistory",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "ComponentAsset",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "ConsumableUser",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "LicenseSeat",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "EmailTemplate",
                schema: "core");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "core");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "core");

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: "core");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "core");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "core");

            migrationBuilder.DropTable(
                name: "BookAuthor",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookSubject",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryMember",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryMemberRequest",
                schema: "library");

            migrationBuilder.DropTable(
                name: "MemberStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Allocation",
                schema: "training");

            migrationBuilder.DropTable(
                name: "BatchScheduleGalleryItem",
                schema: "training");

            migrationBuilder.DropTable(
                name: "BudgetItem",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Course_CourseModule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseMethod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseModule_Course",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseModuleTopic",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseScheduleEligible",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ExamAnswer",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ExamParticipant",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Grade",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ResourcePersonExpertise",
                schema: "training");

            migrationBuilder.DropTable(
                name: "RoomFacilities",
                schema: "training");

            migrationBuilder.DropTable(
                name: "RoutinePeriod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "SessionProgress",
                schema: "training");

            migrationBuilder.DropTable(
                name: "TopicQuestion",
                schema: "training");

            migrationBuilder.DropTable(
                name: "TopicResourcePerson",
                schema: "training");

            migrationBuilder.DropTable(
                name: "TotalMark",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Accessory",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetDepreciation",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Component",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Consumable",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "License",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "core");

            migrationBuilder.DropTable(
                name: "BloodGroup",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Education",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "core");

            migrationBuilder.DropTable(
                name: "MaritalStatus",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Religion",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "core");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Budget",
                schema: "training");

            migrationBuilder.DropTable(
                name: "QuestionOption",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ExamQuestion",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Expertise",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Facilities",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ModuleRoutine",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ResourcePerson",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseEvaluationMethod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "BatchScheduleAllocation",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "ItemCode",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Exam",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ClassRoutineModule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "HonorariumHead",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Method",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Bed",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "training");

            migrationBuilder.DropTable(
                name: "AssetModel",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetCheckout",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Depreciation",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetStatus",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "EvaluationMethod",
                schema: "training");

            migrationBuilder.DropTable(
                name: "ClassRoutine",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseModule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Honorarium",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "core");

            migrationBuilder.DropTable(
                name: "BatchSchedule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Floor",
                schema: "training");

            migrationBuilder.DropTable(
                name: "RoomType",
                schema: "training");

            migrationBuilder.DropTable(
                name: "CourseSchedule",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Hostel",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "training");

            migrationBuilder.DropTable(
                name: "Media",
                schema: "core");

            migrationBuilder.DropTable(
                name: "User",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "core");

            migrationBuilder.DropTable(
                name: "District",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Division",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Upazila",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Library",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "library");

            migrationBuilder.DropTable(
                name: "EBook",
                schema: "library");

            migrationBuilder.DropTable(
                name: "EBookFormat",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookReservation",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookItem",
                schema: "library");

            migrationBuilder.DropTable(
                name: "ReservationStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookIssue",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookEdition",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookFormat",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Rack",
                schema: "library");

            migrationBuilder.DropTable(
                name: "BookStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Fine",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCard",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCardStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCardType",
                schema: "library");
        }
    }
}
