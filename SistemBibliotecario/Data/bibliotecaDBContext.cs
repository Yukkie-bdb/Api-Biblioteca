using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data.Map;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data;

public class bibliotecaDBContext : DbContext
{
    public bibliotecaDBContext(DbContextOptions<bibliotecaDBContext> options) : base(options) { }

    public DbSet<usuarioModel> Usuarios { get; set; }
    public DbSet<livroModel> Livros { get; set; }
    public DbSet<autorModel> Autores { get; set; }
    public DbSet<editoraModel> Editores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new LivroMap());
        modelBuilder.ApplyConfiguration(new AutorMap());
        modelBuilder.ApplyConfiguration(new EditoraMap());

        base.OnModelCreating(modelBuilder);
    }
}