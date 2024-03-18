using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    /// <inheritdoc />
    public partial class LivoAdicionado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anoPublicacao = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    ISBN = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    sinopse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
