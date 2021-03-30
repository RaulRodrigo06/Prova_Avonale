using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Update
{
    public class Retorno_Delete
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o Delete")]
        public async Task E_Possivel_Realizar_Cotroller_Delete()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new ProductsController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, resultValue.StatusCode);
            Assert.Equal("Produto Excluído com sucesso", resultValue.Value);
        }
    }
}
