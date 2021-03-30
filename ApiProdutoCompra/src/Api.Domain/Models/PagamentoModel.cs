using System;
using Api.Domain.Entities;

namespace Api.Domain.Models
{
    public class PagamentoModel
    {
        public Guid id_produto { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }
    }
}
