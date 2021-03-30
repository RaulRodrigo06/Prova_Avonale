using System;

namespace Api.Domain.Models
{
    public class ProductModel
    {
        public string nome { get; set; }
        public decimal valor_unitario { get; set; }
        public int qntd_estoque { get; set; }
        public Guid Id { get; set; }
        public decimal? ValorUltVenda { get; set; }
        public DateTime? DataUltCompra { get; set; }
    }
}
