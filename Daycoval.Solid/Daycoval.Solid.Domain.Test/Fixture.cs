using Daycoval.Solid.Domain.Services;
using Daycoval.Solid.Domain.Services.Estoque;
using Moq;

namespace Daycoval.Solid.Domain.Test
{
    public class Fixture
    {
        public PedidoService CreatePedidoService()
        {
            var estoqueServiceMock = new Mock<IEstoque>();

            var emailMessageMock = new Mock<IEmailMessage>();
            var smsService = new Mock<INotificar>();

            var pagamentoCartaoService = new Mock<IPagamentoCartao>();
            var pagamentoDinheiroService = new Mock<IPagamento>();

            return new PedidoService(estoqueServiceMock.Object, emailMessageMock.Object, smsService.Object, pagamentoCartaoService.Object, pagamentoDinheiroService.Object);

        }
    }
}
