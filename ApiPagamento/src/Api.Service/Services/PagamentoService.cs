using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Pagamentos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PagamentoService : IPagamentoService
    {
        private IRepository<PagamentoEntity> _repository;
        private readonly IMapper _mapper;
        public PagamentoService(IRepository<PagamentoEntity> productrepository, IMapper mapper)
        {
            _repository = productrepository;
            _mapper = mapper;
        }

        public async Task<PagamentoDtoCreateResult> Post(PagamentoDtoCreate Pagamento)
        {
            var model = _mapper.Map<PagamentoModel>(Pagamento);
            var entity = _mapper.Map<PagamentoEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PagamentoDtoCreateResult>(result);
        }

    }
}
