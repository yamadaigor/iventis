using Iventis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iventis.Infrastructure.Mapping
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.MotoId)
                   .IsRequired();

            builder.Property(l => l.EntregadorId)
                   .IsRequired();

            builder.Property(l => l.DtInicio)
                   .IsRequired();

            builder.Property(l => l.DtTermino)
                   .IsRequired();

            builder.Property(l => l.DtPrevisaoTermino)
                   .IsRequired();

            builder.Property(l => l.Plano)
                   .IsRequired();
        }
    }
}
