using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<emprestimoModel>
    {
        public void Configure(EntityTypeBuilder<emprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.dataEmprestimo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataDevolucao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.livroId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.usuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
