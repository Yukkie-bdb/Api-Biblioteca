using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<autorModel>
    {
        public void Configure(EntityTypeBuilder<autorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.nacionalidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataNascimento).IsRequired().HasMaxLength(255);
        }
    }
}
