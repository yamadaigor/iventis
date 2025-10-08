using System.Text.Json.Serialization;
using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.DTO
{
    public class EntregadorDTO
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        private string cnpj { get; set; }
        public string Cnpj {
            set
            {
                cnpj = value.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            get
            {
                return cnpj;
            }

        }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public string TipoCnh { get; set; }
        public string ImagemCnh { get; set; }
    }
}
