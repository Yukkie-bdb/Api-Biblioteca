using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    /// <inheritdoc />
    public partial class ReservaeAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pontuacao = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dataAvaliacao = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false),
                    livroId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    usuarioId = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Livros_livroId",
                        column: x => x.livroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataReserva = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    livroId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    usuarioId = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Livros_livroId",
                        column: x => x.livroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_livroId",
                table: "Avaliacoes",
                column: "livroId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_usuarioId",
                table: "Avaliacoes",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_livroId",
                table: "Reservas",
                column: "livroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_usuarioId",
                table: "Reservas",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
