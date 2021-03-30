using System;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.Products
{
    public class PagamentoDto
    {
        public Guid produto_id { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao Cartao { get; set; }
    }
}
