using Api.Domain.Entities;

namespace Api.Domain.Dtos
{
    public class PagamentoDtoCreate
    {
        public decimal Valor { get; set; }
        public cartao Cartao { get; set; }
    }
}
