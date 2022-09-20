using Daycoval.Solid.Domain.Entidades;
using FluentAssertions;
using Moq;
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

            var notificarClienteEmail = true;
            var notificarSms = true;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarClienteEmail, notificarSms);

            fakerCarrinhoEntity.ValorTotalPedido.Should().NotBe(0);

            fixture._emailMessageMock.Verify(em => em.enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

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

        [Fact]
        public void ValidNotificarClientEmail_EfetuarPedido_ReturnEmailEnviar()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarClienteEmail = true;
            var notificarSms = false;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarClienteEmail, notificarSms);

            fixture._emailMessageMock.Verify(em => em.enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            fixture._smsService.VerifyNoOtherCalls();
        }

        [Fact]
        public void ValidNotificarClientSms_EfetuarPedido_ReturnSmsEnviar()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarClienteEmail = false;
            var notificarSms = true;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarClienteEmail, notificarSms);

            fixture._emailMessageMock.VerifyNoOtherCalls();
            fixture._smsService.Verify(em => em.enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ValidNotificarClientSmsNotificarClienteEmail_EfetuarPedido_ReturnSmsEnviarEmailEnviar()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarClienteEmail = true;
            var notificarSms = true;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarClienteEmail, notificarSms);

            fixture._emailMessageMock.Verify(em => em.enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            fixture._smsService.Verify(em => em.enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ValidBaixarEstoque_EfetuarPedido_ReturnExecuteBaixarEstoque()
        {

            var fakeEntities = new FakerEntities();
            var fakerCarrinhoEntity = fakeEntities.fakerCarrinhoEntity.Generate();
            var fakerDetalhePagamentoEntity = fakeEntities.fakerDetalhamentoPagamentoEntity.Generate();

            var fixture = new Fixture();
            var pedidoService = fixture.CreatePedidoService();

            var notificarClienteEmail = true;
            var notificarSms = false;

            pedidoService.EfetuarPedido(fakerCarrinhoEntity, fakerDetalhePagamentoEntity, notificarClienteEmail, notificarSms);

            fixture._estoqueServiceMock.Verify(em => em.BaixarEstoque(It.IsAny<Produto>()), Times.AtLeastOnce);
        }
       
    }
}
