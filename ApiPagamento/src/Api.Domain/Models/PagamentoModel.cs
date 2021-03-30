using Api.Domain.Entities;

namespace Api.Domain.Models
{
    public class PagamentoModel
    {
        public decimal valor { get; set; }
        public cartao Cartao { get; set; }
    }
}
