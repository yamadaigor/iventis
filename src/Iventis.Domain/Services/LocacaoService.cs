using AutoMapper;
using Iventis.Domain.DTO;
using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Domain.Interfaces.Services;
using Iventis.Domain.Validators;
using static Iventis.Domain.Utils.Enums;

namespace Iventis.Domain.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMapper _mapper;

        public LocacaoService(ILocacaoRepository locacaoRepository,
                              IEntregadorRepository entregadorRepository,
                              IMapper mapper)
        {
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;
            _mapper = mapper;   
        }

        public async Task<OperationResultDTO> LocarMoto(LocacaoDTO locacao)
        {
            var operationresult = new OperationResultDTO();

            var validationResult = new LocacaoValidator().Validate(locacao);

            if (!validationResult.IsValid)
            {
                operationresult.Success = validationResult.IsValid;
                operationresult.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                operationresult = await ValidateEntregador(locacao);

                if (operationresult.Success)
                {
                    var locacaoEntity = _mapper.Map<Locacao>(locacao);
                    await _locacaoRepository.Add(locacaoEntity);
                }
            }
            return operationresult;
        }

        private async Task<OperationResultDTO> ValidateEntregador(LocacaoDTO locacao)
        {
            var opResult = new OperationResultDTO();
            // Somente Entregador Habilitado com Categoria A podem efetuar a Locação.
            var entregador = (await _entregadorRepository.Get(e => e.Identificador == locacao.EntregadorId)).FirstOrDefault();

            if (entregador == null)
            {
                opResult.AddErrorMessage("Entregador não existe para o indentificador informado");
                return opResult;
            }

            if (!entregador.TipoCnh.Equals(TipoCnh.A.ToString()))
            {
                opResult.AddErrorMessage("A Cnh precisa ser Categoria 'A' para efetuar a locação");
                return opResult;
            }

            return opResult;
        }

        public async Task<LocacaoDetalheDTO> GetLocacaoById(string id)
        {
            LocacaoDetalheDTO locacao = null;

            var guidId = new Guid(id);

            var locacaoEntity = await _locacaoRepository.GetById(guidId);

            if (locacaoEntity is not null)
            {
                locacao = _mapper.Map<LocacaoDetalheDTO>(locacaoEntity);
            }
            return locacao;
        }
    }
}
