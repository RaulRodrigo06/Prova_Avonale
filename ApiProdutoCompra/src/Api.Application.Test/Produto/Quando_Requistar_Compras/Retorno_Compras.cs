using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Products;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.Quando_Requisitar_Creat
{
    public class Retorno_Compras
    {
        private ProductsController _controller;
        private ComprasController _compracontroller;

        [Fact(DisplayName = "É Possível realizar o created")]
        public async Task E_Possivel_Realizar_Cotroller_Created()
        {
            var serviceMock = new Mock<IProductService>();
            var errormock = new Mock<IError>();
            var Valor_Unitario = Faker.RandomNumber.Next(0, 10000);
            serviceMock.Setup(m => m.RequestExterno(It.IsAny<PagamentoDto>())).ReturnsAsync(
                new RequestExternoDto
                {
                    valor = Valor_Unitario,
                    estado = "Aprovado"
                }
            );
            var cartao = new Cartao
            {
                titular = Faker.Name.FullName(),
                cvv = "311",
                data_expiracao = "03/2022",
                bandeira = "VISA",
                numero = "3021907089762341"
            };
            var pagamentodto = new PagamentoDto
            {
                produto_id = Guid.NewGuid(),
                qtde_comprada = Faker.RandomNumber.Next(1, 10),
                Cartao = cartao
            };

            var result = await _compracontroller.Compras(pagamentodto);
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as RequestExternoDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.valor, Valor_Unitario);
            Assert.Equal("Aprovado", resultValue.estado);
        }
    }
}
