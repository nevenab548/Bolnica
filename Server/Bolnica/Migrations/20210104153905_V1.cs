using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolnica.Migrations
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
                    BrojSmena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smene",
                columns: table => new
                {
                    BrojSmene = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Lekar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smene", x => x.BrojSmene);
                    table.ForeignKey(
                        name: "FK_Smene_Bolnica_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    Brojsobe = table.Column<int>(name: "Broj sobe", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odelenje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Primljeni = table.Column<int>(type: "int", nullable: false),
                    MaxPrimljeni = table.Column<int>(type: "int", nullable: false),
                    Hitno = table.Column<bool>(type: "bit", nullable: false),
                    Pacijenti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.Brojsobe);
                    table.ForeignKey(
                        name: "FK_Soba_Bolnica_BolnicaID",
                        column: x => x.BolnicaID,
                        principalTable: "Bolnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smene_BolnicaID",
                table: "Smene",
                column: "BolnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_BolnicaID",
                table: "Soba",
                column: "BolnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smene");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Bolnica");
        }
    }
}
