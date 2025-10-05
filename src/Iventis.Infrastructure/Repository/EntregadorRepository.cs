using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces;
using Iventis.Infrastructure.Data;

namespace Iventis.Infrastructure.Repository
{
    internal class EntregadorRepository : Repository<Entregador>,IEntregadorRepository
    {
        public EntregadorRepository(IventisContext context) : base(context){}
    }
}
