using AutoMapper;
using Iventis.Domain.DTO;
using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Domain.Interfaces.Services;
using Iventis.Domain.Validators;

namespace Iventis.Domain.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _motoRepository;
        private readonly IMapper _mapper;

        public MotoService(IMotoRepository motoRepository,
                           IMapper mapper)
        {
            _motoRepository = motoRepository;
            _mapper = mapper;
        }

        public async Task<OperationResultDTO> AddMoto(MotoDTO moto)
        {
            var operationresult = new OperationResultDTO();

            var validationResult = new MotoValidator().Validate(moto);

            if (!validationResult.IsValid)
            {
                operationresult.Success = validationResult.IsValid;
                operationresult.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var motoEntity = _mapper.Map<Moto>(moto);
                await _motoRepository.Add(motoEntity);
            }
            return (operationresult);
        }

        public async Task<List<MotoDTO>> GetMotos(string placa)
        {
            var motosDTO = new List<MotoDTO>();

            var motos = (await _motoRepository.Get(m => string.IsNullOrEmpty(placa) ||
                                                        m.Placa.Equals(placa, StringComparison.InvariantCultureIgnoreCase))).ToList();

            if (motos.Any())
                motosDTO = _mapper.Map<List<MotoDTO>>(motos);

            return motosDTO;
        }

        public async Task<OperationResultDTO> UpdatePlaca(string id, PlacaDTO placa)
        {
            var operationResult = new OperationResultDTO();

            var guidId = new Guid(id);

            var moto = await _motoRepository.GetById(guidId);

            if (moto is null)
            {
                operationResult.Success = false;
                operationResult.ErrorMessages.Add("Ocorreu um erro: A moto não foi encontrada.");
            }
            else
            {
                moto.Placa = placa.Placa;
                await  _motoRepository.Update(moto);
            }

            return operationResult;
        }

        public async Task<MotoDTO> GetMotoById(string id)
        {
            MotoDTO moto = null;

            var guidId = new Guid(id);

            var motoEntity = await _motoRepository.GetById(guidId);

            if (motoEntity is not null)
            {
                moto = _mapper.Map<MotoDTO>(motoEntity);
            }
            return moto;
        }

        public async Task<OperationResultDTO> DeleteMoto(string id)
        {
            var operationResult = new OperationResultDTO();

            var guidId = new Guid(id);

            var motoEntity = await _motoRepository.GetById(guidId);

            if (motoEntity is not null)
            {
                await _motoRepository.Delete(guidId);
            }
            else
            {
                operationResult.Success = false;
                operationResult.ErrorMessages.Add("Ocorreu um erro ao excluir: A moto não existe para o id informado");
            }

            return operationResult;
        }
    }
}
