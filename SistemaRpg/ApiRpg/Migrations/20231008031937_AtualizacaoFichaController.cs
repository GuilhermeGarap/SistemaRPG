using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRpg.Migrations
{
    public partial class AtualizacaoFichaController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClasseNome",
                table: "Fichas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClasseNome",
                table: "Fichas");
        }
    }
}
