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
    public class Retorno_Get
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o Get")]
        public async Task E_Possivel_Realizar_Cotroller_Delete()
        {
            var serviceMock = new Mock<IProductService>();
            var Nome = Faker.Name.FullName();
            var Valor_Unitario = Faker.RandomNumber.Next(0, 10000);
            var qtde_Estoque = Faker.RandomNumber.Next(0, 10000);

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new ProductDto
                {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qtde_estoque = qtde_Estoque
                }
            );

            _controller = new ProductsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as ProductDto;
            Assert.NotNull(resultValue);
            Assert.Equal(Nome, resultValue.nome);
            Assert.Equal(Valor_Unitario, resultValue.valor_unitario);
            Assert.Equal(qtde_Estoque, resultValue.qtde_estoque);

        }
    }
}
