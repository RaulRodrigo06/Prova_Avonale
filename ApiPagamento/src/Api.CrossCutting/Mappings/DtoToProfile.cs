using Api.Domain.Dtos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToProfile : Profile
    {
        public DtoToProfile()
        {
            CreateMap<PagamentoModel, PagamentoDtoCreate>().ReverseMap();

        }
    }
}
