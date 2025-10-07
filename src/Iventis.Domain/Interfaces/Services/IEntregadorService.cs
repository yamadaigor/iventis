using Iventis.Domain.DTO;

namespace Iventis.Domain.Interfaces.Services
{
    public interface IEntregadorService
    {
        Task<OperationResultDTO> AddEntregador(EntregadorDTO entregador);
        Task<OperationResultDTO> EnvarFotoCnh(string id, CnhDTO cnh);
    }
}
