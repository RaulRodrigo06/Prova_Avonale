using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Moq;
using Xunit;

namespace Api.Service.Test.Product
{
    public class QuantoForExecutadoGetAll : ProductTestes
    {
        private IProductService _service;
        private Mock<IProductService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaProductDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<ProductDto>();
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
