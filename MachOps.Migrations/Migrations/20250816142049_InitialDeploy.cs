using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachOps.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialDeploy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Nvarchar(30)", nullable: false),
                    Type = table.Column<int>(type: "Int", nullable: false),
                    Status = table.Column<int>(type: "Int", nullable: false),
                    Location = table.Column<string>(type: "Nvarchar(20)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Start = table.Column<DateTime>(type: "Date", nullable: true),
                    Return = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Nvarchar(254)", nullable: false),
                    Password = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "Nvarchar(20)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "SmallDateTime", nullable: false),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    Role = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Name_Machines",
                table: "Machines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Email_Users",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Phone_Users",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
