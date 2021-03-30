using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Update
{
    public class Retorno_Update
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o Update")]
        public async Task E_Possivel_Realizar_Cotroller_Update()
        {
            var serviceMock = new Mock<IProductService>();
            var Nome = Faker.Name.FullName();
            var Valor_Unitario = Faker.RandomNumber.Next(0, 10000);
            var Qntd_Estoque = Faker.RandomNumber.Next(0, 10000);

            serviceMock.Setup(m => m.Put(It.IsAny<ProductDtoUpdate>())).ReturnsAsync(
                new ProductDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qntd_estoque = Qntd_Estoque
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            var ProductDtoUpdate = new ProductDtoUpdate
            {
                Id = Guid.NewGuid(),
                nome = Nome,
                valor_unitario = Valor_Unitario,
                qntd_estoque = Qntd_Estoque
            };

            var result = await _controller.Put(ProductDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as ProductDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(ProductDtoUpdate.nome, resultValue.nome);
            Assert.Equal(ProductDtoUpdate.valor_unitario, resultValue.valor_unitario);
            Assert.Equal(ProductDtoUpdate.qntd_estoque, resultValue.qntd_estoque);
        }
    }
}
