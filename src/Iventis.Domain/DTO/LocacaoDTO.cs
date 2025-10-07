using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.DTO
{
    public class LocacaoDTO 
    {
        public string EntregadorId { get; set; }
        public string MotoId { get; set; }
        private DateTime _dataInicio { get; set; }
        public DateTime DataInicio
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
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public PlanoLocacao Plano { get; set; }
    }
}
