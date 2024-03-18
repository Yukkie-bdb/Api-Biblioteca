using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class EditoraMap : IEntityTypeConfiguration<editoraModel>
    {
        public void Configure(EntityTypeBuilder<editoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.localizacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.anoFundacao).IsRequired().HasMaxLength(255);
        }
    }
}
