using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Products;
using Moq;
using Xunit;

namespace Api.Service.Test.Product
{
    public class QuandoForExecutadoDelete : ProductTestes
    {
        private IProductService _service;
        private Mock<IProductService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método DELETE.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Delete(idUsuario)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(idUsuario);
            Assert.True(deletado);

            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
