using AutoMapper;
using Iventis.Domain.DTO;
using Iventis.Domain.Entities;

namespace Iventis.App.Utils
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // Moto 
            CreateMap<Moto, MotoDTO>();
            CreateMap<MotoDTO, Moto>();

            // Entregador 
            CreateMap<Entregador, EntregadorDTO>();
            CreateMap<EntregadorDTO, Entregador>();

            // Locação 
            CreateMap<Locacao, LocacaoDTO>();
            CreateMap<LocacaoDTO, Locacao>();
            CreateMap<Locacao, LocacaoDetalheDTO>();
            CreateMap<LocacaoDetalheDTO, Locacao>();
        }
    }
}
