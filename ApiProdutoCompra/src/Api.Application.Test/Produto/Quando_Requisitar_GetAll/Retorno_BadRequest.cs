using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_GetAll
{
    public class Retorno_BadRequest
    {
        private ProductsController _controller;

        [Fact(DisplayName = "É Possível realizar o GetAll")]
        public async Task E_Possivel_Realizar_Cotroller_Delete()
        {
            var serviceMock = new Mock<IProductService>();
            var Nome = Faker.Name.FullName();
            var Valor_Unitario = Faker.RandomNumber.Next(0, 10000);
            var Qntd_Estoque = Faker.RandomNumber.Next(0, 10000);
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<ProductDto>
                {
                    new ProductDto
                    {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qntd_estoque = Qntd_Estoque
                    },
                    new ProductDto
                    {
                    Id = Guid.NewGuid(),
                    nome = Nome,
                    valor_unitario = Valor_Unitario,
                    qntd_estoque = Qntd_Estoque
                    }
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Inválido Id");
            var result = await _controller.GetAll();
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, resultValue.StatusCode);
            Assert.Equal("Ocorreu um erro Desconhecido", resultValue.Value);
        }
    }
}
