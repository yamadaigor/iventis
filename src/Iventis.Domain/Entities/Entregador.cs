using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.Entities
{
    public class Entregador : BaseEntity
    {
        public Entregador()
        {
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public TipoCnh TipoCnh { get; set; }
        public byte[] ImagemCnh { get; set; }

        // EntityFramework Relationships
        public IEnumerable<Locacao> Locacoes { get; set; }
    }
}
