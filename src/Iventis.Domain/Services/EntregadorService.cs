using AutoMapper;
using Iventis.Domain.DTO;
using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Domain.Interfaces.Services;
using Iventis.Domain.Validators;

namespace Iventis.Domain.Services
{
    public class EntregadorService : IEntregadorService
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMapper _mapper;
        public EntregadorService(IEntregadorRepository entreagadorRepository,
                                 IMapper mapper)
        {
            _entregadorRepository = entreagadorRepository;
            _mapper = mapper;
        }
        public async Task<OperationResultDTO> AddEntregador(EntregadorDTO entregador)
        {
            
            var operationresult = new OperationResultDTO();

            var validationResult = new EntregadorValidator().Validate(entregador);

            if (!validationResult.IsValid)
            {
                operationresult.Success = validationResult.IsValid;
                operationresult.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var entregadorEntity = _mapper.Map<Entregador>(entregador);
                await _entregadorRepository.Add(entregadorEntity);
            }
            return (operationresult);
        }

        public async Task<OperationResultDTO> EnvarFotoCnh(string id, CnhDTO cnh)
        {
            var operationResult = new OperationResultDTO();

            var guidId = new Guid(id);

            var entregador = await _entregadorRepository.GetById(guidId);

            if (entregador is null)
            {
                operationResult.Success = false;
                operationResult.ErrorMessages.Add("Ocorreu um erro: A moto não foi encontrada.");
            }
            else
            {
                entregador.ImagemCnh = Convert.FromBase64String(cnh.ImagemCnh);
                await _entregadorRepository.Update(entregador);
            }

            return operationResult;
        }
    }
}
