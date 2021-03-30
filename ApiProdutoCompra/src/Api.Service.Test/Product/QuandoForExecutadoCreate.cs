using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Moq;
using Xunit;

namespace Api.Service.Test.Product
{
    public class QuandoForExecutadoCreate : ProductTestes
    {
        private IProductService _service;
        private Mock<IProductService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método POST.")]
        public async Task E_Possivel_Executar_Metodo_POST()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Post(ProductDtoCreate)).ReturnsAsync(ProductDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(ProductDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeProduto, result.nome);
            Assert.Equal(valor_unitarioProduto, result.valor_unitario);
            Assert.Equal(qntd_estoqueProduto, result.qntd_estoque);
        }
    }
}
