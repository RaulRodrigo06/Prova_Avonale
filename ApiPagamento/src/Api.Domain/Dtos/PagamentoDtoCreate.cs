using Api.Domain.Entities;

namespace Api.Domain.Dtos
{
    public class PagamentoDtoCreate
    {
        public int valor { get; set; }
        public cartao Cartao { get; set; }
    }
}
