using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Pagamentos
{
    public interface IPagamentoService
    {
        Task<PagamentoDtoCreateResult> Post(PagamentoDtoCreate user);
    }
}
