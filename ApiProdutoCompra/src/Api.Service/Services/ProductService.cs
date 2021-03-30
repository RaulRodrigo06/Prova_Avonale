using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Products;
using Api.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace Api.Service.Services
{
    public class ProductService : IProductService
    {
        private const string _comprasUrl = "http://localhost:5000/api/pagamento/compras";
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private IRepository<ProductEntity> _productrepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<ProductEntity> productrepository, IMapper mapper)
        {
            _productrepository = productrepository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _productrepository.DeleteAsync(id);
        }

        public async Task<ProductDto> Get(Guid id)
        {
            var entity = await _productrepository.SelectAsync(id);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var listEntity = await _productrepository.SelectAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(listEntity);
        }

        public async Task<ProductDtoCreateResult> Post(ProductDtoCreate product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _productrepository.InsertAsync(entity);

            return _mapper.Map<ProductDtoCreateResult>(result);
        }
        public async Task<ProductDtoUpdateResult> Put(ProductDtoUpdate product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _productrepository.UpdateAsync(entity);
            return _mapper.Map<ProductDtoUpdateResult>(result);
        }
        public async Task<RequestExternoDto> RequestExterno(PagamentoDto produto)
        {
            var getproduct = await Get(produto.produto_id);
            var prepararproduct = produto.qtde_comprada * getproduct.valor_unitario;
            var produtosend = new PagamentoExternoSend
            {
                valor = prepararproduct,
                cartao = produto.Cartao
            };
            var data = JsonConvert.SerializeObject(produtosend);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(_comprasUrl, content);
            var retorno = JsonConvert.DeserializeObject<RequestExternoDto>(response.Content.ReadAsStringAsync().Result);
            return retorno;
        }
    }
}
