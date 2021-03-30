using System;

namespace Api.Domain.Entities
{
    public class PagamentoEntity
    {
        public Guid id_produto { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }
    }
}
