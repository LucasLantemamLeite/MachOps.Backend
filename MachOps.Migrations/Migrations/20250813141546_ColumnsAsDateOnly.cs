using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachOps.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsAsDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MaintenanceStartDate",
                table: "Machines",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "Machines",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MaintenanceStartDate",
                table: "Machines",
                type: "DateTime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "Machines",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);
        }
    }
}
