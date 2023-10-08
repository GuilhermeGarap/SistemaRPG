using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRpg.Migrations
{
    public partial class AtualizacaoCampanhaController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Campanhas_CampanhaId",
                table: "Fichas");

            migrationBuilder.DropIndex(
                name: "IX_Fichas_CampanhaId",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "CampanhaId",
                table: "Fichas");

            migrationBuilder.CreateTable(
                name: "CampanhaFicha",
                columns: table => new
                {
                    CampanhasCampanhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FichasFichaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaFicha", x => new { x.CampanhasCampanhaId, x.FichasFichaId });
                    table.ForeignKey(
                        name: "FK_CampanhaFicha_Campanhas_CampanhasCampanhaId",
                        column: x => x.CampanhasCampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "CampanhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaFicha_Fichas_FichasFichaId",
                        column: x => x.FichasFichaId,
                        principalTable: "Fichas",
                        principalColumn: "FichaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaFicha_FichasFichaId",
                table: "CampanhaFicha",
                column: "FichasFichaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaFicha");

            migrationBuilder.AddColumn<int>(
                name: "CampanhaId",
                table: "Fichas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_CampanhaId",
                table: "Fichas",
                column: "CampanhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Campanhas_CampanhaId",
                table: "Fichas",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "CampanhaId");
        }
    }
}
