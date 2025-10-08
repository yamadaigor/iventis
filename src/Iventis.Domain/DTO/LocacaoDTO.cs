using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.DTO
{
    public class LocacaoDTO 
    {
        public string IdentificadorMoto { get; set; }
        public string IdentificadorEntregador { get; set; }
        private DateTime _dataInicio { get; set; }
        public DateTime DtInicio
        {
            set
            {
                if (value != DateTime.MinValue)
                    value.AddDays(1);

                _dataInicio = value;
            }

            get
            {
                return _dataInicio;
            }
        }
        public DateTime DtTermino { get; set; }
        public DateTime DtPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }
    }
}
