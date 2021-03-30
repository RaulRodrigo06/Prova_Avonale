using System;

namespace Api.Domain.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public decimal valor_unitario { get; set; }
        public int qtde_estoque { get; set; }
        public DateTime DataUltCompra { get; set; }
        public decimal ValorUltVenda { get; set; }
    }
}
