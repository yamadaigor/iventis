using Iventis.Domain.DTO;

namespace Iventis.Domain.Interfaces.Services
{
    public interface IMotoService
    {
        Task<OperationResultDTO> AddMoto(MotoDTO moto);
        Task<List<MotoDTO>> GetMotos(string placa);
        Task<OperationResultDTO> UpdatePlaca(string id, PlacaDTO placa);
        Task<MotoDTO> GetMotoById(string id);
        Task<OperationResultDTO> DeleteMoto(string id);
    }
}
