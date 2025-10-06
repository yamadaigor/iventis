using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Infrastructure.Data;

namespace Iventis.Infrastructure.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(IventisContext context) : base(context) { }
    }
}
