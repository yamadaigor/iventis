using Iventis.Domain.DTO;

namespace Iventis.Domain.Interfaces.Services
{
    public interface ICalculoLocacaoService
    {
        Task<RetornoCalculoLocacaoDTO> CalcularLocacao(LocacaoDetalheDTO locacao, DateTime dataInformada);
    }
}
