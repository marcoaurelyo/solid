using Daycoval.Solid.Domain.Services;
using Daycoval.Solid.Domain.Services.Estoque;
using Moq;

namespace Daycoval.Solid.Domain.Test
{
    public class Fixture
    {
        public Mock<IEstoque> _estoqueServiceMock;
        public Mock<IEmailMessage> _emailMessageMock;
        public Mock<INotificar> _smsService;
        public Mock<IPagamentoCartao> _pagamentoCartaoService;
        public Mock<IPagamento> _pagamentoDinheiroService;
        public PedidoService CreatePedidoService()
        {
            _estoqueServiceMock = new Mock<IEstoque>();

            _emailMessageMock = new Mock<IEmailMessage>();
            _smsService = new Mock<INotificar>();

            _pagamentoCartaoService = new Mock<IPagamentoCartao>();
            _pagamentoDinheiroService = new Mock<IPagamento>();

            return new PedidoService(_estoqueServiceMock.Object, _emailMessageMock.Object, _smsService.Object, _pagamentoCartaoService.Object, _pagamentoDinheiroService.Object);

        }
    }
}
