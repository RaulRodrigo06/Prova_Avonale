using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Products;
using Moq;
using Xunit;

namespace Api.Service.Test.Product
{
    public class QuandoForExecutadoUpdate : ProductTestes
    {
        private IProductService _service;
        private Mock<IProductService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método PUT.")]
        public async Task E_Possivel_Executar_Metodo_Put()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Post(ProductDtoCreate)).ReturnsAsync(ProductDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(ProductDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeProduto, result.nome);
            Assert.Equal(valor_unitarioProduto, result.valor_unitario);
            Assert.Equal(qtde_estoqueProduto, result.qtde_estoque); ;

            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Put(ProductDtoUpdate)).ReturnsAsync(ProductDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(ProductDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeProdutoAlterado, resultUpdate.nome);
            Assert.Equal(valor_unitarioAlterado, resultUpdate.valor_unitario);
            Assert.Equal(qtde_estoqueAlterado, resultUpdate.qtde_estoque);

        }
    }
}
