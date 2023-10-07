using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRpg.Migrations
{
    public partial class AtualizacaoClasses_CrudClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Usuarios_UsuarioId",
                table: "Campanhas");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_UsuarioId",
                table: "Campanhas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Campanhas");

            migrationBuilder.AlterColumn<int>(
                name: "Vida",
                table: "Fichas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Estamina",
                table: "Fichas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Fichas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_ClasseId",
                table: "Fichas",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Classes_ClasseId",
                table: "Fichas",
                column: "ClasseId",
                principalTable: "Classes",
                principalColumn: "ClasseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Classes_ClasseId",
                table: "Fichas");

            migrationBuilder.DropIndex(
                name: "IX_Fichas_ClasseId",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Fichas");

            migrationBuilder.AlterColumn<int>(
                name: "Vida",
                table: "Fichas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Estamina",
                table: "Fichas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Campanhas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_UsuarioId",
                table: "Campanhas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Usuarios_UsuarioId",
                table: "Campanhas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }
    }
}
