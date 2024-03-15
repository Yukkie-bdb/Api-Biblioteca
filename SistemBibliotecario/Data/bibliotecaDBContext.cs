using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data.Map;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data;

public class bibliotecaDBContext : DbContext
{
    public bibliotecaDBContext(DbContextOptions<bibliotecaDBContext> options) : base(options) { }

    public DbSet<usuarioModel> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());

        base.OnModelCreating(modelBuilder);
    }
}