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
    public class Retorno_Create
    {
        private PagamentoController _controller;

        [Fact(DisplayName = "É Possível realizar o created")]
        public async Task E_Possivel_Realizar_Cotroller_Created()
        {
            var serviceMock = new Mock<IPagamentoService>();
            var Valor = Faker.RandomNumber.Next(0, 10000);
            var cartao = new cartao
            {
                titular = Faker.Name.FullName(),
                numero = Faker.Name.FullName(),
                cvv = Faker.Name.FullName(),
                bandeira = Faker.Name.FullName(),
                data_expiracao = Faker.Name.FullName(),
            };


            _controller = new PagamentoController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var PagamentoDtoCreate = new PagamentoDtoCreate
            {
                Valor = Valor,
                Cartao = cartao,
            };


            var result = await _controller.Post(PagamentoDtoCreate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as PagamentoDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(PagamentoDtoCreate.Valor, resultValue.Valor);
            Assert.Equal("Aprovado", resultValue.Estado);
        }
    }
}
