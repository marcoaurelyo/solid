using Daycoval.Solid.Domain.Services;
using Daycoval.Solid.Domain.Services.Estoque;
using Daycoval.Solid.Domain.Services.Impostos;
using Daycoval.Solid.Domain.Services.Notificar;
using Daycoval.Solid.Domain.Services.Pagamento;
using Moq;

namespace Daycoval.Solid.Domain.Test
{
    public class Fixture
    {
        public Mock<GatewayPagamentoService> _pagamentoMock;
        public Mock<EstoqueService> _estoqueMock;
        public Mock<INotificar> _notificarMock;

       
        public PedidoService CreatePedidoService()
        {
            _pagamentoMock = new Mock<GatewayPagamentoService>();
            _estoqueMock = new Mock<EstoqueService>();
            _notificarMock = new Mock<INotificar>();
           
            return new PedidoService(
                                     _pagamentoMock.Object, 
                                     _estoqueMock.Object,
                                     _notificarMock.Object);

        }
    }
}
