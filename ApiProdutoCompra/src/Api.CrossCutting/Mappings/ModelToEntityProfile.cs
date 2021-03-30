using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            CreateMap<PagamentoEntity, PagamentoModel>().ReverseMap();
            //.ForMember(x=>x.valor_unitario,y=>y.MapFrom(z=>z.valor_unitario));
        }
    }
}
