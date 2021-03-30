using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PagamentoDtoCreate, PagamentoEntity>().ReverseMap();

            CreateMap<PagamentoDtoCreateResult, PagamentoEntity>().ReverseMap();

        }
    }
}
