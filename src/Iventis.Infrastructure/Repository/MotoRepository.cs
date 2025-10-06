using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iventis.Infrastructure.Repository
{
    public class MotoRepository : Repository<Moto>, IMotoRepository
    {
        public MotoRepository(IventisContext context) : base(context) { }
        
    }
}
