using Bogus;
using Daycoval.Solid.Domain.Entidades;
using FluentAssertions;
using Xunit;

namespace Daycoval.Solid.Domain.Test.FakerEntitiesTests
{
    public class FakerEntitiesTests_FakerDetalhePagamentoEntity
    {
        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakerDetalhePagamento()
        {
            var sut = new FakerEntities();
            sut.fakerDetalhamentoPagamentoEntity.Should().NotBeNull();
        }

        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeOfDetalhePagamento()
        {
            var sut = new FakerEntities();
            sut.fakerDetalhamentoPagamentoEntity.Should().BeOfType<Faker<DetalhePagamento>>();
        }

        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeFormaPagamento()
        {
            var sut = new FakerEntities();
            var dPagamento = sut.fakerDetalhamentoPagamentoEntity.Generate();
            dPagamento.FormaPagamento.Should().BeDefined();
        }

        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeNomeImpressoCartao()
        {
            var sut = new FakerEntities();
            var dPagamento = sut.fakerDetalhamentoPagamentoEntity.Generate();
            if (dPagamento.FormaPagamento != FormaPagamento.Dinheiro)
                dPagamento.NomeImpressoCartao.Should().NotBeNullOrEmpty();
        }


        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeNumeroCartao()
        {
            var sut = new FakerEntities();
            var dPagamento = sut.fakerDetalhamentoPagamentoEntity.Generate();
            if (dPagamento.FormaPagamento != FormaPagamento.Dinheiro)
                dPagamento.NumeroCartao.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeMesExpiracao()
        {
            var sut = new FakerEntities();
            var dPagamento = sut.fakerDetalhamentoPagamentoEntity.Generate();
            if (dPagamento.FormaPagamento != FormaPagamento.Dinheiro)
                dPagamento.MesExpiracao.Should().NotBe(0);
        }

        [Fact]
        public void FakerEntities_FakerDetalhePagamentoEntity_ReturnFakeAnoExpiracao()
        {
            var sut = new FakerEntities();
            var dPagamento = sut.fakerDetalhamentoPagamentoEntity.Generate();
            if (dPagamento.FormaPagamento != FormaPagamento.Dinheiro)
                dPagamento.AnoExpiracao.Should().NotBe(0);
        }

    }
}
