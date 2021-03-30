namespace Api.Domain.Entities
{
    public class PagamentoExternoSend
    {
        public decimal valor { get; set; }
        public Cartao CartaoSend { get; set; }
    }
}
