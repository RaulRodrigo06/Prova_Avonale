using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Get
{
    public class Retorno_BadRequest
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o Get")]
        public async Task E_Possivel_Realizar_Cotroller_Delete()
        {
            var serviceMock = new Mock<IProductService>();
            var Nome = Faker.Name.FullName();
            var Valor_Unitario = Faker.RandomNumber.Next(0, 10000);
            var Qntd_Estoque = Faker.RandomNumber.Next(0, 10000);

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new ProductDto
                {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qntd_estoque = Qntd_Estoque
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, resultValue.StatusCode);
            Assert.Equal("Ocorreu um erro Desconhecido", resultValue.Value);

        }
    }
}
