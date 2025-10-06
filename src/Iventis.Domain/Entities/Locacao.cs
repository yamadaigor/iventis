using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.Entities
{
    public class Locacao : BaseEntity
    {
        public Locacao()
        {
                Id = Guid.NewGuid();
        }
        public Guid MotoId { get; set; }
        public Guid EntregadorId { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtTermino { get; set; }
        public DateTime DtPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }

        // EntityFramework relationships
        public Entregador Entregador { get; set; }
        public Moto Moto { get; set; }
    }
}
