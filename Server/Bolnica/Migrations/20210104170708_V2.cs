using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KapacitetSobe",
                table: "Bolnica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KapacitetSobe",
                table: "Bolnica");
        }
    }
}
