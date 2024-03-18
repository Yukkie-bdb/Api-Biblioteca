using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<livroModel>
    {
        public void Configure(EntityTypeBuilder<livroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.anoPublicacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(255);
            builder.Property(x => x.sinopse).IsRequired().HasMaxLength(255);
        }
    }
    
}
