using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Update
{
    public class Retorno_DeleteBadRequest
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o Delete")]
        public async Task E_Possivel_Realizar_Cotroller_DeleteBadRequest()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new ProductsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(default(Guid));
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, resultValue.StatusCode);
            Assert.Equal("Ocorreu um erro Desconhecido", resultValue.Value);


        }
    }
}
