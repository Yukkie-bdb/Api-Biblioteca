using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<avaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<avaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.pontuacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.comentario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataAvaliacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.livroId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.usuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
