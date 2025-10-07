using Iventis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iventis.Infrastructure.Mapping
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("Moto");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Identificador)
                   .IsRequired();

            builder.Property(m => m.Ano)
                   .IsRequired()
                   .HasColumnType("varchar(4)");

            builder.Property(m => m.Modelo)
                   .IsRequired();

            builder.Property(m => m.Placa)
                   .IsRequired()
                   .HasColumnType("varchar(4)");

            builder.HasIndex(m => m.Placa)
                   .IsUnique();
            
            builder.HasMany(m => m.Locacoes)
              .WithOne(l => l.Moto)
              .HasForeignKey(l => l.MotoId);
        }
    }
}
