using System;

namespace Api.Domain.Dtos.Products
{
    public class ProductDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public decimal valor_unitario { get; set; }
        public int qtde_estoque { get; set; }
    }
}
