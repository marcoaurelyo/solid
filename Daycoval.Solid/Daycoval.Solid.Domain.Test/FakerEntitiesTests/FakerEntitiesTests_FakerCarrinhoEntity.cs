using Bogus;
using Daycoval.Solid.Domain.Entidades;
using FluentAssertions;
using Xunit;

namespace Daycoval.Solid.Domain.Test.FakerEntitiesTests
{
    public class FakerEntitiesTests_FakerCarrinhoEntity
    {
        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakerCarrinho()
        {
            var sut = new FakerEntities();
            sut.fakerCarrinhoEntity.Should().NotBeNull();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeOfDevice()
        {
            var sut = new FakerEntities();
            sut.fakerCarrinhoEntity.Should().BeOfType<Faker<Carrinho>>();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeCarrinho()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            carrinho.Cliente.Should().NotBeNull();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeClienteWithEmail()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            carrinho.Cliente.Email.Should().NotBeEmpty();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeClienteWithCelular()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            carrinho.Cliente.Celular.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeProduto()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            carrinho.Produtos.Should().NotBeNull();
        }

        [Fact]
        public void FakerEntities_FakerCarrinhoEntity_ReturnFakeProdutoWithValor()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            foreach (var item in carrinho.Produtos)
            {
                item.Valor.Should().NotBe(0);
            }
        }

        [Fact]
        public void FakerEntities_FakerDeviceEntity_ReturnFakeProdutoWithTipoProduto()
        {
            var sut = new FakerEntities();
            var carrinho = sut.fakerCarrinhoEntity.Generate();
            foreach (var item in carrinho.Produtos)
            {
                item.TipoProduto.Should().BeDefined();
            }
        }
    }
}
