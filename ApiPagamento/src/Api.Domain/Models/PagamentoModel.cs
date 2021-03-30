using Api.Domain.Entities;

namespace Api.Domain.Models
{
    public class PagamentoModel
    {
        public decimal Valor { get; set; }
        public cartao Cartao { get; set; }
    }
}
