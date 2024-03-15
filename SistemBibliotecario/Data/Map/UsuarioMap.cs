using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<usuarioModel>
    {
        public void Configure(EntityTypeBuilder<usuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.senha).IsRequired().HasMaxLength(255);
        }
    }
}
