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
        }
    }
}
