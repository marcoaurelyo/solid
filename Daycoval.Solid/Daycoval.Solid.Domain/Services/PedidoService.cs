using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services.Estoque;
using Daycoval.Solid.Domain.Services.Impostos;
using Daycoval.Solid.Domain.Services.Notificar;
using Daycoval.Solid.Domain.Services.Pagamento;
using System.Runtime.InteropServices;

namespace Daycoval.Solid.Domain.Services
{
    public class PedidoService
    {
        IPagamento _pagamento;
        IEstoque _estoqueService;
        INotificar _notificar;

        public PedidoService(IPagamento pagamento,
                             IEstoque estoqueService,
                             INotificar notificar)
        {
            this._estoqueService = estoqueService;
            this._pagamento = pagamento;
            this._notificar = notificar;
        }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            Validacao(carrinho, detalhePagamento);

            carrinho.RealizaCalculoImposto();

            carrinho.CalcularValorTotalPedido();

            _pagamento.RealizarPagamento(carrinho, detalhePagamento);

            _estoqueService.VerificarCarrinho(carrinho);

            _estoqueService.BaixarEstoque(carrinho);
            
            _notificar.RealizarNotificacao(carrinho.Cliente, notificarClienteEmail, notificarClienteSms);
        }
        private void Validacao(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            if (carrinho == null || carrinho.Produtos == null || carrinho.Cliente == null || detalhePagamento == null)
                throw new ExternalException("Parametros obrigratóris");
        }



    }
}