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
        private readonly IMotoRepository _motoRepository;
        private readonly IMapper _mapper;
        private readonly ICalculoLocacaoService _calculoLocacaoService;

        public LocacaoService(ILocacaoRepository locacaoRepository,
                              IEntregadorRepository entregadorRepository,
                              IMotoRepository motoRepository,
                              IMapper mapper,
                              ICalculoLocacaoService calculoLocacaoService)
        {
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;
            _motoRepository = motoRepository;
            _mapper = mapper;
            _calculoLocacaoService = calculoLocacaoService;
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

                    var entragadorId = (await _entregadorRepository.Get(e => e.Identificador == locacao.IdentificadorEntregador)).FirstOrDefault().Id; // Mudei de última hora pra funcionar
                    var motoId = (await _motoRepository.Get(e => e.Identificador == locacao.IdentificadorMoto)).FirstOrDefault().Id;// Mudei de última hora pra funcionar

                    locacaoEntity.MotoId = motoId;
                    locacaoEntity.EntregadorId = entragadorId;

                    await _locacaoRepository.Add(locacaoEntity);
                }
            }
            return operationresult;
        }

        private async Task<OperationResultDTO> ValidateEntregador(LocacaoDTO locacao)
        {
            var opResult = new OperationResultDTO();
            // Somente Entregador Habilitado com Categoria A podem efetuar a Locação.
            var entregador = (await _entregadorRepository.Get(e => e.Identificador == locacao.IdentificadorEntregador)).FirstOrDefault();

            if (entregador == null)
            {
                opResult.AddErrorMessage("Entregador não existe para o indentificador informado");
                return opResult;
            }

            //if (!entregador.TipoCnh.Equals(TipoCnh.A.ToString()))
            if (!entregador.TipoCnh.Equals("A"))// coloquei fixo porque estava dando problema com enum (precisava fazer uma extension para pegar a description, mas não deu tempo).
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

        public async Task<RetornoCalculoLocacaoDTO> GetValorLocacao(string id, DateTime dataInformada)
        {
            var locacaoEntity = await _locacaoRepository.GetById(new Guid(id));

            if (locacaoEntity is null)
                throw new Exception("Não existe locação para o Id informado");

            var locacao = _mapper.Map<LocacaoDetalheDTO>(locacaoEntity);

            var operationResult = await ValidateEntregador(locacao);

            if (!operationResult.Success)
                throw new Exception($"Ocorreu um erro inesperado: {string.Join(",", operationResult.ErrorMessages)}");

            var retornoCalculoLocacao = await _calculoLocacaoService.CalcularLocacao(locacao, dataInformada);

            return retornoCalculoLocacao;
        }
    }
}
