namespace Api.Domain.Entities
{
    public class PagamentoExternoSend
    {
        public decimal valor { get; set; }
        public Cartao cartao { get; set; }
    }
}
