using FluentAssertions;
using Xunit;

namespace Daycoval.Solid.Domain.Test
{
    public class PedidoServiceTest
    {
        [Fact]
        public void ValidPedidoService_EfetuarPedidoReturnValorTotalPedidoMaiorZero()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();
            
            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarCliente = true;
            var notificarSms = true;
            
            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarCliente, notificarSms);
            
            fakerCarrinhoEntity.ValorTotalPedido.Should().NotBe(0);

        }

        [Fact]
        public void ValidPedidoService_EfetuarPedidoReturnFoipago()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarCliente = true;
            var notificarSms = true;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarCliente, notificarSms);

            fakerCarrinhoEntity.FoiPago.Should().BeTrue();

        }

        [Fact]
        public void ValidPedidoService_EfetuarPedidoReturnFoiEntregue()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarCliente = true;
            var notificarSms = true;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarCliente, notificarSms);

            fakerCarrinhoEntity.FoiEntregue.Should().BeTrue();

        }


    }
}
