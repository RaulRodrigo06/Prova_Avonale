using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : PagamentoEntity
    {
        Task<T> InsertAsync(T item);
    }
}
