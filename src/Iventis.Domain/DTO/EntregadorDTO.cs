using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.DTO
{
    public class EntregadorDTO
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public TipoCnh TipoCnh { get; set; }
        public string ImagemCnh { get; set; }
    }
}
