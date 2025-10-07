namespace Iventis.Domain.DTO
{
    public class LocacaoDetalheDTO : LocacaoDTO
    {
        public int ValoDiaria
        {
            get
            {
                switch (Plano)
                {
                    case Utils.Enums.PlanoLocacao.SeteDias:
                        return 30;
                    case Utils.Enums.PlanoLocacao.QuinzeDias:
                        return 28;
                    case Utils.Enums.PlanoLocacao.TrintaDias:
                        return 22;
                    case Utils.Enums.PlanoLocacao.QuarentaCincoDias:
                        return 20;
                    case Utils.Enums.PlanoLocacao.CinquentaDias:
                        return 18;
                    default:
                        return 0;
                }
            }
        }
    }
}
