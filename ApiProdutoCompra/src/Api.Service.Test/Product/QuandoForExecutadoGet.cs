using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Moq;
using Xunit;

namespace Api.Service.Test.Product
{
    public class QuandoForExecutadoGet : ProductTestes
    {
        private IProductService _service;
        private Mock<IProductService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Get(idUsuario)).ReturnsAsync(ProductDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(idUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == idUsuario);
            Assert.Equal(NomeProduto, result.nome);

            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ProductDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(idUsuario);
            Assert.Null(_record);

        }
    }
}
