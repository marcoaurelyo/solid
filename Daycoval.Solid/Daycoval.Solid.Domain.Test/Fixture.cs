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
       
        public Mock<ImpostoFactory> _impostoMock;
        public Mock<GatewayPagamentoService> _pagamentoMock;
        public Mock<IEstoque> _estoqueMock;
        public Mock<INotificar> _notificarMock;

       
        public PedidoService CreatePedidoService()
        {
          
            _impostoMock = new Mock<ImpostoFactory>();
            _pagamentoMock = new Mock<GatewayPagamentoService>();
            _estoqueMock = new Mock<IEstoque>();
            _notificarMock = new Mock<INotificar>();

           
            return new PedidoService(_impostoMock.Object, 
                                     _pagamentoMock.Object, 
                                     _estoqueMock.Object,
                                     _notificarMock.Object);

        }
    }
}
