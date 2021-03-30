using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Pagamentos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Creat
{
    public class Retorno_OutRange
    {
        private PagamentosController _controller;

        [Fact(DisplayName = "É Possível realizar o OutRange")]
        public async Task E_Possivel_Realizar_Cotroller_OutRange()
        {
            var serviceMock = new Mock<IPagamentoService>();
            var Valor = Faker.RandomNumber.Next(-10, 0);
            var cartao = new cartao
            {
                titular = Faker.Name.FullName(),
                numero = Faker.Name.FullName(),
                cvv = Faker.Name.FullName(),
                bandeira = Faker.Name.FullName(),
                data_expiracao = DateTime.UtcNow,

            };

            serviceMock.Setup(m => m.Post(It.IsAny<PagamentoDtoCreate>())).ReturnsAsync(
                new PagamentoDtoCreateResult
                {
                    valor = Valor,
                    estado = "Aprovado",
                }
            );

            _controller = new PagamentosController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var PagamentoDtoCreate = new PagamentoDtoCreate
            {
                valor = Valor,
                Cartao = cartao,
            };

            var result = await _controller.Post(PagamentoDtoCreate);
            ObjectResult resultValue = Assert.IsType<ObjectResult>(result);
            Assert.Equal(412, resultValue.StatusCode);
        }
    }
}
