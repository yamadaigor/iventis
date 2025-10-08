using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.Entities
{
    public class Entregador : BaseEntity
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public string TipoCnh { get; set; }

        //public byte[] ImagemCnh { get; set; } // não tive tempo suficiente pra ver essa questão. 
        public string ImagemCnh { get; set; }

        // EntityFramework Relationships
        public IEnumerable<Locacao> Locacoes { get; set; }
    }
}
