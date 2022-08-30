using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IWantApp.Migrations
{
    public partial class AddCreatedByAndUpdatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Products",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7572),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7337),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: true,
                defaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(8118),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7996),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9822));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Products",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9365),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9134),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9968),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(8118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9822),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 38, 59, 371, DateTimeKind.Utc).AddTicks(7996));
        }
    }
}
