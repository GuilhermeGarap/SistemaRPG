using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRpg.Migrations
{
    public partial class Classes_Teste_UsuarioController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    AtributoBonus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClasseId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sinopse = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.CampanhaId);
                    table.ForeignKey(
                        name: "FK_Campanhas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    FichaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Vida = table.Column<int>(type: "INTEGER", nullable: false),
                    Estamina = table.Column<int>(type: "INTEGER", nullable: false),
                    DesAparencia = table.Column<string>(type: "TEXT", nullable: false),
                    Historia = table.Column<string>(type: "TEXT", nullable: false),
                    Vigor = table.Column<int>(type: "INTEGER", nullable: false),
                    Presenca = table.Column<int>(type: "INTEGER", nullable: false),
                    Sabedoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Forca = table.Column<int>(type: "INTEGER", nullable: false),
                    Agilidade = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CampanhaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.FichaId);
                    table.ForeignKey(
                        name: "FK_Fichas_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "CampanhaId");
                    table.ForeignKey(
                        name: "FK_Fichas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_UsuarioId",
                table: "Campanhas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_CampanhaId",
                table: "Fichas",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_UsuarioId",
                table: "Fichas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
