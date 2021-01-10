using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolnica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BrojSoba = table.Column<int>(type: "int", nullable: false),
                    KapacitetSobe = table.Column<int>(type: "int", nullable: false),
                    Usmeni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    BrojSmene = table.Column<int>(type: "int", nullable: false),
                    Lekar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Smena_Bolnica_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(type: "int", nullable: false),
                    Odelenje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Primljeni = table.Column<int>(type: "int", nullable: false),
                    MaxPrimljeni = table.Column<int>(type: "int", nullable: false),
                    Pacijenti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Soba_Bolnica_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smena_BolnicaID",
                table: "Smena",
                column: "BolnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_BolnicaID",
                table: "Soba",
                column: "BolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smena");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Bolnica");
        }
    }
}
