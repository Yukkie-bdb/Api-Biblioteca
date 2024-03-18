using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    /// <inheritdoc />
    public partial class Editora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "editoraModelId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Editores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    localizacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    anoFundacao = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_editoraModelId",
                table: "Livros",
                column: "editoraModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Editores_editoraModelId",
                table: "Livros",
                column: "editoraModelId",
                principalTable: "Editores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editores_editoraModelId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Editores");

            migrationBuilder.DropIndex(
                name: "IX_Livros_editoraModelId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "editoraModelId",
                table: "Livros");
        }
    }
}
