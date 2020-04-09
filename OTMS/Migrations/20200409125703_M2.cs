using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Status",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Status",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Status",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Religion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Religion",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Religion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Religion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Religion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Religion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Religion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MaritalStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "MaritalStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaritalStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaritalStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaritalStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "MaritalStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "MaritalStatus",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Gender",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gender",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Gender",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Gender",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BloodGroup",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "BloodGroup",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BloodGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BloodGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BloodGroup",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "BloodGroup",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "BloodGroup",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 6L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 7L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "BloodGroup",
                keyColumn: "Id",
                keyValue: 8L,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 12L, null, null, true, false, "Honorable Guest Speaker", null, null, 0L },
                    { 11L, null, null, true, false, "Deputy Secretary", null, null, 0L },
                    { 1L, null, null, true, false, "Director General", null, null, 0L },
                    { 9L, null, null, true, false, "Secretary", null, null, 0L },
                    { 2L, null, null, true, false, "Director", null, null, 0L },
                    { 3L, null, null, true, false, "Additional Director", null, null, 0L },
                    { 4L, null, null, true, false, "Deputy Director or Equivalent", null, null, 0L },
                    { 5L, null, null, true, false, "Assistant Director or Equivalent", null, null, 0L },
                    { 6L, null, null, true, false, "Social services officer 1st Class Gazetted or Equivalent", null, null, 0L },
                    { 7L, null, null, true, false, "Social services officer 2nd Class Gazetted or Equivalent", null, null, 0L },
                    { 8L, null, null, true, false, "Additional Secretary", null, null, 0L },
                    { 10L, null, null, true, false, "Joint Secretary", null, null, 0L }
                });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 6L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 7L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Religion",
                keyColumn: "Id",
                keyValue: 8L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Religion");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "MaritalStatus");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BloodGroup");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "BloodGroup");
        }
    }
}
