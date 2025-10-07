using Iventis.Domain.DTO;

namespace Iventis.Domain.Interfaces.Services
{
    public interface ILocacaoService
    {
        Task<OperationResultDTO> LocarMoto(LocacaoDTO locacao);
        Task<LocacaoDetalheDTO> GetLocacaoById(string id);
    }
}
