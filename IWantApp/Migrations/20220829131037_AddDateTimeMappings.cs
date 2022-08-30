using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IWantApp.Migrations
{
    public partial class AddDateTimeMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2022, 8, 29, 13, 10, 36, 909, DateTimeKind.Utc).AddTicks(9822));
        }
    }
}
