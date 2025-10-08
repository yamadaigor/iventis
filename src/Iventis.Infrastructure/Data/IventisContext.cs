using Iventis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iventis.Infrastructure.Data
{
    public class IventisContext : DbContext
    {
        public IventisContext(DbContextOptions options) : base(options){}

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
            Pega o DBContext, vai buscar todas as entidades que estão mapeadas e vai buscas classes que herdam de 
            EtntityTypeConfiguration para as entidades que estão relacionadas no DB Context e registram 
            todas de uma vez só.
           */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IventisContext).Assembly);

            // Desabilitar o Cascade Delete - Impede a exclusão do filho
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
