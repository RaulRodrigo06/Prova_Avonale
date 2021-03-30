using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Pagamentos;
using AutoMapper;

namespace Api.Service.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IMapper _mapper;
        public PagamentoService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PagamentoDtoCreateResult ProcessarPagamento(PagamentoDtoCreate Pagamento)
        {
            var result = new PagamentoDtoCreateResult
            {
                Valor = Pagamento.Valor,
                Estado = null,
            };
            if (Pagamento.Valor > 100)
            {
                result.Estado = "Aprovado";
            }
            else
            {
                result.Estado = "Reprovado";
            }
            return result;
        }
    }

}

