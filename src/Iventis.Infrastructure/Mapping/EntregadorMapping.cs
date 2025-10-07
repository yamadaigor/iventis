using Iventis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iventis.Infrastructure.Mapping
{
    public class EntregadorMapping : IEntityTypeConfiguration<Entregador>
    {
        public void Configure(EntityTypeBuilder<Entregador> builder)
        {
            builder.ToTable("Entregador");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                   .IsRequired();

            builder.Property(e => e.Cnpj)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

            builder.Property(e => e.DataNascimento)
                   .IsRequired();

            builder.Property(e => e.NumeroCnh)
                   .IsRequired();

            builder.Property(e => e.TipoCnh)
                   .IsRequired();

            builder.Property(e => e.ImagemCnh)
                   .IsRequired();

            builder.HasMany(e => e.Locacoes)
               .WithOne(l => l.Entregador)
               .HasForeignKey(l => l.EntregadorId);

            builder.HasIndex(m => m.Cnpj)
                   .IsUnique();

            builder.HasIndex(m => m.NumeroCnh)
                  .IsUnique();
        }
    }
}
