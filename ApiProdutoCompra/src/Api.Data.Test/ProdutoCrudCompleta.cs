using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleta : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;
        public UsuarioCrudCompleta(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "ProductEntity")]
        public async Task E_Possivel_Realizer_CRUD_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                ProductImplementation _repositorio = new ProductImplementation(context);
                ProductEntity _entity = new ProductEntity
                {
                    nome = Faker.Name.FullName(),
                    valor_unitario = Faker.RandomNumber.Next(0, 10000),
                    qtde_estoque = Faker.RandomNumber.Next(0, 10000)
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.nome, _registroCriado.nome);
                Assert.Equal(_entity.valor_unitario, _registroCriado.valor_unitario);
                Assert.Equal(_registroCriado.qtde_estoque, _registroCriado.qtde_estoque);

                _entity.nome = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.nome, _registroAtualizado.nome);
                Assert.Equal(_entity.valor_unitario, _registroAtualizado.valor_unitario);
                Assert.Equal(_entity.qtde_estoque, _registroAtualizado.qtde_estoque);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.nome, _registroAtualizado.nome);
                Assert.Equal(_entity.valor_unitario, _registroAtualizado.valor_unitario);
                Assert.Equal(_entity.qtde_estoque, _registroAtualizado.qtde_estoque);

                var _registroTotais = await _repositorio.SelectAsync();
                Assert.NotNull(_registroTotais);
                Assert.True(_registroTotais.Count() > 1);

                var _registroDeletado = await _repositorio.DeleteAsync(_registroAtualizado.Id);
                Assert.True(_registroDeletado);

            }
        }
    }
}
