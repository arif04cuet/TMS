using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class TMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "asset");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "library");

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
                    Term = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
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
                    table.PrimaryKey("PK_Status", x => x.Id);
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
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
                    Name = table.Column<string>(nullable: true)
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
                    Type = table.Column<int>(nullable: false),
                    EULA = table.Column<string>(nullable: true),
                    IsRequireUserConfirmation = table.Column<bool>(nullable: false),
                    IsSendEmail = table.Column<bool>(nullable: false),
                    MediaId = table.Column<long>(nullable: true)
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
                    Eol = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    DepreciationId = table.Column<long>(nullable: false),
                    IsRequestable = table.Column<bool>(nullable: false),
                    MediaId = table.Column<long>(nullable: true),
                    AssetModelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetModel_AssetModel_AssetModelId",
                        column: x => x.AssetModelId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetModel_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetModel_Depreciation_DepreciationId",
                        column: x => x.DepreciationId,
                        principalSchema: "asset",
                        principalTable: "Depreciation",
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
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Component_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    CategoryId = table.Column<long>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    ModelNo = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    MinQuantity = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MediaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumable_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "asset",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumable_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalSchema: "asset",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    AssetModelId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    ItemNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<long>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    PurchaseCost = table.Column<double>(nullable: false),
                    Warrantly = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsRequestable = table.Column<bool>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    MediaId = table.Column<long>(nullable: true)
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
                        name: "FK_Asset_Office_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "core",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "core",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "asset",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "asset",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_AssetAudit_AssetModel_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
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
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_AssetModel_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
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
                    AuthorId = table.Column<long>(nullable: true)
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
                    Amount = table.Column<float>(nullable: false),
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
                    Name = table.Column<string>(nullable: true),
                    CardTypeId = table.Column<long>(nullable: false),
                    Fees = table.Column<float>(nullable: false),
                    MaxIssueCount = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCard", x => x.Id);
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
                    MemberSince = table.Column<DateTime>(nullable: false),
                    TotalBooksCheckout = table.Column<long>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMember", x => x.Id);
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
                        name: "FK_ComponentAsset_AssetModel_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
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
                        name: "FK_LicenseSeat_AssetModel_IssuedToAssetId",
                        column: x => x.IssuedToAssetId,
                        principalSchema: "asset",
                        principalTable: "AssetModel",
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
                name: "MemberLibraryCard",
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
                    CardNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LibraryCardId = table.Column<long>(nullable: false),
                    CardStatusId = table.Column<long>(nullable: false),
                    CardExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLibraryCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_LibraryCardStatus_CardStatusId",
                        column: x => x.CardStatusId,
                        principalSchema: "library",
                        principalTable: "LibraryCardStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_LibraryCard_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalSchema: "library",
                        principalTable: "LibraryCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalSchema: "library",
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberLibraryCard_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    MemberLibraryCardId = table.Column<long>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_BookIssue_MemberLibraryCard_MemberLibraryCardId",
                        column: x => x.MemberLibraryCardId,
                        principalSchema: "library",
                        principalTable: "MemberLibraryCard",
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
                    BookId = table.Column<long>(nullable: false),
                    BookItemId = table.Column<long>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    ReservationById = table.Column<long>(nullable: true),
                    LibraryId = table.Column<long>(nullable: true)
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
                schema: "core",
                table: "BloodGroup",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "A+", null, null, 0L },
                    { 2L, null, null, true, false, "A-", null, null, 0L },
                    { 3L, null, null, true, false, "B+", null, null, 0L },
                    { 4L, null, null, true, false, "B-", null, null, 0L },
                    { 5L, null, null, true, false, "AB+", null, null, 0L },
                    { 6L, null, null, true, false, "AB-", null, null, 0L },
                    { 7L, null, null, true, false, "O+", null, null, 0L },
                    { 8L, null, null, true, false, "O-", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Designation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 12L, null, null, true, false, "Honorable Guest Speaker", null, null, 0L },
                    { 11L, null, null, true, false, "Deputy Secretary", null, null, 0L },
                    { 10L, null, null, true, false, "Joint Secretary", null, null, 0L },
                    { 8L, null, null, true, false, "Additional Secretary", null, null, 0L },
                    { 7L, null, null, true, false, "Social services officer 2nd Class Gazetted or Equivalent", null, null, 0L },
                    { 9L, null, null, true, false, "Secretary", null, null, 0L },
                    { 5L, null, null, true, false, "Assistant Director or Equivalent", null, null, 0L },
                    { 4L, null, null, true, false, "Deputy Director or Equivalent", null, null, 0L },
                    { 3L, null, null, true, false, "Additional Director", null, null, 0L },
                    { 2L, null, null, true, false, "Director", null, null, 0L },
                    { 1L, null, null, true, false, "Director General", null, null, 0L },
                    { 6L, null, null, true, false, "Social services officer 1st Class Gazetted or Equivalent", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "District",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 46L, null, null, true, false, "Joypurhat", null, null, 0L },
                    { 45L, null, null, true, false, "Bogura", null, null, 0L },
                    { 44L, null, null, true, false, "Sherpur", null, null, 0L },
                    { 43L, null, null, true, false, "Netrokona", null, null, 0L },
                    { 42L, null, null, true, false, "Mymensingh", null, null, 0L },
                    { 41L, null, null, true, false, "Jamalpur", null, null, 0L },
                    { 38L, null, null, true, false, "Meherpur", null, null, 0L },
                    { 39L, null, null, true, false, "Narail", null, null, 0L },
                    { 37L, null, null, true, false, "Magura", null, null, 0L },
                    { 36L, null, null, true, false, "Kushtia", null, null, 0L },
                    { 35L, null, null, true, false, "Khulna", null, null, 0L },
                    { 47L, null, null, true, false, "Naogaon", null, null, 0L },
                    { 40L, null, null, true, false, "Satkhira", null, null, 0L },
                    { 48L, null, null, true, false, "Natore", null, null, 0L },
                    { 59L, null, null, true, false, "Rangpur", null, null, 0L },
                    { 50L, null, null, true, false, "Pabna", null, null, 0L },
                    { 51L, null, null, true, false, "Rajshahi", null, null, 0L },
                    { 52L, null, null, true, false, "Sirajganj", null, null, 0L },
                    { 53L, null, null, true, false, "Dinajpur", null, null, 0L },
                    { 54L, null, null, true, false, "Gaibandha", null, null, 0L },
                    { 56L, null, null, true, false, "Lalmonirhat", null, null, 0L },
                    { 57L, null, null, true, false, "Nilphamari", null, null, 0L },
                    { 58L, null, null, true, false, "Panchagarh", null, null, 0L },
                    { 34L, null, null, true, false, "Jhenaidah", null, null, 0L },
                    { 60L, null, null, true, false, "Thakurgaon", null, null, 0L },
                    { 61L, null, null, true, false, "Habiganj", null, null, 0L },
                    { 62L, null, null, true, false, "Moulvibazar", null, null, 0L },
                    { 63L, null, null, true, false, "Sunamganj", null, null, 0L },
                    { 64L, null, null, true, false, "Sylhet", null, null, 0L },
                    { 49L, null, null, true, false, "Chapainawabganj", null, null, 0L },
                    { 33L, null, null, true, false, "Jashore", null, null, 0L },
                    { 55L, null, null, true, false, "Kurigram", null, null, 0L },
                    { 31L, null, null, true, false, "Bagerhat", null, null, 0L },
                    { 1L, null, null, true, false, "Barguna", null, null, 0L },
                    { 2L, null, null, true, false, "Barishal", null, null, 0L },
                    { 3L, null, null, true, false, "Bhola", null, null, 0L },
                    { 4L, null, null, true, false, "Jhalokathi", null, null, 0L },
                    { 5L, null, null, true, false, "Patuakhali", null, null, 0L },
                    { 6L, null, null, true, false, "Pirojpur", null, null, 0L },
                    { 7L, null, null, true, false, "Bandarban", null, null, 0L },
                    { 32L, null, null, true, false, "Chuadanga", null, null, 0L },
                    { 9L, null, null, true, false, "Chandpur", null, null, 0L },
                    { 10L, null, null, true, false, "Chattogram", null, null, 0L },
                    { 11L, null, null, true, false, "Cumilla", null, null, 0L },
                    { 12L, null, null, true, false, "Cox's Bazar", null, null, 0L },
                    { 13L, null, null, true, false, "Feni", null, null, 0L },
                    { 14L, null, null, true, false, "Khagrachhari", null, null, 0L },
                    { 15L, null, null, true, false, "Lakshmipur", null, null, 0L },
                    { 8L, null, null, true, false, "Brahmanbaria", null, null, 0L },
                    { 17L, null, null, true, false, "Rangamati", null, null, 0L },
                    { 18L, null, null, true, false, "Dhaka", null, null, 0L },
                    { 19L, null, null, true, false, "Faridpur", null, null, 0L },
                    { 20L, null, null, true, false, "Gazipur", null, null, 0L },
                    { 21L, null, null, true, false, "Gopalganj", null, null, 0L },
                    { 22L, null, null, true, false, "Kishoreganj", null, null, 0L },
                    { 23L, null, null, true, false, "Madaripur", null, null, 0L },
                    { 24L, null, null, true, false, "Manikganj", null, null, 0L },
                    { 25L, null, null, true, false, "Munshiganj", null, null, 0L },
                    { 26L, null, null, true, false, "Narayanganj", null, null, 0L },
                    { 27L, null, null, true, false, "Narsingdi", null, null, 0L },
                    { 28L, null, null, true, false, "Rajbari", null, null, 0L },
                    { 29L, null, null, true, false, "Shariatpur", null, null, 0L },
                    { 30L, null, null, true, false, "Tangail", null, null, 0L },
                    { 16L, null, null, true, false, "Noakhali", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Gender",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 3L, null, null, true, false, "Other", null, null, 0L },
                    { 2L, null, null, true, false, "Female", null, null, 0L },
                    { 1L, null, null, true, false, "Male", null, null, 0L }
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
                    { 1L, null, null, true, false, "Married", null, null, 0L },
                    { 2L, null, null, true, false, "Un married", null, null, 0L },
                    { 3L, null, null, true, false, "Widowed", null, null, 0L },
                    { 4L, null, null, true, false, "Divorced", null, null, 0L },
                    { 5L, null, null, true, false, "Never married", null, null, 0L }
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
                    { 6L, null, null, true, false, "Book", null, null, 0L },
                    { 5L, null, null, true, false, "Profile", null, null, 0L },
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
                    { 7L, null, null, true, false, "Sikhism", null, null, 0L },
                    { 6L, null, null, true, false, "Jainism", null, null, 0L },
                    { 5L, null, null, true, false, "Buddhism", null, null, 0L },
                    { 8L, null, null, true, false, "Other", null, null, 0L },
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
                    { 1L, null, null, true, false, "Pending", null, null, 0L },
                    { 2L, null, null, true, false, "Approved", null, null, 0L },
                    { 3L, null, null, true, false, "Active", null, null, 0L },
                    { 4L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "BookFormat",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 5L, null, null, true, false, "Newspaper", null, null, 0L },
                    { 7L, null, null, true, false, "Journal", null, null, 0L },
                    { 4L, null, null, true, false, "Ebook", null, null, 0L },
                    { 6L, null, null, true, false, "Magazine", null, null, 0L },
                    { 2L, null, null, true, false, "Paperback", null, null, 0L },
                    { 1L, null, null, true, false, "Hardcover", null, null, 0L },
                    { 3L, null, null, true, false, "Audiobook", null, null, 0L }
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
                    { 2L, null, null, true, false, "In active", null, null, 0L },
                    { 3L, null, null, true, false, "Lost", null, null, 0L },
                    { 1L, null, null, true, false, "Active", null, null, 0L }
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
                    { 1L, null, null, true, false, "Active", null, null, 0L },
                    { 2L, null, null, true, false, "Closed", null, null, 0L },
                    { 3L, null, null, true, false, "Canceled", null, null, 0L },
                    { 4L, null, null, true, false, "Blacklisted", null, null, 0L },
                    { 5L, null, null, true, false, "None", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "library",
                table: "ReservationStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 4L, null, null, true, false, "Canceled", null, null, 0L },
                    { 1L, null, null, true, false, "Waiting", null, null, 0L },
                    { 2L, null, null, true, false, "Pending", null, null, 0L },
                    { 3L, null, null, true, false, "Completed", null, null, 0L },
                    { 5L, null, null, true, false, "None", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permission",
                columns: new[] { "Id", "Code", "Description", "GroupId", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 100L, "user.create", null, 1L, 1L, "Create" },
                    { 603L, "book.delete", null, 6L, 2L, "Delete" },
                    { 604L, "book.list", null, 6L, 2L, "List" },
                    { 602L, "book.view", null, 6L, 2L, "View" },
                    { 601L, "book.update", null, 6L, 2L, "Update" },
                    { 600L, "book.create", null, 6L, 2L, "Create" },
                    { 505L, "profile.manage", null, 5L, 1L, "Manage" },
                    { 502L, "profile.view", null, 5L, 1L, "View" },
                    { 501L, "profile.update", null, 5L, 1L, "Update" },
                    { 405L, "department.manage", null, 4L, 1L, "Manage" },
                    { 403L, "department.delete", null, 4L, 1L, "Delete" },
                    { 404L, "department.list", null, 4L, 1L, "List" },
                    { 402L, "department.view", null, 4L, 1L, "View" },
                    { 401L, "department.update", null, 4L, 1L, "Update" },
                    { 400L, "department.create", null, 4L, 1L, "Create" },
                    { 305L, "designation.manage", null, 3L, 1L, "Manage" },
                    { 303L, "designation.delete", null, 3L, 1L, "Delete" },
                    { 304L, "designation.list", null, 3L, 1L, "List" },
                    { 101L, "user.update", null, 1L, 1L, "Update" },
                    { 102L, "user.view", null, 1L, 1L, "View" },
                    { 104L, "user.list", null, 1L, 1L, "List" },
                    { 103L, "user.delete", null, 1L, 1L, "Delete" },
                    { 105L, "user.manage", null, 1L, 1L, "Manage" },
                    { 200L, "role.create", null, 2L, 1L, "Create" },
                    { 605L, "book.manage", null, 6L, 2L, "Manage" },
                    { 201L, "role.update", null, 2L, 1L, "Update" },
                    { 204L, "role.list", null, 2L, 1L, "List" },
                    { 203L, "role.delete", null, 2L, 1L, "Delete" },
                    { 205L, "role.manage", null, 2L, 1L, "Manage" },
                    { 300L, "designation.create", null, 3L, 1L, "Create" },
                    { 301L, "designation.update", null, 3L, 1L, "Update" },
                    { 302L, "designation.view", null, 3L, 1L, "View" },
                    { 202L, "role.view", null, 2L, 1L, "View" }
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
                    { 1L, 105L, 1L },
                    { 2L, 205L, 1L },
                    { 3L, 305L, 1L },
                    { 4L, 405L, 1L },
                    { 5L, 505L, 1L }
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
                name: "IX_AssetModel_AssetModelId",
                schema: "asset",
                table: "AssetModel",
                column: "AssetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_CategoryId",
                schema: "asset",
                table: "AssetModel",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_DepreciationId",
                schema: "asset",
                table: "AssetModel",
                column: "DepreciationId");

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
                name: "IX_Consumable_CategoryId",
                schema: "asset",
                table: "Consumable",
                column: "CategoryId");

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
                name: "IX_BookIssue_MemberLibraryCardId",
                schema: "library",
                table: "BookIssue",
                column: "MemberLibraryCardId");

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
                name: "IX_MemberLibraryCard_CardStatusId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "CardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_LibraryCardId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_LibraryId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_UserId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rack_LibraryId",
                schema: "library",
                table: "Rack",
                column: "LibraryId");

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
                name: "FK_MemberLibraryCard_User_UserId",
                schema: "library",
                table: "MemberLibraryCard");

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
                name: "FK_MemberLibraryCard_Library_LibraryId",
                schema: "library",
                table: "MemberLibraryCard");

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
                name: "Asset",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetAudit",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetMaintenance",
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
                name: "MemberStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "Accessory",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Component",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Consumable",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "AssetModel",
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
                name: "Category",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Depreciation",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "asset");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "core");

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
                name: "MemberLibraryCard",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCardStatus",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCard",
                schema: "library");

            migrationBuilder.DropTable(
                name: "LibraryCardType",
                schema: "library");
        }
    }
}
