using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemBibliotecario.Migrations
{
    /// <inheritdoc />
    public partial class AutorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nacionalidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dataNascimento = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
