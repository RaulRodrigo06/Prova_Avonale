using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Products;

namespace Api.Service.Test.Product
{
    public class ProductTestes
    {
        public static string NomeProduto { get; set; }
        public static decimal valor_unitarioProduto { get; set; }
        public static int qntd_estoqueProduto { get; set; }
        public static string NomeProdutoAlterado { get; set; }
        public static decimal valor_unitarioAlterado { get; set; }
        public static int qntd_estoqueAlterado { get; set; }
        public static Guid idUsuario { get; set; }

        public List<ProductDto> listaProductDto = new List<ProductDto>();
        public ProductDto ProductDto;
        public ProductDtoCreate ProductDtoCreate;
        public ProductDtoCreateResult ProductDtoCreateResult;
        public ProductDtoUpdate ProductDtoUpdate;
        public ProductDtoUpdateResult ProductDtoUpdateResult;

        public ProductTestes()
        {
            idUsuario = Guid.NewGuid();
            NomeProdutoAlterado = Faker.Name.FullName();
            valor_unitarioAlterado = Faker.RandomNumber.Next(0, 100000);
            qntd_estoqueAlterado = Faker.RandomNumber.Next(0, 1000000);

            for (int i = 0; i < 10; i++)
            {
                var dto = new ProductDto()
                {
                    Id = Guid.NewGuid(),
                    nome = Faker.Name.FullName(),
                    valor_unitario = Faker.RandomNumber.Next(0, 100000),
                    qntd_estoque = Faker.RandomNumber.Next(0, 100000)
                };
                listaProductDto.Add(dto);
            }

            ProductDto = new ProductDto()
            {
                Id = idUsuario,
                nome = NomeProduto,
                valor_unitario = valor_unitarioProduto,
                qntd_estoque = qntd_estoqueProduto,
                DataUltCompra = DateTime.UtcNow,
                ValorUltVenda = Faker.RandomNumber.Next(0, 100000)
            };

            ProductDtoCreate = new ProductDtoCreate()
            {
                nome = NomeProduto,
                valor_unitario = valor_unitarioProduto,
                qntd_estoque = qntd_estoqueProduto
            };

            ProductDtoCreateResult = new ProductDtoCreateResult()
            {
                Id = idUsuario,
                nome = NomeProduto,
                valor_unitario = valor_unitarioProduto,
                qntd_estoque = qntd_estoqueProduto,
            };

            ProductDtoUpdate = new ProductDtoUpdate()
            {
                Id = idUsuario,
                nome = NomeProdutoAlterado,
                valor_unitario = valor_unitarioAlterado,
                qntd_estoque = qntd_estoqueAlterado
            };

            ProductDtoUpdateResult = new ProductDtoUpdateResult()
            {
                Id = idUsuario,
                nome = NomeProdutoAlterado,
                valor_unitario = valor_unitarioAlterado,
                qntd_estoque = qntd_estoqueAlterado
            };
        }
    }
}


