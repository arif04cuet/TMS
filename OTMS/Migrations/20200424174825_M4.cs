using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMember_Library_LibraryId",
                table: "LibraryMember");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Status1_StatusId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Status_StatusId",
                table: "Vendor");

            migrationBuilder.DropTable(
                name: "Status1");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "BookItem");

            migrationBuilder.EnsureSchema(
                name: "asset");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "library");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendor",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "UserToken",
                newName: "UserToken",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRole",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "UserProfile",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "UserPermission",
                newName: "UserPermission",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Upazila",
                newName: "Upazila",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Supplier",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subject",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Status",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "RolePermission",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "ReservationStatus",
                newName: "ReservationStatus",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Religion",
                newName: "Religion",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshToken",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Rack",
                newName: "Rack",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publisher",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "PermissionGroup",
                newName: "PermissionGroup",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permission",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Module",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "MemberStatus",
                newName: "MemberStatus",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "MemberLibraryCard",
                newName: "MemberLibraryCard",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Media",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "MaritalStatus",
                newName: "MaritalStatus",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturer",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Location",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "LibraryMember",
                newName: "LibraryMember",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "LibraryCardType",
                newName: "LibraryCardType",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "LibraryCardStatus",
                newName: "LibraryCardStatus",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "LibraryCard",
                newName: "LibraryCard",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Library",
                newName: "Library",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Language",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Gender",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Fine",
                newName: "Fine",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "EmailTemplate",
                newName: "EmailTemplate",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Education",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "EBookFormat",
                newName: "EBookFormat",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "EBook",
                newName: "EBook",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Division",
                newName: "Division",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "District",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Designation",
                newName: "Designation",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Depreciation",
                newName: "Depreciation",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Department",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category",
                newSchema: "asset");

            migrationBuilder.RenameTable(
                name: "BookSubject",
                newName: "BookSubject",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookStatus",
                newName: "BookStatus",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookReservation",
                newName: "BookReservation",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookItem",
                newName: "BookItem",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookIssue",
                newName: "BookIssue",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookFormat",
                newName: "BookFormat",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookEdition",
                newName: "BookEdition",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BookAuthor",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Book",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "BloodGroup",
                newName: "BloodGroup",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Author",
                newSchema: "library");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Address",
                newSchema: "core");

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "Rack",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "MemberLibraryCard",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "LibraryMember",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "LibraryCard",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DueAmount",
                schema: "library",
                table: "Fine",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "Fine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                schema: "library",
                table: "Fine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "EBook",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "BookReservation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "BookItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "BookIssue",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                schema: "library",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                schema: "library",
                table: "Book",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Rack_LibraryId",
                schema: "library",
                table: "Rack",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLibraryCard_LibraryId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_LibraryId",
                schema: "library",
                table: "LibraryCard",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_LibraryId",
                schema: "library",
                table: "Fine",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_EBook_LibraryId",
                schema: "library",
                table: "EBook",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_LibraryId",
                schema: "library",
                table: "BookReservation",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookItem_LibraryId",
                schema: "library",
                table: "BookItem",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_LibraryId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LibraryId",
                schema: "library",
                table: "Book",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Status_StatusId",
                schema: "asset",
                table: "Vendor",
                column: "StatusId",
                principalSchema: "asset",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                schema: "core",
                table: "User",
                column: "StatusId",
                principalSchema: "core",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Library_LibraryId",
                schema: "library",
                table: "Book",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssue_Library_LibraryId",
                schema: "library",
                table: "BookIssue",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookItem_Library_LibraryId",
                schema: "library",
                table: "BookItem",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservation_Library_LibraryId",
                schema: "library",
                table: "BookReservation",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EBook_Library_LibraryId",
                schema: "library",
                table: "EBook",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fine_Library_LibraryId",
                schema: "library",
                table: "Fine",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCard_Library_LibraryId",
                schema: "library",
                table: "LibraryCard",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMember_Library_LibraryId",
                schema: "library",
                table: "LibraryMember",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberLibraryCard_Library_LibraryId",
                schema: "library",
                table: "MemberLibraryCard",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Library_LibraryId",
                schema: "library",
                table: "Rack",
                column: "LibraryId",
                principalSchema: "library",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Status_StatusId",
                schema: "asset",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                schema: "core",
                table: "User");

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
                name: "FK_LibraryMember_Library_LibraryId",
                schema: "library",
                table: "LibraryMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberLibraryCard_Library_LibraryId",
                schema: "library",
                table: "MemberLibraryCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Library_LibraryId",
                schema: "library",
                table: "Rack");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "asset");

            migrationBuilder.DropIndex(
                name: "IX_Rack_LibraryId",
                schema: "library",
                table: "Rack");

            migrationBuilder.DropIndex(
                name: "IX_MemberLibraryCard_LibraryId",
                schema: "library",
                table: "MemberLibraryCard");

            migrationBuilder.DropIndex(
                name: "IX_LibraryCard_LibraryId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropIndex(
                name: "IX_Fine_LibraryId",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropIndex(
                name: "IX_EBook_LibraryId",
                schema: "library",
                table: "EBook");

            migrationBuilder.DropIndex(
                name: "IX_BookReservation_LibraryId",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropIndex(
                name: "IX_BookItem_LibraryId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropIndex(
                name: "IX_BookIssue_LibraryId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropIndex(
                name: "IX_Book_LibraryId",
                schema: "library",
                table: "Book");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Status",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Status",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "MemberLibraryCard");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "LibraryCard");

            migrationBuilder.DropColumn(
                name: "DueAmount",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                schema: "library",
                table: "Fine");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "EBook");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "BookReservation");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "BookItem");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "BookIssue");

            migrationBuilder.DropColumn(
                name: "Isbn",
                schema: "library",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                schema: "library",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Subject",
                schema: "library",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "ReservationStatus",
                schema: "library",
                newName: "ReservationStatus");

            migrationBuilder.RenameTable(
                name: "Rack",
                schema: "library",
                newName: "Rack");

            migrationBuilder.RenameTable(
                name: "Publisher",
                schema: "library",
                newName: "Publisher");

            migrationBuilder.RenameTable(
                name: "MemberStatus",
                schema: "library",
                newName: "MemberStatus");

            migrationBuilder.RenameTable(
                name: "MemberLibraryCard",
                schema: "library",
                newName: "MemberLibraryCard");

            migrationBuilder.RenameTable(
                name: "LibraryMember",
                schema: "library",
                newName: "LibraryMember");

            migrationBuilder.RenameTable(
                name: "LibraryCardType",
                schema: "library",
                newName: "LibraryCardType");

            migrationBuilder.RenameTable(
                name: "LibraryCardStatus",
                schema: "library",
                newName: "LibraryCardStatus");

            migrationBuilder.RenameTable(
                name: "LibraryCard",
                schema: "library",
                newName: "LibraryCard");

            migrationBuilder.RenameTable(
                name: "Library",
                schema: "library",
                newName: "Library");

            migrationBuilder.RenameTable(
                name: "Fine",
                schema: "library",
                newName: "Fine");

            migrationBuilder.RenameTable(
                name: "EBookFormat",
                schema: "library",
                newName: "EBookFormat");

            migrationBuilder.RenameTable(
                name: "EBook",
                schema: "library",
                newName: "EBook");

            migrationBuilder.RenameTable(
                name: "BookSubject",
                schema: "library",
                newName: "BookSubject");

            migrationBuilder.RenameTable(
                name: "BookStatus",
                schema: "library",
                newName: "BookStatus");

            migrationBuilder.RenameTable(
                name: "BookReservation",
                schema: "library",
                newName: "BookReservation");

            migrationBuilder.RenameTable(
                name: "BookItem",
                schema: "library",
                newName: "BookItem");

            migrationBuilder.RenameTable(
                name: "BookIssue",
                schema: "library",
                newName: "BookIssue");

            migrationBuilder.RenameTable(
                name: "BookFormat",
                schema: "library",
                newName: "BookFormat");

            migrationBuilder.RenameTable(
                name: "BookEdition",
                schema: "library",
                newName: "BookEdition");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                schema: "library",
                newName: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "Book",
                schema: "library",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Author",
                schema: "library",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "UserToken",
                schema: "core",
                newName: "UserToken");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "core",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                schema: "core",
                newName: "UserProfile");

            migrationBuilder.RenameTable(
                name: "UserPermission",
                schema: "core",
                newName: "UserPermission");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "core",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Upazila",
                schema: "core",
                newName: "Upazila");

            migrationBuilder.RenameTable(
                name: "Status",
                schema: "core",
                newName: "Status");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                schema: "core",
                newName: "RolePermission");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "core",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Religion",
                schema: "core",
                newName: "Religion");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                schema: "core",
                newName: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "PermissionGroup",
                schema: "core",
                newName: "PermissionGroup");

            migrationBuilder.RenameTable(
                name: "Permission",
                schema: "core",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "Module",
                schema: "core",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Media",
                schema: "core",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "MaritalStatus",
                schema: "core",
                newName: "MaritalStatus");

            migrationBuilder.RenameTable(
                name: "Language",
                schema: "core",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "Gender",
                schema: "core",
                newName: "Gender");

            migrationBuilder.RenameTable(
                name: "EmailTemplate",
                schema: "core",
                newName: "EmailTemplate");

            migrationBuilder.RenameTable(
                name: "Education",
                schema: "core",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "Division",
                schema: "core",
                newName: "Division");

            migrationBuilder.RenameTable(
                name: "District",
                schema: "core",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "Designation",
                schema: "core",
                newName: "Designation");

            migrationBuilder.RenameTable(
                name: "Department",
                schema: "core",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "BloodGroup",
                schema: "core",
                newName: "BloodGroup");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "core",
                newName: "Address");

            migrationBuilder.RenameTable(
                name: "Vendor",
                schema: "asset",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "Supplier",
                schema: "asset",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                schema: "asset",
                newName: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "asset",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Depreciation",
                schema: "asset",
                newName: "Depreciation");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "asset",
                newName: "Category");

            migrationBuilder.AlterColumn<long>(
                name: "LibraryId",
                table: "LibraryMember",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "BookItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Status1",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, null, null, true, false, "Pending", null, null, 0L },
                    { 2L, null, null, true, false, "Approved", null, null, 0L },
                    { 3L, null, null, true, false, "Active", null, null, 0L },
                    { 4L, null, null, true, false, "In active", null, null, 0L }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMember_Library_LibraryId",
                table: "LibraryMember",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status1_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Status_StatusId",
                table: "Vendor",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
