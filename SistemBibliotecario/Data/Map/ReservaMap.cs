using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<reservaModel>
    {
        public void Configure(EntityTypeBuilder<reservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.dataReserva).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.livroId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.usuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
