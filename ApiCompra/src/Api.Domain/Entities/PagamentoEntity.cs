using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class PagamentoEntity
    {
        public decimal valor { get; set; }
        [NotMapped]
        public cartao Cartao { get; set; }
    }
}
