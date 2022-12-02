using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenchmarkParallelForConsole.Migrations
{
    public partial class Createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Founded = table.Column<int>(type: "int", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organisation");
        }
    }
}
