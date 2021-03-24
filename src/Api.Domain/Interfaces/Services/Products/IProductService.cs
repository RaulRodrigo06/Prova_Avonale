using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;

namespace Api.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> Get(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDtoCreateResult> Post(ProductDtoCreate user);
        Task<ProductDtoUpdateResult> Put(ProductDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
