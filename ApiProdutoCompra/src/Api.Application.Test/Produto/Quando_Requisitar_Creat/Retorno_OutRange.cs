using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Creat
{
    public class Retorno_OutRange
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o OutRange")]
        public async Task E_Possivel_Realizar_Cotroller_OutRange()
        {
            var serviceMock = new Mock<IProductService>();
            var Nome = Faker.Name.FullName();
            var Valor_Unitario = Faker.RandomNumber.Next(-10, 0);
            var qtde_Estoque = Faker.RandomNumber.Next(-10, 0);

            serviceMock.Setup(m => m.Post(It.IsAny<ProductDtoCreate>())).ReturnsAsync(
                new ProductDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qtde_estoque = qtde_Estoque
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var ProductDtoCreate = new ProductDtoCreate
            {
                nome = Nome,
                valor_unitario = Valor_Unitario,
                qtde_estoque = qtde_Estoque
            };

            var result = await _controller.Post(ProductDtoCreate);
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(412, resultValue.StatusCode);
            Assert.Equal("Os valores informados não são válidos", resultValue.Value);


        }
    }
}
