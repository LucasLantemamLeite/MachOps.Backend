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
                    CreateAt = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Start = table.Column<DateTime>(type: "Date", nullable: true),
                    Return = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Name_Machines",
                table: "Machines",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
