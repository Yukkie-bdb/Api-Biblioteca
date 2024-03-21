using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    /// <inheritdoc />
    public partial class Emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataEmprestimo = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false),
                    dataDevolucao = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    livroId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    usuarioId = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_livroId",
                        column: x => x.livroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_livroId",
                table: "Emprestimos",
                column: "livroId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_usuarioId",
                table: "Emprestimos",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");
        }
    }
}
