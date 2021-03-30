using Api.Domain.Dtos.Products;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ProductModel, ProductDto>().ReverseMap();
            CreateMap<ProductModel, ProductDtoCreate>().ReverseMap();
            CreateMap<ProductModel, ProductDtoUpdate>().ReverseMap();
            CreateMap<PagamentoModel, PagamentoDto>().ReverseMap();
        }
    }
}
